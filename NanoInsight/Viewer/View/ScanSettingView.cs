using C1.Win.C1InputPanel;
using C1.Win.C1Ribbon;
using log4net;
using NanoInsight.Viewer.Model;
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
            this.rbtnTwoScanners.CheckedChanged += ScanHeadChanged;
            this.rbtnGalvano.CheckedChanged += ScanModeChanged;

            for (int i = 0; i < mPixelDwellButtons.Length; i++)
            {
                mPixelDwellButtons[i].Click += ScanPixelDwellChanged;
            }

            nbScanPixelCalibration.ValueChanged += ScanPixelCalibrationChanged;
            nbScanPixelScale.ValueChanged += ScanPixelScaleChanged;

            for (int i = 0; i < mScanPixelButtons.Length; i++)
            {
                mScanPixelButtons[i].Click += ScanPixelChanged;
            }

            cbxLineSkip.SelectedIndexChanged += ScanLineSkipChanged;

            cbxPinHoleSelect.SelectedIndexChanged += SelectedScanChannelChanged;
            tbarPinHole.ValueChanged += PinHoleChanged;

            for (int i = 0; i < mChannelGainBars.Length; i++)
            {
                mChannelGainBars[i].ValueChanged += ChannelGainChanged;
                mChannelOffsetBars[i].ValueChanged += ChannelOffsetChanged;
                mChannelPowerBars[i].ValueChanged += ChannelPowerChanged;
                mChannelActivateButtons[i].Click += ChannelActivateChanged;
            }
        }

        /// <summary>
        /// 设置DataBindings
        /// </summary>
        private void SetDataBindings()
        {
            // 采集模式
            this.btnLive.DataBindings.Add("Text", mScanSettingsVM.ScanLiveMode, "Text");
            this.btnLive.DataBindings.Add("Pressed", mScanSettingsVM.ScanLiveMode, "IsEnabled");
            this.btnCapture.DataBindings.Add("Text", mScanSettingsVM.ScanCaptureMode, "Text");
            this.btnCapture.DataBindings.Add("Pressed", mScanSettingsVM.ScanCaptureMode, "IsEnabled");
            // 扫描头
            this.rbtnTwoScanners.DataBindings.Add("Text", mScanSettingsVM.TwoGalvo, "Text");
            this.rbtnTwoScanners.DataBindings.Add("Checked", mScanSettingsVM.TwoGalvo, "IsEnabled");
            this.rbtnThreeScanners.DataBindings.Add("Text", mScanSettingsVM.ThreeGalvo, "Text");
            this.rbtnThreeScanners.DataBindings.Add("Checked", mScanSettingsVM.ThreeGalvo, "IsEnabled");
            // 扫描模式
            this.rbtnGalvano.DataBindings.Add("Text", mScanSettingsVM.Galavano, "Text");
            this.rbtnGalvano.DataBindings.Add("Checked", mScanSettingsVM.Galavano, "IsEnabled");
            this.rbtnResonant.DataBindings.Add("Text", mScanSettingsVM.Resonant, "Text");
            this.rbtnResonant.DataBindings.Add("Checked", mScanSettingsVM.Resonant, "IsEnabled");
            // 扫描方向
            this.btnUnidirection.DataBindings.Add("Text", mScanSettingsVM.Unidirection, "Text");
            this.btnUnidirection.DataBindings.Add("Pressed", mScanSettingsVM.Unidirection, "IsEnabled");
            this.btnBidirection.DataBindings.Add("Text", mScanSettingsVM.Bidirection, "Text");
            this.btnBidirection.DataBindings.Add("Pressed", mScanSettingsVM.Bidirection, "IsEnabled");
            // 双向补偿
            this.nbScanPixelCalibration.DataBindings.Add("Enabled", mScanSettingsVM.Bidirection, "IsEnabled");
            this.nbScanPixelCalibration.DataBindings.Add("Maximum", mScanSettingsVM, "ScanPixelCalibrationMaximum");
            this.nbScanPixelCalibration.DataBindings.Add("Value", mScanSettingsVM, "ScanPixelCalibration");
            //// 像素缩放
            this.nbScanPixelScale.DataBindings.Add("Value", mScanSettingsVM, "ScanPixelScale");
            // 像素时间
            // 快速模式使能
            this.rbtnFastMode.DataBindings.Add("Pressed", mScanSettingsVM, "FastModeEnabled");
            for (int i = 0; i < mPixelDwellButtons.Length; i++)
            {
                mPixelDwellButtons[i].Tag = mScanSettingsVM.ScanPixelDwellList[i];
                mPixelDwellButtons[i].DataBindings.Add("Text", mScanSettingsVM.ScanPixelDwellList[i], "Text");
                mPixelDwellButtons[i].DataBindings.Add("Pressed", mScanSettingsVM.ScanPixelDwellList[i], "IsEnabled");
            }
            // 扫描像素
            for (int i = 0; i < mScanPixelButtons.Length; i++)
            {
                mScanPixelButtons[i].Tag = mScanSettingsVM.ScanPixelList[i];
                mScanPixelButtons[i].DataBindings.Add("Text", mScanSettingsVM.ScanPixelList[i], "Text");
                mScanPixelButtons[i].DataBindings.Add("Pressed", mScanSettingsVM.ScanPixelList[i], "IsEnabled");
            }
            // 帧率 & 帧时间
            this.lbFPSValue.DataBindings.Add("Text", mScanSettingsVM, "FPS", true, DataSourceUpdateMode.OnPropertyChanged, null, "0.000 fps");
            this.lbFrameTimeValue.DataBindings.Add("Text", mScanSettingsVM, "FrameTime", true, DataSourceUpdateMode.OnPropertyChanged, null, "0.000 sec");
            // 跳行扫描
            this.chbxLineSkip.DataBindings.Add("Checked", mScanSettingsVM, "ScanLineSkipEnabled");
            this.cbxLineSkip.DataSource = mScanSettingsVM.ScanLineSkipList;
            this.cbxLineSkip.DisplayMember = "Text";
            this.cbxLineSkip.ValueMember = "Data";
            this.cbxLineSkip.SelectedItem = mScanSettingsVM.SelectedScanLineSkip;
            // 扫描通道
            for (int i = 0; i < mChannelGainBars.Length; i++)
            {
                mChannelGainBars[i].Tag = i;
                mChannelOffsetBars[i].Tag = i;
                mChannelPowerBars[i].Tag = i;
                mChannelActivateButtons[i].Tag = i;
            }
            // 扫描通道1 - 405nm
            this.gh405.DataBindings.Add("BackColor", mScanSettingsVM.ScanChannel405, "PseudoColor");
            this.tbar405HV.DataBindings.Add("Value", mScanSettingsVM.ScanChannel405, "Gain");
            this.tbx405HV.DataBindings.Add("Text", tbar405HV, "Value");
            this.tbar405Offset.DataBindings.Add("Value", mScanSettingsVM.ScanChannel405, "Offset");
            this.tbx405Offset.DataBindings.Add("Text", tbar405Offset, "Value");
            this.tbar405Power.DataBindings.Add("Value", mScanSettingsVM.ScanChannel405, "LaserPower");
            this.tbx405Power.DataBindings.Add("Text", tbar405Power, "Value");
            this.btn405Power.DataBindings.Add("Pressed", mScanSettingsVM.ScanChannel405, "Activated");
            // 扫描通道2 - 488nm
            this.gh488.DataBindings.Add("BackColor", mScanSettingsVM.ScanChannel488, "PseudoColor");
            this.tbar488HV.DataBindings.Add("Value", mScanSettingsVM.ScanChannel488, "Gain");
            this.tbx488HV.DataBindings.Add("Text", tbar488HV, "Value");
            this.tbar488Offset.DataBindings.Add("Value", mScanSettingsVM.ScanChannel488, "Offset");
            this.tbx488Offset.DataBindings.Add("Text", tbar488Offset, "Value");
            this.tbar488Power.DataBindings.Add("Value", mScanSettingsVM.ScanChannel488, "LaserPower");
            this.tbx488Power.DataBindings.Add("Text", tbar488Power, "Value");
            this.btn488Power.DataBindings.Add("Pressed", mScanSettingsVM.ScanChannel488, "Activated");
            // 扫描通道3 - 561nm
            this.gh561.DataBindings.Add("BackColor", mScanSettingsVM.ScanChannel561, "PseudoColor");
            this.tbar561HV.DataBindings.Add("Value", mScanSettingsVM.ScanChannel561, "Gain");
            this.tbx561HV.DataBindings.Add("Text", tbar561HV, "Value");
            this.tbar561Offset.DataBindings.Add("Value", mScanSettingsVM.ScanChannel561, "Offset");
            this.tbx561Offset.DataBindings.Add("Text", tbar561Offset, "Value");
            this.tbar561Power.DataBindings.Add("Value", mScanSettingsVM.ScanChannel561, "LaserPower");
            this.tbx561Power.DataBindings.Add("Text", tbar561Power, "Value");
            this.btn561Power.DataBindings.Add("Pressed", mScanSettingsVM.ScanChannel561, "Activated");
            // 扫描通道4 - 640nm
            this.gh640.DataBindings.Add("BackColor", mScanSettingsVM.ScanChannel640, "PseudoColor");
            this.tbar640HV.DataBindings.Add("Value", mScanSettingsVM.ScanChannel640, "Gain");
            this.tbx640HV.DataBindings.Add("Text", tbar640HV, "Value");
            this.tbar640Offset.DataBindings.Add("Value", mScanSettingsVM.ScanChannel640, "Offset");
            this.tbx640Offset.DataBindings.Add("Text", tbar640Offset, "Value");
            this.tbar640Power.DataBindings.Add("Value", mScanSettingsVM.ScanChannel640, "LaserPower");
            this.tbx640Power.DataBindings.Add("Text", tbar640Power, "Value");
            this.btn640Power.DataBindings.Add("Pressed", mScanSettingsVM.ScanChannel640, "Activated");
            // 小孔
            this.cbxPinHoleSelect.DataSource = mScanSettingsVM.ScanChannels;
            this.cbxPinHoleSelect.DisplayMember = "LaserWaveLength";
            this.cbxPinHoleSelect.ValueMember = "PinHole";
            this.cbxPinHoleSelect.SelectedItem = mScanSettingsVM.SelectedScanChannel;
            this.tbarPinHole.DataBindings.Add("Value", mScanSettingsVM, "SelectedPinHole");
            this.tbxPinHole.DataBindings.Add("Text", tbarPinHole, "Value");
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
                mScanSettingsVM.Engine.StartAcquisition(mScanSettingsVM.ScanLiveMode.ID);
            }
            else
            {
                mScanSettingsVM.Engine.StopAcquisition();
            }
            mScanSettingsVM.ScanLiveMode.IsEnabled = mScanSettingsVM.Engine.Configuration.ScanLiveMode.IsEnabled;
            mScanSettingsVM.ScanCaptureMode.IsEnabled = mScanSettingsVM.Engine.Configuration.ScanCaptureMode.IsEnabled;
            mScanSettingsVM.Update();
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

            if (btnCapture.Pressed)
            {
                mScanSettingsVM.Engine.StartAcquisition(mScanSettingsVM.ScanCaptureMode.ID);
            }
            else
            {
                mScanSettingsVM.Engine.StopAcquisition();
            }
            mScanSettingsVM.ScanLiveMode.IsEnabled = mScanSettingsVM.Engine.Configuration.ScanLiveMode.IsEnabled;
            mScanSettingsVM.ScanCaptureMode.IsEnabled = mScanSettingsVM.Engine.Configuration.ScanCaptureMode.IsEnabled;
            mScanSettingsVM.Update();
        }

        /// <summary>
        /// 扫描头切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanHeadChanged(object sender, EventArgs e)
        {
            int id = rbtnTwoScanners.Checked ? mScanSettingsVM.TwoGalvo.ID : mScanSettingsVM.ThreeGalvo.ID;
            mScanSettingsVM.Engine.SetScanHead(id);
            mScanSettingsVM.TwoGalvo.IsEnabled = mScanSettingsVM.Engine.Configuration.TwoGalvo.IsEnabled;
            mScanSettingsVM.ThreeGalvo.IsEnabled = mScanSettingsVM.Engine.Configuration.ThreeGalvo.IsEnabled;
        }

        /// <summary>
        /// 切换扫描模式
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanModeChanged(object sender, EventArgs e)
        {
            int id = rbtnGalvano.Checked ? mScanSettingsVM.Galavano.ID : mScanSettingsVM.Resonant.ID;
            mScanSettingsVM.Engine.SetScanMode(id);
            mScanSettingsVM.Galavano.IsEnabled = mScanSettingsVM.Engine.Configuration.Galvano.IsEnabled;
            mScanSettingsVM.Resonant.IsEnabled = mScanSettingsVM.Engine.Configuration.Resonant.IsEnabled;
        }

        private void UnidirectionClick(object sender, EventArgs e)
        {
            if (mScanSettingsVM.Unidirection.IsEnabled)
            {
                btnUnidirection.Pressed = true;
                return;
            }
            mScanSettingsVM.Engine.SetScanDirection(mScanSettingsVM.Unidirection.ID);
            mScanSettingsVM.Bidirection.IsEnabled = mScanSettingsVM.Engine.Configuration.Bidirection.IsEnabled;
            mScanSettingsVM.Unidirection.IsEnabled = mScanSettingsVM.Engine.Configuration.Unidirection.IsEnabled;
            mScanSettingsVM.Update();
        }

        private void BidirectionClick(object sender, EventArgs e)
        {
            if (mScanSettingsVM.Bidirection.IsEnabled)
            {
                btnBidirection.Pressed = true;
                return;
            }
            mScanSettingsVM.Engine.SetScanDirection(mScanSettingsVM.Bidirection.ID);
            mScanSettingsVM.Bidirection.IsEnabled = mScanSettingsVM.Engine.Configuration.Bidirection.IsEnabled;
            mScanSettingsVM.Unidirection.IsEnabled = mScanSettingsVM.Engine.Configuration.Unidirection.IsEnabled;
            mScanSettingsVM.Update();
        }

        /// <summary>
        /// 像素停留时间按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanPixelDwellChanged(object sender, EventArgs e)
        {
            InputButton button = (InputButton)sender;
            ScanPixelDwellModel model = (ScanPixelDwellModel)button.Tag;
            if (model.IsEnabled)
            {
                button.Pressed = true;
                return;
            }
            nbScanPixelCalibration.ValueChanged -= ScanPixelCalibrationChanged;
            mScanSettingsVM.SelectScanPixelDwell(model.ID);
            mScanSettingsVM.Update();
            nbScanPixelCalibration.ValueChanged += ScanPixelCalibrationChanged;
        }

        /// <summary>
        /// 扫描像素按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanPixelChanged(object sender, EventArgs e)
        {
            InputButton button = (InputButton)sender;
            ScanPixelModel model = (ScanPixelModel)button.Tag;
            if (model.IsEnabled)
            {
                button.Pressed = true;
                return;
            }

            mScanSettingsVM.SelectScanPixel(model.ID);
            mScanSettingsVM.Update();
        }

        /// <summary>
        /// 双向扫描像素补偿更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanPixelCalibrationChanged(object sender, EventArgs e)
        {
            mScanSettingsVM.SetScanPixelCalibration((int)nbScanPixelCalibration.Value);
        }

        /// <summary>
        /// 扫描像素缩放系数更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanPixelScaleChanged(object sender, EventArgs e)
        {
            mScanSettingsVM.SetScanPixelScale((int)nbScanPixelScale.Value);
        }

        /// <summary>
        /// 切换跳行扫描事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ScanLineSkipChanged(object sender, EventArgs e)
        {
            int id = ((ScanLineSkipModel)cbxLineSkip.SelectedItem).ID;
            mScanSettingsVM.Engine.SelectLineSkip(id);
            mScanSettingsVM.SelectedScanLineSkip = mScanSettingsVM.ScanLineSkipList.Where(p => p.ID == mScanSettingsVM.Engine.Configuration.SelectedScanLineSkip.ID).First();
        }

        private void ScanSettingViewLoad(object sender, EventArgs e)
        {
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }

        /// <summary>
        /// 跳行扫描使能变更事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LineSkipCheckedChanged(object sender, EventArgs e)
        {
            mScanSettingsVM.Engine.SetLineSkipStatus(chbxLineSkip.Checked);
        }

        /// <summary>
        /// 快速模式使能点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FastModeClick(object sender, EventArgs e)
        {
            mScanSettingsVM.Engine.SetFastModeStatus(rbtnFastMode.Pressed);
            mScanSettingsVM.FastModeEnabled = mScanSettingsVM.Engine.Configuration.FastModeEnabled;
            Logger.Info(string.Format("Fast Mode Enabled [{0}].", mScanSettingsVM.FastModeEnabled));
        }

        /// <summary>
        /// 通道增益更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelGainChanged(object sender, EventArgs e)
        {
            InputTrackBar bar = (InputTrackBar)sender;
            int id = (int)bar.Tag;
            mScanSettingsVM.Engine.SetChannelGain(id, bar.Value);
            mScanSettingsVM.ScanChannels[id].Gain = mScanSettingsVM.Engine.Configuration.ScanChannels[id].Gain;
        }

        /// <summary>
        /// 通道偏置更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelOffsetChanged(object sender, EventArgs e)
        {
            InputTrackBar bar = (InputTrackBar)sender;
            int id = (int)bar.Tag;
            mScanSettingsVM.Engine.SetChannelOffset(id, bar.Value);
            mScanSettingsVM.ScanChannels[id].Offset = mScanSettingsVM.Engine.Configuration.ScanChannels[id].ImageSettings.Offset;
        }

        /// <summary>
        /// 通道功率更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelPowerChanged(object sender, EventArgs e)
        {
            InputTrackBar bar = (InputTrackBar)sender;
            int id = (int)bar.Tag;
            mScanSettingsVM.Engine.SetChannelPower(id, bar.Value);
            mScanSettingsVM.ScanChannels[id].LaserPower = mScanSettingsVM.Engine.Configuration.ScanChannels[id].LaserPower;
        }

        /// <summary>
        /// 通道激光开关事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChannelActivateChanged(object sender, EventArgs e)
        {
            InputButton button = (InputButton)sender;
            int id = (int)button.Tag;
            mScanSettingsVM.Engine.SetChannelStatus(id, button.Pressed);
            mScanSettingsVM.ScanChannels[id].Activated = mScanSettingsVM.Engine.Configuration.ScanChannels[id].Activated;
        }

        /// <summary>
        /// 切换扫描通道事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectedScanChannelChanged(object sender, EventArgs e)
        {
            tbarPinHole.ValueChanged -= PinHoleChanged;
            mScanSettingsVM.SelectedScanChannel = (ScanChannelModel)cbxPinHoleSelect.SelectedItem;
            mScanSettingsVM.SelectedPinHole = mScanSettingsVM.SelectedScanChannel.PinHole;
            tbarPinHole.ValueChanged += PinHoleChanged;
        }

        /// <summary>
        /// 设置小孔孔径
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PinHoleChanged(object sender, EventArgs e)
        {
            InputTrackBar bar = (InputTrackBar)sender;
            int id = mScanSettingsVM.SelectedScanChannel.ID;
            mScanSettingsVM.Engine.SetChannelPinHole(id, bar.Value);
            mScanSettingsVM.SelectedScanChannel.PinHole = mScanSettingsVM.Engine.Configuration.ScanChannels[id].PinHole;
        }

    }
}
