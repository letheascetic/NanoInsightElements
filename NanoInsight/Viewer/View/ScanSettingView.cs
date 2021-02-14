using C1.Win.C1InputPanel;
using C1.Win.C1Ribbon;
using log4net;
using NanoInsight.Viewer.ViewModel;
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
    public partial class ScanSettingView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private ScanSettingsViewModel mScanSettingsVM;

        private InputButton[] mPixelDwellButtons;
        private InputButton[] mScanPixelButtons;
        private InputTrackBar[] mChannelGainBars;
        private InputTrackBar[] mChannelOffsetBars;
        private InputTrackBar[] mChannelPowerBars;
        private InputButton[] mChannelActivateButtons;

        public ScanSettingView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 初始化成员变量
        /// </summary>
        private void Initialize()
        {
            mScanSettingsVM = new ScanSettingsViewModel();

            mPixelDwellButtons = new InputButton[]
            {
                btnPixelDwell2,
                btnPixelDwell4,
                btnPixelDwell6,
                btnPixelDwell8,
                btnPixelDwell10,
                btnPixelDwell20,
                btnPixelDwell50,
                btnPixelDwell100
            };

            mScanPixelButtons = new InputButton[]
            {
                btnScanPixel64,
                btnScanPixel128,
                btnScanPixel256,
                btnScanPixel512,
                btnScanPixel1024,
                btnScanPixel2048,
                btnScanPixel4096
            };

            mChannelGainBars = new InputTrackBar[]
            {
                tbar405HV,
                tbar488HV,
                tbar561HV,
                tbar640HV
            };

            mChannelOffsetBars = new InputTrackBar[]
            {
                tbar405Offset,
                tbar488Offset,
                tbar561Offset,
                tbar640Offset
            };

            mChannelPowerBars = new InputTrackBar[]
            {
                tbar405Power,
                tbar488Power,
                tbar561Power,
                tbar640Power
            };

            mChannelActivateButtons = new InputButton[]
            {
                btn405Power,
                btn488Power,
                btn561Power,
                btn640Power
            };
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {
            //this.rbtnTwoScanners.CheckedChanged += ScannerHeadChanged;
            //this.rbtnGalvano.CheckedChanged += ScanModeChanged;

            //for (int i = 0; i < mPixelDwellButtons.Length; i++)
            //{
            //    mPixelDwellButtons[i].Tag = mScanSettingsVM.Engine.Config.ScanPixelDwellList[i];
            //    mPixelDwellButtons[i].Click += ScanPixelDwellChanged;
            //}

            //nbScanPixelCalibration.ValueChanged += ScanPixelCalibrationChanged;
            //nbScanPixelScale.ValueChanged += ScanPixelScaleChanged;

            //for (int i = 0; i < mScanPixelButtons.Length; i++)
            //{
            //    mScanPixelButtons[i].Tag = mScanSettingsVM.Engine.Config.ScanPixelList[i];
            //    mScanPixelButtons[i].Click += ScanPixelChanged;
            //}

            //cbxLineSkip.SelectedIndexChanged += ScanLineSkipChanged;

            //cbxPinHoleSelect.SelectedIndexChanged += ScanPinHoleChanged;

            //for (int i = 0; i < mChannelGainBars.Length; i++)
            //{
            //    mChannelGainBars[i].Tag = i;
            //    mChannelGainBars[i].ValueChanged += ChannelGainChanged;
            //    mChannelOffsetBars[i].Tag = i;
            //    mChannelOffsetBars[i].ValueChanged += ChannelOffsetChanged;
            //    mChannelPowerBars[i].Tag = i;
            //    mChannelPowerBars[i].ValueChanged += ChannelPowerChanged;
            //    mChannelActivateButtons[i].Tag = i;
            //    mChannelActivateButtons[i].Click += ChannelActivateChanged;
            //}
        }

        /// <summary>
        /// 设置DataBindings
        /// </summary>
        private void SetDataBindings()
        {
            // 采集模式
            //this.btnLive.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanLiveMode, "Text");
            //this.btnLive.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanLiveMode, "IsEnabled");
            //this.btnCapture.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanCaptureMode, "Text");
            //this.btnCapture.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanCaptureMode, "IsEnabled");
            // 扫描头
            //this.rbtnTwoScanners.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScannerHeadTwoGalv, "Text");
            //this.rbtnTwoScanners.DataBindings.Add("Checked", mScanSettingsVM.Engine.Config.ScannerHeadTwoGalv, "IsEnabled");
            //this.rbtnThreeScanners.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScannerHeadThreeGalv, "Text");
            //this.rbtnThreeScanners.DataBindings.Add("Checked", mScanSettingsVM.Engine.Config.ScannerHeadThreeGalv, "IsEnabled");
            // 扫描模式
            //this.rbtnGalvano.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanModeGalavano, "Text");
            //this.rbtnGalvano.DataBindings.Add("Checked", mScanSettingsVM.Engine.Config.ScanModeGalavano, "IsEnabled");
            //this.rbtnResonant.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanModeResonant, "Text");
            //this.rbtnResonant.DataBindings.Add("Checked", mScanSettingsVM.Engine.Config.ScanModeResonant, "IsEnabled");
            // 扫描方向
            //this.btnUniDirection.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanUniDirection, "Text");
            //this.btnUniDirection.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanUniDirection, "IsEnabled");
            //this.btnBiDirection.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanBiDirection, "Text");
            //this.btnBiDirection.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanBiDirection, "IsEnabled");
            // 双向补偿
            //this.nbScanPixelCalibration.DataBindings.Add("Enabled", mScanSettingsVM.Engine.Config.ScanBiDirection, "IsEnabled");
            //this.nbScanPixelCalibration.DataBindings.Add("Maximum", mScanSettingsVM, "ScanPixelCalibrationMaximum");
            //this.nbScanPixelCalibration.DataBindings.Add("Value", mScanSettingsVM, "ScanPixelCalibration");
            //// 像素缩放
            //this.nbScanPixelScale.DataBindings.Add("Value", mScanSettingsVM, "ScanPixelScale");
            // 像素时间
            // 快速模式使能
            //this.rbtnFastMode.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config, "FastModeEnabled");
            //foreach (InputButton button in mPixelDwellButtons)
            //{
            //    ScanPixelDwellModel model = (ScanPixelDwellModel)button.Tag;
            //    button.DataBindings.Add("Text", model, "Text");
            //    button.DataBindings.Add("Pressed", model, "IsEnabled");
            //}
            // 扫描像素
            //foreach (InputButton button in mScanPixelButtons)
            //{
            //    ScanPixelModel model = (ScanPixelModel)button.Tag;
            //    button.DataBindings.Add("Text", model, "Text");
            //    button.DataBindings.Add("Pressed", model, "IsEnabled");
            //}
            // 帧率 & 帧时间
            //this.lbFPSValue.DataBindings.Add("Text", mScanSettingsVM.Engine.Sequence, "FPS", true, DataSourceUpdateMode.OnPropertyChanged, null, "0.000 fps");
            //this.lbFrameTimeValue.DataBindings.Add("Text", mScanSettingsVM.Engine.Sequence, "FrameTime", true, DataSourceUpdateMode.OnPropertyChanged, null, "0.000 sec");
            // 跳行扫描
            //this.chbxLineSkip.DataBindings.Add("Checked", mScanSettingsVM.Engine.Config, "ScanLineSkipEnabled");
            //this.cbxLineSkip.DataSource = mScanSettingsVM.Engine.Config.ScanLineSkipList;
            //this.cbxLineSkip.DisplayMember = "Text";
            //this.cbxLineSkip.ValueMember = "Data";
            //this.cbxLineSkip.SelectedItem = mScanSettingsVM.Engine.Config.SelectedScanLineSkip;
            // 扫描通道1 - 405nm
            //this.gh405.DataBindings.Add("BackColor", mScanSettingsVM.Engine.Config.ScanChannel405, "PseudoColor");
            //this.gh405.DataBindings.Add("Collapsed", mScanSettingsVM.Engine.Config.ScanChannel405, "Collapsed");
            //this.tbar405HV.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel405, "Gain");
            //this.tbx405HV.DataBindings.Add("Text", tbar405HV, "Value");
            //this.tbar405Offset.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel405, "Offset");
            //this.tbx405Offset.DataBindings.Add("Text", tbar405Offset, "Value");
            //this.tbar405Power.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel405, "LaserPower");
            //this.tbx405Power.DataBindings.Add("Text", tbar405Power, "Value");
            //this.btn405Power.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanChannel405, "Activated");
            // 扫描通道2 - 488nm
            //this.gh488.DataBindings.Add("BackColor", mScanSettingsVM.Engine.Config.ScanChannel488, "PseudoColor");
            //this.gh488.DataBindings.Add("Collapsed", mScanSettingsVM.Engine.Config.ScanChannel488, "Collapsed");
            //this.tbar488HV.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel488, "Gain");
            //this.tbx488HV.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel488, "Gain");
            //this.tbar488Offset.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel488, "Offset");
            //this.tbx488Offset.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel488, "Offset");
            //this.tbar488Power.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel488, "LaserPower");
            //this.tbx488Power.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel488, "LaserPower");
            //this.btn488Power.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanChannel488, "Activated");
            // 扫描通道3 - 561nm
            //this.gh561.DataBindings.Add("BackColor", mScanSettingsVM.Engine.Config.ScanChannel561, "PseudoColor");
            //this.gh561.DataBindings.Add("Collapsed", mScanSettingsVM.Engine.Config.ScanChannel561, "Collapsed");
            //this.tbar561HV.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel561, "Gain");
            //this.tbx561HV.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel561, "Gain");
            //this.tbar561Offset.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel561, "Offset");
            //this.tbx561Offset.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel561, "Offset");
            //this.tbar561Power.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel561, "LaserPower");
            //this.tbx561Power.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel561, "LaserPower");
            //this.btn561Power.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanChannel561, "Activated");
            // 扫描通道4 - 640nm
            //this.gh640.DataBindings.Add("BackColor", mScanSettingsVM.Engine.Config.ScanChannel640, "PseudoColor");
            //this.gh640.DataBindings.Add("Collapsed", mScanSettingsVM.Engine.Config.ScanChannel640, "Collapsed");
            //this.tbar640HV.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel640, "Gain");
            //this.tbx640HV.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel640, "Gain");
            //this.tbar640Offset.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel640, "Offset");
            //this.tbx640Offset.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel640, "Offset");
            //this.tbar640Power.DataBindings.Add("Value", mScanSettingsVM.Engine.Config.ScanChannel640, "LaserPower");
            //this.tbx640Power.DataBindings.Add("Text", mScanSettingsVM.Engine.Config.ScanChannel640, "LaserPower");
            //this.btn640Power.DataBindings.Add("Pressed", mScanSettingsVM.Engine.Config.ScanChannel640, "Activated");
            // 小孔
            //this.cbxPinHoleSelect.DataSource = mScanSettingsVM.Engine.Config.ScanPinHoleList;
            //this.cbxPinHoleSelect.DisplayMember = "Name";
            //this.cbxPinHoleSelect.ValueMember = "Size";
            //this.cbxPinHoleSelect.SelectedItem = mScanSettingsVM.Engine.Config.SelectedPinHole;
            //this.tbxPinHole.DataBindings.Add("Text", tbarPinHole, "Value");

            // 其他
        }

        /// <summary>
        /// 实时采集模式点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LiveClick(object sender, EventArgs e)
        {
            if (btnLive.Pressed && btnCapture.Pressed)
            {
                btnCapture.Pressed = false;
            }
            if (btnLive.Pressed)
            {
                
            }
            //if (mScanSettingsVM.Engine.ScanAcquisitionChangeCommand(btnLive.Pressed, btnCapture.Pressed) != API_RETURN_CODE.API_SUCCESS)
            //{
            //    btnLive.Pressed = false;
            //    btnCapture.Pressed = false;
            //}
        }

        /// <summary>
        /// 捕捉模式点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CaptureClick(object sender, EventArgs e)
        {
            if (btnLive.Pressed && btnCapture.Pressed)
            {
                btnLive.Pressed = false;
            }
            //if (mScanSettingsVM.Engine.ScanAcquisitionChangeCommand(btnLive.Pressed, btnCapture.Pressed) != API_RETURN_CODE.API_SUCCESS)
            //{
            //    btnLive.Pressed = false;
            //    btnCapture.Pressed = false;
            //}
        }

    }
}
