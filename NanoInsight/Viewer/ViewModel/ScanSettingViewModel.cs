using GalaSoft.MvvmLight;
using NanoInsight.Engine.Core;
using NanoInsight.Viewer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class ScanSettingViewModel : ViewModelBase
    {
        private Scheduler mScheduler;

        ///////////////////////////////////////////////////////////////////////////////////////////
        private ScanAcquisitionModel scanLiveMode;
        private ScanAcquisitionModel scanCaptureMode;

        /// <summary>
        /// 实时模式
        /// </summary>
        public ScanAcquisitionModel ScanLiveMode
        {
            get { return scanLiveMode; }
            set { scanLiveMode = value; RaisePropertyChanged(() => ScanLiveMode); }
        }
        /// <summary>
        /// 捕捉模式
        /// </summary>
        public ScanAcquisitionModel ScanCaptureMode
        {
            get { return scanCaptureMode; }
            set { scanCaptureMode = value; RaisePropertyChanged(() => ScanCaptureMode); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////
        public ScanSettingViewModel()
        {
            mScheduler = Scheduler.CreateInstance();
            ScanLiveMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanLiveMode);
            ScanCaptureMode = new ScanAcquisitionModel(mScheduler.Configuration.ScanCaptureMode);
        }
    }
}
