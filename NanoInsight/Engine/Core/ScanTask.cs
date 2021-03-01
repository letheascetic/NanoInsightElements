using Emgu.CV;
using log4net;
using NanoInsight.Engine.Attribute;
using NanoInsight.Engine.Common;
using NanoInsight.Engine.Data;
using NumSharp;
using System;
using System.Collections.Generic;
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

        private int mTaskId;
        private string mTaskName;
        private ScanInfo mScanInfo;
        private ScanData mScanData;
        private TaskSettings mTaskSettings;

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

        public ScanData ScanData
        {
            get { return mScanData; }
            set { mScanData = value; }
        }

        public ScanTask(int taskId, string taskName, Config config, ScanSequence sequence)
        {
            mTaskSettings = new TaskSettings(config, sequence);
            TaskId = taskId;
            TaskName = taskName;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////








        ///////////////////////////////////////////////////////////////////////////////////////////












        /// <summary>
        /// 启动扫描
        /// </summary>
        public void Start()
        {
            bool[] statusOfChannels = mTaskSettings.ScanChannels.Select(p => p.Activated).ToArray();

            ScanInfo = new ScanInfo(mTaskSettings.Sequence.InputAcquisitionCountPerFrame);
            ScanData = new ScanData(mTaskSettings.SelectedScanPixel.Data, mTaskSettings.SelectedScanPixel.Data, mTaskSettings.Sequence.InputAcquisitionCountPerFrame,
                mTaskSettings.GetChannelNum(), 1, statusOfChannels);
        }

        /// <summary>
        /// 停止扫描
        /// </summary>
        public void Stop()
        {

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
                    //  GrayImages.Bank -> BGRImages.Bank
                    ScanData.ToBGRImages(mTaskSettings.ScanChannels[i].ImageSettings.PseudoColorLUT, i, 0, sampleData.CurrentBank[i]);
                }
            }
        }

        /// <summary>
        /// 更新Bank图像
        /// </summary>
        /// <param name="sampleData"></param>
        public void ConvertSamples(ApdSampleData sampleData)
        {
            //MatrixUtil.ToCounter(sampleData.NSamples, mSequence.InputSampleCountPerRow);
            //NDArray matrix = MatrixUtil.ToMatrix(sampleData.NSamples, mSequence.InputSampleCountPerPixel, mSequence.InputPixelCountPerRow,
            //    mSequence.InputPixelCountPerAcquisition / mSequence.InputPixelCountPerRow, mConfig.SelectedScanDirection.ID,
            //    mConfig.SelectedScanPixelDwell.ScanPixelOffset, mConfig.SelectedScanPixelDwell.ScanPixelCalibration,
            //    mConfig.SelectedScanPixel.Data);
            //Mat originImage = ScanData.OriginDataSet[sampleData.ChannelIndex][0].Banks[ScanInfo.CurrentBank[sampleData.ChannelIndex]].Bank;
            //MatrixUtil.ToBankImage(matrix, ref originImage);
            //Mat grayImage = ScanData.GrayImages[sampleData.ChannelIndex][0].Banks[ScanInfo.CurrentBank[sampleData.ChannelIndex]].Bank;
            //double scale = 1.0 / Math.Pow(2, mConfig.SelectedScanPixelDwell.ScanPixelScale);
            //MatrixUtil.ToOriginImage(originImage, ref grayImage, scale, mConfig.ScanChannels[sampleData.ChannelIndex].ImageSettings.Offset);
        }

    }
}

