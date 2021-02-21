using Emgu.CV;
using GalaSoft.MvvmLight;
using log4net;
using NanoInsight.Engine.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Viewer.ViewModel
{
    public class ScanImageViewModel : ViewModelBase
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private readonly Scheduler mScheduler;
        private ScanTask mScanTask;

        private Mat mScanImageAll;
        private Mat mScanImage405;
        private Mat mScanImage488;
        private Mat mScanImage561;
        private Mat mScanImage640;

        private ScanTask Task
        {
            get { return mScanTask; }
            set { mScanTask = value; RaisePropertyChanged(() => Task); }
        }

        public Scheduler Engine
        {
            get { return mScheduler; }
        }

        public Mat ScanImageAll
        {
            get { return mScanImageAll; }
            set { mScanImageAll = value; RaisePropertyChanged(() => ScanImageAll); }
        }

        public Mat ScanImage405
        {
            get { return mScanImage405; }
            set { mScanImage405 = value; RaisePropertyChanged(() => ScanImage405); }
        }

        public Mat ScanImage488
        {
            get { return mScanImage488; }
            set { mScanImage488 = value; RaisePropertyChanged(() => ScanImage488); }
        }

        public Mat ScanImage561
        {
            get { return mScanImage561; }
            set { mScanImage561 = value; RaisePropertyChanged(() => ScanImage561); }
        }

        public Mat ScanImage640
        {
            get { return mScanImage640; }
            set { mScanImage640 = value; RaisePropertyChanged(() => ScanImage640); }
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanImageViewModel(ScanTask scanTask)
        {
            mScanTask = scanTask;
            mScheduler = Scheduler.CreateInstance();
        }
    }
}
