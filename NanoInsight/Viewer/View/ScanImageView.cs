using C1.Win.C1Ribbon;
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

        public ScanImageView(ScanTask scanTask)
        {
            InitializeComponent();
            mScanImageVM = new ScanImageViewModel(scanTask);
        }

        /// <summary>
        /// 初始化
        /// </summary>
        private void Initialize()        {
            mTabPages = new TabPage[] { pageAll, page405, page488, page561, page640 };
            mImages = new ImageBox[] { imageAll, image405, image488, image561, image640 };
            InitializeTabPages();

            lbPixelSize.Text = string.Format("{0} um/px", mScanImageVM.Engine.Configuration.ScanPixelSize.ToString("F3"));
            lbScanPixel.Text = string.Format("{0} x {1} pixels", mScanImageVM.Engine.Configuration.SelectedScanPixel.Data, mScanImageVM.Engine.Configuration.SelectedScanPixel.Data);
            lbFps.Text = string.Format("{0} fps", mScanImageVM.Engine.Sequence.FPS.ToString("F3"));
            if (mScanImageVM.Engine.Configuration.IsScanning)
            {
                lbFrame.Text = string.Format("NO. {0} frame", mScanImageVM.Engine.ScanningTask.ScanInfo.CurrentFrame);
                lbTimeSpan.Text = string.Format("{0} secs", mScanImageVM.Engine.ScanningTask.ScanInfo.TimeSpan.ToString("F1"));
            }
            else
            {
                lbFrame.Text = string.Format("NO. 0 frame");
                lbTimeSpan.Text = string.Format("0.0 secs");
            }
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {
            mScanImageVM.Engine.ChannelActivateChangedEvent += ChannelActivateChangedEventHandler;
            mScanImageVM.Engine.ScanAcquisitionChangedEvent += ScanAcquisitionChangedEventHandler;
            mScanImageVM.Engine.ScanPixelChangedEvent += ScanPixelChangedEventHandler;
        }

        private int ScanPixelChangedEventHandler(Engine.Attribute.ScanPixel scanPixel)
        {
            lbPixelSize.Text = string.Format("{0} um/px", mScanImageVM.Engine.Configuration.ScanPixelSize.ToString("F3"));
            lbFps.Text = string.Format("{0} fps", mScanImageVM.Engine.Sequence.FPS.ToString("F3"));
            lbScanPixel.Text = string.Format("{0} x {1} pixels", mScanImageVM.Engine.Configuration.SelectedScanPixel.Data, mScanImageVM.Engine.Configuration.SelectedScanPixel.Data);
            return ApiCode.Success;
        }

        private int ScanAcquisitionChangedEventHandler(Engine.Attribute.ScanAcquisition scanAcquisition)
        {
            if (scanAcquisition != null)
            {
                mImageTimer.Start();
            }
            else
            {
                mImageTimer.Stop();
            }
            return ApiCode.Success;
        }

        private int ChannelActivateChangedEventHandler(Engine.Attribute.ScanChannel channel)
        {
            InitializeTabPages();
            return ApiCode.Success;
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
                if (id < 0 && mScanImageVM.Engine.Configuration.GetActivatedChannelNum() > 1)
                {
                    tabControl.TabPages.Add(page);
                }
                else if (id >= 0 && mScanImageVM.Engine.Configuration.ScanChannels[id].Activated)
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
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }
    }
}
