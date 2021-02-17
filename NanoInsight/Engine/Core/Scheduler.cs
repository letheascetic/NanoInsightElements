using log4net;
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
        private const int PMT_TASK_COUNT = 4;
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
        public event ChannelOffsetChangedEventHandler ChannelOffsetChangedEvent;
        public event ChannelPowerChangedEventHandler ChannelPowerChangedEvent;
        public event ChannelLaserColorChangedEventHandler ChannelLaserColorChangedEvent;
        public event ChannelPseudoColorChangedEventHandler ChannelPseudoColorChangedEvent;
        public event ChannelActivateChangedEventHandler ChannelActivateChangedEvent;
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
        public List<ScanTask> ScanTasks
        {
            get { return mScanTasks; }
            set { mScanTasks = value; }
        }

        public ScanTask ScanningTask
        {
            get { return mScanningTask; }
            set { mScanningTask = value; }
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
        /// 创建指定TaskID的扫描任务，若已经存在，则返回已经存在的
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="taskName"></param>
        /// <param name="scanTask"></param>
        /// <returns></returns>
        public int CreateScanTask(int taskId, string taskName, out ScanTask scanTask)
        {
            scanTask = GetScanTask(taskId);
            if (scanTask == null)
            {
                scanTask = new ScanTask(taskId, taskName);
                ScanTasks.Add(scanTask);
            }
            return ApiCode.Success;
        }

        /// <summary>
        /// 获取指定TaskId的扫描任务
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public ScanTask GetScanTask(int taskId)
        {
            return ScanTasks.Where(p => p.TaskId == taskId).FirstOrDefault();
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

            ScanningTask = scanTask;

            mSequence.GenerateScanCoordinates();         // 生成扫描范围序列和电压序列
            mSequence.GenerateFrameScanWaves();          // 生成帧电压序列
            OpenLaserChannels();                         // 打开激光器
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

            code = mNiDaq.Start();                       // 启动板卡

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

            ScanningTask = null;
            CloseLaserChannels();

            return ApiCode.Success;
        }

        public void Release()
        {
            ReleaseLaser();
            ReleaseUsbDac();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 启动指定的采集模式
        /// </summary>
        /// <param name="id"></param>
        public int StartAcquisition(int id)
        {
            int code = BeforePropertyChanged();

            if (mConfig.GetActivatedChannelNum() == 0)
            {
                return ApiCode.SchedulerNoScanChannelActivated;
            }

            code |= mConfig.StartAcquisition(id);
            if (!ApiCode.IsSuccessful(code))
            {
                return code;
            }

            CreateScanTask(0, "实时扫描", out ScanTask scanTask);
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

        /// <summary>
        /// 设置扫描头
        /// </summary>
        /// <param name="id"></param>
        public int SetScanHead(int id)
        {
            int code = BeforePropertyChanged();
            code |= mConfig.SetScanHead(id);
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
                if (ScanHeadChangedEvent != null)
                {
                    return ScanHeadChangedEvent.Invoke(mConfig.SelectedScanHead);
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
            int code = BeforePropertyChanged();
            code |= mConfig.SetScanDirection(id);
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
                if (ScanDirectionChangedEvent != null)
                {
                    return ScanDirectionChangedEvent.Invoke(mConfig.SelectedScanDirection);
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
            int code = BeforePropertyChanged();
            code |= mConfig.SetScanMode(id);
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
                if (ScanModeChangedEvent != null)
                {
                    return ScanModeChangedEvent.Invoke(mConfig.SelectedScanMode);
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
            int code = BeforePropertyChanged();
            code |= mConfig.SelectScanPixel(id);
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
                if (ScanPixelChangedEvent != null)
                {
                    return ScanPixelChangedEvent.Invoke(mConfig.SelectedScanPixel);
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
            mConfig.FastModeEnabled = status;
            return ApiCode.Success;
        }

        /// <summary>
        /// 选择像素时间
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int SelectScanPixelDwell(int id)
        {
            int code = BeforePropertyChanged();
            code |= mConfig.SelectScanPixelDwell(id);
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
                if (ScanPixelDwellChangedEvent != null)
                {
                    return ScanPixelDwellChangedEvent.Invoke(mConfig.SelectedScanPixelDwell);
                }
            }
            return code;
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
            int code = BeforePropertyChanged();
            code |= mConfig.SelectLineSkip(id); ;
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
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
            int code = BeforePropertyChanged();
            code |= mConfig.SetLineSkipStatus(status);
            code |= AfterPropertyChanged();
            if (ApiCode.IsSuccessful(code))
            {
                if (LineSkipStatusChangedEvent != null)
                {
                    return LineSkipStatusChangedEvent.Invoke(status);
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
                if (ChannelGainChangedEvent != null)
                {
                    return ChannelGainChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道偏置
        /// </summary>
        /// <param name="id"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public int SetChannelOffset(int id, int offset)
        {
            int code = mConfig.SetChannelOffset(id, offset);
            if (ApiCode.IsSuccessful(code))
            {
                if (ChannelOffsetChangedEvent != null)
                {
                    return ChannelOffsetChangedEvent.Invoke(mConfig.ScanChannels[id]);
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
                if (ChannelLaserColorChangedEvent != null)
                {
                    return ChannelLaserColorChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        /// <summary>
        /// 设置通道伪彩色
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <returns></returns>
        public int SetChannelPseudoColor(int id, Color color)
        {
            int code = mConfig.SetChannelPseudoColor(id, color);
            if (ApiCode.IsSuccessful(code))
            {
                if (ChannelPseudoColorChangedEvent != null)
                {
                    return ChannelPseudoColorChangedEvent.Invoke(mConfig.ScanChannels[id]);
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
            int code = BeforePropertyChanged();
            code |= mConfig.SetChannelStatus(id, activated);

            if (mConfig.IsScanning)
            {
                ScanChannel channel = mConfig.FindScanChannel(id);
                if (!channel.Activated && mConfig.GetActivatedChannelNum() == 0)
                {
                    channel.Activated = true;
                }
            }

            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
                if (ChannelActivateChangedEvent != null)
                {
                    return ChannelActivateChangedEvent.Invoke(mConfig.ScanChannels[id]);
                }
            }
            return code;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        /// <summary>
        /// 设置扫描区域
        /// </summary>
        /// <param name="scanRange"></param>
        /// <returns></returns>
        public int SetScanArea(RectangleF scanRange)
        {
            int code = BeforePropertyChanged();
            code |= mConfig.SetScanArea(scanRange);
            code |= AfterPropertyChanged();

            if (ApiCode.IsSuccessful(code))
            {
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
            mNiDaq = new NiDaq();
            mSequence = ScanSequence.CreateInstance();
            ScanTasks = new List<ScanTask>();
            ScanningTask = null;
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
                    Laser.SetChannelPower(mConfig.ScanChannels[i].ID, Laser.ConfigValueToPower(mConfig.ScanChannels[i].LaserPower));
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
                PmtSampleData sampleData = new PmtSampleData(samples, acquisitionCount);
                mPmtSampleQueue.TryAdd(sampleData, 50, mCancelToken.Token);
                // Logger.Info(string.Format("Enqueue Pmt Samples [{0}][{1}].", acquisitionCount, samples[0].Length));
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
                ApdSampleData sampleData = new ApdSampleData(samples, channelIndex, acquisitionCount);
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
                        ScanningTask.ScanInfo.UpdateScanInfo(sampleData);
                        //ScanningTask.ConvertSamples(sampleData);
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
                        ScanningTask.ScanInfo.UpdateScanInfo(sampleData);
                        //ScanningTask.ConvertSamples(sampleData);
                        //if (ScanImageUpdatedEvent != null)
                        //{
                        //    ScanImageUpdatedEvent.Invoke(ScanningTask.ScanData.GrayImages);
                        //}
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

    }
}
