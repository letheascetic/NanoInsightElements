using log4net;
using NanoInsight.Engine.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Data
{
    /// <summary>
    /// 扫描信息
    /// </summary>
    public class ScanInfo
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private DateTime startTime;
        private double timeSpan;
        private double frameTime;
        private double fps;
        private long[] currentFrame;
        private int[] currentBank;
        private int numOfBank;
        private long[] acquisitionCount;

        /// <summary>
        /// 扫描开始时间
        /// </summary>
        public DateTime StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }
        /// <summary>
        /// 扫描时长
        /// </summary>
        public double TimeSpan
        {
            get { return timeSpan; }
            set { timeSpan = value; }
        }
        /// <summary>
        /// 扫描帧率
        /// </summary>
        public double FPS
        {
            get { return fps; }
            set { fps = value; }
        }
        /// <summary>
        /// 扫描帧时间
        /// </summary>
        public double FrameTime
        {
            get { return frameTime; }
            set { frameTime = value; }
        }
        /// <summary>
        /// 当前帧
        /// </summary>
        public long[] CurrentFrame
        {
            get { return currentFrame; }
            set { currentFrame = value; }
        }
        /// <summary>
        /// 当前Bank
        /// </summary>
        public int[] CurrentBank
        {
            get { return currentBank; }
            set { currentBank = value; }
        }
        /// <summary>
        /// 单帧中包含的Bank数量
        /// </summary>
        public int NumOfBank
        {
            get { return numOfBank; }
            set { numOfBank = value; }
        }
        /// <summary>
        /// 采集次数
        /// </summary>
        public long[] AcquisitionCount
        {
            get { return acquisitionCount; }
            set { acquisitionCount = value; }
        }

        public ScanInfo(int numOfBank)
        {
            StartTime = DateTime.Now;
            TimeSpan = 0.0;
            FPS = 0.0;
            FrameTime = 0.0;
            CurrentFrame = new long[] { -1, -1, -1, -1 };
            CurrentBank = new int[] { -1, -1, -1, -1 };
            NumOfBank = numOfBank;
            AcquisitionCount = new long[] { -1, -1, -1, -1 };
        }

        public void UpdateScanInfo(PmtSampleData sampleData)
        {
            // AcquisitionCount = sampleData.AcquisitionCount;
            for (int i = 0; i < AcquisitionCount.Length; i++)
            {
                AcquisitionCount[i] = sampleData.AcquisitionCount[i];
                if (AcquisitionCount[i] >= 0)
                {
                    CurrentBank[i] = (int)(AcquisitionCount[i] % NumOfBank);
                    CurrentFrame[i] = AcquisitionCount[i] / NumOfBank;
                }
            }

            int bank = CurrentBank.Where(p => p >= 0).First();
            long frame = CurrentFrame.Where(p => p >= 0).First();
            if (bank == NumOfBank - 1)
            {
                TimeSpan = (DateTime.Now - StartTime).TotalSeconds;
                FrameTime = TimeSpan / (frame + 1);
                FPS = 1.0 / FrameTime;
                Logger.Info(string.Format("TimeSpan[{0}] Frame[{1}] Bank[{2}] FPS[{3}] FrameTime[{4}].", TimeSpan, frame, bank, FPS, FrameTime));
            }
        }

        public void UpdateScanInfo(ApdSampleData sampleData)
        {
            AcquisitionCount[sampleData.ChannelIndex] = sampleData.AcquisitionCount;
            CurrentBank[sampleData.ChannelIndex] = (int)(AcquisitionCount[sampleData.ChannelIndex] % NumOfBank);
            CurrentFrame[sampleData.ChannelIndex] = AcquisitionCount[sampleData.ChannelIndex] / NumOfBank;

            if (CurrentBank[sampleData.ChannelIndex] == NumOfBank - 1)
            {
                TimeSpan = (DateTime.Now - StartTime).TotalSeconds;
                FrameTime = TimeSpan / (CurrentFrame[sampleData.ChannelIndex] + 1);
                FPS = 1.0 / FrameTime;
                Logger.Info(string.Format("TimeSpan[{0}] Frame[{1}] Bank[{2}] FPS[{3}] FrameTime[{4}].", TimeSpan, CurrentFrame[sampleData.ChannelIndex], CurrentBank[sampleData.ChannelIndex], FPS, FrameTime));
            }
        }

    }
}
