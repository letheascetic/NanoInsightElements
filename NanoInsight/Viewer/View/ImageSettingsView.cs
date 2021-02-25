using C1.Win.C1Input;
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
    public partial class ImageSettingsView : C1RibbonForm
    {
        ///////////////////////////////////////////////////////////////////////////////////////////
        private static readonly ILog Logger = LogManager.GetLogger("info");
        ///////////////////////////////////////////////////////////////////////////////////////////

        private ImageSettingsViewModel mImageSettingsVM;
        private InputTrackBar[] mChannelBrightnessBars;
        private InputTrackBar[] mChannelContrastBars;
        private InputTrackBar[] mChannelGammaBars;
        private C1RangeSlider[] mChannelThresholdSliders;

        public ImageSettingsView()
        {
            InitializeComponent();
            Initialize();
            SetDataBindings();
            RegisterEvents();
        }

        /// <summary>
        /// 初始化成员变量
        /// </summary>
        private void Initialize()
        {
            mImageSettingsVM = new ImageSettingsViewModel();

            mChannelBrightnessBars = new InputTrackBar[] 
            {
                tbar405Brightness,
                tbar488Brightness,
                tbar561Brightness,
                tbar640Brightness
            };

            mChannelContrastBars = new InputTrackBar[]
            {
                tbar405Contrast,
                tbar488Contrast,
                tbar561Contrast,
                tbar640Contrast
            };

            mChannelGammaBars = new InputTrackBar[]
            {
                tbar405Gamma,
                tbar488Gamma,
                tbar561Gamma,
                tbar640Gamma
            };

            mChannelThresholdSliders = new C1RangeSlider[] { rs405, rs488, rs561, rs640 };
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {
            for (int i = 0; i < mChannelBrightnessBars.Length; i++)
            {
                mChannelBrightnessBars[i].ValueChanged += ChannelBrightnessChanged;
            }

            for (int i = 0; i < mChannelContrastBars.Length; i++)
            {
                mChannelContrastBars[i].ValueChanged += ChannelContrastChanged;
            }

            for (int i = 0; i < mChannelGammaBars.Length; i++)
            {
                mChannelGammaBars[i].ValueChanged += ChannelGammaChanged;
            }

            for (int i = 0; i < mChannelThresholdSliders.Length; i++)
            {
                mChannelThresholdSliders[i].LowerValueChanged += ChannelThresholdMinChanged;
                mChannelThresholdSliders[i].UpperValueChanged += ChannelThresholdMaxChanged;
            }

        }

        /// <summary>
        /// 设置DataBindings
        /// </summary>
        private void SetDataBindings()
        {
            cbxColorSpace.DataSource = mImageSettingsVM.ColorSpaceList;
            cbxColorSpace.DisplayMember = "Name";
            cbxColorSpace.ValueMember = "ID";
            cbxColorSpace.DataBindings.Add("SelectedItem", mImageSettingsVM, "SelectedColorSpace");

            cbxCorrection.DataSource = mImageSettingsVM.ImageCorrectionList;
            cbxCorrection.DisplayMember = "Name";
            cbxCorrection.ValueMember = "ID";
            cbxCorrection.DataBindings.Add("SelectedItem", mImageSettingsVM, "SelectedImageCorrection");

            sp405.DataBindings.Add("HeaderBackColor", mImageSettingsVM.ScanChannel405, "LaserColor");
            sp488.DataBindings.Add("HeaderBackColor", mImageSettingsVM.ScanChannel488, "LaserColor");
            sp561.DataBindings.Add("HeaderBackColor", mImageSettingsVM.ScanChannel561, "LaserColor");
            sp640.DataBindings.Add("HeaderBackColor", mImageSettingsVM.ScanChannel640, "LaserColor");

            tbar405Brightness.DataBindings.Add("Value", mImageSettingsVM.ScanChannel405, "Brightness");
            tbx405Brightness.DataBindings.Add("Text", tbar405Brightness, "Value");
            tbar405Contrast.DataBindings.Add("Value", mImageSettingsVM.ScanChannel405, "Contrast");
            tbx405Contrast.DataBindings.Add("Text", tbar405Contrast, "Value");
            tbar405Gamma.DataBindings.Add("Value", mImageSettingsVM.ScanChannel405, "Gamma");
            tbx405Gamma.DataBindings.Add("Text", tbar405Gamma, "Value");
            btn405PseudoColor.DataBindings.Add("BackColor", mImageSettingsVM.ScanChannel405, "PseudoColor");

            tbar488Brightness.DataBindings.Add("Value", mImageSettingsVM.ScanChannel488, "Brightness");
            tbx488Brightness.DataBindings.Add("Text", tbar488Brightness, "Value");
            tbar488Contrast.DataBindings.Add("Value", mImageSettingsVM.ScanChannel488, "Contrast");
            tbx488Contrast.DataBindings.Add("Text", tbar488Contrast, "Value");
            tbar488Gamma.DataBindings.Add("Value", mImageSettingsVM.ScanChannel488, "Gamma");
            tbx488Gamma.DataBindings.Add("Text", tbar488Gamma, "Value");
            btn488PseudoColor.DataBindings.Add("BackColor", mImageSettingsVM.ScanChannel488, "PseudoColor");

            tbar561Brightness.DataBindings.Add("Value", mImageSettingsVM.ScanChannel561, "Brightness");
            tbx561Brightness.DataBindings.Add("Text", tbar561Brightness, "Value");
            tbar561Contrast.DataBindings.Add("Value", mImageSettingsVM.ScanChannel561, "Contrast");
            tbx561Contrast.DataBindings.Add("Text", tbar561Contrast, "Value");
            tbar561Gamma.DataBindings.Add("Value", mImageSettingsVM.ScanChannel561, "Gamma");
            tbx561Gamma.DataBindings.Add("Text", tbar561Gamma, "Value");
            btn561PseudoColor.DataBindings.Add("BackColor", mImageSettingsVM.ScanChannel561, "PseudoColor");

            tbar640Brightness.DataBindings.Add("Value", mImageSettingsVM.ScanChannel640, "Brightness");
            tbx640Brightness.DataBindings.Add("Text", tbar640Brightness, "Value");
            tbar640Contrast.DataBindings.Add("Value", mImageSettingsVM.ScanChannel640, "Contrast");
            tbx640Contrast.DataBindings.Add("Text", tbar640Contrast, "Value");
            tbar640Gamma.DataBindings.Add("Value", mImageSettingsVM.ScanChannel640, "Gamma");
            tbx640Gamma.DataBindings.Add("Text", tbar640Gamma, "Value");
            btn640PseudoColor.DataBindings.Add("BackColor", mImageSettingsVM.ScanChannel640, "PseudoColor");

        }

        private void ChannelGammaChanged(object sender, EventArgs e)
        {
            
        }

        private void ChannelBrightnessChanged(object sender, EventArgs e)
        {

        }

        private void ChannelContrastChanged(object sender, EventArgs e)
        {

        }

        private void ChannelThresholdMinChanged(object sender, EventArgs e)
        {

        }

        private void ChannelThresholdMaxChanged(object sender, EventArgs e)
        {

        }

    }
}
