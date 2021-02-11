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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainView));
            this.c1CommandHolder = new C1.Win.C1Command.C1CommandHolder();
            this.cmdMenuFile = new C1.Win.C1Command.C1CommandMenu();
            this.cmdMenuView = new C1.Win.C1Command.C1CommandMenu();
            this.cmdLinkTheme = new C1.Win.C1Command.C1CommandLink();
            this.cmdTheme = new C1.Win.C1Command.C1Command();
            this.cmdMenuWindow = new C1.Win.C1Command.C1CommandMenu();
            this.cmdLinkScanArea = new C1.Win.C1Command.C1CommandLink();
            this.cmdScanArea = new C1.Win.C1Command.C1Command();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.mainMenu = new C1.Win.C1Command.C1MainMenu();
            this.cmdLinkFile = new C1.Win.C1Command.C1CommandLink();
            this.cmdLinkView = new C1.Win.C1Command.C1CommandLink();
            this.cmdLinkWindow = new C1.Win.C1Command.C1CommandLink();
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.lbSelectLaser = new System.Windows.Forms.ToolStripLabel();
            this.cbxSelectLaser = new System.Windows.Forms.ToolStripComboBox();
            this.btnLaserConnect = new System.Windows.Forms.ToolStripButton();
            this.btnLaserRelease = new System.Windows.Forms.ToolStripButton();
            this.dockToolBar = new C1.Win.C1Command.C1CommandDock();
            this.toolBar = new C1.Win.C1Command.C1ToolBar();
            this.cmdLinkSysSettings = new C1.Win.C1Command.C1CommandLink();
            this.cmdSysSettings = new C1.Win.C1Command.C1Command();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder)).BeginInit();
            this.toolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockToolBar)).BeginInit();
            this.dockToolBar.SuspendLayout();
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
            this.cmdLinkSysSettings});
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
            this.cmdScanArea.Name = "cmdScanArea";
            this.cmdScanArea.ShortcutText = "";
            this.cmdScanArea.Text = "扫描区域（&S）";
            this.cmdScanArea.Click += new C1.Win.C1Command.ClickEventHandler(this.ScanAreaClick);
            // 
            // statusStrip
            // 
            this.statusStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Location = new System.Drawing.Point(0, 739);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1184, 22);
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
            this.mainMenu.Size = new System.Drawing.Size(1184, 26);
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
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbSelectLaser,
            this.cbxSelectLaser,
            this.btnLaserConnect,
            this.btnLaserRelease});
            this.toolStrip.Location = new System.Drawing.Point(0, 26);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1184, 25);
            this.toolStrip.TabIndex = 15;
            this.toolStrip.Text = "toolStrip1";
            // 
            // lbSelectLaser
            // 
            this.lbSelectLaser.Name = "lbSelectLaser";
            this.lbSelectLaser.Size = new System.Drawing.Size(59, 22);
            this.lbSelectLaser.Text = "激光端口:";
            // 
            // cbxSelectLaser
            // 
            this.cbxSelectLaser.BackColor = System.Drawing.SystemColors.Control;
            this.cbxSelectLaser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSelectLaser.Font = new System.Drawing.Font("微软雅黑", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxSelectLaser.Items.AddRange(new object[] {
            "COM1",
            "COM2",
            "COM3",
            "COM4",
            "COM5",
            "COM6",
            "COM7",
            "COM8"});
            this.cbxSelectLaser.Name = "cbxSelectLaser";
            this.cbxSelectLaser.Size = new System.Drawing.Size(75, 25);
            // 
            // btnLaserConnect
            // 
            this.btnLaserConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLaserConnect.Image = ((System.Drawing.Image)(resources.GetObject("btnLaserConnect.Image")));
            this.btnLaserConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLaserConnect.Name = "btnLaserConnect";
            this.btnLaserConnect.Size = new System.Drawing.Size(23, 22);
            // 
            // btnLaserRelease
            // 
            this.btnLaserRelease.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnLaserRelease.Image = ((System.Drawing.Image)(resources.GetObject("btnLaserRelease.Image")));
            this.btnLaserRelease.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnLaserRelease.Name = "btnLaserRelease";
            this.btnLaserRelease.Size = new System.Drawing.Size(23, 22);
            // 
            // dockToolBar
            // 
            this.dockToolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dockToolBar.Controls.Add(this.toolBar);
            this.dockToolBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.dockToolBar.Id = 3;
            this.dockToolBar.Location = new System.Drawing.Point(0, 51);
            this.dockToolBar.Name = "dockToolBar";
            this.dockToolBar.Size = new System.Drawing.Size(1184, 28);
            // 
            // toolBar
            // 
            this.toolBar.AccessibleName = "Tool Bar";
            this.toolBar.CommandHolder = null;
            this.toolBar.Location = new System.Drawing.Point(3, 0);
            this.toolBar.Name = "toolBar";
            this.toolBar.Size = new System.Drawing.Size(25, 25);
            this.toolBar.Text = "工具栏";
            this.toolBar.VisualStyle = C1.Win.C1Command.VisualStyle.Custom;
            this.toolBar.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2010Blue;
            // 
            // cmdLinkSysSettings
            // 
            this.cmdLinkSysSettings.Command = this.cmdSysSettings;
            this.cmdLinkSysSettings.SortOrder = 1;
            // 
            // cmdSysSettings
            // 
            this.cmdSysSettings.Name = "cmdSysSettings";
            this.cmdSysSettings.ShortcutText = "";
            this.cmdSysSettings.Text = "系统设置（&S）";
            this.cmdSysSettings.Click += new C1.Win.C1Command.ClickEventHandler(this.SysSettingsClick);
            // 
            // MainView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 761);
            this.Controls.Add(this.dockToolBar);
            this.Controls.Add(this.toolStrip);
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
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dockToolBar)).EndInit();
            this.dockToolBar.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripLabel lbSelectLaser;
        private System.Windows.Forms.ToolStripComboBox cbxSelectLaser;
        private System.Windows.Forms.ToolStripButton btnLaserConnect;
        private System.Windows.Forms.ToolStripButton btnLaserRelease;
        private C1.Win.C1Command.C1CommandDock dockToolBar;
        private C1.Win.C1Command.C1ToolBar toolBar;
        private C1.Win.C1Command.C1CommandLink cmdLinkScanArea;
        private C1.Win.C1Command.C1Command cmdScanArea;
        private C1.Win.C1Command.C1CommandLink cmdLinkSysSettings;
        private C1.Win.C1Command.C1Command cmdSysSettings;
    }
}