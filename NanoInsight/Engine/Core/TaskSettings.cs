using NanoInsight.Engine.Attribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoInsight.Engine.Core
{
    public class TaskSettings
    {
        ///////////////////////////////////////////////////////////////////////////////////////////

        public ScanAcquisition SelectedScanAcquisition { get; }

        public ScanHead SelectedScanHead { get; }

        public ScanDirection SelectedScanDirection { get; }

        public ScanMode SelectedScanMode { get; }

        public ScanPixel SelectedScanPixel { get; }

        public float ScanPixelSize { get; }

        public bool FastModeEnabled { get; }

        public ScanPixelDwell SelectedScanPixelDwell { get; }

        public bool ScanLineSkipEnabled { get; }

        public ScanLineSkip SelectedScanLineSkip { get; }

        public ScanChannel ScanChannel405 { get; set; }

        public ScanChannel ScanChannel488 { get; set; }

        public ScanChannel ScanChannel561 { get; set; }

        public ScanChannel ScanChannel640 { get; set; }

        public ScanChannel[] ScanChannels { get; set; }

        public ScanAreaType SelectedScanAreaType { get; }

        public ScanArea SelectedScanArea { get; }

        public ScanArea FullScanArea { get; }

        ///////////////////////////////////////////////////////////////////////////////////////////


        public TaskSettings()
        {
            Config mConfig = Config.GetConfig();
            ScanSequence mSequence = ScanSequence.CreateInstance();

            SelectedScanAcquisition = mConfig.SelectedScanAcquisition;

        }

    }
}
