using C1.Win.C1Ribbon;
using C1.Win.C1Themes;
using log4net;
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

        public MainView()
        {
            InitializeComponent();
        }





        ///////////////////////////////////////////////////////////////////////////////////////////

        private void InitAppearance()
        {

        }

        /// <summary>
        /// 应用主题
        /// </summary>
        private void ApplyTheme(string themeName)
        {
            this.SuspendPainting();
            Properties.Settings.Default.ThemeName = themeName;
            C1ThemeController.ApplyThemeToControlTree(this, C1ThemeController.GetThemeByName(themeName, false));
            this.ResumePainting();
        }

        ///////////////////////////////////////////////////////////////////////////////////////////

        private void MainViewLoad(object sender, EventArgs e)
        {
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.AllPaintingInWmPaint, true);
            ApplyTheme(Properties.Settings.Default.ThemeName);
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
            ScanAreaView mScanAreaView = new ScanAreaView()
            {
                MdiParent = this,
                Visible = true
            };
        }

        private void SysSettingsClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            SysSettingsView mSysSettingsView = new SysSettingsView()
            {
                MdiParent = this,
                Visible = true
            };
        }

        private void ScanSettingsClick(object sender, C1.Win.C1Command.ClickEventArgs e)
        {
            ScanSettingView mScanSettingsView = new ScanSettingView()
            {
                MdiParent = this,
                Visible = true
            };
        }
    }
}
