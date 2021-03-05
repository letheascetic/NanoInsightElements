using C1.Win.C1Ribbon;
using C1.Win.C1Themes;
using log4net;
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
    public partial class MainView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private MainViewModel mMainViewModel;
        private ScanSettingView mScanSettingView;
        private ScanAreaView mScanAreaView;
        private SysSettingsView mSysSettingsView;
        private ScanParasView mScanParasView;
        private ImageSettingsView mImageSettingsView;
        private List<ScanImageView> mScanImageViewList;
        
        public MainView()
        {
            InitializeComponent();
            Initialize();
            RegisterEvents();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        private void InitAppearance()
        {
            // WindowState = FormWindowState.Maximized;
            mScanSettingView.Location = new Point(this.ClientRectangle.Right - mScanSettingView.Width, 0);
            mScanAreaView.Location = new Point(mScanSettingView.Location.X - mScanAreaView.Width, 0);
            // mImageSettingsView.Location = new Point(mScanAreaView.Location.X - mImageSettingsView.Width, 0);

            mScanSettingView.Visible = true;
            mScanAreaView.Visible = true;
            // mImageSettingsView.Visible = true;

            cmdScanSettings.Checked = mScanSettingView.Visible;
            cmdScanArea.Checked = mScanAreaView.Visible;
            cmdImageSettings.Checked = mImageSettingsView.Visible;
            cmdSysSettings.Checked = mSysSettingsView.Visible;
            cmdScanParas.Checked = mScanParasView.Visible;
        }

        private void Initialize()
        {
            mMainViewModel = new MainViewModel();

            mScanSettingView = new ScanSettingView() { MdiParent = this };
            mScanAreaView = new ScanAreaView() { MdiParent = this };
            mSysSettingsView = new SysSettingsView() { MdiParent = this };
            mImageSettingsView = new ImageSettingsView() { MdiParent = this };
            mScanParasView = new ScanParasView() { MdiParent = this };
            mScanImageViewList = new List<ScanImageView>();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            ApplyTheme(Properties.Settings.Default.ThemeName);
        }

        /// <summary>
        /// 应用主题
        /// </summary>
        private void ApplyTheme(string themeName)
        {
            this.SuspendPainting();
            Properties.Settings.Default.ThemeName = themeName;

            List<Control> noThemeControls = new List<Control>() { mScanSettingView, mScanAreaView, mSysSettingsView, mImageSettingsView, mScanParasView };
            noThemeControls.AddRange(mScanImageViewList);
            C1ThemeController.ApplyThemeToControlTree(this, C1ThemeController.GetThemeByName(themeName, false), (c) => !noThemeControls.Contains(c));

            mScanSettingView.ApplyTheme();
            mScanAreaView.ApplyTheme();
            mSysSettingsView.ApplyTheme();
            mImageSettingsView.ApplyTheme();
            mScanParasView.ApplyTheme();
            foreach (ScanImageView scanImageView in mScanImageViewList)
            {
                scanImageView.ApplyTheme();
            }

            this.ResumePainting();
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {
            mMainViewModel.Engine.ScanAcquisitionChangedEvent += ScanAcquisitionChangedEvent;
        }

        private int ScanAcquisitionChangedEvent(Engine.Attribute.ScanAcquisition scanAcquisition)
        {
            if (scanAcquisition == null)
            {
                ScanImageView scanImageView = mScanImageViewList.Where(p => p.ScanImageVM.Task.Scanning).FirstOrDefault();
                if (scanImageView != null)
                {
                    scanImageView.StopScanning();
                }
            }
            else
            {
                int taskId = mMainViewModel.Engine.ScanningTask.TaskId;
                ScanImageView scanImageView = mScanImageViewList.Where(p => p.TaskId == taskId).FirstOrDefault();
                if (scanImageView == null)
                {
                    scanImageView = new ScanImageView(mMainViewModel.Engine.ScanningTask) { MdiParent = this, Visible = true };
                    mScanImageViewList.Add(scanImageView);
                }
                else
                {
                    scanImageView.UpdateStatus(mMainViewModel.Engine.ScanningTask);
                    scanImageView.Visible = true;
                }
                scanImageView.StartScanning();
                scanImageView.Activate();
            }
            return ApiCode.Success;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        private void MainViewLoad(object sender, EventArgs e)
        {
            InitAppearance();
        }

        private void ThemeClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            ThemeView themeManager = new ThemeView();
            if (themeManager.ShowDialog() == DialogResult.OK)
            {
                if (themeManager.ThemeName != Properties.Settings.Default.ThemeName)
                {
                    ApplyTheme(themeManager.ThemeName);
                }
            }
        }

        private void ScanAreaClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mScanAreaView.Visible = cmdScanArea.Checked;
        }

        private void SysSettingsClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mSysSettingsView.Visible = cmdSysSettings.Checked;
        }

        private void ScanSettingsClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mScanSettingView.Visible = cmdScanSettings.Checked;
        }

        private void ScanParasClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mScanParasView.Visible = cmdScanParas.Checked;
        }

        private void ScanImageClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            ScanImageView mScanImageView = new ScanImageView(null)
            {
                MdiParent = this, 
                Visible = true
            };
        }

        private void ImageSettingsClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            mImageSettingsView.Visible = cmdImageSettings.Checked;
        }
    }
}
