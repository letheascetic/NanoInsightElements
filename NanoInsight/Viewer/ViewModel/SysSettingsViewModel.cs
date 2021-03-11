using GalaSoft.MvvmLight;
using log4net;
using NanoInsight.Engine.Core;
using NanoInsight.Engine.Device;
using NanoInsight.Viewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class SysSettingsViewModel : ViewModelBase
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private readonly Scheduler mScheduler;

        public Scheduler Engine
        {
            get { return mScheduler; }
        }

        private string[] mXGalvoChannels;
        private string[] mYGalvoChannels;
        private string[] mY2GalvoChannels;

        public string[] XGalvoAoChannels
        {
            get { return mXGalvoChannels; }
            set { mXGalvoChannels = value; RaisePropertyChanged(() => XGalvoAoChannels); }
        }
        public string[] YGalvoAoChannels
        {
            get { return mYGalvoChannels; }
            set { mYGalvoChannels = value; RaisePropertyChanged(() => YGalvoAoChannels); }
        }
        public string[] Y2GalvoAoChannels
        {
            get { return mY2GalvoChannels; }
            set { mY2GalvoChannels = value; RaisePropertyChanged(() => Y2GalvoAoChannels); }
        }

        private string[][] mAiChannels;
        private string[][] mCiSources;
        private string[][] mCiChannels;
        private string[] mTriggerSignals;
        private string[] mTriggerReceivers;
        private string[] mStartTriggers;

        private GalvoPropertyModel mGalvoProperty;
        private DetectorPropertyModel mDetector;
        private ScanAreaModel mFullScanArea;

        public string[][] AiChannels
        {
            get { return mAiChannels; }
            set { mAiChannels = value; RaisePropertyChanged(() => AiChannels); }
        }

        public string[][] CiSources
        {
            get { return mCiSources; }
            set { mCiSources = value; RaisePropertyChanged(() => CiSources); }
        }

        public string[][] CiChannels
        {
            get { return mCiChannels; }
            set { mCiChannels = value; RaisePropertyChanged(() => CiChannels); }
        }

        public string[] TriggerSignals
        {
            get { return mTriggerSignals; }
            set { mTriggerSignals = value; RaisePropertyChanged(() => TriggerSignals); }
        }

        public string[] TriggerReceivers
        {
            get { return mTriggerReceivers; }
            set { mTriggerReceivers = value; RaisePropertyChanged(() => TriggerReceivers); }
        }

        public string[] StartTriggers
        {
            get { return mStartTriggers; }
            set { mStartTriggers = value; RaisePropertyChanged(() => StartTriggers); }
        }

        public GalvoPropertyModel GalvoProperty
        {
            get { return mGalvoProperty; }
            set { mGalvoProperty = value; RaisePropertyChanged(() => GalvoProperty); }
        }

        public DetectorPropertyModel Detector
        {
            get { return mDetector; }
            set { mDetector = value; RaisePropertyChanged(() => Detector); }
        }
        
        public ScanAreaModel FullScanArea
        {
            get { return mFullScanArea; }
            set { mFullScanArea = value; RaisePropertyChanged(() => FullScanArea); }
        }

        public SysSettingsViewModel()
        {
            mScheduler = Scheduler.CreateInstance();

            XGalvoAoChannels = NiDaq.GetAoChannels();
            YGalvoAoChannels = NiDaq.GetAoChannels();
            Y2GalvoAoChannels = NiDaq.GetAoChannels();

            AiChannels = new string[4][]
            {
                NiDaq.GetAiChannels(),
                NiDaq.GetAiChannels(),
                NiDaq.GetAiChannels(),
                NiDaq.GetAiChannels()
            };
            CiSources = new string[4][]
            {
                NiDaq.GetCiChannels(),
                NiDaq.GetCiChannels(),
                NiDaq.GetCiChannels(),
                NiDaq.GetCiChannels()
            };
            CiChannels = new string[4][]
            {
                NiDaq.GetPFIs(),
                NiDaq.GetPFIs(),
                NiDaq.GetPFIs(),
                NiDaq.GetPFIs()
            };
            StartTriggers = NiDaq.GetStartSyncSignals();
            TriggerSignals = NiDaq.GetDoLines();
            TriggerReceivers = NiDaq.GetPFIs();

            GalvoProperty = new GalvoPropertyModel(mScheduler.Configuration.GalvoAttr);
            Detector = new DetectorPropertyModel(mScheduler.Configuration.Detector);
            FullScanArea = new ScanAreaModel(mScheduler.Configuration.FullScanArea);
        }

        public int SetDetectorMode(int id)
        {
            int code = mScheduler.SetDetectorMode(id);
            Detector.Pmt.IsEnabled = mScheduler.Configuration.Detector.Pmt.IsEnabled;
            Detector.Apd.IsEnabled = mScheduler.Configuration.Detector.Apd.IsEnabled;
            return code;
        }

        public int SetPmtChannel(int id, string pmtChannel)
        {
            int code = mScheduler.SetPmtChannel(id, pmtChannel);
            PmtChannelModel channel = Detector.FindPmtChannel(id);
            channel.AiChannel = mScheduler.Configuration.Detector.FindPmtChannel(id).AiChannel;
            return code;
        }

        public int SetApdSource(int id, string ciSource)
        {
            int code = mScheduler.SetApdSource(id, ciSource);
            ApdChannelModel channel = Detector.FindApdChannel(id);
            channel.CiSource = mScheduler.Configuration.Detector.FindApdChannel(id).CiSource;
            return code;
        }

        public int SetApdChannel(int id, string ciChannel)
        {
            int code = mScheduler.SetApdChannel(id, ciChannel);
            ApdChannelModel channel = Detector.FindApdChannel(id);
            channel.CiChannel = mScheduler.Configuration.Detector.FindApdChannel(id).CiChannel;
            return code;
        }


    }
}
