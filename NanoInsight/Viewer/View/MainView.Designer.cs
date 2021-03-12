namespace NanoInsight.Viewer.View
{
    partial class MainView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.c1CommandHolder = new C1.Win.C1Command.C1CommandHolder();
            this.cmdMenuFile = new C1.Win.C1Command.C1CommandMenu();
            this.cmdMenuView = new C1.Win.C1Command.C1CommandMenu();
            this.cmdLinkTheme = new C1.Win.C1Command.C1CommandLink();
            this.cmdTheme = new C1.Win.C1Command.C1Command();
            this.cmdMenuWindow = new C1.Win.C1Command.C1CommandMenu();
            this.cmdLinkScanArea = new C1.Win.C1Command.C1CommandLink();
            this.cmdScanArea = new C1.Win.C1Command.C1Command();
            this.cmdLinkSysSettings = new C1.Win.C1Command.C1CommandLink();
            this.cmdSysSettings = new C1.Win.C1Command.C1Command();
            this.cmdLinkScanSettings = new C1.Win.C1Command.C1CommandLink();
            this.cmdScanSettings = new C1.Win.C1Command.C1Command();
            this.cmdLinkScanParas = new C1.Win.C1Command.C1CommandLink();
            this.cmdScanParas = new C1.Win.C1Command.C1Command();
            this.cmdLinkScanImage = new C1.Win.C1Command.C1CommandLink();
            this.cmdScanImage = new C1.Win.C1Command.C1Command();
            this.cmdLinkImageSettings = new C1.Win.C1Command.C1CommandLink();
            this.cmdImageSettings = new C1.Win.C1Command.C1Command();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new C1.Win.C1Command.C1MainMenu();
            this.cmdLinkFile = new C1.Win.C1Command.C1CommandLink();
            this.cmdLinkView = new C1.Win.C1Command.C1CommandLink();
            this.cmdLinkWindow = new C1.Win.C1Command.C1CommandLink();
            this.snapFormExtender = new SnapFormExtender.SnapFormExtender(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapFormExtender)).BeginInit();
            this.SuspendLayout();
            // 
            // c1CommandHolder
            // 
            this.c1CommandHolder.Commands.Add(this.cmdMenuFile);
            this.c1CommandHolder.Commands.Add(this.cmdMenuView);
            this.c1CommandHolder.Commands.Add(this.cmdMenuWindow);
            this.c1CommandHolder.Commands.Add(this.cmdTheme);
            this.c1CommandHolder.Commands.Add(this.cmdScanArea);
            this.c1CommandHolder.Commands.Add(this.cmdSysSettings);
            this.c1CommandHolder.Commands.Add(this.cmdScanSettings);
            this.c1CommandHolder.Commands.Add(this.cmdScanParas);
            this.c1CommandHolder.Commands.Add(this.cmdScanImage);
            this.c1CommandHolder.Commands.Add(this.cmdImageSettings);
            this.c1CommandHolder.Owner = this;
            // 
            // cmdMenuFile
            // 
            this.cmdMenuFile.HideNonRecentLinks = false;
            this.cmdMenuFile.Name = "cmdMenuFile";
            this.cmdMenuFile.ShortcutText = "";
            this.cmdMenuFile.Text = "文件（&F）";
            // 
            // cmdMenuView
            // 
            this.cmdMenuView.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.cmdLinkTheme});
            this.cmdMenuView.HideNonRecentLinks = false;
            this.cmdMenuView.Name = "cmdMenuView";
            this.cmdMenuView.ShortcutText = "";
            this.cmdMenuView.Text = "视图（&V）";
            // 
            // cmdLinkTheme
            // 
            this.cmdLinkTheme.Command = this.cmdTheme;
            // 
            // cmdTheme
            // 
            this.cmdTheme.Name = "cmdTheme";
            this.cmdTheme.ShortcutText = "";
            this.cmdTheme.Text = "主题（&T）";
            this.cmdTheme.Click += new C1.Win.C1Command.ClickEventHandler(this.ThemeClick);
            // 
            // cmdMenuWindow
            // 
            this.cmdMenuWindow.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.cmdLinkScanArea,
            this.cmdLinkSysSettings,
            this.cmdLinkScanSettings,
            this.cmdLinkScanParas,
            this.cmdLinkScanImage,
            this.cmdLinkImageSettings});
            this.cmdMenuWindow.HideNonRecentLinks = false;
            this.cmdMenuWindow.Name = "cmdMenuWindow";
            this.cmdMenuWindow.ShortcutText = "";
            this.cmdMenuWindow.Text = "窗口（&W）";
            // 
            // cmdLinkScanArea
            // 
            this.cmdLinkScanArea.Command = this.cmdScanArea;
            // 
            // cmdScanArea
            // 
            this.cmdScanArea.CheckAutoToggle = true;
            this.cmdScanArea.Name = "cmdScanArea";
            this.cmdScanArea.ShortcutText = "";
            this.cmdScanArea.Text = "扫描区域（&A）";
            this.cmdScanArea.Click += new C1.Win.C1Command.ClickEventHandler(this.ScanAreaClick);
            // 
            // cmdLinkSysSettings
            // 
            this.cmdLinkSysSettings.Command = this.cmdSysSettings;
            this.cmdLinkSysSettings.SortOrder = 1;
            // 
            // cmdSysSettings
            // 
            this.cmdSysSettings.CheckAutoToggle = true;
            this.cmdSysSettings.Name = "cmdSysSettings";
            this.cmdSysSettings.ShortcutText = "";
            this.cmdSysSettings.Text = "系统设置（&S）";
            this.cmdSysSettings.Click += new C1.Win.C1Command.ClickEventHandler(this.SysSettingsClick);
            // 
            // cmdLinkScanSettings
            // 
            this.cmdLinkScanSettings.Command = this.cmdScanSettings;
            this.cmdLinkScanSettings.SortOrder = 2;
            // 
            // cmdScanSettings
            // 
            this.cmdScanSettings.CheckAutoToggle = true;
            this.cmdScanSettings.Name = "cmdScanSettings";
            this.cmdScanSettings.ShortcutText = "";
            this.cmdScanSettings.Text = "扫描设置（&C）";
            this.cmdScanSettings.Click += new C1.Win.C1Command.ClickEventHandler(this.ScanSettingsClick);
            // 
            // cmdLinkScanParas
            // 
            this.cmdLinkScanParas.Command = this.cmdScanParas;
            this.cmdLinkScanParas.SortOrder = 3;
            // 
            // cmdScanParas
            // 
            this.cmdScanParas.CheckAutoToggle = true;
            this.cmdScanParas.Name = "cmdScanParas";
            this.cmdScanParas.ShortcutText = "";
            this.cmdScanParas.Text = "扫描参数（&P）";
            this.cmdScanParas.Click += new C1.Win.C1Command.ClickEventHandler(this.ScanParasClick);
            // 
            // cmdLinkScanImage
            // 
            this.cmdLinkScanImage.Command = this.cmdScanImage;
            this.cmdLinkScanImage.SortOrder = 4;
            // 
            // cmdScanImage
            // 
            this.cmdScanImage.Name = "cmdScanImage";
            this.cmdScanImage.ShortcutText = "";
            this.cmdScanImage.Text = "扫描图像（&I）";
            this.cmdScanImage.Click += new C1.Win.C1Command.ClickEventHandler(this.ScanImageClick);
            // 
            // cmdLinkImageSettings
            // 
            this.cmdLinkImageSettings.Command = this.cmdImageSettings;
            this.cmdLinkImageSettings.SortOrder = 5;
            this.cmdLinkImageSettings.Text = "图像调节（&H）";
            // 
            // cmdImageSettings
            // 
            this.cmdImageSettings.CheckAutoToggle = true;
            this.cmdImageSettings.Name = "cmdImageSettings";
            this.cmdImageSettings.ShortcutText = "";
            this.cmdImageSettings.Text = "图像调节";
            this.cmdImageSettings.Click += new C1.Win.C1Command.ClickEventHandler(this.ImageSettingsClick);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 945);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1592, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // mainMenu
            // 
            this.mainMenu.AccessibleName = "Menu Bar";
            this.mainMenu.CommandHolder = null;
            this.mainMenu.CommandLinks.AddRange(new C1.Win.C1Command.C1CommandLink[] {
            this.cmdLinkFile,
            this.cmdLinkView,
            this.cmdLinkWindow});
            this.mainMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1592, 26);
            this.mainMenu.VisualStyle = C1.Win.C1Command.VisualStyle.Custom;
            this.mainMenu.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // cmdLinkFile
            // 
            this.cmdLinkFile.Command = this.cmdMenuFile;
            // 
            // cmdLinkView
            // 
            this.cmdLinkView.Command = this.cmdMenuView;
            this.cmdLinkView.SortOrder = 1;
            // 
            // cmdLinkWindow
            // 
            this.cmdLinkWindow.Command = this.cmdMenuWindow;
            this.cmdLinkWindow.SortOrder = 2;
            // 
            // snapFormExtender
            // 
            this.snapFormExtender.Distance = 10;
            this.snapFormExtender.Form = this;
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1592, 967);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.mainMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nano Insight v";
            this.VisualStyleHolder = C1.Win.C1Ribbon.VisualStyle.Custom;
            this.Load += new System.EventHandler(this.MainViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.snapFormExtender)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder;
        private System.Windows.Forms.StatusStrip statusStrip;
        private C1.Win.C1Command.C1CommandMenu cmdMenuFile;
        private C1.Win.C1Command.C1MainMenu mainMenu;
        private C1.Win.C1Command.C1CommandLink cmdLinkFile;
        private C1.Win.C1Command.C1CommandLink cmdLinkView;
        private C1.Win.C1Command.C1CommandLink cmdLinkWindow;
        private C1.Win.C1Command.C1CommandMenu cmdMenuView;
        private C1.Win.C1Command.C1CommandMenu cmdMenuWindow;
        private C1.Win.C1Command.C1CommandLink cmdLinkTheme;
        private C1.Win.C1Command.C1Command cmdTheme;
        private C1.Win.C1Command.C1CommandLink cmdLinkScanArea;
        private C1.Win.C1Command.C1Command cmdScanArea;
        private C1.Win.C1Command.C1CommandLink cmdLinkSysSettings;
        private C1.Win.C1Command.C1Command cmdSysSettings;
        private C1.Win.C1Command.C1CommandLink cmdLinkScanSettings;
        private C1.Win.C1Command.C1Command cmdScanSettings;
        private C1.Win.C1Command.C1CommandLink cmdLinkScanParas;
        private C1.Win.C1Command.C1Command cmdScanParas;
        private SnapFormExtender.SnapFormExtender snapFormExtender;
        private C1.Win.C1Command.C1CommandLink cmdLinkScanImage;
        private C1.Win.C1Command.C1Command cmdScanImage;
        private C1.Win.C1Command.C1CommandLink cmdLinkImageSettings;
        private C1.Win.C1Command.C1Command cmdImageSettings;
    }
}