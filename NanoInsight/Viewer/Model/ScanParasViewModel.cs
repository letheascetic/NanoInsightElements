using GalaSoft.MvvmLight;
using log4net;
using NanoInsight.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    public class ScanParasViewModel : ViewModelBase
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        private static readonly int SAMPLE_COUNT_FACTOR = 2;
        ///////////////////////////////////////////////////////////////////////////////////////////

        private readonly Scheduler mScheduler;

        private int outputSampleCountPerFrame;
        private int outputRoundTripCountPerFrame;
        private int outputSampleCountPerRoundTrip;
        private double outputSampleRate;
        private double triggerOutputSampleRate;
        private double inputSampleRate;
        private int inputSampleCountPerRoundTrip;
        private int inputRoundTripCountPerFrame;
        private int inputSampleCountPerFrame;
        private int inputSampleCountPerPixel;
        private int inputSampleCountPerAcquisition;
        private int inputPixelCountPerAcquisition;
        private int inputRoundTripCountPerAcquisition;
        private int inputAcquisitionCountPerFrame;
        private int inputSampleCountPerRow;
        private int inputPixelCountPerRow;
        private double fps;
        private double frameTime;

        /// <summary>
        /// 单帧输出样本数
        /// </summary>
        public int OutputSampleCountPerFrame
        {
            get { return outputSampleCountPerFrame; }
            set { outputSampleCountPerFrame = value; RaisePropertyChanged(() => OutputSampleCountPerFrame); }
        }
        /// <summary>
        /// 单帧往返次数
        /// </summary>
        public int OutputRoundTripCountPerFrame
        {
            get { return outputRoundTripCountPerFrame; }
            set { outputRoundTripCountPerFrame = value; RaisePropertyChanged(() => OutputRoundTripCountPerFrame); }
        }
        /// <summary>
        /// 单次往返样本数
        /// </summary>
        public int OutputSampleCountPerRoundTrip
        {
            get { return outputSampleCountPerRoundTrip; }
            set { outputSampleCountPerRoundTrip = value; RaisePropertyChanged(() => OutputSampleCountPerRoundTrip); }
        }
        /// <summary>
        /// 样本输出速率
        /// </summary>
        public double OutputSampleRate
        {
            get { return outputSampleRate; }
            set { outputSampleRate = value; RaisePropertyChanged(() => OutputSampleRate); }
        }
        /// <summary>
        /// 触发输出速率
        /// </summary>
        public double TriggerOutputSampleRate
        {
            get { return triggerOutputSampleRate; }
            set { triggerOutputSampleRate = value; RaisePropertyChanged(() => TriggerOutputSampleRate); }
        }
        /// <summary>
        /// 样本采样速率
        /// </summary>
        public double InputSampleRate
        {
            get { return inputSampleRate; }
            set { inputSampleRate = value; RaisePropertyChanged(() => InputSampleRate); }
        }
        /// <summary>
        /// 单次往返采集的样本数
        /// </summary>
        public int InputSampleCountPerRoundTrip
        {
            get { return inputSampleCountPerRoundTrip; }
            set { inputSampleCountPerRoundTrip = value; RaisePropertyChanged(() => InputSampleCountPerRoundTrip); }
        }
        /// <summary>
        /// 单帧的往返次数
        /// </summary>
        public int InputRoundTripCountPerFrame
        {
            get { return inputRoundTripCountPerFrame; }
            set { inputRoundTripCountPerFrame = value; RaisePropertyChanged(() => InputRoundTripCountPerFrame); }
        }
        /// <summary>
        /// 单帧采集的样本数
        /// </summary>
        public int InputSampleCountPerFrame
        {
            get { return inputSampleCountPerFrame; }
            set { inputSampleCountPerFrame = value; RaisePropertyChanged(() => InputSampleCountPerFrame); }
        }
        /// <summary>
        /// 单像素采集的样本数
        /// </summary>
        public int InputSampleCountPerPixel
        {
            get { return inputSampleCountPerPixel; }
            set { inputSampleCountPerPixel = value; RaisePropertyChanged(() => InputSampleCountPerPixel); }
        }
        /// <summary>
        /// 单次采集的样本数
        /// </summary>
        public int InputSampleCountPerAcquisition
        {
            get { return inputSampleCountPerAcquisition; }
            set { inputSampleCountPerAcquisition = value; RaisePropertyChanged(() => InputSampleCountPerAcquisition); }
        }
        /// <summary>
        /// 单次采集的像素数
        /// </summary>
        public int InputPixelCountPerAcquisition
        {
            get { return inputPixelCountPerAcquisition; }
            set { inputPixelCountPerAcquisition = value; RaisePropertyChanged(() => InputPixelCountPerAcquisition); }
        }
        /// <summary>
        /// 单次采集的往返次数
        /// </summary>
        public int InputRoundTripCountPerAcquisition
        {
            get { return inputRoundTripCountPerAcquisition; }
            set { inputRoundTripCountPerAcquisition = value; RaisePropertyChanged(() => InputRoundTripCountPerAcquisition); }
        }
        /// <summary>
        /// 单帧包含的采集次数
        /// </summary>
        public int InputAcquisitionCountPerFrame
        {
            get { return inputAcquisitionCountPerFrame; }
            set { inputAcquisitionCountPerFrame = value; RaisePropertyChanged(() => InputAcquisitionCountPerFrame); }
        }
        /// <summary>
        /// 每行采集的样本数
        /// </summary>
        public int InputSampleCountPerRow
        {
            get { return inputSampleCountPerRow; }
            set { inputSampleCountPerRow = value; RaisePropertyChanged(() => InputSampleCountPerRow); }
        }
        /// <summary>
        /// 每行采集的像素数
        /// </summary>
        public int InputPixelCountPerRow
        {
            get { return inputPixelCountPerRow; }
            set { inputPixelCountPerRow = value; RaisePropertyChanged(() => InputPixelCountPerRow); }
        }
        /// <summary>
        /// 帧率
        /// </summary>
        public double FPS
        {
            get { return fps; }
            set { fps = value; RaisePropertyChanged(() => FPS); }
        }
        /// <summary>
        /// 帧时间
        /// </summary>
        public double FrameTime
        {
            get { return frameTime; }
            set { frameTime = value; RaisePropertyChanged(() => FrameTime); }
        }

        private double[] triggerTimeValues;
        private double[] timeValues;
        private double[] xGalvoValues;
        private double[] yGalvoValues;
        private double[] y2GalvoValues;
        private byte[] triggerVlaues;

        public double[] TimeValues
        {
            get { return timeValues; }
            set { timeValues = value; RaisePropertyChanged(() => TimeValues); }
        }

        public double[] TriggerTimeValues
        {
            get { return triggerTimeValues; }
            set { triggerTimeValues = value; RaisePropertyChanged(() => TriggerTimeValues); }
        }

        public double[] XGalvoValues
        {
            get { return xGalvoValues; }
            set { xGalvoValues = value; RaisePropertyChanged(() => XGalvoValues); }
        }

        public double[] YGalvoValues
        {
            get { return yGalvoValues; }
            set { yGalvoValues = value; RaisePropertyChanged(() => YGalvoValues); }
        }

        public double[] Y2GalvoValues
        {
            get { return y2GalvoValues; }
            set { y2GalvoValues = value; RaisePropertyChanged(() => Y2GalvoValues); }
        }

        public byte[] TriggerValues
        {
            get { return triggerVlaues; }
            set { triggerVlaues = value; RaisePropertyChanged(() => TriggerValues); }
        }

        public Scheduler Engine
        {
            get { return mScheduler; }
        }

        public ScanParasViewModel()
        {
            mScheduler = Scheduler.CreateInstance();
            UpdateVariables();
            // 注册事件
            mScheduler.ScanAreaChangedEvent += ScanAreaChangedEventHandler;
            mScheduler.FullScanAreaChangedEvent += ScanAreaChangedEventHandler;
            mScheduler.ScanHeadChangedEvent += ScanHeadChangedEventHandler;
            mScheduler.ScanDirectionChangedEvent += ScanDirectionChangedEventHandler;
            mScheduler.LineSkipChangedEvent += LineSkipChangedEventHandler;
            mScheduler.LineSkipStatusChangedEvent += LineSkipStatusChangedEventHandler;
            mScheduler.ScanPixelChangedEvent += ScanPixelChangedEventHandler;
            mScheduler.ScanPixelDwellChangedEvent += ScanPixelDwellChangedEventHandler;
            mScheduler.ChannelActivateChangedEvent += ChannelActivateChangedEventHandler;
        }

        private int ChannelActivateChangedEventHandler(Engine.Attribute.ScanChannel channel)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int ScanPixelDwellChangedEventHandler(Engine.Attribute.ScanPixelDwell scanPixelDwell)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int ScanPixelChangedEventHandler(Engine.Attribute.ScanPixel scanPixel)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int LineSkipStatusChangedEventHandler(bool status)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int LineSkipChangedEventHandler(Engine.Attribute.ScanLineSkip lineSkip)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int ScanDirectionChangedEventHandler(Engine.Attribute.ScanDirection scanDirection)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int ScanHeadChangedEventHandler(Engine.Attribute.ScanHead scanHead)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private int ScanAreaChangedEventHandler(Engine.Attribute.ScanArea scanArea)
        {
            UpdateVariables();
            return ApiCode.Success;
        }

        private void UpdateVariables()
        {
            OutputSampleCountPerFrame = mScheduler.Sequence.OutputSampleCountPerFrame;
            OutputRoundTripCountPerFrame = mScheduler.Sequence.OutputRoundTripCountPerFrame;
            OutputSampleCountPerRoundTrip = mScheduler.Sequence.OutputSampleCountPerRoundTrip;
            OutputSampleRate = mScheduler.Sequence.OutputSampleRate;
            TriggerOutputSampleRate = mScheduler.Sequence.TriggerOutputSampleRate;
            InputSampleRate = mScheduler.Sequence.InputSampleRate;
            InputSampleCountPerRoundTrip = mScheduler.Sequence.InputSampleCountPerRoundTrip;
            InputRoundTripCountPerFrame = mScheduler.Sequence.InputRoundTripCountPerFrame;
            InputSampleCountPerFrame = mScheduler.Sequence.InputSampleCountPerFrame;
            InputSampleCountPerPixel = mScheduler.Sequence.InputSampleCountPerPixel;
            InputSampleCountPerAcquisition = mScheduler.Sequence.InputSampleCountPerAcquisition;
            InputPixelCountPerAcquisition = mScheduler.Sequence.InputPixelCountPerAcquisition;
            InputRoundTripCountPerAcquisition = mScheduler.Sequence.InputRoundTripCountPerAcquisition;
            InputAcquisitionCountPerFrame = mScheduler.Sequence.InputAcquisitionCountPerFrame;
            InputSampleCountPerRow = mScheduler.Sequence.InputSampleCountPerRow;
            InputPixelCountPerRow = mScheduler.Sequence.InputPixelCountPerRow;
            FPS = mScheduler.Sequence.FPS;
            FrameTime = mScheduler.Sequence.FrameTime;
        }

    }
}
