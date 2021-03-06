﻿using log4net;
using NanoInsight.Engine.Attribute;
using NanoInsight.Engine.Data;
using NanoInsight.Engine.Device;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class Scheduler
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        private volatile static Scheduler pScheduler = null;
        private static readonly object locker = new object();
        ///////////////////////////////////////////////////////////////////////////////////////////
        private const int PMT_TASK_COUNT = 1;
        private const int APD_TASK_COUNT = 4;
        ///////////////////////////////////////////////////////////////////////////////////////////
        public event ScanAreaChangedEventHandler ScanAreaChangedEvent;
        public event ScanAreaChangedEventHandler FullScanAreaChangedEvent;
        public event ScanAcquisitionChangedEventHandler ScanAcquisitionChangedEvent;
        public event ScanHeadChangedEventHandler ScanHeadChangedEvent;
        public event ScanDirectionChangedEventHandler ScanDirectionChangedEvent;
        public event ScanModeChangedEventHandler ScanModeChangedEvent;
        public event LineSkipChangedEventHandler LineSkipChangedEvent;
        public event LineSkipStatusChangedEventHandler LineSkipStatusChangedEvent;
        public event ScanPixelChangedEventHandler ScanPixelChangedEvent;
        public event ScanPixelDwellChangedEventHandler ScanPixelDwellChangedEvent;
        public event ScanPixelOffsetChangedEventHandler ScanPixelOffsetChangedEvent;
        public event ScanPixelCalibrationChangedEventHandler ScanPixelCalibrationChangedEvent;
        public event ScanPixelScaleChangedEventHandler ScanPixelScaleChangedEvent;
        public event ChannelGainChangedEventHandler ChannelGainChangedEvent;
        public event ChannelPowerChangedEventHandler ChannelPowerChangedEvent;
        public event ChannelLaserColorChangedEventHandler ChannelLaserColorChangedEvent;
        public event ChannelActivateChangedEventHandler ChannelActivateChangedEvent;
        public event ChannelPinHoleChangedEventHandler ChannelPinHoleChangedEvent;
        public event ImageOffsetChangedEventHandler ImageOffsetChangedEvent;
        public event ImagePseudoColorChangedEventHandler ImagePseudoColorChangedEvent;
        ///////////////////////////////////////////////////////////////////////////////////////////

        private NiDaq mNiDaq;
        private ScanSequence mSequence;
        private Config mConfig;

        private List<ScanTask> mScanTasks;
        private ScanTask mScanningTask;

        private CancellationTokenSource mCancelToken;
        private BlockingCollection<PmtSampleData> mPmtSampleQueue;
        private BlockingCollection<ApdSampleData> mApdSampleQueue;
        private Task[] mSampleWorkers;

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 是否有任务正在扫描中
        /// </summary>
        public bool IsScanning { get { return mConfig.IsScanning; } }

        /// <summary>
        /// 正在扫描的任务
        /// </summary>
        public ScanTask ScanningTask
        {
            get { return mScanningTask; }
        }

        public ScanSequence Sequence
        {
            get { return mSequence; }
        }

        public Config Configuration
        {
            get { return mConfig; }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        public static Scheduler CreateInstance()
        {
            if (pScheduler == null)
            {
                lock (locker)
                {
                    if (pScheduler == null)
                    {
                        pScheduler = new Scheduler();
                    }
                }
            }
            return pScheduler;
        }

        /// <summary>
        /// 设置扫描头
        /// </summary>
        /// <param name="id"></param>
        public int SetScanHead(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetScanHead(id);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();

                if (ScanHeadChangedEvent != null)
                {
                    return ScanHeadChangedEvent.Invoke(mConfig.SelectedScanHead);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置扫描模式
        /// </summary>
        /// <param name="id"></param>
        public int SetScanMode(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetScanMode(id);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();

                if (ScanModeChangedEvent != null)
                {
                    return ScanModeChangedEvent.Invoke(mConfig.SelectedScanMode);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置扫描方向
        /// </summary>
        /// <param name="id"></param>
        public int SetScanDirection(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetScanDirection(id);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();
                if (ScanDirectionChangedEvent != null)
                {
                    return ScanDirectionChangedEvent.Invoke(mConfig.SelectedScanDirection);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置扫描像素
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectScanPixel(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SelectScanPixel(id);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();
                if (ScanPixelChangedEvent != null)
                {
                    return ScanPixelChangedEvent.Invoke(mConfig.SelectedScanPixel);
                }
            }
            return code;
        }

        /// <summary>
        /// 选择像素时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectScanPixelDwell(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SelectScanPixelDwell(id);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();
                if (ScanPixelDwellChangedEvent != null)
                {
                    return ScanPixelDwellChangedEvent.Invoke(mConfig.SelectedScanPixelDwell);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置快速扫描模式
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int SetFastModeStatus(bool status)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            mConfig.FastModeEnabled = status;
            mSequence.GenerateScanCoordinates();
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置双向扫描时候的像素补偿
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelCalibration"></param>
        /// <returns></returns>
        public int SetScanPixelCalibration(int id, int scanPixelCalibration)
        {
            int code = mConfig.SetScanPixelCalibration(id, scanPixelCalibration);

            if (ApiCode.IsSuccessful(code))
            {
                if (mConfig.IsScanning)
                {
                    ScanningTask.SetScanPixelCalibration(id, scanPixelCalibration);
                }

                if (ScanPixelCalibrationChangedEvent != null)
                {
                    return ScanPixelCalibrationChangedEvent.Invoke(mConfig.SelectedScanPixelDwell);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置每行采集像素截取时的偏移量
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelOffset"></param>
        /// <returns></returns>
        public int SetScanPixelOffset(int id, int scanPixelOffset)
        {
            int code = mConfig.SetScanPixelOffset(id, scanPixelOffset);
            if (ApiCode.IsSuccessful(code))
            {
                if (mConfig.IsScanning)
                {
                    ScanningTask.SetScanPixelOffset(id, scanPixelOffset);
                }

                if (ScanPixelOffsetChangedEvent != null)
                {
                    return ScanPixelOffsetChangedEvent.Invoke(mConfig.SelectedScanPixelDwell);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置扫描像素缩放系数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="scanPixelScale"></param>
        /// <returns></returns>
        public int SetScanPixelScale(int id, int scanPixelScale)
        {
            int code = mConfig.SetScanPixelScale(id, scanPixelScale);

            if (ApiCode.IsSuccessful(code))
            {
                if (mConfig.IsScanning)
                {
                    ScanningTask.SetScanPixelScale(id, scanPixelScale);
                }

                if (ScanPixelScaleChangedEvent != null)
                {
                    return ScanPixelScaleChangedEvent.Invoke(mConfig.SelectedScanPixelDwell);
                }
            }
            return code;
        }

        /// <summary>
        /// 选择跳行扫描
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectLineSkip(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SelectLineSkip(id);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();
                if (LineSkipChangedEvent != null)
                {
                    return LineSkipChangedEvent.Invoke(mConfig.SelectedScanLineSkip);
                }
            }
            return code;
        }

        /// <summary>
        /// 跳行扫描开关状态变化
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public int SetLineSkipStatus(bool status)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetLineSkipStatus(status);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();
                if (LineSkipStatusChangedEvent != null)
                {
                    return LineSkipStatusChangedEvent.Invoke(status);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道状态
        /// </summary>
        /// <param name="id"></param>
        /// <param name="activated"></param>
        /// <returns></returns>
        public int SetChannelStatus(int id, bool activated)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetChannelStatus(id, activated);

            if (ApiCode.IsSuccessful(code))
            {
                if (ChannelActivateChangedEvent != null)
                {
                    return ChannelActivateChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道增益
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gain"></param>
        /// <returns></returns>
        public int SetChannelGain(int id, int gain)
        {
            int code = mConfig.SetChannelGain(id, gain);

            if (ApiCode.IsSuccessful(code))
            {
                code |= UsbDac.SetDacOut(UsbDac.ScanChannelToDacChannel(id), UsbDac.ConfigValueToVout(gain));
            }
                
            if (ApiCode.IsSuccessful(code))
            {
                if (mConfig.IsScanning)
                {
                    ScanningTask.SetChannelGain(id, gain);
                }

                if (ChannelGainChangedEvent != null)
                {
                    return ChannelGainChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道功率
        /// </summary>
        /// <param name="id"></param>
        /// <param name="power"></param>
        /// <returns></returns>
        public int SetChannelPower(int id, int power)
        {
            int code = mConfig.SetChannelPower(id, power);

            if (ApiCode.IsSuccessful(code))
            {
                if (mConfig.IsScanning)
                {
                    if (mConfig.ScanChannels[id].Activated)
                    {
                        Laser.SetChannelPower(id, power);
                    }
                    ScanningTask.SetChannelPower(id, power);
                }

                if (ChannelPowerChangedEvent != null)
                {
                    return ChannelPowerChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置激光颜色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int SetChannelLaserColor(int id, Color color)
        {
            int code = mConfig.SetChannelLaserColor(id, color);

            if (ApiCode.IsSuccessful(code))
            {
                if (mConfig.IsScanning)
                {
                    ScanningTask.SetChannelLaserColor(id, color);
                }

                if (ChannelLaserColorChangedEvent != null)
                {
                    return ChannelLaserColorChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道小孔孔径
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pinHole"></param>
        /// <returns></returns>
        public int SetChannelPinHole(int id, int pinHole)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetChannelPinHole(id, pinHole);

            if (ApiCode.IsSuccessful(code))
            {
                if (ChannelPinHoleChangedEvent != null)
                {
                    ChannelPinHoleChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置扫描区域
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetScanArea(RectangleF scanRange)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetScanArea(scanRange);

            if (ApiCode.IsSuccessful(code))
            {
                mSequence.GenerateScanCoordinates();
                if (ScanAreaChangedEvent != null)
                {
                    return ScanAreaChangedEvent.Invoke(mConfig.SelectedScanArea);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置全视场的扫描范围
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetFullScanArea(RectangleF scanRange)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetFullScanArea(scanRange);
            if (ApiCode.IsSuccessful(code))
            {
                if (FullScanAreaChangedEvent != null)
                {
                    return FullScanAreaChangedEvent.Invoke(mConfig.FullScanArea);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置全视场的扫描范围
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetFullScanArea(float scanRange)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            int code = mConfig.SetFullScanArea(scanRange);
            if (ApiCode.IsSuccessful(code))
            {
                if (FullScanAreaChangedEvent != null)
                {
                    return FullScanAreaChangedEvent.Invoke(mConfig.FullScanArea);
                }
            }
            return code;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 获取指定TaskId的扫描任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ScanTask GetScanTask(int taskId)
        {
            return mScanTasks.Where(p => p.TaskId == taskId).FirstOrDefault();
        }

        /// <summary>
        /// 启动指定采集类型的采集任务
        /// </summary>
        /// <param name="acquisitionId">采集类型</param>
        /// <param name="taskId">任务Id</param>
        /// <returns></returns>
        public int StartAcquisition(int acquisitionId, int taskId)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            if (mConfig.GetActivatedChannelNum() == 0)
            {
                return ApiCode.SchedulerNoScanChannelActivated;
            }

            int code = mConfig.SetAcquisition(acquisitionId);
            if (!ApiCode.IsSuccessful(code))
            {
                return code;
            }

            CreateScanTask(taskId, "实时扫描", out ScanTask scanTask);
            code = StartScanTask(scanTask);

            if (ApiCode.IsSuccessful(code))
            {
                if (ScanAcquisitionChangedEvent != null)
                {
                    return ScanAcquisitionChangedEvent.Invoke(mConfig.SelectedScanAcquisition);
                }
            }

            return code;
        }

        /// <summary>
        /// 停止采集
        /// </summary>
        /// <returns></returns>
        public int StopAcquisition()
        {
            int code = ApiCode.Success;
            int taskId = ScanningTask.TaskId;
            if (mConfig.IsScanning)
            {
                mConfig.StopAcquisition();
                code = StopScanTask();
            }
            if (ApiCode.IsSuccessful(code))
            {
                if (ScanAcquisitionChangedEvent != null)
                {
                    return ScanAcquisitionChangedEvent.Invoke(mConfig.SelectedScanAcquisition);
                }
            }
            return code;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 创建指定TaskID的扫描任务，若已经存在，则从任务池中删除已有的，再新建
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <param name="scanTask"></param>
        /// <returns></returns>
        private int CreateScanTask(int taskId, string taskName, out ScanTask scanTask)
        {
            scanTask = GetScanTask(taskId);
            if (scanTask != null)
            {
                mScanTasks.Remove(scanTask);
            }

            scanTask = new ScanTask(taskId, taskName, mConfig, mSequence);
            mScanTasks.Add(scanTask);
            return ApiCode.Success;
        }

        /// <summary>
        /// 启动扫描任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <returns></returns>
        private int StartScanTask(ScanTask scanTask)
        {
            int code = ApiCode.Success;
            if (mConfig.GetActivatedChannelNum() == 0)
            {
                code = ApiCode.SchedulerNoScanChannelActivated;
                Logger.Info(string.Format("start scan task[{0}|{1}] failed: [{2}].", scanTask.TaskId, scanTask.TaskName, code));
                return code;
            }

            mScanningTask = scanTask;
            mScanningTask.Settings.Sequence.GenerateFrameScanWaves();
            // mSequence.GenerateScanCoordinates();      // 生成扫描范围序列和电压序列
            // mSequence.GenerateFrameScanWaves();       // 生成帧电压序列

            OpenLaserChannels();                         // 打开激光器
            // SetLaserChannelPower();                      // 设置激光器功率
            ScanningTask.Start();

            mCancelToken = new CancellationTokenSource();
            if (mConfig.Detector.CurrentDetecor.ID == DetectorType.Pmt)
            {
                mPmtSampleQueue = new BlockingCollection<PmtSampleData>(new ConcurrentQueue<PmtSampleData>());
                mSampleWorkers = new Task[PMT_TASK_COUNT];
                for (int i = 0; i < mSampleWorkers.Length; i++)
                {
                    mSampleWorkers[i] = Task.Run(() => PmtSampleWorker());
                }
            }
            else
            {
                mApdSampleQueue = new BlockingCollection<ApdSampleData>(new ConcurrentQueue<ApdSampleData>());
                mSampleWorkers = new Task[APD_TASK_COUNT];
                for (int i = 0; i < mSampleWorkers.Length; i++)
                {
                    mSampleWorkers[i] = Task.Run(() => ApdSampleWorker());
                }
            }

            code = mNiDaq.SetGalvoOffsetVoltage(mConfig.GalvoAttr.XGalvoAoChannel, mScanningTask.Settings.Sequence.XWave[0]);
            code |= mNiDaq.SetGalvoOffsetVoltage(mConfig.GalvoAttr.YGalvoAoChannel, mScanningTask.Settings.Sequence.Y1Wave[0]);
            code = mNiDaq.Start(mScanningTask.Settings.Sequence);                       // 启动板卡

            if (!ApiCode.IsSuccessful(code))
            {
                Logger.Info(string.Format("start scan task[{0}|{1}] failed: [{2}].", scanTask.TaskId, scanTask.TaskName, code));
                StopScanTask();
                return code;
            }

            Logger.Info(string.Format("start scan task[{0}|{1}] success.", scanTask.TaskId, scanTask.TaskName));
            return code;
        }

        /// <summary>
        /// 停止扫描任务
        /// </summary>
        /// <returns></returns>
        private int StopScanTask()
        {
            if (ScanningTask == null)
            {
                return ApiCode.SchedulerScanTaskInvalid;
            }

            if (GetScanTask(ScanningTask.TaskId) == null)
            {
                return ApiCode.SchedulerScanTaskNotFound;
            }

            Logger.Info(string.Format("stop scan task[{0}|{1}].", ScanningTask.TaskId, ScanningTask.TaskName));

            mNiDaq.Stop();
            ScanningTask.Stop();

            mCancelToken.Cancel();
            if (mConfig.Detector.CurrentDetecor.ID == DetectorType.Pmt)
            {
                mPmtSampleQueue.CompleteAdding();
            }
            else
            {
                mApdSampleQueue.CompleteAdding();
            }
            Task.WaitAll(mSampleWorkers);
            Dispose();

            mScanningTask = null;
            CloseLaserChannels();
            // SetGalvoOffsetVoltage();

            return ApiCode.Success;
        }

        //public void Release()
        //{
        //    ReleaseLaser();
        //    ReleaseUsbDac();
        //}

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 设置伽马校正值
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="channelId"></param>
        /// <param name="gamma"></param>
        /// <returns></returns>
        public int SetImageGamma(int taskId, int channelId, int gamma)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = scanTask.SetImageGamma(channelId, gamma);
            return code;
        }

        /// <summary>
        /// 设置伽马校正范围的最小值
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="gammaMin"></param>
        /// <returns></returns>
        public int SetImageGammaRangeMin(int taskId, int channelId, int gammaMin)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = scanTask.SetImageGammaRangeMin(channelId, gammaMin);
            return code;
        }

        /// <summary>
        /// 设置伽马校正范围的最大值
        /// </summary>
        /// <param name="id"></param>
        /// <param name="gammaMax"></param>
        /// <returns></returns>
        public int SetImageGammaRangeMax(int taskId, int channelId, int gammaMax)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = scanTask.SetImageGammaRangeMax(channelId, gammaMax);
            return code;
        }

        /// <summary>
        /// 设置亮度对比度校正的亮度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="brightness"></param>
        /// <returns></returns>
        public int SetImageBrightness(int taskId, int channelId, int brightness)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = scanTask.SetImageBrightness(channelId, brightness);
            return code;
        }

        /// <summary>
        /// 设置图像的对比度
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contrast"></param>
        /// <returns></returns>
        public int SetImageContrast(int taskId, int channelId, int contrast)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = scanTask.SetImageContrast(channelId, contrast);
            return code;
        }

        /// <summary>
        /// 设置通道伪彩色
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int SetImagePseudoColor(int taskId, int channelId, Color color)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = scanTask.SetImagePseudoColor(channelId, color);

            if (ApiCode.IsSuccessful(code))
            {
                if (ImagePseudoColorChangedEvent != null)
                {
                    return ImagePseudoColorChangedEvent.Invoke(scanTask.Settings.ScanChannels[channelId].ImageSettings);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道偏置
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public int SetImageOffset(int taskId, int channelId, int offset)
        {
            ScanTask scanTask = mScanTasks.FirstOrDefault(p => p.TaskId == taskId);
            if (scanTask == null)
            {
                return ApiCode.SchedulerNoScanTaskExist;
            }

            int code = mConfig.SetChannelOffset(channelId, offset);
            code |= scanTask.SetImageOffset(channelId, offset);
            if (ApiCode.IsSuccessful(code))
            {
                if (ImageOffsetChangedEvent != null)
                {
                    return ImageOffsetChangedEvent.Invoke(scanTask.Settings.ScanChannels[channelId].ImageSettings);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道偏置
        /// </summary>
        /// <param name="channelId"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public int SetImageOffset(int channelId, int offset)
        {
            int code = mConfig.SetChannelOffset(channelId, offset);
            if (ApiCode.IsSuccessful(code))
            {
                if (ImageOffsetChangedEvent != null)
                {
                    return ImageOffsetChangedEvent.Invoke(mConfig.ScanChannels[channelId].ImageSettings);
                }
            }
            return code;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 设置X振镜控制通道
        /// </summary>
        /// <param name="xGalvoChannel"></param>
        /// <returns></returns>
        public int SetXGalvoChannel(string xGalvoChannel)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.XGalvoAoChannel = xGalvoChannel;
            Logger.Info(string.Format("X Galvo Ao Channel [{0}].", mConfig.GalvoAttr.XGalvoAoChannel));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置Y振镜控制通道
        /// </summary>
        /// <param name="yGalvoChannel"></param>
        /// <returns></returns>
        public int SetYGalvoChannel(string yGalvoChannel)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.YGalvoAoChannel = yGalvoChannel;
            Logger.Info(string.Format("Y Galvo Ao Channel [{0}].", mConfig.GalvoAttr.YGalvoAoChannel));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置Y2振镜控制通道
        /// </summary>
        /// <param name="y2GalvoChannel"></param>
        /// <returns></returns>
        public int SetY2GalvoChannel(string y2GalvoChannel)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.Y2GalvoAoChannel = y2GalvoChannel;
            Logger.Info(string.Format("Y2 Galvo Ao Channel [{0}].", mConfig.GalvoAttr.Y2GalvoAoChannel));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置X振镜偏置电压
        /// </summary>
        /// <param name="offsetVoltage"></param>
        /// <returns></returns>
        public int SetXGalvoOffsetVoltage(double offsetVoltage)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.XGalvoOffsetVoltage = offsetVoltage;
            Logger.Info(string.Format("X Galvo Offset Voltage [{0}].", mConfig.GalvoAttr.XGalvoOffsetVoltage));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置X振镜校准电压
        /// </summary>
        /// <param name="calibrationVoltage"></param>
        /// <returns></returns>
        public int SetXGalvoCalibrationVoltage(double calibrationVoltage)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.XGalvoCalibrationVoltage = calibrationVoltage;
            Logger.Info(string.Format("X Galvo Calibration Voltage [{0}].", mConfig.GalvoAttr.XGalvoCalibrationVoltage));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置Y振镜偏置电压
        /// </summary>
        /// <param name="offsetVoltage"></param>
        /// <returns></returns>
        public int SetYGalvoOffsetVoltage(double offsetVoltage)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.YGalvoOffsetVoltage = offsetVoltage;
            Logger.Info(string.Format("Y Galvo Offset Voltage [{0}].", mConfig.GalvoAttr.YGalvoOffsetVoltage));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置Y振镜校准电压
        /// </summary>
        /// <param name="calibrationVoltage"></param>
        /// <returns></returns>
        public int SetYGalvoCalibrationVoltage(double calibrationVoltage)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.YGalvoCalibrationVoltage = calibrationVoltage;
            Logger.Info(string.Format("Y Galvo Calibration Voltage [{0}].", mConfig.GalvoAttr.YGalvoCalibrationVoltage));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置振镜响应时间
        /// </summary>
        /// <param name="responseTime"></param>
        /// <returns></returns>
        public int SetGalvoResponseTime(double responseTime)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.GalvoAttr.GalvoResponseTime = responseTime;
            Logger.Info(string.Format("Galvo Response Time [{0}].", mConfig.GalvoAttr.GalvoResponseTime));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置探测器类型
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SetDetectorMode(int id)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            
            mConfig.Detector.Pmt.IsEnabled = mConfig.Detector.Pmt.ID == id;
            mConfig.Detector.Apd.IsEnabled = !mConfig.Detector.Pmt.IsEnabled;
            Logger.Info(string.Format("Detector Mode [{0}].", mConfig.Detector.CurrentDetecor.Text));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置PMT通道
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pmtChannel"></param>
        /// <returns></returns>
        public int SetPmtChannel(int id, string pmtChannel)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }

            PmtChannel channel = mConfig.Detector.FindPmtChannel(id);
            channel.AiChannel = pmtChannel;
            Logger.Info(string.Format("Pmt [{0}] Ao Channel [{1}].", channel.ID, channel.AiChannel));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置APD的计数器（Source）
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apdSource"></param>
        /// <returns></returns>
        public int SetApdSource(int id, string apdSource)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            ApdChannel channel = mConfig.Detector.FindApdChannel(id);
            channel.CiSource = apdSource;
            Logger.Info(string.Format("Apd [{0}] Ci Channel [{1}:{2}].", channel.ID, channel.CiSource, channel.CiChannel));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置APD的计数器端口
        /// </summary>
        /// <param name="id"></param>
        /// <param name="apdChannel"></param>
        /// <returns></returns>
        public int SetApdChannel(int id, string apdChannel)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            ApdChannel channel = mConfig.Detector.FindApdChannel(id);
            channel.CiChannel = apdChannel;
            Logger.Info(string.Format("Apd [{0}] Ci Channel [{1}:{2}].", channel.ID, channel.CiSource, channel.CiChannel));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置StartTrigger
        /// </summary>
        /// <param name="startTrigger"></param>
        /// <returns></returns>
        public int SetStartTrigger(string startTrigger)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.Detector.StartTrigger = startTrigger;
            Logger.Info(string.Format("Start Trigger [{0}].", mConfig.Detector.StartTrigger));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置触发输出端口
        /// </summary>
        /// <param name="triggerSignal"></param>
        /// <returns></returns>
        public int SetTriggerSignal(string triggerSignal)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.Detector.TriggerSignal = triggerSignal;
            Logger.Info(string.Format("Trigger Signal [{0}].", mConfig.Detector.TriggerSignal));
            return ApiCode.Success;
        }

        /// <summary>
        /// 设置触发接收端口
        /// </summary>
        /// <param name="triggerReceive"></param>
        /// <returns></returns>
        public int SetTriggerReceiver(string triggerReceive)
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            mConfig.Detector.TriggerReceive = triggerReceive;
            Logger.Info(string.Format("Trigger Receiver [{0}].", mConfig.Detector.TriggerReceive));
            return ApiCode.Success;
        }

        /// <summary>
        /// 控制振镜偏转到其偏置电压对应的角度
        /// </summary>
        /// <returns></returns>
        public int SetGalvoOffsetVoltage()
        {
            if (mConfig.IsScanning)
            {
                return ApiCode.SchedulerTaskScanning;
            }
            int code = mNiDaq.SetGalvoOffsetVoltage(mConfig.GalvoAttr.XGalvoAoChannel, mConfig.GalvoAttr.XGalvoOffsetVoltage);
            code |= mNiDaq.SetGalvoOffsetVoltage(mConfig.GalvoAttr.YGalvoAoChannel, mConfig.GalvoAttr.YGalvoOffsetVoltage);
            return code;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        private Scheduler()
        {
            Initialize();
        }

        private void Initialize()
        {
            mConfig = Config.GetConfig();
            mSequence = new ScanSequence();
            mNiDaq = new NiDaq(mConfig);
            mScanTasks = new List<ScanTask>();
            mScanningTask = null;
            ConfigUsbDac();
            ConfigLaser();
            mNiDaq.AiSamplesReceived += PmtReceiveSamples;
            mNiDaq.CiSamplesReceived += ApdReceiveSamples;
        }

        /// <summary>
        /// 初始化增益控制板卡
        /// </summary>
        private void ConfigUsbDac()
        {
            UsbDac.Connect();
            UsbDac.SetDacOut(UsbDac.ScanChannelToDacChannel(ScanChannel.Channel405), UsbDac.ConfigValueToVout(mConfig.ScanChannel405.Gain));
            UsbDac.SetDacOut(UsbDac.ScanChannelToDacChannel(ScanChannel.Channel488), UsbDac.ConfigValueToVout(mConfig.ScanChannel488.Gain));
            UsbDac.SetDacOut(UsbDac.ScanChannelToDacChannel(ScanChannel.Channel561), UsbDac.ConfigValueToVout(mConfig.ScanChannel561.Gain));
            UsbDac.SetDacOut(UsbDac.ScanChannelToDacChannel(ScanChannel.Channel640), UsbDac.ConfigValueToVout(mConfig.ScanChannel640.Gain));
        }

        /// <summary>
        /// 初始化激光器
        /// </summary>
        private void ConfigLaser()
        {
            string portName = mConfig.LaserPort;
            Laser.Connect(portName);

            for (int i = 0; i < mConfig.GetChannelNum(); i++)
            {
                if (!mConfig.ScanChannels[i].Activated)
                {
                    continue;
                }
                if (!ApiCode.IsSuccessful(Laser.OpenChannel(i)))
                {
                    mConfig.ScanChannels[i].Activated = false;
                }
                Laser.SetChannelPower(i, mConfig.ScanChannels[i].LaserPower);
            }
        }

        /// <summary>
        /// 打开对应的激光
        /// </summary>
        private void OpenLaserChannels()
        {
            if (!Laser.IsConnected())
            {
                Laser.Connect(mConfig.LaserPort);
            }

            for (int i = 0; i < mConfig.GetChannelNum(); i++)
            {
                if (mConfig.ScanChannels[i].Activated)
                {
                    Laser.OpenChannel(i);
                    Laser.SetChannelPower(mConfig.ScanChannels[i].ID, mConfig.ScanChannels[i].LaserPower);
                }
            }
        }

        /// <summary>
        /// 关闭所有的激光
        /// </summary>
        private void CloseLaserChannels()
        {
            for (int i = 0; i < mConfig.GetChannelNum(); i++)
            {
                Laser.CloseChannel(i);
            }
        }

        private void ReleaseLaser()
        {
            if (Laser.IsConnected())
            {
                for (int i = 0; i < mConfig.GetChannelNum(); i++)
                {
                    if (mConfig.ScanChannels[i].Activated)
                    {
                        Laser.CloseChannel(i);
                        mConfig.ScanChannels[i].Activated = false;
                    }
                }
            }
            Laser.Release();
        }

        private void ReleaseUsbDac()
        {
            if (UsbDac.IsConnected())
            {
                UsbDac.Release();
            }
        }

        private void PmtReceiveSamples(object sender, short[][] samples, long[] acquisitionCount)
        {
            try
            {
                ScanningTask.ScanInfo.UpdateScanInfo(acquisitionCount);
                PmtSampleData sampleData = new PmtSampleData(samples, acquisitionCount, 
                    ScanningTask.ScanInfo.CurrentFrame, ScanningTask.ScanInfo.CurrentBank);
                mPmtSampleQueue.TryAdd(sampleData, 50, mCancelToken.Token);
            }
            catch (OperationCanceledException)
            {
                Logger.Info(string.Format("Enqueue Pmt Smaples [{0}] Canceled.", acquisitionCount));
                mPmtSampleQueue.CompleteAdding();
            }
        }

        private void ApdReceiveSamples(object sender, int channelIndex, int[] samples, long acquisitionCount)
        {
            try
            {
                ScanningTask.ScanInfo.UpdateScanInfo(channelIndex, acquisitionCount);
                ApdSampleData sampleData = new ApdSampleData(samples, channelIndex, acquisitionCount, 
                    ScanningTask.ScanInfo.CurrentFrame[channelIndex], ScanningTask.ScanInfo.CurrentBank[channelIndex]);
                mApdSampleQueue.TryAdd(sampleData, 50, mCancelToken.Token);
                Logger.Info(string.Format("Enqueue Apd Samples [{0}][{1}].", channelIndex, acquisitionCount));
            }
            catch (OperationCanceledException)
            {
                Logger.Info(string.Format("Enqueue Apd Smaples [{0}][{1}] Canceled.", channelIndex, acquisitionCount));
                mPmtSampleQueue.CompleteAdding();
            }
        }

        private void PmtSampleWorker()
        {
            while (!mPmtSampleQueue.IsCompleted)
            {
                try
                {
                    if (mPmtSampleQueue.TryTake(out PmtSampleData sampleData, 20, mCancelToken.Token))
                    {
                        ScanningTask.ConvertSamples(sampleData);
                        //if (ScanImageUpdatedEvent != null)
                        //{
                        //    ScanImageUpdatedEvent.Invoke(ScanningTask.ScanData.GrayImages);
                        //}
                    }
                }
                catch (OperationCanceledException)
                {
                    Logger.Info(string.Format("Pmt Sample Worker Canceled."));
                    break;
                }
            }
            Logger.Info(string.Format("Pmt Sample Worker Finished."));
        }

        private void ApdSampleWorker()
        {
            while (!mApdSampleQueue.IsCompleted)
            {
                try
                {
                    if (mApdSampleQueue.TryTake(out ApdSampleData sampleData, 20, mCancelToken.Token))
                    {
                        int lastBankIndex = GetLastBankIndex(ScanningTask.ScanInfo);
                        ScanningTask.ConvertSamples(sampleData, lastBankIndex);
                    }
                }
                catch (OperationCanceledException)
                {
                    Logger.Info(string.Format("Apd Sample Worker Canceled."));
                    break;
                }
            }
            Logger.Info(string.Format("Apd Sample Worker Finished."));
        }

        private void Dispose()
        {
            if (mCancelToken != null)
            {
                mCancelToken.Dispose();
                mCancelToken = null;
            }

            if (mApdSampleQueue != null)
            {
                mApdSampleQueue.Dispose();
                mApdSampleQueue = null;
            }

            if (mPmtSampleQueue != null)
            {
                mPmtSampleQueue.Dispose();
                mPmtSampleQueue = null;
            }

            foreach (Task consumer in mSampleWorkers)
            {
                if (consumer != null)
                {
                    consumer.Dispose();
                }
            }
            mSampleWorkers = null;
        }

        /// <summary>
        /// 在属性变化前执行
        /// </summary>
        /// <returns></returns>
        private int BeforePropertyChanged()
        {
            // 如果当前正在采集(有任一采集模式使能)，则先停止采集
            if (mConfig.IsScanning)
            {
                return StopScanTask();
            }
            return ApiCode.Success;
        }

        private int AfterPropertyChanged()
        {
            if (mConfig.IsScanning)
            {
                CreateScanTask(0, "实时扫描", out ScanTask scanTask);
                return StartScanTask(scanTask);
            }
            else
            {
                mSequence.GenerateScanCoordinates();
            }
            return ApiCode.Success;
        }

        private int GetLastBankIndex(ScanInfo scanInfo)
        {
            long acquisitionCount = scanInfo.AcquisitionCount.Where(p => p>=0).Min();
            int bankIndex = (int)(acquisitionCount % scanInfo.NumOfBank);
            if (bankIndex > 0)
            {
                return bankIndex - 1;
            }
            else
            {
                return acquisitionCount == 0 ? -1 : scanInfo.NumOfBank - 1;
            }
        }

    }
}
