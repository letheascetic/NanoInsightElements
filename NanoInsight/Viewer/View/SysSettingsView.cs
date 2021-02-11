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
    public partial class SysSettingsView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private SysSettingsViewModel mSysSettingsViewModel;

        private InputComboBox[] mPmtChannelCbx;
        private InputComboBox[] mApdSourceCbx;
        private InputComboBox[] mApdChannelCbx;


        public SysSettingsView()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 初始化成员变量
        /// </summary>
        private void Initialize()
        {
            mSysSettingsViewModel = new SysSettingsViewModel();
            mPmtChannelCbx = new InputComboBox[]
            {
                cbx405PMT,
                cbx488PMT,
                cbx561PMT,
                cbx640PMT
            };
            mApdSourceCbx = new InputComboBox[]
            {
                cbx405Ctr,
                cbx488Ctr,
                cbx561Ctr,
                cbx640Ctr
            };
            mApdChannelCbx = new InputComboBox[]
            {
                cbx405Channel,
                cbx488Channel,
                cbx561Channel,
                cbx640Channel
            };
        }

        private void SetDataBindings()
        {
            // 振镜模拟输出通道
            cbxXGalvo.DataSource = mSysSettingsViewModel.XGalvoAoChannels;
            cbxYGalvo.DataSource = mSysSettingsViewModel.YGalvoAoChannels;
            cbxYGalvo2.DataSource = mSysSettingsViewModel.Y2GalvoAoChannels;


            cbxXGalvo.SelectedItem = mSysSettingsViewModel.Engine.Config.GalvoProperty.XGalvoAoChannel;
            cbxYGalvo.SelectedItem = mSysSettingsViewModel.Engine.Config.GalvoProperty.YGalvoAoChannel;
            cbxYGalvo2.SelectedItem = mSysSettingsViewModel.Engine.Config.GalvoProperty.Y2GalvoAoChannel;

            // 振镜偏置电压和校准电压
            nbXGalvoOffset.DataBindings.Add("Value", mSysSettingsViewModel.Engine.Config.GalvoProperty, "XGalvoOffsetVoltage");
            nbYGalvoOffset.DataBindings.Add("Value", mSysSettingsViewModel.Engine.Config.GalvoProperty, "YGalvoOffsetVoltage");

            nbXGalvoCalibration.DataBindings.Add("Value", mSysSettingsViewModel.Engine.Config.GalvoProperty, "XGalvoCalibrationVoltage");
            nbYGalvoCalibration.DataBindings.Add("Value", mSysSettingsViewModel.Engine.Config.GalvoProperty, "YGalvoCalibrationVoltage");

            // 振镜响应时间和视场大小
            nbGalvoResponseTime.DataBindings.Add("Value", mSysSettingsViewModel.Engine.Config.GalvoProperty, "GalvoResponseTime");
            nbScanRange.DataBindings.Add("Value", mSysSettingsViewModel.Engine.Config.FullScanArea.ScanRange, "Width");

            // 采集控制
            rbtnPMT.DataBindings.Add("Checked", mSysSettingsViewModel.Engine.Config.Detector.DetectorPmt, "IsEnabled");
            rbtnAPD.DataBindings.Add("Checked", mSysSettingsViewModel.Engine.Config.Detector.DetectorApd, "IsEnabled");
            cbxStartSync.DataSource = mSysSettingsViewModel.StartTriggers;
            cbxStartSync.SelectedItem = mSysSettingsViewModel.Engine.Config.Detector.StartTrigger;
            cbxTrigger.DataSource = mSysSettingsViewModel.TriggerSignals;
            cbxTrigger.SelectedItem = mSysSettingsViewModel.Engine.Config.Detector.TriggerSignal;
            cbxTriggerR.DataSource = mSysSettingsViewModel.TriggerReceivers;
            cbxTriggerR.SelectedItem = mSysSettingsViewModel.Engine.Config.Detector.TriggerReceive;

            // PMT
            for (int i = 0; i < mPmtChannelCbx.Length; i++)
            {
                mPmtChannelCbx[i].Tag = i;
                mPmtChannelCbx[i].DataSource = mSysSettingsViewModel.AiChannels[i];
                mPmtChannelCbx[i].SelectedItem = mSysSettingsViewModel.Engine.Config.FindPmtChannel(i).AiChannel;
            }

            // APD
            for (int i = 0; i < mApdSourceCbx.Length; i++)
            {
                mApdSourceCbx[i].Tag = i;
                mApdSourceCbx[i].DataSource = mSysSettingsViewModel.CiSources[i];
                mApdSourceCbx[i].SelectedItem = mSysSettingsViewModel.Engine.Config.FindApdChannel(i).CiSource;
            }

            for (int i = 0; i < mApdChannelCbx.Length; i++)
            {
                mApdChannelCbx[i].Tag = i;
                mApdChannelCbx[i].DataSource = mSysSettingsViewModel.CiChannels[i];
                mApdChannelCbx[i].SelectedItem = mSysSettingsViewModel.Engine.Config.FindApdChannel(i).CiChannel;
            }
        }

        private void RegisterEvents()
        {
            // 振镜控制端口
            cbxXGalvo.SelectedIndexChanged += XGalvoChannelChanged;
            cbxYGalvo.SelectedIndexChanged += YGalvoChannelChanged;
            cbxYGalvo2.SelectedIndexChanged += Y2GalvoChannelChanged;

            // 振镜偏置电压和校准电压
            nbXGalvoOffset.ChangeCommitted += XGalvoOffsetVoltageChaned;
            nbYGalvoOffset.ChangeCommitted += YGalvoOffsetVoltageChaned;
            nbXGalvoCalibration.ChangeCommitted += XGalvoCalibrationVoltageChaned;
            nbYGalvoCalibration.ChangeCommitted += YGalvoCalibrationVoltageChaned;

            // 振镜响应时间和视场
            nbGalvoResponseTime.ValueChanged += GalvoResponseTimeChanged;
            nbScanRange.ValueChanged += FullScanAreaChanged;

            // 探测器类型 启动同步 触发信号 触发接收端口
            rbtnPMT.CheckedChanged += DetectorModeChanged;
            cbxStartSync.SelectedIndexChanged += StartTriggerChanged;
            cbxTrigger.SelectedIndexChanged += TriggerSignalChanged;
            cbxTriggerR.SelectedIndexChanged += TriggerReceiveChanged;

            // PMT
            for (int i = 0; i < mPmtChannelCbx.Length; i++)
            {
                mPmtChannelCbx[i].SelectedIndexChanged += PmtChannelChanged;
            }

            // APD
            for (int i = 0; i < mApdSourceCbx.Length; i++)
            {
                mApdSourceCbx[i].SelectedIndexChanged += ApdSourceChanged;
            }

            for (int i = 0; i < mApdChannelCbx.Length; i++)
            {
                mApdChannelCbx[i].SelectedIndexChanged += ApdChannelChanged;
            }

        }

        /// <summary>
        /// X振镜端口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void XGalvoChannelChanged(object sender, EventArgs e)
        {
            // mSysSettingsViewModel.Engine.SetXGalvoChannel(cbxXGalvo.SelectedItem.ToString());
        }

        /// <summary>
        /// Y振镜端口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YGalvoChannelChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.YGalvoChannelChangeCommand(cbxYGalvo.SelectedItem.ToString());
        }

        /// <summary>
        /// Y2振镜端口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Y2GalvoChannelChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetY2GalvoChannel(cbxYGalvo2.SelectedItem.ToString());
        }

        private void XGalvoOffsetVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetXGalvoOffsetVoltage((double)nbXGalvoOffset.Value);
        }

        private void YGalvoOffsetVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetYGalvoOffsetVoltage((double)nbYGalvoOffset.Value);
        }

        private void XGalvoCalibrationVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetXGalvoCalibrationVoltage((double)nbXGalvoCalibration.Value);
        }

        private void YGalvoCalibrationVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetYGalvoCalibrationVoltage((double)nbYGalvoCalibration.Value);
        }

        private void GalvoResponseTimeChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetGalvoResponseTime((double)nbGalvoResponseTime.Value);
        }

        private void FullScanAreaChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.FullScanAreaChangeCommand((float)nbScanRange.Value);
        }

        private void DetectorModeChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.SetDetectorMode(rbtnPMT.Checked);
        }

        private void StartTriggerChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.StartTriggerChangeCommand(cbxStartSync.SelectedItem.ToString());
        }

        private void TriggerSignalChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.TriggerSignalChangeCommand(cbxTrigger.SelectedItem.ToString());
        }

        private void TriggerReceiveChanged(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.TriggerReceiverChangeCommand(cbxTriggerR.SelectedItem.ToString());
        }

        private void GalvoCalibration(object sender, EventArgs e)
        {
            mSysSettingsViewModel.Engine.GalvoCalibrationCommand();
        }

    }
}
