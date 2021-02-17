using C1.Win.C1Ribbon;
using log4net;
using NanoInsight.Viewer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NanoInsight.Viewer.View
{
    public partial class ScanParasView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private ScanParasViewModel mScanParasVM;

        public ScanParasView()
        {
            InitializeComponent();
        }

        private void Initialize()
        {
            mScanParasVM = new ScanParasViewModel();
        }

        private void RegisterEvents()
        {

        }

        private void SetDataBindings()
        {
            tbxOutputSampleRate.DataBindings.Add("Text", mScanParasVM, "OutputSampleRate");
            tbxOutputSampleCountPerRoundTrip.DataBindings.Add("Text", mScanParasVM, "OutputSampleCountPerRoundTrip");
            tbxOutputRoundTripPerFrame.DataBindings.Add("Text", mScanParasVM, "OutputRoundTripCountPerFrame");
            tbxOutputSampleCountPerFrame.DataBindings.Add("Text", mScanParasVM, "OutputSampleCountPerFrame");

            tbxInputSampleRate.DataBindings.Add("Text", mScanParasVM, "InputSampleRate");
            tbxInputSampleCountPerRoundTrip.DataBindings.Add("Text", mScanParasVM, "InputSampleCountPerRoundTrip");
            tbxInputRoundTripCountPerFrame.DataBindings.Add("Text", mScanParasVM, "InputRoundTripCountPerFrame");
            tbxInputSampleCountPerFrame.DataBindings.Add("Text", mScanParasVM, "InputSampleCountPerFrame");
            tbxInputSampleCountPerPixel.DataBindings.Add("Text", mScanParasVM, "InputSampleCountPerPixel");
            tbxInputSampleCountPerAcquisition.DataBindings.Add("Text", mScanParasVM, "InputSampleCountPerAcquisition");
            tbxInputPixelCountPerAcquisition.DataBindings.Add("Text", mScanParasVM, "InputPixelCountPerAcquisition");
            tbxInputRoundTripCountPerAcquisition.DataBindings.Add("Text", mScanParasVM, "InputRoundTripCountPerAcquisition");
            tbxInputAcquisitionCountPerFrame.DataBindings.Add("Text", mScanParasVM, "InputAcquisitionCountPerFrame");

            tbxFPS.DataBindings.Add("Text", mScanParasVM, "FPS");
            tbxFrameTime.DataBindings.Add("Text", mScanParasVM, "FrameTime");
        }

        private void ScanParasViewLoad(object sender, EventArgs e)
        {
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }
    }
}
