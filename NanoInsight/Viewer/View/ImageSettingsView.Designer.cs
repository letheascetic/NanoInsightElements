
namespace NanoInsight.Viewer.View
{
    partial class ImageSettingsView
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
            this.dockToolBar = new C1.Win.C1Command.C1CommandDock();
            this.toolBar = new C1.Win.C1Command.C1ToolBar();
            this.c1CommandHolder = new C1.Win.C1Command.C1CommandHolder();
            this.histogramBox = new Emgu.CV.UI.HistogramBox();
            this.inputPanel = new C1.Win.C1InputPanel.C1InputPanel();
            this.inputSeparator1 = new C1.Win.C1InputPanel.InputSeparator();
            this.lbBrightness = new C1.Win.C1InputPanel.InputLabel();
            this.tbrBrightness = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbxBrightness = new C1.Win.C1InputPanel.InputTextBox();
            this.lbContrast = new C1.Win.C1InputPanel.InputLabel();
            this.tbarContrast = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbxContrast = new C1.Win.C1InputPanel.InputTextBox();
            this.lbGamma = new C1.Win.C1InputPanel.InputLabel();
            this.tbarGamma = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbxGamma = new C1.Win.C1InputPanel.InputTextBox();
            this.lbMinimum = new C1.Win.C1InputPanel.InputLabel();
            this.nbMinimum = new C1.Win.C1InputPanel.InputNumericBox();
            this.lbMaximum = new C1.Win.C1InputPanel.InputLabel();
            this.nbMaximum = new C1.Win.C1InputPanel.InputNumericBox();
            this.inputComboBox1 = new C1.Win.C1InputPanel.InputComboBox();
            this.lbChannel = new C1.Win.C1InputPanel.InputLabel();
            this.btnPseudoColor = new C1.Win.C1InputPanel.InputButton();
            this.cbxImageColor = new C1.Win.C1InputPanel.InputComboBox();
            this.lbImageColor = new C1.Win.C1InputPanel.InputLabel();
            this.inputSeparator2 = new C1.Win.C1InputPanel.InputSeparator();
            this.lbPseudoColor = new C1.Win.C1InputPanel.InputLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dockToolBar)).BeginInit();
            this.dockToolBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPanel)).BeginInit();
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
            this.dockToolBar.Size = new System.Drawing.Size(272, 26);
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
            // c1CommandHolder
            // 
            this.c1CommandHolder.Owner = this;
            // 
            // histogramBox
            // 
            this.histogramBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.histogramBox.Location = new System.Drawing.Point(0, 31);
            this.histogramBox.Name = "histogramBox";
            this.histogramBox.Size = new System.Drawing.Size(272, 176);
            this.histogramBox.TabIndex = 2;
            // 
            // inputPanel
            // 
            this.inputPanel.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.inputPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.inputPanel.Items.Add(this.inputSeparator1);
            this.inputPanel.Items.Add(this.lbImageColor);
            this.inputPanel.Items.Add(this.cbxImageColor);
            this.inputPanel.Items.Add(this.inputSeparator2);
            this.inputPanel.Items.Add(this.lbChannel);
            this.inputPanel.Items.Add(this.inputComboBox1);
            this.inputPanel.Items.Add(this.lbPseudoColor);
            this.inputPanel.Items.Add(this.btnPseudoColor);
            this.inputPanel.Items.Add(this.lbBrightness);
            this.inputPanel.Items.Add(this.tbrBrightness);
            this.inputPanel.Items.Add(this.tbxBrightness);
            this.inputPanel.Items.Add(this.lbContrast);
            this.inputPanel.Items.Add(this.tbarContrast);
            this.inputPanel.Items.Add(this.tbxContrast);
            this.inputPanel.Items.Add(this.lbGamma);
            this.inputPanel.Items.Add(this.tbarGamma);
            this.inputPanel.Items.Add(this.tbxGamma);
            this.inputPanel.Items.Add(this.lbMinimum);
            this.inputPanel.Items.Add(this.nbMinimum);
            this.inputPanel.Items.Add(this.lbMaximum);
            this.inputPanel.Items.Add(this.nbMaximum);
            this.inputPanel.Location = new System.Drawing.Point(0, 213);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(272, 216);
            this.inputPanel.TabIndex = 19;
            // 
            // inputSeparator1
            // 
            this.inputSeparator1.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.inputSeparator1.Name = "inputSeparator1";
            this.inputSeparator1.Width = 260;
            // 
            // lbBrightness
            // 
            this.lbBrightness.Name = "lbBrightness";
            this.lbBrightness.Text = "亮度";
            this.lbBrightness.Width = 40;
            // 
            // tbrBrightness
            // 
            this.tbrBrightness.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbrBrightness.Maximum = 100;
            this.tbrBrightness.Name = "tbrBrightness";
            this.tbrBrightness.Width = 160;
            // 
            // tbxBrightness
            // 
            this.tbxBrightness.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxBrightness.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxBrightness.Name = "tbxBrightness";
            this.tbxBrightness.Width = 40;
            // 
            // lbContrast
            // 
            this.lbContrast.Name = "lbContrast";
            this.lbContrast.Text = "对比度";
            this.lbContrast.Width = 40;
            // 
            // tbarContrast
            // 
            this.tbarContrast.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbarContrast.Maximum = 100;
            this.tbarContrast.Name = "tbarContrast";
            this.tbarContrast.Width = 160;
            // 
            // tbxContrast
            // 
            this.tbxContrast.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxContrast.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxContrast.Name = "tbxContrast";
            this.tbxContrast.Width = 40;
            // 
            // lbGamma
            // 
            this.lbGamma.Name = "lbGamma";
            this.lbGamma.Text = "伽马";
            this.lbGamma.Width = 40;
            // 
            // tbarGamma
            // 
            this.tbarGamma.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbarGamma.Maximum = 100;
            this.tbarGamma.Name = "tbarGamma";
            this.tbarGamma.Width = 160;
            // 
            // tbxGamma
            // 
            this.tbxGamma.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxGamma.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxGamma.Name = "tbxGamma";
            this.tbxGamma.Width = 40;
            // 
            // lbMinimum
            // 
            this.lbMinimum.Name = "lbMinimum";
            this.lbMinimum.Text = "最小值";
            this.lbMinimum.Width = 40;
            // 
            // nbMinimum
            // 
            this.nbMinimum.Break = C1.Win.C1InputPanel.BreakType.Column;
            this.nbMinimum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nbMinimum.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.nbMinimum.Name = "nbMinimum";
            this.nbMinimum.Width = 40;
            // 
            // lbMaximum
            // 
            this.lbMaximum.Name = "lbMaximum";
            this.lbMaximum.Text = "最大值";
            this.lbMaximum.Width = 40;
            // 
            // nbMaximum
            // 
            this.nbMaximum.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.nbMaximum.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nbMaximum.Name = "nbMaximum";
            this.nbMaximum.Width = 40;
            // 
            // inputComboBox1
            // 
            this.inputComboBox1.Break = C1.Win.C1InputPanel.BreakType.None;
            this.inputComboBox1.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList;
            this.inputComboBox1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.inputComboBox1.Name = "inputComboBox1";
            this.inputComboBox1.Width = 50;
            // 
            // lbChannel
            // 
            this.lbChannel.Name = "lbChannel";
            this.lbChannel.Text = "通道";
            // 
            // btnPseudoColor
            // 
            this.btnPseudoColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPseudoColor.Name = "btnPseudoColor";
            this.btnPseudoColor.Width = 25;
            // 
            // cbxImageColor
            // 
            this.cbxImageColor.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.cbxImageColor.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList;
            this.cbxImageColor.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxImageColor.Name = "cbxImageColor";
            this.cbxImageColor.Width = 50;
            // 
            // lbImageColor
            // 
            this.lbImageColor.Name = "lbImageColor";
            this.lbImageColor.Text = "图像色彩";
            // 
            // inputSeparator2
            // 
            this.inputSeparator2.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.inputSeparator2.Name = "inputSeparator2";
            this.inputSeparator2.Width = 260;
            // 
            // lbPseudoColor
            // 
            this.lbPseudoColor.Name = "lbPseudoColor";
            this.lbPseudoColor.Text = "图像色彩";
            // 
            // ImageSettingsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 429);
            this.Controls.Add(this.inputPanel);
            this.Controls.Add(this.histogramBox);
            this.Controls.Add(this.dockToolBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ImageSettingsView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "图像调整";
            ((System.ComponentModel.ISupportInitialize)(this.dockToolBar)).EndInit();
            this.dockToolBar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.c1CommandHolder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inputPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1Command.C1CommandDock dockToolBar;
        private C1.Win.C1Command.C1ToolBar toolBar;
        private C1.Win.C1Command.C1CommandHolder c1CommandHolder;
        private Emgu.CV.UI.HistogramBox histogramBox;
        private C1.Win.C1InputPanel.C1InputPanel inputPanel;
        private C1.Win.C1InputPanel.InputSeparator inputSeparator1;
        private C1.Win.C1InputPanel.InputLabel lbBrightness;
        private C1.Win.C1InputPanel.InputTrackBar tbrBrightness;
        private C1.Win.C1InputPanel.InputTextBox tbxBrightness;
        private C1.Win.C1InputPanel.InputLabel lbContrast;
        private C1.Win.C1InputPanel.InputTrackBar tbarContrast;
        private C1.Win.C1InputPanel.InputTextBox tbxContrast;
        private C1.Win.C1InputPanel.InputLabel lbGamma;
        private C1.Win.C1InputPanel.InputTrackBar tbarGamma;
        private C1.Win.C1InputPanel.InputTextBox tbxGamma;
        private C1.Win.C1InputPanel.InputLabel lbMinimum;
        private C1.Win.C1InputPanel.InputLabel lbMaximum;
        private C1.Win.C1InputPanel.InputNumericBox nbMinimum;
        private C1.Win.C1InputPanel.InputNumericBox nbMaximum;
        private C1.Win.C1InputPanel.InputLabel lbChannel;
        private C1.Win.C1InputPanel.InputComboBox inputComboBox1;
        private C1.Win.C1InputPanel.InputButton btnPseudoColor;
        private C1.Win.C1InputPanel.InputComboBox cbxImageColor;
        private C1.Win.C1InputPanel.InputLabel lbImageColor;
        private C1.Win.C1InputPanel.InputSeparator inputSeparator2;
        private C1.Win.C1InputPanel.InputLabel lbPseudoColor;
    }
}