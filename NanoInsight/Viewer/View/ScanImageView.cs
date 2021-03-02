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

            //lbFrame.Text = string.Format("NO. 0 frame");
            //lbTimeSpan.Text = string.Format("0.0 secs");
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

        private void ButtonClick(object sender, EventArgs e)
        {
            short[] data = new short[2 * 20 * 10];
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = (short)i;
            }
            NDArray matrix = MatrixUtil.ToMatrix(data, 2, 20, 10, 1, 4, 2, 16);
            Mat image = new Mat(10, 16, DepthType.Cv32S, 1);
            MatrixUtil.ToBankImage(matrix, ref image);
        }

        private void ScanImageViewLoad(object sender, EventArgs e)
        {
            ApplyTheme();
        }
    }
}
