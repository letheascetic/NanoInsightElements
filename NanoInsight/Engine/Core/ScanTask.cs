using Emgu.CV;
using log4net;
using NanoInsight.Engine.Attribute;
using NanoInsight.Engine.Common;
using NanoInsight.Engine.Data;
using NumSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class ScanTask
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private bool mScanning;
        private int mTaskId;
        private string mTaskName;
        private ScanInfo mScanInfo;
        private ScanData mScanData;
        private TaskSettings mTaskSettings;

        private int mApdCurrentBank;    

        public bool Scanning
        {
            get { return mScanning; }
        }
        /// <summary>
        /// 扫描任务ID
        /// </summary>
        public int TaskId
        {
            get { return mTaskId; }
            set { mTaskId = value; }
        }
        /// <summary>
        /// 扫描任务名
        /// </summary>
        public string TaskName
        {
            get { return mTaskName; }
            set { mTaskName = value; }
        }
        /// <summary>
        /// 扫描信息
        /// </summary>
        public ScanInfo ScanInfo
        {
            get { return mScanInfo; }
            set { mScanInfo = value; }
        }
        /// <summary>
        /// 扫描数据
        /// </summary>
        public ScanData ScanData
        {
            get { return mScanData; }
            set { mScanData = value; }
        }
        /// <summary>
        /// 扫描任务的参数
        /// </summary>
        public TaskSettings Settings
        {
            get { return mTaskSettings; }
            set { mTaskSettings = value; }
        }

        public ScanTask(int taskId, string taskName, Config config, ScanSequence sequence)
        {
            mTaskSettings = new TaskSettings(config, sequence);
            TaskId = taskId;
            TaskName = taskName;
            mScanning = false;
            mApdCurrentBank = -1;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 设置该扫描任务双向扫描中像素补偿的值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelCalibration"></param>
        public void SetScanPixelCalibration(int id, int scanPixelCalibration)
        {
            if (Settings.SelectedScanPixelDwell.ID == id)
            {
                Settings.SelectedScanPixelDwell.ScanPixelCalibration = scanPixelCalibration;
            }
        }

        /// <summary>
        /// 设置每行采集像素截取时的偏移量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelOffset"></param>
        public void SetScanPixelOffset(int id, int scanPixelOffset)
        {
            if (Settings.SelectedScanPixelDwell.ID == id)
            {
                Settings.SelectedScanPixelDwell.ScanPixelOffset = scanPixelOffset;
            }
        }

        /// <summary>
        /// 设置扫描像素缩放系数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelScale"></param>
        public void SetScanPixelScale(int id, int scanPixelScale)
        {
            if (Settings.SelectedScanPixelDwell.ID == id)
            {
                Settings.SelectedScanPixelDwell.ScanPixelScale = scanPixelScale;
            }
        }

        /// <summary>
        /// 设置扫描任务的通道增益
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gain"></param>
        public void SetChannelGain(int id, int gain)
        {
            Settings.ScanChannels[id].Gain = gain;
        }

        /// <summary>
        /// 设置扫描任务的激光功率
        /// </summary>
        /// <param name="id"></param>
        /// <param name="power"></param>
        public void SetChannelPower(int id, int power)
        {
            Settings.ScanChannels[id].LaserPower = power;
        }

        /// <summary>
        /// 设置扫描任务的激光颜色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        public void SetChannelLaserColor(int id, Color color)
        {
            Settings.ScanChannels[id].LaserColor = color;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 设置伽马校正伽马值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gamma"></param>
        /// <returns></returns>
        public int SetImageGamma(int id, int gamma)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetGamma(gamma);

            // 扫描任务的图像校正模式是Gamma校正，则需要依次对所有激活通道的图像做伽马校正，并重新转换成伪彩色
            if (scanChannel.Activated && Settings.SelectedImageCorrection.ID == ImageCorrection.Gamma)
            {
                ScanData.ToGrayImages(scanChannel.ImageSettings.GammaLUT, id);
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置伽马校正范围的最小值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gammaMin"></param>
        /// <returns></returns>
        public int SetImageGammaRangeMin(int id, int gammaMin)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetGammaMin(gammaMin);

            if (scanChannel.Activated && Settings.SelectedImageCorrection.ID == ImageCorrection.Gamma)
            {
                ScanData.ToGrayImages(scanChannel.ImageSettings.GammaLUT, id);
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }

            return ApiCode.Success;
        }

        /// <summary>
        /// 设置伽马校正范围的最大值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gammaMax"></param>
        /// <returns></returns>
        public int SetImageGammaRangeMax(int id, int gammaMax)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetGammaMax(gammaMax);

            if (scanChannel.Activated && Settings.SelectedImageCorrection.ID == ImageCorrection.Gamma)
            {
                ScanData.ToGrayImages(scanChannel.ImageSettings.GammaLUT, id);
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置亮度对比度校正的亮度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        public int SetImageBrightness(int id, int brightness)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetBrightness(brightness);

            // 扫描任务图像校正模式是亮度-对比度校正，则需要依次对所有激活通道的图像做亮度-对比度校正，并重新转换成伪彩色
            if (scanChannel.Activated && Settings.SelectedImageCorrection.ID == ImageCorrection.ContrastBrightness)
            {
                ScanData.ToGrayImages(scanChannel.ImageSettings.Brightness, scanChannel.ImageSettings.Contrast, id);
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置图像的对比度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contrast"></param>
        /// <returns></returns>
        public int SetImageContrast(int id, int contrast)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetContrast(contrast);

            // 扫描任务图像校正模式是亮度-对比度校正，则需要依次对所有激活通道的图像做亮度-对比度校正，并重新转换成伪彩色
            if (scanChannel.Activated && Settings.SelectedImageCorrection.ID == ImageCorrection.ContrastBrightness)
            {
                ScanData.ToGrayImages(scanChannel.ImageSettings.Brightness, scanChannel.ImageSettings.Contrast, id);
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }

            return ApiCode.Success;
        }

        /// <summary>
        /// 设置通道伪彩色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int SetImagePseudoColor(int id, Color color)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetPseudoColor(color);

            if (scanChannel.Activated)
            {
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }

            return ApiCode.Success;
        }

        /// <summary>
        /// 设置通道偏置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public int SetImageOffset(int id, int offset)
        {
            ScanChannel scanChannel = Settings.ScanChannels.FirstOrDefault(p => p.ID == id);
            if (scanChannel == null)
            {
                return ApiCode.SchedulerScanChannelIdInvalid;
            }
            scanChannel.ImageSettings.SetOffset(offset);

            if (scanChannel.Activated)
            {
                ScanData.ToOriginImages(Settings.SelectedScanPixelDwell.ScanPixelScale, id, scanChannel.ImageSettings.Offset);
                if (Settings.SelectedImageCorrection.ID == ImageCorrection.ContrastBrightness)
                {
                    ScanData.ToGrayImages(scanChannel.ImageSettings.Brightness, scanChannel.ImageSettings.Contrast, id);
                }
                else
                {
                    ScanData.ToGrayImages(scanChannel.ImageSettings.GammaLUT, id);
                }
                ScanData.ToBGRImages(scanChannel.ImageSettings.PseudoColorLUT, id);
            }

            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 启动扫描
        /// </summary>
        public void Start()
        {
            mScanning = true;
            bool[] statusOfChannels = mTaskSettings.ScanChannels.Select(p => p.Activated).ToArray();

            ScanInfo = new ScanInfo(mTaskSettings.Sequence.InputAcquisitionCountPerFrame);
            ScanData = new ScanData(mTaskSettings.SelectedScanPixel.Data, mTaskSettings.SelectedScanPixel.Data, mTaskSettings.Sequence.InputAcquisitionCountPerFrame,
                mTaskSettings.GetChannelNum(), 1, statusOfChannels);
            mApdCurrentBank = -1;
        }

        /// <summary>
        /// 停止扫描
        /// </summary>
        public void Stop()
        {
            mScanning = false;
        }

        /// <summary>
        /// 更新Bank图像
        /// </summary>
        /// <param name="sampleData"></param>
        public void ConvertSamples(PmtSampleData sampleData)
        {
            for (int i = 0; i < mTaskSettings.GetChannelNum(); i++)
            {
                if (sampleData.NSamples[i] != null)
                {
                    short[] list = sampleData.NSamples[i];
                    double x = sampleData.NSamples[i].Average<short>(new Func<short, int>(delegate (short p) { return (int)p; }));
                    Logger.Info(string.Format("Average value [{0}][{1}].", i, x));
                    // 负电压转换
                    MatrixUtil.ToPositive(ref sampleData.NSamples[i]);
                    // 生成Bank数据矩阵[截断/双向扫描偶数行翻转和错位补偿]
                    NDArray matrix = MatrixUtil.ToMatrix(sampleData.NSamples[i], mTaskSettings.Sequence.InputSampleCountPerPixel, mTaskSettings.Sequence.InputPixelCountPerRow,
                        mTaskSettings.Sequence.InputPixelCountPerAcquisition / mTaskSettings.Sequence.InputPixelCountPerRow, mTaskSettings.SelectedScanDirection.ID,
                        mTaskSettings.SelectedScanPixelDwell.ScanPixelOffset, mTaskSettings.SelectedScanPixelDwell.ScanPixelCalibration,
                        mTaskSettings.SelectedScanPixel.Data);
                    // Matrix -> OriginDataSet.Bank
                    ScanData.ToDataSet(matrix, i, 0, sampleData.CurrentBank[i]);
                    // OriginDataSet.Bank -> OriginImages.Bank
                    ScanData.ToOriginImages(mTaskSettings.SelectedScanPixelDwell.ScanPixelScale, i, 0, sampleData.CurrentBank[i], mTaskSettings.ScanChannels[i].ImageSettings.Offset);
                    // OriginImages.Bank -> GrayImages.Bank
                    if (mTaskSettings.SelectedImageCorrection.ID == ImageCorrection.ContrastBrightness)
                    {
                        ScanData.ToGrayImages(mTaskSettings.ScanChannels[i].ImageSettings.Brightness, mTaskSettings.ScanChannels[i].ImageSettings.Contrast, i, 0, sampleData.CurrentBank[i]);
                    }
                    else
                    {
                        ScanData.ToGrayImages(mTaskSettings.ScanChannels[i].ImageSettings.GammaLUT, i, 0, sampleData.CurrentBank[i]);
                    }
                    // GrayImages.Bank -> BGRImages.Bank
                    ScanData.ToBGRImages(mTaskSettings.ScanChannels[i].ImageSettings.PseudoColorLUT, i, 0, sampleData.CurrentBank[i]);
                }
            }
            // BGRImages.Bank->MergeImages.Bank
            if (ScanData.ActivatedChannelNum > 1)
            {
                int bankIndex = sampleData.CurrentBank.Where(p => p >= 0).First();
                ScanData.ToMergeImages(0, bankIndex);
            }
        }

        /// <summary>
        /// 更新Bank图像
        /// </summary>
        /// <param name="sampleData"></param>
        public void ConvertSamples(ApdSampleData sampleData, int lastBankIndex)
        {
            // BGRImages.Bank -> MergeImages.Bank
            if (ScanData.ActivatedChannelNum > 1)
            {
                if (mApdCurrentBank != lastBankIndex)
                {
                    mApdCurrentBank = lastBankIndex;
                    ScanData.ToMergeImages(0, mApdCurrentBank);
                }
            }

            // 脉冲计数
            MatrixUtil.ToCounter(sampleData.NSamples, mTaskSettings.Sequence.InputSampleCountPerRow);
            // 
            NDArray matrix = MatrixUtil.ToMatrix(sampleData.NSamples, mTaskSettings.Sequence.InputSampleCountPerPixel, mTaskSettings.Sequence.InputPixelCountPerRow,
                mTaskSettings.Sequence.InputPixelCountPerAcquisition / mTaskSettings.Sequence.InputPixelCountPerRow, mTaskSettings.SelectedScanDirection.ID,
                mTaskSettings.SelectedScanPixelDwell.ScanPixelOffset, mTaskSettings.SelectedScanPixelDwell.ScanPixelCalibration,
                mTaskSettings.SelectedScanPixel.Data);
            // Matrix -> OriginDataSet.Bank
            ScanData.ToDataSet(matrix, sampleData.ChannelIndex, 0, sampleData.CurrentBank);
            // OriginDataSet.Bank -> OriginImages.Bank
            ScanData.ToOriginImages(mTaskSettings.SelectedScanPixelDwell.ScanPixelScale, sampleData.ChannelIndex, 0, sampleData.CurrentBank, mTaskSettings.ScanChannels[sampleData.ChannelIndex].ImageSettings.Offset);
            // OriginImages.Bank -> GrayImages.Bank
            if (mTaskSettings.SelectedImageCorrection.ID == ImageCorrection.ContrastBrightness)
            {
                ScanData.ToGrayImages(mTaskSettings.ScanChannels[sampleData.ChannelIndex].ImageSettings.Brightness, mTaskSettings.ScanChannels[sampleData.ChannelIndex].ImageSettings.Contrast, sampleData.ChannelIndex, 0, sampleData.CurrentBank);
            }
            else
            {
                ScanData.ToGrayImages(mTaskSettings.ScanChannels[sampleData.ChannelIndex].ImageSettings.GammaLUT, sampleData.ChannelIndex, 0, sampleData.CurrentBank);
            }
            // GrayImages.Bank -> BGRImages.Bank
            ScanData.ToBGRImages(mTaskSettings.ScanChannels[sampleData.ChannelIndex].ImageSettings.PseudoColorLUT, sampleData.ChannelIndex, 0, sampleData.CurrentBank);
        }

    }
}

