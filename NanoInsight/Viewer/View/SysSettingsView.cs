using C1.Win.C1InputPanel;
using C1.Win.C1Ribbon;
using log4net;
using NanoInsight.Engine.Attribute;
using NanoInsight.Engine.Core;
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

        private SysSettingsViewModel mSysSettingsVM;

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
            mSysSettingsVM = new SysSettingsViewModel();
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
            cbxXGalvo.DataSource = mSysSettingsVM.XGalvoAoChannels;
            cbxYGalvo.DataSource = mSysSettingsVM.YGalvoAoChannels;
            cbxYGalvo2.DataSource = mSysSettingsVM.Y2GalvoAoChannels;


            cbxXGalvo.SelectedItem = mSysSettingsVM.GalvoProperty.XGalvoAoChannel;
            cbxYGalvo.SelectedItem = mSysSettingsVM.GalvoProperty.YGalvoAoChannel;
            cbxYGalvo2.SelectedItem = mSysSettingsVM.GalvoProperty.Y2GalvoAoChannel;

            // 振镜偏置电压和校准电压
            nbXGalvoOffset.DataBindings.Add("Value", mSysSettingsVM.GalvoProperty, "XGalvoOffsetVoltage");
            nbYGalvoOffset.DataBindings.Add("Value", mSysSettingsVM.GalvoProperty, "YGalvoOffsetVoltage");

            nbXGalvoCalibration.DataBindings.Add("Value", mSysSettingsVM.GalvoProperty, "XGalvoCalibrationVoltage");
            nbYGalvoCalibration.DataBindings.Add("Value", mSysSettingsVM.GalvoProperty, "YGalvoCalibrationVoltage");

            // 振镜响应时间和视场大小
            nbGalvoResponseTime.DataBindings.Add("Value", mSysSettingsVM.GalvoProperty, "GalvoResponseTime");
            nbScanRange.DataBindings.Add("Value", mSysSettingsVM.FullScanArea.ScanRange, "Width");

            // 采集控制
            rbtnPMT.DataBindings.Add("Checked", mSysSettingsVM.Detector.Pmt, "IsEnabled");
            rbtnAPD.DataBindings.Add("Checked", mSysSettingsVM.Detector.Apd, "IsEnabled");
            cbxStartSync.DataSource = mSysSettingsVM.StartTriggers;
            cbxStartSync.SelectedItem = mSysSettingsVM.Detector.StartTrigger;
            cbxTrigger.DataSource = mSysSettingsVM.TriggerSignals;
            cbxTrigger.SelectedItem = mSysSettingsVM.Detector.TriggerSignal;
            cbxTriggerR.DataSource = mSysSettingsVM.TriggerReceivers;
            cbxTriggerR.SelectedItem = mSysSettingsVM.Detector.TriggerReceive;

            // PMT
            for (int i = 0; i < mPmtChannelCbx.Length; i++)
            {
                mPmtChannelCbx[i].Tag = i;
                mPmtChannelCbx[i].DataSource = mSysSettingsVM.AiChannels[i];
                mPmtChannelCbx[i].SelectedItem = mSysSettingsVM.Detector.FindPmtChannel(i).AiChannel;
            }

            // APD
            for (int i = 0; i < mApdSourceCbx.Length; i++)
            {
                mApdSourceCbx[i].Tag = i;
                mApdSourceCbx[i].DataSource = mSysSettingsVM.CiSources[i];
                mApdSourceCbx[i].SelectedItem = mSysSettingsVM.Detector.FindApdChannel(i).CiSource;
            }

            for (int i = 0; i < mApdChannelCbx.Length; i++)
            {
                mApdChannelCbx[i].Tag = i;
                mApdChannelCbx[i].DataSource = mSysSettingsVM.CiChannels[i];
                mApdChannelCbx[i].SelectedItem = mSysSettingsVM.Detector.FindApdChannel(i).CiChannel;
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
            mSysSettingsVM.Engine.SetXGalvoChannel(cbxXGalvo.SelectedItem.ToString());
            mSysSettingsVM.GalvoProperty.XGalvoAoChannel = mSysSettingsVM.Engine.Configuration.GalvoAttr.XGalvoAoChannel;
        }
        /// <summary>
        /// Y振镜端口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void YGalvoChannelChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetYGalvoChannel(cbxYGalvo.SelectedItem.ToString());
            mSysSettingsVM.GalvoProperty.YGalvoAoChannel = mSysSettingsVM.Engine.Configuration.GalvoAttr.YGalvoAoChannel;
        }

        /// <summary>
        /// Y2振镜端口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Y2GalvoChannelChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetY2GalvoChannel(cbxYGalvo2.SelectedItem.ToString());
            mSysSettingsVM.GalvoProperty.Y2GalvoAoChannel = mSysSettingsVM.Engine.Configuration.GalvoAttr.Y2GalvoAoChannel;
        }

        private void XGalvoOffsetVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetXGalvoOffsetVoltage((double)nbXGalvoOffset.Value);
            mSysSettingsVM.GalvoProperty.XGalvoOffsetVoltage = mSysSettingsVM.Engine.Configuration.GalvoAttr.XGalvoOffsetVoltage;
        }

        private void YGalvoOffsetVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetYGalvoOffsetVoltage((double)nbYGalvoOffset.Value);
            mSysSettingsVM.GalvoProperty.YGalvoOffsetVoltage = mSysSettingsVM.Engine.Configuration.GalvoAttr.YGalvoOffsetVoltage;
        }

        private void XGalvoCalibrationVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetXGalvoCalibrationVoltage((double)nbXGalvoCalibration.Value);
            mSysSettingsVM.GalvoProperty.XGalvoCalibrationVoltage = mSysSettingsVM.Engine.Configuration.GalvoAttr.XGalvoCalibrationVoltage;
        }

        private void YGalvoCalibrationVoltageChaned(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetYGalvoCalibrationVoltage((double)nbYGalvoCalibration.Value);
            mSysSettingsVM.GalvoProperty.YGalvoCalibrationVoltage = mSysSettingsVM.Engine.Configuration.GalvoAttr.YGalvoCalibrationVoltage;
        }

        private void GalvoResponseTimeChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetGalvoResponseTime((double)nbGalvoResponseTime.Value);
            mSysSettingsVM.GalvoProperty.GalvoResponseTime = mSysSettingsVM.Engine.Configuration.GalvoAttr.GalvoResponseTime;
        }

        private void FullScanAreaChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetFullScanArea((float)nbScanRange.Value);
            mSysSettingsVM.FullScanArea.Update(mSysSettingsVM.Engine.Configuration.FullScanArea.ScanRange);
        }

        private void DetectorModeChanged(object sender, EventArgs e)
        {
            int id = rbtnPMT.Checked ? DetectorType.Pmt : DetectorType.Apd;
            mSysSettingsVM.SetDetectorMode(id);
        }

        private void StartTriggerChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetStartTrigger(cbxStartSync.SelectedItem.ToString());
            mSysSettingsVM.Detector.StartTrigger = mSysSettingsVM.Engine.Configuration.Detector.StartTrigger;
        }

        private void TriggerSignalChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetTriggerSignal(cbxTrigger.SelectedItem.ToString());
            mSysSettingsVM.Detector.TriggerSignal = mSysSettingsVM.Engine.Configuration.Detector.TriggerSignal;
        }

        private void TriggerReceiveChanged(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetTriggerReceiver(cbxTriggerR.SelectedItem.ToString());
            mSysSettingsVM.Detector.TriggerReceive = mSysSettingsVM.Engine.Configuration.Detector.TriggerReceive;
        }

        private void SetGalvoOffsetVoltage(object sender, EventArgs e)
        {
            mSysSettingsVM.Engine.SetGalvoOffsetVoltage();
        }

        /// <summary>
        /// PMT通道接口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PmtChannelChanged(object sender, EventArgs e)
        {
            InputComboBox cbx = (InputComboBox)sender;
            mSysSettingsVM.SetPmtChannel((int)cbx.Tag, cbx.SelectedItem.ToString());
        }

        /// <summary>
        /// APD使用的计数器更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApdSourceChanged(object sender, EventArgs e)
        {
            InputComboBox cbx = (InputComboBox)sender;
            mSysSettingsVM.SetApdSource((int)cbx.Tag, cbx.SelectedItem.ToString());
        }

        /// <summary>
        /// APD使用的计数器接收端口更新事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ApdChannelChanged(object sender, EventArgs e)
        {
            InputComboBox cbx = (InputComboBox)sender;
            mSysSettingsVM.SetApdChannel((int)cbx.Tag, cbx.SelectedItem.ToString());
        }

    }
}
