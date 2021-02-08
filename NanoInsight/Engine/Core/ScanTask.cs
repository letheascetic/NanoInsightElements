using log4net;
using NanoInsight.Engine.Data;
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
        private readonly Config mConfig;
        private readonly ScanSequence mSequence;
        private int mTaskId;
        private string mTaskName;
        private ScanInfo mScanInfo;
        private ScanData mScanData;

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

        public ScanTask(int taskId, string taskName)
        {
            mConfig = Config.GetConfig();
            mSequence = ScanSequence.CreateInstance();
            TaskId = taskId;
            TaskName = taskName;
        }

        /// <summary>
        /// 启动扫描
        /// </summary>
        public void Start()
        {
            bool[] statusOfChannels = mConfig.ScanChannels.Select(p => p.Activated).ToArray();

            ScanInfo = new ScanInfo(mSequence.InputAcquisitionCountPerFrame);
            ScanData = new ScanData(mConfig.SelectedScanPixel.Data, mConfig.SelectedScanPixel.Data, mSequence.InputAcquisitionCountPerFrame,
                mConfig.GetChannelNum(), 1, statusOfChannels);
        }

        /// <summary>
        /// 停止扫描
        /// </summary>
        public void Stop()
        {

        }
    }
}
