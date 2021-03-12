namespace NanoInsight.Viewer.View
{
    partial class ScanImageView
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
            this.dockToolBar = new C1.Win.C1Command.C1CommandDock();
            this.toolBar = new C1.Win.C1Command.C1ToolBar();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lbPixelSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbScanPixel = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbBitDepth = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbFps = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbFrame = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbTimeSpan = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbCurrent = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.pageAll = new System.Windows.Forms.TabPage();
            this.imageAll = new Emgu.CV.UI.ImageBox();
            this.page405 = new System.Windows.Forms.TabPage();
            this.image405 = new Emgu.CV.UI.ImageBox();
            this.page488 = new System.Windows.Forms.TabPage();
            this.image488 = new Emgu.CV.UI.ImageBox();
            this.page561 = new System.Windows.Forms.TabPage();
            this.image561 = new Emgu.CV.UI.ImageBox();
            this.page640 = new System.Windows.Forms.TabPage();
            this.image640 = new Emgu.CV.UI.ImageBox();
            this.mImageTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dockToolBar)).BeginInit();
            this.dockToolBar.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.pageAll.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageAll)).BeginInit();
            this.page405.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image405)).BeginInit();
            this.page488.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image488)).BeginInit();
            this.page561.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image561)).BeginInit();
            this.page640.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image640)).BeginInit();
            this.SuspendLayout();
            // 
            // dockToolBar
            // 
            this.dockToolBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(246)))), ((int)(((byte)(253)))));
            this.dockToolBar.Controls.Add(this.toolBar);
            this.dockToolBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.dockToolBar.Id = 3;
            this.dockToolBar.Location = new System.Drawing.Point(0, 0);
            this.dockToolBar.Name = "dockToolBar";
            this.dockToolBar.Size = new System.Drawing.Size(592, 27);
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
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lbPixelSize,
            this.lbScanPixel,
            this.lbBitDepth,
            this.lbFps,
            this.lbFrame,
            this.lbTimeSpan,
            this.lbCurrent});
            this.statusStrip.Location = new System.Drawing.Point(0, 543);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip.Size = new System.Drawing.Size(592, 26);
            this.statusStrip.TabIndex = 14;
            this.statusStrip.Text = "statusStrip";
            // 
            // lbPixelSize
            // 
            this.lbPixelSize.BackColor = System.Drawing.Color.Transparent;
            this.lbPixelSize.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbPixelSize.Name = "lbPixelSize";
            this.lbPixelSize.Size = new System.Drawing.Size(68, 21);
            this.lbPixelSize.Text = "{0} um/px";
            // 
            // lbScanPixel
            // 
            this.lbScanPixel.BackColor = System.Drawing.Color.Transparent;
            this.lbScanPixel.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbScanPixel.Name = "lbScanPixel";
            this.lbScanPixel.Size = new System.Drawing.Size(105, 21);
            this.lbScanPixel.Text = "512 x 512 pixels";
            // 
            // lbBitDepth
            // 
            this.lbBitDepth.BackColor = System.Drawing.Color.Transparent;
            this.lbBitDepth.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbBitDepth.Name = "lbBitDepth";
            this.lbBitDepth.Size = new System.Drawing.Size(47, 21);
            this.lbBitDepth.Text = "16bits";
            // 
            // lbFps
            // 
            this.lbFps.BackColor = System.Drawing.Color.Transparent;
            this.lbFps.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbFps.Name = "lbFps";
            this.lbFps.Size = new System.Drawing.Size(58, 21);
            this.lbFps.Text = "1.28 fps";
            // 
            // lbFrame
            // 
            this.lbFrame.BackColor = System.Drawing.Color.Transparent;
            this.lbFrame.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbFrame.Name = "lbFrame";
            this.lbFrame.Size = new System.Drawing.Size(84, 21);
            this.lbFrame.Text = "NO. 1 frame";
            // 
            // lbTimeSpan
            // 
            this.lbTimeSpan.BackColor = System.Drawing.Color.Transparent;
            this.lbTimeSpan.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbTimeSpan.Name = "lbTimeSpan";
            this.lbTimeSpan.Size = new System.Drawing.Size(76, 21);
            this.lbTimeSpan.Text = "xx seconds";
            // 
            // lbCurrent
            // 
            this.lbCurrent.BackColor = System.Drawing.Color.Transparent;
            this.lbCurrent.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.lbCurrent.Name = "lbCurrent";
            this.lbCurrent.Size = new System.Drawing.Size(105, 21);
            this.lbCurrent.Text = "[255, (512, 512)]";
            // 
            // tabControl
            // 
            this.tabControl.Alignment = System.Windows.Forms.TabAlignment.Bottom;
            this.tabControl.Controls.Add(this.pageAll);
            this.tabControl.Controls.Add(this.page405);
            this.tabControl.Controls.Add(this.page488);
            this.tabControl.Controls.Add(this.page561);
            this.tabControl.Controls.Add(this.page640);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 27);
            this.tabControl.Margin = new System.Windows.Forms.Padding(0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(592, 516);
            this.tabControl.TabIndex = 22;
            // 
            // pageAll
            // 
            this.pageAll.BackColor = System.Drawing.Color.Transparent;
            this.pageAll.Controls.Add(this.imageAll);
            this.pageAll.Location = new System.Drawing.Point(4, 4);
            this.pageAll.Margin = new System.Windows.Forms.Padding(0);
            this.pageAll.Name = "pageAll";
            this.pageAll.Size = new System.Drawing.Size(584, 490);
            this.pageAll.TabIndex = 0;
            this.pageAll.Tag = "-1";
            this.pageAll.Text = "全部";
            // 
            // imageAll
            // 
            this.imageAll.BackColor = System.Drawing.Color.Black;
            this.imageAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imageAll.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.imageAll.Location = new System.Drawing.Point(0, 0);
            this.imageAll.Margin = new System.Windows.Forms.Padding(0);
            this.imageAll.Name = "imageAll";
            this.imageAll.Size = new System.Drawing.Size(584, 490);
            this.imageAll.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imageAll.TabIndex = 2;
            this.imageAll.TabStop = false;
            this.imageAll.Tag = "-1";
            // 
            // page405
            // 
            this.page405.BackColor = System.Drawing.Color.Transparent;
            this.page405.Controls.Add(this.image405);
            this.page405.Location = new System.Drawing.Point(4, 4);
            this.page405.Margin = new System.Windows.Forms.Padding(0);
            this.page405.Name = "page405";
            this.page405.Size = new System.Drawing.Size(584, 490);
            this.page405.TabIndex = 1;
            this.page405.Tag = "0";
            this.page405.Text = "405nm";
            // 
            // image405
            // 
            this.image405.BackColor = System.Drawing.Color.Black;
            this.image405.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image405.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.RightClickMenu;
            this.image405.Location = new System.Drawing.Point(0, 0);
            this.image405.Margin = new System.Windows.Forms.Padding(0);
            this.image405.Name = "image405";
            this.image405.Size = new System.Drawing.Size(584, 490);
            this.image405.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image405.TabIndex = 2;
            this.image405.TabStop = false;
            this.image405.Tag = "0";
            // 
            // page488
            // 
            this.page488.BackColor = System.Drawing.Color.Transparent;
            this.page488.Controls.Add(this.image488);
            this.page488.Location = new System.Drawing.Point(4, 4);
            this.page488.Margin = new System.Windows.Forms.Padding(0);
            this.page488.Name = "page488";
            this.page488.Size = new System.Drawing.Size(584, 490);
            this.page488.TabIndex = 2;
            this.page488.Tag = "1";
            this.page488.Text = "488nm";
            // 
            // image488
            // 
            this.image488.BackColor = System.Drawing.Color.Black;
            this.image488.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image488.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.image488.Location = new System.Drawing.Point(0, 0);
            this.image488.Margin = new System.Windows.Forms.Padding(0);
            this.image488.Name = "image488";
            this.image488.Size = new System.Drawing.Size(584, 490);
            this.image488.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image488.TabIndex = 2;
            this.image488.TabStop = false;
            this.image488.Tag = "1";
            // 
            // page561
            // 
            this.page561.BackColor = System.Drawing.Color.Transparent;
            this.page561.Controls.Add(this.image561);
            this.page561.Location = new System.Drawing.Point(4, 4);
            this.page561.Margin = new System.Windows.Forms.Padding(0);
            this.page561.Name = "page561";
            this.page561.Size = new System.Drawing.Size(584, 490);
            this.page561.TabIndex = 3;
            this.page561.Tag = "2";
            this.page561.Text = "561nm";
            // 
            // image561
            // 
            this.image561.BackColor = System.Drawing.Color.Black;
            this.image561.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image561.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.image561.Location = new System.Drawing.Point(0, 0);
            this.image561.Margin = new System.Windows.Forms.Padding(0);
            this.image561.Name = "image561";
            this.image561.Size = new System.Drawing.Size(584, 490);
            this.image561.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image561.TabIndex = 3;
            this.image561.TabStop = false;
            this.image561.Tag = "2";
            // 
            // page640
            // 
            this.page640.BackColor = System.Drawing.Color.Transparent;
            this.page640.Controls.Add(this.image640);
            this.page640.Location = new System.Drawing.Point(4, 4);
            this.page640.Margin = new System.Windows.Forms.Padding(0);
            this.page640.Name = "page640";
            this.page640.Size = new System.Drawing.Size(584, 490);
            this.page640.TabIndex = 4;
            this.page640.Tag = "3";
            this.page640.Text = "640nm";
            // 
            // image640
            // 
            this.image640.BackColor = System.Drawing.Color.Black;
            this.image640.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image640.FunctionalMode = Emgu.CV.UI.ImageBox.FunctionalModeOption.Minimum;
            this.image640.Location = new System.Drawing.Point(0, 0);
            this.image640.Margin = new System.Windows.Forms.Padding(0);
            this.image640.Name = "image640";
            this.image640.Size = new System.Drawing.Size(584, 490);
            this.image640.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image640.TabIndex = 2;
            this.image640.TabStop = false;
            this.image640.Tag = "3";
            // 
            // mImageTimer
            // 
            this.mImageTimer.Tick += new System.EventHandler(this.ImageTimerTick);
            // 
            // ScanImageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(592, 569);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.dockToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.Name = "ScanImageView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "扫描图像";
            this.Load += new System.EventHandler(this.ScanImageViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.dockToolBar)).EndInit();
            this.dockToolBar.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.pageAll.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageAll)).EndInit();
            this.page405.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image405)).EndInit();
            this.page488.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image488)).EndInit();
            this.page561.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image561)).EndInit();
            this.page640.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.image640)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Command.C1CommandDock dockToolBar;
        private C1.Win.C1Command.C1ToolBar toolBar;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lbPixelSize;
        private System.Windows.Forms.ToolStripStatusLabel lbScanPixel;
        private System.Windows.Forms.ToolStripStatusLabel lbBitDepth;
        private System.Windows.Forms.ToolStripStatusLabel lbFps;
        private System.Windows.Forms.ToolStripStatusLabel lbFrame;
        private System.Windows.Forms.ToolStripStatusLabel lbTimeSpan;
        private System.Windows.Forms.ToolStripStatusLabel lbCurrent;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage pageAll;
        private Emgu.CV.UI.ImageBox imageAll;
        private System.Windows.Forms.TabPage page405;
        private Emgu.CV.UI.ImageBox image405;
        private System.Windows.Forms.TabPage page488;
        private Emgu.CV.UI.ImageBox image488;
        private System.Windows.Forms.TabPage page561;
        private Emgu.CV.UI.ImageBox image561;
        private System.Windows.Forms.TabPage page640;
        private Emgu.CV.UI.ImageBox image640;
        private System.Windows.Forms.Timer mImageTimer;
    }
}