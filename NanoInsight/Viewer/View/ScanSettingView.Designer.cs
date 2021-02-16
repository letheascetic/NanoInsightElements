
namespace NanoInsight.Viewer.View
{
    partial class ScanSettingView
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
            this.inputPanel = new C1.Win.C1InputPanel.C1InputPanel();
            this.btnLive = new C1.Win.C1InputPanel.InputButton();
            this.btnCapture = new C1.Win.C1InputPanel.InputButton();
            this.rbtnTwoScanners = new C1.Win.C1InputPanel.InputRadioButton();
            this.rbtnThreeScanners = new C1.Win.C1InputPanel.InputRadioButton();
            this.rbtnGalvano = new C1.Win.C1InputPanel.InputRadioButton();
            this.rbtnResonant = new C1.Win.C1InputPanel.InputRadioButton();
            this.separator6 = new C1.Win.C1InputPanel.InputSeparator();
            this.btnUnidirection = new C1.Win.C1InputPanel.InputButton();
            this.btnBidirection = new C1.Win.C1InputPanel.InputButton();
            this.nbScanPixelCalibration = new C1.Win.C1InputPanel.InputNumericBox();
            this.chbxLineSkip = new C1.Win.C1InputPanel.InputCheckBox();
            this.cbxLineSkip = new C1.Win.C1InputPanel.InputComboBox();
            this.separator1 = new C1.Win.C1InputPanel.InputSeparator();
            this.lbPixelDwell = new C1.Win.C1InputPanel.InputLabel();
            this.nbScanPixelScale = new C1.Win.C1InputPanel.InputNumericBox();
            this.rbtnFastMode = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell2 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell4 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell6 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell8 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell10 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell20 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell50 = new C1.Win.C1InputPanel.InputButton();
            this.btnPixelDwell100 = new C1.Win.C1InputPanel.InputButton();
            this.separator2 = new C1.Win.C1InputPanel.InputSeparator();
            this.lbScanPixel = new C1.Win.C1InputPanel.InputLabel();
            this.btnScanPixel64 = new C1.Win.C1InputPanel.InputButton();
            this.btnScanPixel128 = new C1.Win.C1InputPanel.InputButton();
            this.btnScanPixel256 = new C1.Win.C1InputPanel.InputButton();
            this.btnScanPixel512 = new C1.Win.C1InputPanel.InputButton();
            this.btnScanPixel1024 = new C1.Win.C1InputPanel.InputButton();
            this.btnScanPixel2048 = new C1.Win.C1InputPanel.InputButton();
            this.btnScanPixel4096 = new C1.Win.C1InputPanel.InputButton();
            this.separator3 = new C1.Win.C1InputPanel.InputSeparator();
            this.btnLineOptionNormal = new C1.Win.C1InputPanel.InputButton();
            this.btnAveraging = new C1.Win.C1InputPanel.InputSplitButton();
            this.btnIntegrate = new C1.Win.C1InputPanel.InputSplitButton();
            this.chbxSequence = new C1.Win.C1InputPanel.InputCheckBox();
            this.btnSequence = new C1.Win.C1InputPanel.InputSplitButton();
            this.lbFPS = new C1.Win.C1InputPanel.InputLabel();
            this.lbFPSValue = new C1.Win.C1InputPanel.InputLabel();
            this.lbFrameTime = new C1.Win.C1InputPanel.InputLabel();
            this.lbFrameTimeValue = new C1.Win.C1InputPanel.InputLabel();
            this.separator4 = new C1.Win.C1InputPanel.InputSeparator();
            this.lbPinHoleSelect = new C1.Win.C1InputPanel.InputLabel();
            this.cbxPinHoleSelect = new C1.Win.C1InputPanel.InputComboBox();
            this.lbPinHole = new C1.Win.C1InputPanel.InputLabel();
            this.tbarPinHole = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbxPinHole = new C1.Win.C1InputPanel.InputTextBox();
            this.tbxPinHoleAU = new C1.Win.C1InputPanel.InputTextBox();
            this.separator5 = new C1.Win.C1InputPanel.InputSeparator();
            this.gh405 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lb405HV = new C1.Win.C1InputPanel.InputLabel();
            this.tbar405HV = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx405HV = new C1.Win.C1InputPanel.InputTextBox();
            this.lb405Offset = new C1.Win.C1InputPanel.InputLabel();
            this.tbar405Offset = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx405Offset = new C1.Win.C1InputPanel.InputTextBox();
            this.btn405Power = new C1.Win.C1InputPanel.InputButton();
            this.tbar405Power = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx405Power = new C1.Win.C1InputPanel.InputTextBox();
            this.gh488 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lb488HV = new C1.Win.C1InputPanel.InputLabel();
            this.tbar488HV = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx488HV = new C1.Win.C1InputPanel.InputTextBox();
            this.lb488Offset = new C1.Win.C1InputPanel.InputLabel();
            this.tbar488Offset = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx488Offset = new C1.Win.C1InputPanel.InputTextBox();
            this.btn488Power = new C1.Win.C1InputPanel.InputButton();
            this.tbar488Power = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx488Power = new C1.Win.C1InputPanel.InputTextBox();
            this.gh561 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lb561HV = new C1.Win.C1InputPanel.InputLabel();
            this.tbar561HV = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx561HV = new C1.Win.C1InputPanel.InputTextBox();
            this.lb561Offset = new C1.Win.C1InputPanel.InputLabel();
            this.tbar561Offset = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx561Offset = new C1.Win.C1InputPanel.InputTextBox();
            this.btn561Power = new C1.Win.C1InputPanel.InputButton();
            this.tbar561Power = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx561Power = new C1.Win.C1InputPanel.InputTextBox();
            this.gh640 = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lb640HV = new C1.Win.C1InputPanel.InputLabel();
            this.tbar640HV = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx640HV = new C1.Win.C1InputPanel.InputTextBox();
            this.lb640Offset = new C1.Win.C1InputPanel.InputLabel();
            this.tbar640Offset = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx640Offset = new C1.Win.C1InputPanel.InputTextBox();
            this.btn640Power = new C1.Win.C1InputPanel.InputButton();
            this.tbar640Power = new C1.Win.C1InputPanel.InputTrackBar();
            this.tbx640Power = new C1.Win.C1InputPanel.InputTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.inputPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // inputPanel
            // 
            this.inputPanel.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.inputPanel.DesignScaleFactor = 1.001042F;
            this.inputPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.inputPanel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.inputPanel.Items.Add(this.btnLive);
            this.inputPanel.Items.Add(this.btnCapture);
            this.inputPanel.Items.Add(this.rbtnTwoScanners);
            this.inputPanel.Items.Add(this.rbtnThreeScanners);
            this.inputPanel.Items.Add(this.rbtnGalvano);
            this.inputPanel.Items.Add(this.rbtnResonant);
            this.inputPanel.Items.Add(this.separator6);
            this.inputPanel.Items.Add(this.btnUnidirection);
            this.inputPanel.Items.Add(this.btnBidirection);
            this.inputPanel.Items.Add(this.nbScanPixelCalibration);
            this.inputPanel.Items.Add(this.chbxLineSkip);
            this.inputPanel.Items.Add(this.cbxLineSkip);
            this.inputPanel.Items.Add(this.separator1);
            this.inputPanel.Items.Add(this.lbPixelDwell);
            this.inputPanel.Items.Add(this.nbScanPixelScale);
            this.inputPanel.Items.Add(this.rbtnFastMode);
            this.inputPanel.Items.Add(this.btnPixelDwell2);
            this.inputPanel.Items.Add(this.btnPixelDwell4);
            this.inputPanel.Items.Add(this.btnPixelDwell6);
            this.inputPanel.Items.Add(this.btnPixelDwell8);
            this.inputPanel.Items.Add(this.btnPixelDwell10);
            this.inputPanel.Items.Add(this.btnPixelDwell20);
            this.inputPanel.Items.Add(this.btnPixelDwell50);
            this.inputPanel.Items.Add(this.btnPixelDwell100);
            this.inputPanel.Items.Add(this.separator2);
            this.inputPanel.Items.Add(this.lbScanPixel);
            this.inputPanel.Items.Add(this.btnScanPixel64);
            this.inputPanel.Items.Add(this.btnScanPixel128);
            this.inputPanel.Items.Add(this.btnScanPixel256);
            this.inputPanel.Items.Add(this.btnScanPixel512);
            this.inputPanel.Items.Add(this.btnScanPixel1024);
            this.inputPanel.Items.Add(this.btnScanPixel2048);
            this.inputPanel.Items.Add(this.btnScanPixel4096);
            this.inputPanel.Items.Add(this.separator3);
            this.inputPanel.Items.Add(this.btnLineOptionNormal);
            this.inputPanel.Items.Add(this.btnAveraging);
            this.inputPanel.Items.Add(this.btnIntegrate);
            this.inputPanel.Items.Add(this.chbxSequence);
            this.inputPanel.Items.Add(this.btnSequence);
            this.inputPanel.Items.Add(this.lbFPS);
            this.inputPanel.Items.Add(this.lbFPSValue);
            this.inputPanel.Items.Add(this.lbFrameTime);
            this.inputPanel.Items.Add(this.lbFrameTimeValue);
            this.inputPanel.Items.Add(this.separator4);
            this.inputPanel.Items.Add(this.lbPinHoleSelect);
            this.inputPanel.Items.Add(this.cbxPinHoleSelect);
            this.inputPanel.Items.Add(this.lbPinHole);
            this.inputPanel.Items.Add(this.tbarPinHole);
            this.inputPanel.Items.Add(this.tbxPinHole);
            this.inputPanel.Items.Add(this.tbxPinHoleAU);
            this.inputPanel.Items.Add(this.separator5);
            this.inputPanel.Items.Add(this.gh405);
            this.inputPanel.Items.Add(this.lb405HV);
            this.inputPanel.Items.Add(this.tbar405HV);
            this.inputPanel.Items.Add(this.tbx405HV);
            this.inputPanel.Items.Add(this.lb405Offset);
            this.inputPanel.Items.Add(this.tbar405Offset);
            this.inputPanel.Items.Add(this.tbx405Offset);
            this.inputPanel.Items.Add(this.btn405Power);
            this.inputPanel.Items.Add(this.tbar405Power);
            this.inputPanel.Items.Add(this.tbx405Power);
            this.inputPanel.Items.Add(this.gh488);
            this.inputPanel.Items.Add(this.lb488HV);
            this.inputPanel.Items.Add(this.tbar488HV);
            this.inputPanel.Items.Add(this.tbx488HV);
            this.inputPanel.Items.Add(this.lb488Offset);
            this.inputPanel.Items.Add(this.tbar488Offset);
            this.inputPanel.Items.Add(this.tbx488Offset);
            this.inputPanel.Items.Add(this.btn488Power);
            this.inputPanel.Items.Add(this.tbar488Power);
            this.inputPanel.Items.Add(this.tbx488Power);
            this.inputPanel.Items.Add(this.gh561);
            this.inputPanel.Items.Add(this.lb561HV);
            this.inputPanel.Items.Add(this.tbar561HV);
            this.inputPanel.Items.Add(this.tbx561HV);
            this.inputPanel.Items.Add(this.lb561Offset);
            this.inputPanel.Items.Add(this.tbar561Offset);
            this.inputPanel.Items.Add(this.tbx561Offset);
            this.inputPanel.Items.Add(this.btn561Power);
            this.inputPanel.Items.Add(this.tbar561Power);
            this.inputPanel.Items.Add(this.tbx561Power);
            this.inputPanel.Items.Add(this.gh640);
            this.inputPanel.Items.Add(this.lb640HV);
            this.inputPanel.Items.Add(this.tbar640HV);
            this.inputPanel.Items.Add(this.tbx640HV);
            this.inputPanel.Items.Add(this.lb640Offset);
            this.inputPanel.Items.Add(this.tbar640Offset);
            this.inputPanel.Items.Add(this.tbx640Offset);
            this.inputPanel.Items.Add(this.btn640Power);
            this.inputPanel.Items.Add(this.tbar640Power);
            this.inputPanel.Items.Add(this.tbx640Power);
            this.inputPanel.Location = new System.Drawing.Point(0, 0);
            this.inputPanel.Name = "inputPanel";
            this.inputPanel.Size = new System.Drawing.Size(272, 719);
            this.inputPanel.TabIndex = 4;
            // 
            // btnLive
            // 
            this.btnLive.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnLive.CheckOnClick = true;
            this.btnLive.Height = 40;
            this.btnLive.Name = "btnLive";
            this.btnLive.Text = "实时";
            this.btnLive.Width = 50;
            this.btnLive.Click += new System.EventHandler(this.LiveClick);
            // 
            // btnCapture
            // 
            this.btnCapture.Break = C1.Win.C1InputPanel.BreakType.Column;
            this.btnCapture.CheckOnClick = true;
            this.btnCapture.Height = 40;
            this.btnCapture.Name = "btnCapture";
            this.btnCapture.Text = "捕捉";
            this.btnCapture.Width = 50;
            this.btnCapture.Click += new System.EventHandler(this.CaptureClick);
            // 
            // rbtnTwoScanners
            // 
            this.rbtnTwoScanners.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnTwoScanners.GroupName = "Scanners";
            this.rbtnTwoScanners.Name = "rbtnTwoScanners";
            this.rbtnTwoScanners.Text = "双镜";
            // 
            // rbtnThreeScanners
            // 
            this.rbtnThreeScanners.Break = C1.Win.C1InputPanel.BreakType.Column;
            this.rbtnThreeScanners.Font = new System.Drawing.Font("宋体", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnThreeScanners.GroupName = "Scanners";
            this.rbtnThreeScanners.Name = "rbtnThreeScanners";
            this.rbtnThreeScanners.Text = "三镜";
            // 
            // rbtnGalvano
            // 
            this.rbtnGalvano.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnGalvano.GroupName = "ScanMode";
            this.rbtnGalvano.Name = "rbtnGalvano";
            this.rbtnGalvano.Text = "Galvano";
            this.rbtnGalvano.Width = 60;
            // 
            // rbtnResonant
            // 
            this.rbtnResonant.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.rbtnResonant.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnResonant.GroupName = "ScanMode";
            this.rbtnResonant.Name = "rbtnResonant";
            this.rbtnResonant.Text = "Resonant";
            // 
            // separator6
            // 
            this.separator6.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.separator6.Height = 10;
            this.separator6.Name = "separator6";
            this.separator6.Width = 240;
            // 
            // btnUnidirection
            // 
            this.btnUnidirection.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnUnidirection.CheckOnClick = true;
            this.btnUnidirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnUnidirection.Name = "btnUnidirection";
            this.btnUnidirection.Text = "单向";
            this.btnUnidirection.Click += new System.EventHandler(this.UnidirectionClick);
            // 
            // btnBidirection
            // 
            this.btnBidirection.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnBidirection.CheckOnClick = true;
            this.btnBidirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.btnBidirection.Name = "btnBidirection";
            this.btnBidirection.Text = "双向";
            this.btnBidirection.Click += new System.EventHandler(this.BidirectionClick);
            // 
            // nbScanPixelCalibration
            // 
            this.nbScanPixelCalibration.Break = C1.Win.C1InputPanel.BreakType.Column;
            this.nbScanPixelCalibration.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nbScanPixelCalibration.Name = "nbScanPixelCalibration";
            this.nbScanPixelCalibration.Width = 40;
            // 
            // chbxLineSkip
            // 
            this.chbxLineSkip.Break = C1.Win.C1InputPanel.BreakType.None;
            this.chbxLineSkip.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.chbxLineSkip.Name = "chbxLineSkip";
            this.chbxLineSkip.Text = "跳行扫描";
            // 
            // cbxLineSkip
            // 
            this.cbxLineSkip.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.cbxLineSkip.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList;
            this.cbxLineSkip.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxLineSkip.Name = "cbxLineSkip";
            this.cbxLineSkip.Width = 44;
            // 
            // separator1
            // 
            this.separator1.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.separator1.Height = 10;
            this.separator1.Name = "separator1";
            this.separator1.Width = 240;
            // 
            // lbPixelDwell
            // 
            this.lbPixelDwell.Break = C1.Win.C1InputPanel.BreakType.Column;
            this.lbPixelDwell.Height = 20;
            this.lbPixelDwell.Name = "lbPixelDwell";
            this.lbPixelDwell.Text = "像素时间（us）";
            this.lbPixelDwell.Width = 190;
            // 
            // nbScanPixelScale
            // 
            this.nbScanPixelScale.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.nbScanPixelScale.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.nbScanPixelScale.Maximum = new decimal(new int[] {
            24,
            0,
            0,
            0});
            this.nbScanPixelScale.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            -2147483648});
            this.nbScanPixelScale.Name = "nbScanPixelScale";
            this.nbScanPixelScale.Width = 40;
            // 
            // rbtnFastMode
            // 
            this.rbtnFastMode.Break = C1.Win.C1InputPanel.BreakType.None;
            this.rbtnFastMode.CheckOnClick = true;
            this.rbtnFastMode.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.rbtnFastMode.Name = "rbtnFastMode";
            this.rbtnFastMode.Text = "快速模式";
            // 
            // btnPixelDwell2
            // 
            this.btnPixelDwell2.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell2.CheckOnClick = true;
            this.btnPixelDwell2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell2.Name = "btnPixelDwell2";
            this.btnPixelDwell2.Text = "2";
            // 
            // btnPixelDwell4
            // 
            this.btnPixelDwell4.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell4.CheckOnClick = true;
            this.btnPixelDwell4.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell4.Name = "btnPixelDwell4";
            this.btnPixelDwell4.Text = "4";
            // 
            // btnPixelDwell6
            // 
            this.btnPixelDwell6.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell6.CheckOnClick = true;
            this.btnPixelDwell6.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell6.Name = "btnPixelDwell6";
            this.btnPixelDwell6.Text = "6";
            // 
            // btnPixelDwell8
            // 
            this.btnPixelDwell8.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell8.CheckOnClick = true;
            this.btnPixelDwell8.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell8.Name = "btnPixelDwell8";
            this.btnPixelDwell8.Text = "8";
            // 
            // btnPixelDwell10
            // 
            this.btnPixelDwell10.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell10.CheckOnClick = true;
            this.btnPixelDwell10.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell10.Name = "btnPixelDwell10";
            this.btnPixelDwell10.Text = "10";
            // 
            // btnPixelDwell20
            // 
            this.btnPixelDwell20.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell20.CheckOnClick = true;
            this.btnPixelDwell20.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell20.Name = "btnPixelDwell20";
            this.btnPixelDwell20.Text = "20";
            // 
            // btnPixelDwell50
            // 
            this.btnPixelDwell50.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnPixelDwell50.CheckOnClick = true;
            this.btnPixelDwell50.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell50.Name = "btnPixelDwell50";
            this.btnPixelDwell50.Text = "50";
            // 
            // btnPixelDwell100
            // 
            this.btnPixelDwell100.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.btnPixelDwell100.CheckOnClick = true;
            this.btnPixelDwell100.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnPixelDwell100.Name = "btnPixelDwell100";
            this.btnPixelDwell100.Text = "100";
            // 
            // separator2
            // 
            this.separator2.Height = 10;
            this.separator2.Name = "separator2";
            this.separator2.Width = 240;
            // 
            // lbScanPixel
            // 
            this.lbScanPixel.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.lbScanPixel.Height = 20;
            this.lbScanPixel.Name = "lbScanPixel";
            this.lbScanPixel.Text = "扫描像素";
            // 
            // btnScanPixel64
            // 
            this.btnScanPixel64.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnScanPixel64.CheckOnClick = true;
            this.btnScanPixel64.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel64.Name = "btnScanPixel64";
            this.btnScanPixel64.Text = "64 ";
            // 
            // btnScanPixel128
            // 
            this.btnScanPixel128.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnScanPixel128.CheckOnClick = true;
            this.btnScanPixel128.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel128.Name = "btnScanPixel128";
            this.btnScanPixel128.Text = "128";
            // 
            // btnScanPixel256
            // 
            this.btnScanPixel256.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnScanPixel256.CheckOnClick = true;
            this.btnScanPixel256.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel256.Name = "btnScanPixel256";
            this.btnScanPixel256.Text = "256";
            // 
            // btnScanPixel512
            // 
            this.btnScanPixel512.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnScanPixel512.CheckOnClick = true;
            this.btnScanPixel512.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel512.Name = "btnScanPixel512";
            this.btnScanPixel512.Text = "512";
            // 
            // btnScanPixel1024
            // 
            this.btnScanPixel1024.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnScanPixel1024.CheckOnClick = true;
            this.btnScanPixel1024.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel1024.Name = "btnScanPixel1024";
            this.btnScanPixel1024.Text = "1024";
            // 
            // btnScanPixel2048
            // 
            this.btnScanPixel2048.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnScanPixel2048.CheckOnClick = true;
            this.btnScanPixel2048.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel2048.Name = "btnScanPixel2048";
            this.btnScanPixel2048.Text = "2048";
            // 
            // btnScanPixel4096
            // 
            this.btnScanPixel4096.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.btnScanPixel4096.CheckOnClick = true;
            this.btnScanPixel4096.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnScanPixel4096.Name = "btnScanPixel4096";
            this.btnScanPixel4096.Text = "4096";
            // 
            // separator3
            // 
            this.separator3.Height = 10;
            this.separator3.Name = "separator3";
            this.separator3.Width = 240;
            // 
            // btnLineOptionNormal
            // 
            this.btnLineOptionNormal.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnLineOptionNormal.CheckOnClick = true;
            this.btnLineOptionNormal.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnLineOptionNormal.Name = "btnLineOptionNormal";
            this.btnLineOptionNormal.Text = "标准";
            // 
            // btnAveraging
            // 
            this.btnAveraging.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnAveraging.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnAveraging.Name = "btnAveraging";
            this.btnAveraging.Text = "平均";
            // 
            // btnIntegrate
            // 
            this.btnIntegrate.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btnIntegrate.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnIntegrate.Name = "btnIntegrate";
            this.btnIntegrate.Text = "积分";
            // 
            // chbxSequence
            // 
            this.chbxSequence.Break = C1.Win.C1InputPanel.BreakType.None;
            this.chbxSequence.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.chbxSequence.Name = "chbxSequence";
            this.chbxSequence.Text = "扫描序列";
            // 
            // btnSequence
            // 
            this.btnSequence.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.btnSequence.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnSequence.Name = "btnSequence";
            this.btnSequence.Text = "序列";
            // 
            // lbFPS
            // 
            this.lbFPS.Name = "lbFPS";
            this.lbFPS.Text = "帧率：";
            // 
            // lbFPSValue
            // 
            this.lbFPSValue.Name = "lbFPSValue";
            this.lbFPSValue.Width = 60;
            // 
            // lbFrameTime
            // 
            this.lbFrameTime.Name = "lbFrameTime";
            this.lbFrameTime.Text = "帧时间：";
            // 
            // lbFrameTimeValue
            // 
            this.lbFrameTimeValue.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.lbFrameTimeValue.Name = "lbFrameTimeValue";
            this.lbFrameTimeValue.Width = 60;
            // 
            // separator4
            // 
            this.separator4.Height = 10;
            this.separator4.Name = "separator4";
            this.separator4.Width = 240;
            // 
            // lbPinHoleSelect
            // 
            this.lbPinHoleSelect.Name = "lbPinHoleSelect";
            this.lbPinHoleSelect.Text = "选择小孔：";
            // 
            // cbxPinHoleSelect
            // 
            this.cbxPinHoleSelect.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.cbxPinHoleSelect.DropDownStyle = C1.Win.C1InputPanel.InputComboBoxStyle.DropDownList;
            this.cbxPinHoleSelect.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.cbxPinHoleSelect.Name = "cbxPinHoleSelect";
            this.cbxPinHoleSelect.Width = 63;
            // 
            // lbPinHole
            // 
            this.lbPinHole.Name = "lbPinHole";
            this.lbPinHole.Text = "孔径：";
            // 
            // tbarPinHole
            // 
            this.tbarPinHole.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbarPinHole.Maximum = 100;
            this.tbarPinHole.Name = "tbarPinHole";
            this.tbarPinHole.TickFrequency = 10;
            // 
            // tbxPinHole
            // 
            this.tbxPinHole.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbxPinHole.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPinHole.Name = "tbxPinHole";
            this.tbxPinHole.Width = 30;
            // 
            // tbxPinHoleAU
            // 
            this.tbxPinHoleAU.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxPinHoleAU.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxPinHoleAU.Name = "tbxPinHoleAU";
            this.tbxPinHoleAU.Width = 30;
            // 
            // separator5
            // 
            this.separator5.Height = 10;
            this.separator5.Name = "separator5";
            this.separator5.Width = 240;
            // 
            // gh405
            // 
            this.gh405.Collapsible = true;
            this.gh405.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gh405.FontPadding = true;
            this.gh405.Name = "gh405";
            this.gh405.Text = "405nm                                  0.0";
            // 
            // lb405HV
            // 
            this.lb405HV.Name = "lb405HV";
            this.lb405HV.Text = "增益 ";
            // 
            // tbar405HV
            // 
            this.tbar405HV.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar405HV.Maximum = 100;
            this.tbar405HV.Name = "tbar405HV";
            this.tbar405HV.TickFrequency = 10;
            this.tbar405HV.Width = 160;
            // 
            // tbx405HV
            // 
            this.tbx405HV.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx405HV.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx405HV.Name = "tbx405HV";
            this.tbx405HV.Width = 40;
            // 
            // lb405Offset
            // 
            this.lb405Offset.Name = "lb405Offset";
            this.lb405Offset.Text = "偏置 ";
            // 
            // tbar405Offset
            // 
            this.tbar405Offset.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar405Offset.Maximum = 128;
            this.tbar405Offset.Minimum = -128;
            this.tbar405Offset.Name = "tbar405Offset";
            this.tbar405Offset.TickFrequency = 16;
            this.tbar405Offset.Width = 160;
            // 
            // tbx405Offset
            // 
            this.tbx405Offset.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx405Offset.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx405Offset.Name = "tbx405Offset";
            this.tbx405Offset.Width = 40;
            // 
            // btn405Power
            // 
            this.btn405Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btn405Power.CheckOnClick = true;
            this.btn405Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn405Power.Name = "btn405Power";
            this.btn405Power.Text = "功率";
            // 
            // tbar405Power
            // 
            this.tbar405Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar405Power.Maximum = 100;
            this.tbar405Power.Name = "tbar405Power";
            this.tbar405Power.TickFrequency = 10;
            this.tbar405Power.Width = 160;
            // 
            // tbx405Power
            // 
            this.tbx405Power.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx405Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx405Power.Name = "tbx405Power";
            this.tbx405Power.Width = 40;
            // 
            // gh488
            // 
            this.gh488.Collapsible = true;
            this.gh488.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gh488.FontPadding = true;
            this.gh488.Name = "gh488";
            this.gh488.Text = "488nm                                  0.0";
            // 
            // lb488HV
            // 
            this.lb488HV.Name = "lb488HV";
            this.lb488HV.Text = "增益 ";
            // 
            // tbar488HV
            // 
            this.tbar488HV.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar488HV.Maximum = 100;
            this.tbar488HV.Name = "tbar488HV";
            this.tbar488HV.TickFrequency = 10;
            this.tbar488HV.Width = 160;
            // 
            // tbx488HV
            // 
            this.tbx488HV.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx488HV.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx488HV.Name = "tbx488HV";
            this.tbx488HV.Width = 40;
            // 
            // lb488Offset
            // 
            this.lb488Offset.Name = "lb488Offset";
            this.lb488Offset.Text = "偏置 ";
            // 
            // tbar488Offset
            // 
            this.tbar488Offset.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar488Offset.Maximum = 128;
            this.tbar488Offset.Minimum = -128;
            this.tbar488Offset.Name = "tbar488Offset";
            this.tbar488Offset.TickFrequency = 16;
            this.tbar488Offset.Width = 160;
            // 
            // tbx488Offset
            // 
            this.tbx488Offset.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx488Offset.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx488Offset.Name = "tbx488Offset";
            this.tbx488Offset.Width = 40;
            // 
            // btn488Power
            // 
            this.btn488Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btn488Power.CheckOnClick = true;
            this.btn488Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn488Power.Name = "btn488Power";
            this.btn488Power.Text = "功率";
            // 
            // tbar488Power
            // 
            this.tbar488Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar488Power.Maximum = 100;
            this.tbar488Power.Name = "tbar488Power";
            this.tbar488Power.TickFrequency = 10;
            this.tbar488Power.Width = 160;
            // 
            // tbx488Power
            // 
            this.tbx488Power.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx488Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx488Power.Name = "tbx488Power";
            this.tbx488Power.Width = 40;
            // 
            // gh561
            // 
            this.gh561.Collapsible = true;
            this.gh561.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gh561.FontPadding = true;
            this.gh561.Name = "gh561";
            this.gh561.Text = "561nm                                  0.0";
            // 
            // lb561HV
            // 
            this.lb561HV.Name = "lb561HV";
            this.lb561HV.Text = "增益 ";
            // 
            // tbar561HV
            // 
            this.tbar561HV.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar561HV.Maximum = 100;
            this.tbar561HV.Name = "tbar561HV";
            this.tbar561HV.TickFrequency = 10;
            this.tbar561HV.Width = 160;
            // 
            // tbx561HV
            // 
            this.tbx561HV.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx561HV.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx561HV.Name = "tbx561HV";
            this.tbx561HV.Width = 40;
            // 
            // lb561Offset
            // 
            this.lb561Offset.Name = "lb561Offset";
            this.lb561Offset.Text = "偏置 ";
            // 
            // tbar561Offset
            // 
            this.tbar561Offset.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar561Offset.Maximum = 128;
            this.tbar561Offset.Minimum = -128;
            this.tbar561Offset.Name = "tbar561Offset";
            this.tbar561Offset.TickFrequency = 16;
            this.tbar561Offset.Width = 160;
            // 
            // tbx561Offset
            // 
            this.tbx561Offset.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx561Offset.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx561Offset.Name = "tbx561Offset";
            this.tbx561Offset.Width = 40;
            // 
            // btn561Power
            // 
            this.btn561Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btn561Power.CheckOnClick = true;
            this.btn561Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn561Power.Name = "btn561Power";
            this.btn561Power.Text = "功率";
            // 
            // tbar561Power
            // 
            this.tbar561Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar561Power.Maximum = 100;
            this.tbar561Power.Name = "tbar561Power";
            this.tbar561Power.TickFrequency = 10;
            this.tbar561Power.Width = 160;
            // 
            // tbx561Power
            // 
            this.tbx561Power.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx561Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx561Power.Name = "tbx561Power";
            this.tbx561Power.Width = 40;
            // 
            // gh640
            // 
            this.gh640.Collapsible = true;
            this.gh640.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gh640.FontPadding = true;
            this.gh640.Name = "gh640";
            this.gh640.Text = "640nm                                  0.0";
            // 
            // lb640HV
            // 
            this.lb640HV.Name = "lb640HV";
            this.lb640HV.Text = "增益 ";
            // 
            // tbar640HV
            // 
            this.tbar640HV.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar640HV.Maximum = 100;
            this.tbar640HV.Name = "tbar640HV";
            this.tbar640HV.TickFrequency = 10;
            this.tbar640HV.Width = 160;
            // 
            // tbx640HV
            // 
            this.tbx640HV.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx640HV.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx640HV.Name = "tbx640HV";
            this.tbx640HV.Width = 40;
            // 
            // lb640Offset
            // 
            this.lb640Offset.Name = "lb640Offset";
            this.lb640Offset.Text = "偏置 ";
            // 
            // tbar640Offset
            // 
            this.tbar640Offset.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar640Offset.Maximum = 128;
            this.tbar640Offset.Minimum = -128;
            this.tbar640Offset.Name = "tbar640Offset";
            this.tbar640Offset.TickFrequency = 16;
            this.tbar640Offset.Width = 160;
            // 
            // tbx640Offset
            // 
            this.tbx640Offset.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx640Offset.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx640Offset.Name = "tbx640Offset";
            this.tbx640Offset.Width = 40;
            // 
            // btn640Power
            // 
            this.btn640Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.btn640Power.CheckOnClick = true;
            this.btn640Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn640Power.Name = "btn640Power";
            this.btn640Power.Text = "功率";
            // 
            // tbar640Power
            // 
            this.tbar640Power.Break = C1.Win.C1InputPanel.BreakType.None;
            this.tbar640Power.Maximum = 100;
            this.tbar640Power.Name = "tbar640Power";
            this.tbar640Power.TickFrequency = 10;
            this.tbar640Power.Width = 160;
            // 
            // tbx640Power
            // 
            this.tbx640Power.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbx640Power.Font = new System.Drawing.Font("宋体", 7.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbx640Power.Name = "tbx640Power";
            this.tbx640Power.Width = 40;
            // 
            // ScanSettingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(272, 719);
            this.Controls.Add(this.inputPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScanSettingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "扫描设置";
            this.Load += new System.EventHandler(this.ScanSettingViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.inputPanel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1InputPanel.C1InputPanel inputPanel;
        private C1.Win.C1InputPanel.InputButton btnLive;
        private C1.Win.C1InputPanel.InputButton btnCapture;
        private C1.Win.C1InputPanel.InputRadioButton rbtnTwoScanners;
        private C1.Win.C1InputPanel.InputRadioButton rbtnThreeScanners;
        private C1.Win.C1InputPanel.InputRadioButton rbtnGalvano;
        private C1.Win.C1InputPanel.InputRadioButton rbtnResonant;
        private C1.Win.C1InputPanel.InputSeparator separator6;
        private C1.Win.C1InputPanel.InputButton btnUnidirection;
        private C1.Win.C1InputPanel.InputButton btnBidirection;
        private C1.Win.C1InputPanel.InputNumericBox nbScanPixelCalibration;
        private C1.Win.C1InputPanel.InputCheckBox chbxLineSkip;
        private C1.Win.C1InputPanel.InputComboBox cbxLineSkip;
        private C1.Win.C1InputPanel.InputSeparator separator1;
        private C1.Win.C1InputPanel.InputLabel lbPixelDwell;
        private C1.Win.C1InputPanel.InputNumericBox nbScanPixelScale;
        private C1.Win.C1InputPanel.InputButton rbtnFastMode;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell2;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell4;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell6;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell8;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell10;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell20;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell50;
        private C1.Win.C1InputPanel.InputButton btnPixelDwell100;
        private C1.Win.C1InputPanel.InputSeparator separator2;
        private C1.Win.C1InputPanel.InputLabel lbScanPixel;
        private C1.Win.C1InputPanel.InputButton btnScanPixel64;
        private C1.Win.C1InputPanel.InputButton btnScanPixel128;
        private C1.Win.C1InputPanel.InputButton btnScanPixel256;
        private C1.Win.C1InputPanel.InputButton btnScanPixel512;
        private C1.Win.C1InputPanel.InputButton btnScanPixel1024;
        private C1.Win.C1InputPanel.InputButton btnScanPixel2048;
        private C1.Win.C1InputPanel.InputButton btnScanPixel4096;
        private C1.Win.C1InputPanel.InputSeparator separator3;
        private C1.Win.C1InputPanel.InputButton btnLineOptionNormal;
        private C1.Win.C1InputPanel.InputSplitButton btnAveraging;
        private C1.Win.C1InputPanel.InputSplitButton btnIntegrate;
        private C1.Win.C1InputPanel.InputCheckBox chbxSequence;
        private C1.Win.C1InputPanel.InputSplitButton btnSequence;
        private C1.Win.C1InputPanel.InputLabel lbFPS;
        private C1.Win.C1InputPanel.InputLabel lbFPSValue;
        private C1.Win.C1InputPanel.InputLabel lbFrameTime;
        private C1.Win.C1InputPanel.InputLabel lbFrameTimeValue;
        private C1.Win.C1InputPanel.InputSeparator separator4;
        private C1.Win.C1InputPanel.InputLabel lbPinHoleSelect;
        private C1.Win.C1InputPanel.InputComboBox cbxPinHoleSelect;
        private C1.Win.C1InputPanel.InputLabel lbPinHole;
        private C1.Win.C1InputPanel.InputTrackBar tbarPinHole;
        private C1.Win.C1InputPanel.InputTextBox tbxPinHole;
        private C1.Win.C1InputPanel.InputTextBox tbxPinHoleAU;
        private C1.Win.C1InputPanel.InputSeparator separator5;
        private C1.Win.C1InputPanel.InputGroupHeader gh405;
        private C1.Win.C1InputPanel.InputLabel lb405HV;
        private C1.Win.C1InputPanel.InputTrackBar tbar405HV;
        private C1.Win.C1InputPanel.InputTextBox tbx405HV;
        private C1.Win.C1InputPanel.InputLabel lb405Offset;
        private C1.Win.C1InputPanel.InputTrackBar tbar405Offset;
        private C1.Win.C1InputPanel.InputTextBox tbx405Offset;
        private C1.Win.C1InputPanel.InputButton btn405Power;
        private C1.Win.C1InputPanel.InputTrackBar tbar405Power;
        private C1.Win.C1InputPanel.InputTextBox tbx405Power;
        private C1.Win.C1InputPanel.InputGroupHeader gh488;
        private C1.Win.C1InputPanel.InputLabel lb488HV;
        private C1.Win.C1InputPanel.InputTrackBar tbar488HV;
        private C1.Win.C1InputPanel.InputTextBox tbx488HV;
        private C1.Win.C1InputPanel.InputLabel lb488Offset;
        private C1.Win.C1InputPanel.InputTrackBar tbar488Offset;
        private C1.Win.C1InputPanel.InputTextBox tbx488Offset;
        private C1.Win.C1InputPanel.InputButton btn488Power;
        private C1.Win.C1InputPanel.InputTrackBar tbar488Power;
        private C1.Win.C1InputPanel.InputTextBox tbx488Power;
        private C1.Win.C1InputPanel.InputGroupHeader gh561;
        private C1.Win.C1InputPanel.InputLabel lb561HV;
        private C1.Win.C1InputPanel.InputTrackBar tbar561HV;
        private C1.Win.C1InputPanel.InputTextBox tbx561HV;
        private C1.Win.C1InputPanel.InputLabel lb561Offset;
        private C1.Win.C1InputPanel.InputTrackBar tbar561Offset;
        private C1.Win.C1InputPanel.InputTextBox tbx561Offset;
        private C1.Win.C1InputPanel.InputButton btn561Power;
        private C1.Win.C1InputPanel.InputTrackBar tbar561Power;
        private C1.Win.C1InputPanel.InputTextBox tbx561Power;
        private C1.Win.C1InputPanel.InputGroupHeader gh640;
        private C1.Win.C1InputPanel.InputLabel lb640HV;
        private C1.Win.C1InputPanel.InputTrackBar tbar640HV;
        private C1.Win.C1InputPanel.InputTextBox tbx640HV;
        private C1.Win.C1InputPanel.InputLabel lb640Offset;
        private C1.Win.C1InputPanel.InputTrackBar tbar640Offset;
        private C1.Win.C1InputPanel.InputTextBox tbx640Offset;
        private C1.Win.C1InputPanel.InputButton btn640Power;
        private C1.Win.C1InputPanel.InputTrackBar tbar640Power;
        private C1.Win.C1InputPanel.InputTextBox tbx640Power;
    }
}