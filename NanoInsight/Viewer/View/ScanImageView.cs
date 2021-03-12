using C1.Win.C1Ribbon;
using C1.Win.C1Themes;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using log4net;
using NanoInsight.Engine.Common;
using NanoInsight.Engine.Core;
using NanoInsight.Viewer.ViewModel;
using NumSharp;
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
    public partial class ScanImageView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private TabPage[] mTabPages;
        private ImageBox[] mImages;
        private ScanImageViewModel mScanImageVM;
        private int mTaskId;

        public ScanImageViewModel ScanImageVM
        {
            get { return mScanImageVM; }
        }

        public int TaskId
        {
            get { return mTaskId; }
        }

        public ScanImageView(ScanTask scanTask)
        {
            InitializeComponent();
            mScanImageVM = new ScanImageViewModel(scanTask);
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }

        public void UpdateStatus(ScanTask scanTask)
        {
            mScanImageVM = new ScanImageViewModel(scanTask);
            Initialize();
        }

        public void StartScanning()
        {
            mImageTimer.Start();
        }

        public void StopScanning()
        {
            mImageTimer.Stop();
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

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()        
        {
            mTaskId = mScanImageVM.Task.TaskId;

            mTabPages = new TabPage[] { pageAll, page405, page488, page561, page640 };
            mImages = new ImageBox[] { imageAll, image405, image488, image561, image640 };
            InitializeTabPages();

            lbPixelSize.Text = string.Format("{0} um/px", mScanImageVM.Task.Settings.ScanPixelSize.ToString("F3"));
            lbScanPixel.Text = string.Format("{0} x {1} pixels", mScanImageVM.Task.Settings.SelectedScanPixel.Data, mScanImageVM.Task.Settings.SelectedScanPixel.Data);
            lbFps.Text = string.Format("{0} fps", mScanImageVM.Task.Settings.Sequence.FPS.ToString("F3"));

            lbFrame.Text = string.Format("NO. {0} frame", mScanImageVM.Task.ScanInfo.CurrentFrame.Where(p => p>=0).FirstOrDefault());
            lbTimeSpan.Text = string.Format("{0} secs", mScanImageVM.Engine.ScanningTask.ScanInfo.TimeSpan.ToString("F1"));
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {

        }

        /// <summary>
        /// 设置数据绑定
        /// </summary>
        private void SetDataBindings()
        {

        }

        private void InitializeTabPages()
        {
            tabControl.TabPages.Clear();
            foreach (TabPage page in mTabPages)
            {
                int id = int.Parse(page.Tag.ToString());
                if (id < 0 && mScanImageVM.Task.Settings.GetActivatedChannelNum() > 1)
                {
                    tabControl.TabPages.Add(page);
                }
                else if (id >= 0 && mScanImageVM.Task.Settings.ScanChannels[id].Activated)
                {
                    tabControl.TabPages.Add(page);
                }
            }
        }

        private void ScanImageViewLoad(object sender, EventArgs e)
        {
            ApplyTheme();
        }

        private void ImageTimerTick(object sender, EventArgs e)
        {
            if (mScanImageVM.Task.Settings.GetActivatedChannelNum() > 1)
            {
                imageAll.Image = mScanImageVM.Task.ScanData.MergeImages[0].Image;
            }
            if (mScanImageVM.Task.Settings.ScanChannel405.Activated)
            {
                // image405.Image = mScanImageVM.Task.ScanData.GrayImages[0][0].Image;
                image405.Image = mScanImageVM.Task.ScanData.BGRImages[0][0].Image;
            }
            if (mScanImageVM.Task.Settings.ScanChannel488.Activated)
            {
                // image488.Image = mScanImageVM.Task.ScanData.GrayImages[1][0].Image;
                image488.Image = mScanImageVM.Task.ScanData.BGRImages[1][0].Image;
            }
            if (mScanImageVM.Task.Settings.ScanChannel561.Activated)
            {
                // image561.Image = mScanImageVM.Task.ScanData.GrayImages[2][0].Image;
                image561.Image = mScanImageVM.Task.ScanData.BGRImages[2][0].Image;
            }
            if (mScanImageVM.Task.Settings.ScanChannel640.Activated)
            {
                // image640.Image = mScanImageVM.Task.ScanData.GrayImages[3][0].Image;
                image640.Image = mScanImageVM.Task.ScanData.BGRImages[3][0].Image;
            }
        }
    }
}
