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

        private PmtChannelModel pmtChannel405;
        private PmtChannelModel pmtChannel488;
        private PmtChannelModel pmtChannel561;
        private PmtChannelModel pmtChannel640;

        private ApdChannelModel apdChannel405;
        private ApdChannelModel apdChannel488;
        private ApdChannelModel apdChannel561;
        private ApdChannelModel apdChannel640;

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

        public PmtChannelModel PmtChannel405
        {
            get { return pmtChannel405; }
            set { pmtChannel405 = value; RaisePropertyChanged(() => PmtChannel405); }
        }
        public PmtChannelModel PmtChannel488
        {
            get { return pmtChannel488; }
            set { pmtChannel488 = value; RaisePropertyChanged(() => PmtChannel488); }
        }
        public PmtChannelModel PmtChannel561
        {
            get { return pmtChannel561; }
            set { pmtChannel561 = value; RaisePropertyChanged(() => PmtChannel561); }
        }
        public PmtChannelModel PmtChannel640
        {
            get { return pmtChannel640; }
            set { pmtChannel640 = value; RaisePropertyChanged(() => PmtChannel640); }
        }

        public ApdChannelModel ApdChannel405
        {
            get { return apdChannel405; }
            set { apdChannel405 = value; RaisePropertyChanged(() => ApdChannel405); }
        }
        public ApdChannelModel ApdChannel488
        {
            get { return apdChannel488; }
            set { apdChannel488 = value; RaisePropertyChanged(() => ApdChannel488); }
        }
        public ApdChannelModel ApdChannel561
        {
            get { return apdChannel561; }
            set { apdChannel561 = value; RaisePropertyChanged(() => ApdChannel561); }
        }
        public ApdChannelModel ApdChannel640
        {
            get { return apdChannel640; }
            set { apdChannel640 = value; RaisePropertyChanged(() => ApdChannel640); }
        }

        public DetectorPropertyModel(DetectorProperty detectorProperty)
        {
            Apd = new DetectorTypeModel(detectorProperty.Apd);
            Pmt = new DetectorTypeModel(detectorProperty.Pmt);
            StartTrigger = detectorProperty.StartTrigger;
            TriggerSignal = detectorProperty.TriggerSignal;
            TriggerReceive = detectorProperty.TriggerReceive;

            PmtChannel405 = new PmtChannelModel(detectorProperty.PmtChannel405);
            PmtChannel488 = new PmtChannelModel(detectorProperty.PmtChannel488);
            PmtChannel561 = new PmtChannelModel(detectorProperty.PmtChannel561);
            PmtChannel640 = new PmtChannelModel(detectorProperty.PmtChannel640);

            ApdChannel405 = new ApdChannelModel(detectorProperty.ApdChannel405);
            ApdChannel488 = new ApdChannelModel(detectorProperty.ApdChannel488);
            ApdChannel561 = new ApdChannelModel(detectorProperty.ApdChannel561);
            ApdChannel640 = new ApdChannelModel(detectorProperty.ApdChannel640);
        }

        public PmtChannelModel FindPmtChannel(int id)
        {
            switch (id)
            {
                case 0:
                    return PmtChannel405;
                case 1:
                    return PmtChannel488;
                case 2:
                    return PmtChannel561;
                case 3:
                    return PmtChannel640;
                default:
                    return null;
            }
        }

        public ApdChannelModel FindApdChannel(int id)
        {
            switch (id)
            {
                case 0:
                    return ApdChannel405;
                case 1:
                    return ApdChannel488;
                case 2:
                    return ApdChannel561;
                case 3:
                    return ApdChannel640;
                default:
                    return null;
            }
        }

    }
}
