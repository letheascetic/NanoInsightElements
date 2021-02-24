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
        }

        /// <summary>
        /// 注册事件
        /// </summary>
        private void RegisterEvents()
        {
            
        }

        /// <summary>
        /// 设置DataBindings
        /// </summary>
        private void SetDataBindings()
        {
            cbxImageColor.DataSource = mImageSettingsVM.ColorSpaceList;
            cbxImageColor.DisplayMember = "Name";
            cbxImageColor.ValueMember = "ID";
            cbxImageColor.DataBindings.Add("SelectedItem", mImageSettingsVM, "SelectedColorSpace");

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

    }
}
