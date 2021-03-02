using C1.Win.C1Ribbon;
using C1.Win.C1Themes;
using log4net;
using NanoInsight.Engine.Core;
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
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }

        /// <summary>
        /// 应用主题
        /// </summary>
        public void ApplyTheme()
        {
            this.SuspendPainting();
            string themeName = Properties.Settings.Default.ThemeName;
            C1ThemeController.ApplyThemeToControlTree(this, C1ThemeController.GetThemeByName(themeName, false));
            this.ResumePainting();
        }

        private void Initialize()
        {
            mScanParasVM = new ScanParasViewModel();
        }

        private void RegisterEvents()
        {
            // 注册事件
            mScanParasVM.Engine.ScanAreaChangedEvent += ScanAreaChangedEventHandler;
            mScanParasVM.Engine.FullScanAreaChangedEvent += ScanAreaChangedEventHandler;
            mScanParasVM.Engine.ScanHeadChangedEvent += ScanHeadChangedEventHandler;
            mScanParasVM.Engine.ScanDirectionChangedEvent += ScanDirectionChangedEventHandler;
            mScanParasVM.Engine.LineSkipChangedEvent += LineSkipChangedEventHandler;
            mScanParasVM.Engine.LineSkipStatusChangedEvent += LineSkipStatusChangedEventHandler;
            mScanParasVM.Engine.ScanPixelChangedEvent += ScanPixelChangedEventHandler;
            mScanParasVM.Engine.ScanPixelDwellChangedEvent += ScanPixelDwellChangedEventHandler;
            mScanParasVM.Engine.ChannelActivateChangedEvent += ChannelActivateChangedEventHandler;
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
            ApplyTheme();
        }

        private int ChannelActivateChangedEventHandler(Engine.Attribute.ScanChannel channel)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int ScanPixelDwellChangedEventHandler(Engine.Attribute.ScanPixelDwell scanPixelDwell)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int ScanPixelChangedEventHandler(Engine.Attribute.ScanPixel scanPixel)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int LineSkipStatusChangedEventHandler(bool status)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int LineSkipChangedEventHandler(Engine.Attribute.ScanLineSkip lineSkip)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int ScanDirectionChangedEventHandler(Engine.Attribute.ScanDirection scanDirection)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int ScanHeadChangedEventHandler(Engine.Attribute.ScanHead scanHead)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

        private int ScanAreaChangedEventHandler(Engine.Attribute.ScanArea scanArea)
        {
            mScanParasVM.UpdateVariables();
            mScanParasVM.UpdateChartValues();
            chart.Series[0].Points.DataBindXY(mScanParasVM.TimeValues, mScanParasVM.XGalvoValues);
            chart.Series[1].Points.DataBindXY(mScanParasVM.TriggerTimeValues, mScanParasVM.TriggerValues);
            chart.Update();
            return ApiCode.Success;
        }

    }
}
