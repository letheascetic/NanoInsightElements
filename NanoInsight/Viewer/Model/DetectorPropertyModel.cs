using GalaSoft.MvvmLight;
using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.Model
{
    /// <summary>
    /// 探测器类型
    /// </summary>
    public class DetectorTypeModel : ScanPropertyBaseModel
    {
        public DetectorTypeModel(DetectorType detectorType)
        {
            ID = detectorType.ID;
            IsEnabled = detectorType.IsEnabled;
            Text = detectorType.Text;
        }
    }

    public class PmtChannelModel : ObservableObject
    {
        private int id;
        private string aiChannel;

        public int ID
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(() => ID); }
        }

        public string AiChannel
        {
            get { return aiChannel; }
            set { aiChannel = value; RaisePropertyChanged(() => AiChannel); }
        }

        public PmtChannelModel(PmtChannel pmtChannel)
        {
            ID = pmtChannel.ID;
            AiChannel = pmtChannel.AiChannel;
        }

        public PmtChannelModel(int id, string aiChannel)
        {
            ID = id;
            AiChannel = aiChannel;
        }

    }

    public class ApdChannelModel : ObservableObject
    {
        private int id;
        private string ciSource;
        private string ciChannel;

        public int ID
        {
            get { return id; }
            set { id = value; RaisePropertyChanged(() => ID); }
        }

        public string CiSource
        {
            get { return ciSource; }
            set { ciSource = value; RaisePropertyChanged(() => CiSource); }
        }

        public string CiChannel
        {
            get { return ciChannel; }
            set { ciChannel = value; RaisePropertyChanged(() => CiChannel); }
        }

        public ApdChannelModel(ApdChannel apdChannel)
        {
            ID = apdChannel.ID;
            CiSource = apdChannel.CiSource;
            CiChannel = apdChannel.CiChannel;
        }
    }

    public class DetectorPropertyModel : ObservableObject
    {
        private DetectorTypeModel apd;
        private DetectorTypeModel pmt;

        private string startTrigger;
        private string triggerSignal;
        private string triggerReceive;

        /// <summary>
        /// APD
        /// </summary>
        public DetectorTypeModel Apd
        {
            get { return apd; }
            set { apd = value; RaisePropertyChanged(() => Apd); }
        }
        /// <summary>
        /// PMT
        /// </summary>
        public DetectorTypeModel Pmt
        {
            get { return pmt; }
            set { pmt = value; RaisePropertyChanged(() => Pmt); }
        }
        /// <summary>
        /// 启动同步源
        /// </summary>
        public string StartTrigger
        {
            get { return startTrigger; }
            set { startTrigger = value; RaisePropertyChanged(() => StartTrigger); }
        }
        /// <summary>
        /// 触发信号[输出端]
        /// </summary>
        public string TriggerSignal
        {
            get { return triggerSignal; }
            set { triggerSignal = value; RaisePropertyChanged(() => TriggerSignal); }
        }
        /// <summary>
        /// 触发接收端
        /// </summary>
        public string TriggerReceive
        {
            get { return triggerReceive; }
            set { triggerReceive = value; RaisePropertyChanged(() => TriggerReceive); }
        }

    }
}
