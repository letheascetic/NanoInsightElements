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
        }

    }
}
