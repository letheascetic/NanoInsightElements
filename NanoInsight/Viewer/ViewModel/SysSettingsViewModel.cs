using GalaSoft.MvvmLight;
using log4net;
using NanoInsight.Engine.Core;
using NanoInsight.Engine.Device;
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
        }

    }
}
