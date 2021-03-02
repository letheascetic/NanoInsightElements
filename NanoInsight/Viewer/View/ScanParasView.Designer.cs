namespace NanoInsight.Viewer.View
{
    partial class ScanParasView
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panel = new C1.Win.C1InputPanel.C1InputPanel();
            this.ghOutputPara = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lbOutputSampleRate = new C1.Win.C1InputPanel.InputLabel();
            this.tbxOutputSampleRate = new C1.Win.C1InputPanel.InputTextBox();
            this.lbOutputSampleCountPerRoundTrip = new C1.Win.C1InputPanel.InputLabel();
            this.tbxOutputSampleCountPerRoundTrip = new C1.Win.C1InputPanel.InputTextBox();
            this.lbOutputRoundTripPerFrame = new C1.Win.C1InputPanel.InputLabel();
            this.tbxOutputRoundTripPerFrame = new C1.Win.C1InputPanel.InputTextBox();
            this.lbOutputSampleCountPerFrame = new C1.Win.C1InputPanel.InputLabel();
            this.tbxOutputSampleCountPerFrame = new C1.Win.C1InputPanel.InputTextBox();
            this.ghInputPara = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lbInputSampleRate = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputSampleRate = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputSampleCountPerRoundTrip = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputSampleCountPerRoundTrip = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputRoundTripCountPerFrame = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputRoundTripCountPerFrame = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputSampleCountPerFrame = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputSampleCountPerFrame = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputSampleCountPerPixel = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputSampleCountPerPixel = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputSampleCountPerAcquisition = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputSampleCountPerAcquisition = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputPixelCountPerAcquisition = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputPixelCountPerAcquisition = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputRoundTripCountPerAcquisition = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputRoundTripCountPerAcquisition = new C1.Win.C1InputPanel.InputTextBox();
            this.lbInputAcquisitionCountPerFrame = new C1.Win.C1InputPanel.InputLabel();
            this.tbxInputAcquisitionCountPerFrame = new C1.Win.C1InputPanel.InputTextBox();
            this.ghOther = new C1.Win.C1InputPanel.InputGroupHeader();
            this.lbFPS = new C1.Win.C1InputPanel.InputLabel();
            this.tbxFPS = new C1.Win.C1InputPanel.InputTextBox();
            this.lbFrameTime = new C1.Win.C1InputPanel.InputLabel();
            this.tbxFrameTime = new C1.Win.C1InputPanel.InputTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.chart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).BeginInit();
            this.SuspendLayout();
            // 
            // chart
            // 
            chartArea1.Name = "ChartArea1";
            this.chart.ChartAreas.Add(chartArea1);
            this.chart.Dock = System.Windows.Forms.DockStyle.Top;
            legend1.Docking = System.Windows.Forms.DataVisualization.Charting.Docking.Bottom;
            legend1.Name = "Legend1";
            this.chart.Legends.Add(legend1);
            this.chart.Location = new System.Drawing.Point(0, 0);
            this.chart.Name = "chart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "X Galvo";
            series1.YValuesPerPoint = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Legend = "Legend1";
            series2.Name = "Trigger";
            this.chart.Series.Add(series1);
            this.chart.Series.Add(series2);
            this.chart.Size = new System.Drawing.Size(272, 138);
            this.chart.TabIndex = 0;
            this.chart.Text = "振镜控制曲线";
            // 
            // panel
            // 
            this.panel.AutoSizeElement = C1.Framework.AutoSizeElement.Both;
            this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.panel.Items.Add(this.ghOutputPara);
            this.panel.Items.Add(this.lbOutputSampleRate);
            this.panel.Items.Add(this.tbxOutputSampleRate);
            this.panel.Items.Add(this.lbOutputSampleCountPerRoundTrip);
            this.panel.Items.Add(this.tbxOutputSampleCountPerRoundTrip);
            this.panel.Items.Add(this.lbOutputRoundTripPerFrame);
            this.panel.Items.Add(this.tbxOutputRoundTripPerFrame);
            this.panel.Items.Add(this.lbOutputSampleCountPerFrame);
            this.panel.Items.Add(this.tbxOutputSampleCountPerFrame);
            this.panel.Items.Add(this.ghInputPara);
            this.panel.Items.Add(this.lbInputSampleRate);
            this.panel.Items.Add(this.tbxInputSampleRate);
            this.panel.Items.Add(this.lbInputSampleCountPerRoundTrip);
            this.panel.Items.Add(this.tbxInputSampleCountPerRoundTrip);
            this.panel.Items.Add(this.lbInputRoundTripCountPerFrame);
            this.panel.Items.Add(this.tbxInputRoundTripCountPerFrame);
            this.panel.Items.Add(this.lbInputSampleCountPerFrame);
            this.panel.Items.Add(this.tbxInputSampleCountPerFrame);
            this.panel.Items.Add(this.lbInputSampleCountPerPixel);
            this.panel.Items.Add(this.tbxInputSampleCountPerPixel);
            this.panel.Items.Add(this.lbInputSampleCountPerAcquisition);
            this.panel.Items.Add(this.tbxInputSampleCountPerAcquisition);
            this.panel.Items.Add(this.lbInputPixelCountPerAcquisition);
            this.panel.Items.Add(this.tbxInputPixelCountPerAcquisition);
            this.panel.Items.Add(this.lbInputRoundTripCountPerAcquisition);
            this.panel.Items.Add(this.tbxInputRoundTripCountPerAcquisition);
            this.panel.Items.Add(this.lbInputAcquisitionCountPerFrame);
            this.panel.Items.Add(this.tbxInputAcquisitionCountPerFrame);
            this.panel.Items.Add(this.ghOther);
            this.panel.Items.Add(this.lbFPS);
            this.panel.Items.Add(this.tbxFPS);
            this.panel.Items.Add(this.lbFrameTime);
            this.panel.Items.Add(this.tbxFrameTime);
            this.panel.Location = new System.Drawing.Point(0, 138);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(272, 423);
            this.panel.TabIndex = 16;
            // 
            // ghOutputPara
            // 
            this.ghOutputPara.Collapsible = true;
            this.ghOutputPara.Name = "ghOutputPara";
            this.ghOutputPara.Text = "输出参数";
            // 
            // lbOutputSampleRate
            // 
            this.lbOutputSampleRate.Name = "lbOutputSampleRate";
            this.lbOutputSampleRate.Text = "样本输出速率：";
            this.lbOutputSampleRate.Width = 100;
            // 
            // tbxOutputSampleRate
            // 
            this.tbxOutputSampleRate.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxOutputSampleRate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxOutputSampleRate.Name = "tbxOutputSampleRate";
            this.tbxOutputSampleRate.ReadOnly = true;
            // 
            // lbOutputSampleCountPerRoundTrip
            // 
            this.lbOutputSampleCountPerRoundTrip.Name = "lbOutputSampleCountPerRoundTrip";
            this.lbOutputSampleCountPerRoundTrip.Text = "单次往返样本数：";
            this.lbOutputSampleCountPerRoundTrip.Width = 100;
            // 
            // tbxOutputSampleCountPerRoundTrip
            // 
            this.tbxOutputSampleCountPerRoundTrip.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxOutputSampleCountPerRoundTrip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxOutputSampleCountPerRoundTrip.Name = "tbxOutputSampleCountPerRoundTrip";
            this.tbxOutputSampleCountPerRoundTrip.ReadOnly = true;
            // 
            // lbOutputRoundTripPerFrame
            // 
            this.lbOutputRoundTripPerFrame.Name = "lbOutputRoundTripPerFrame";
            this.lbOutputRoundTripPerFrame.Text = "单帧往返次数：";
            this.lbOutputRoundTripPerFrame.Width = 100;
            // 
            // tbxOutputRoundTripPerFrame
            // 
            this.tbxOutputRoundTripPerFrame.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxOutputRoundTripPerFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxOutputRoundTripPerFrame.Name = "tbxOutputRoundTripPerFrame";
            this.tbxOutputRoundTripPerFrame.ReadOnly = true;
            // 
            // lbOutputSampleCountPerFrame
            // 
            this.lbOutputSampleCountPerFrame.Name = "lbOutputSampleCountPerFrame";
            this.lbOutputSampleCountPerFrame.Text = "单帧样本数：";
            this.lbOutputSampleCountPerFrame.Width = 100;
            // 
            // tbxOutputSampleCountPerFrame
            // 
            this.tbxOutputSampleCountPerFrame.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxOutputSampleCountPerFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxOutputSampleCountPerFrame.Name = "tbxOutputSampleCountPerFrame";
            this.tbxOutputSampleCountPerFrame.ReadOnly = true;
            // 
            // ghInputPara
            // 
            this.ghInputPara.Collapsible = true;
            this.ghInputPara.Name = "ghInputPara";
            this.ghInputPara.Text = "输入参数";
            // 
            // lbInputSampleRate
            // 
            this.lbInputSampleRate.Name = "lbInputSampleRate";
            this.lbInputSampleRate.Text = "样本采集速率：";
            this.lbInputSampleRate.Width = 100;
            // 
            // tbxInputSampleRate
            // 
            this.tbxInputSampleRate.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputSampleRate.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputSampleRate.Name = "tbxInputSampleRate";
            this.tbxInputSampleRate.ReadOnly = true;
            // 
            // lbInputSampleCountPerRoundTrip
            // 
            this.lbInputSampleCountPerRoundTrip.Name = "lbInputSampleCountPerRoundTrip";
            this.lbInputSampleCountPerRoundTrip.Text = "单次往返样本数：";
            this.lbInputSampleCountPerRoundTrip.Width = 100;
            // 
            // tbxInputSampleCountPerRoundTrip
            // 
            this.tbxInputSampleCountPerRoundTrip.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputSampleCountPerRoundTrip.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputSampleCountPerRoundTrip.Name = "tbxInputSampleCountPerRoundTrip";
            this.tbxInputSampleCountPerRoundTrip.ReadOnly = true;
            // 
            // lbInputRoundTripCountPerFrame
            // 
            this.lbInputRoundTripCountPerFrame.Name = "lbInputRoundTripCountPerFrame";
            this.lbInputRoundTripCountPerFrame.Text = "单帧往返次数：";
            this.lbInputRoundTripCountPerFrame.Width = 100;
            // 
            // tbxInputRoundTripCountPerFrame
            // 
            this.tbxInputRoundTripCountPerFrame.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputRoundTripCountPerFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputRoundTripCountPerFrame.Name = "tbxInputRoundTripCountPerFrame";
            this.tbxInputRoundTripCountPerFrame.ReadOnly = true;
            // 
            // lbInputSampleCountPerFrame
            // 
            this.lbInputSampleCountPerFrame.Name = "lbInputSampleCountPerFrame";
            this.lbInputSampleCountPerFrame.Text = "单帧样本数：";
            this.lbInputSampleCountPerFrame.Width = 100;
            // 
            // tbxInputSampleCountPerFrame
            // 
            this.tbxInputSampleCountPerFrame.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputSampleCountPerFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputSampleCountPerFrame.Name = "tbxInputSampleCountPerFrame";
            this.tbxInputSampleCountPerFrame.ReadOnly = true;
            // 
            // lbInputSampleCountPerPixel
            // 
            this.lbInputSampleCountPerPixel.Name = "lbInputSampleCountPerPixel";
            this.lbInputSampleCountPerPixel.Text = "单像素样本数：";
            this.lbInputSampleCountPerPixel.Width = 100;
            // 
            // tbxInputSampleCountPerPixel
            // 
            this.tbxInputSampleCountPerPixel.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputSampleCountPerPixel.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputSampleCountPerPixel.Name = "tbxInputSampleCountPerPixel";
            this.tbxInputSampleCountPerPixel.ReadOnly = true;
            // 
            // lbInputSampleCountPerAcquisition
            // 
            this.lbInputSampleCountPerAcquisition.Name = "lbInputSampleCountPerAcquisition";
            this.lbInputSampleCountPerAcquisition.Text = "单次采集样本数：";
            this.lbInputSampleCountPerAcquisition.Width = 100;
            // 
            // tbxInputSampleCountPerAcquisition
            // 
            this.tbxInputSampleCountPerAcquisition.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputSampleCountPerAcquisition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputSampleCountPerAcquisition.Name = "tbxInputSampleCountPerAcquisition";
            this.tbxInputSampleCountPerAcquisition.ReadOnly = true;
            // 
            // lbInputPixelCountPerAcquisition
            // 
            this.lbInputPixelCountPerAcquisition.Name = "lbInputPixelCountPerAcquisition";
            this.lbInputPixelCountPerAcquisition.Text = "单次采集像素数：";
            this.lbInputPixelCountPerAcquisition.Width = 100;
            // 
            // tbxInputPixelCountPerAcquisition
            // 
            this.tbxInputPixelCountPerAcquisition.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputPixelCountPerAcquisition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputPixelCountPerAcquisition.Name = "tbxInputPixelCountPerAcquisition";
            this.tbxInputPixelCountPerAcquisition.ReadOnly = true;
            // 
            // lbInputRoundTripCountPerAcquisition
            // 
            this.lbInputRoundTripCountPerAcquisition.Name = "lbInputRoundTripCountPerAcquisition";
            this.lbInputRoundTripCountPerAcquisition.Text = "单次采集往返数：";
            this.lbInputRoundTripCountPerAcquisition.Width = 100;
            // 
            // tbxInputRoundTripCountPerAcquisition
            // 
            this.tbxInputRoundTripCountPerAcquisition.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputRoundTripCountPerAcquisition.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputRoundTripCountPerAcquisition.Name = "tbxInputRoundTripCountPerAcquisition";
            this.tbxInputRoundTripCountPerAcquisition.ReadOnly = true;
            // 
            // lbInputAcquisitionCountPerFrame
            // 
            this.lbInputAcquisitionCountPerFrame.Name = "lbInputAcquisitionCountPerFrame";
            this.lbInputAcquisitionCountPerFrame.Text = "单帧采集次数：";
            this.lbInputAcquisitionCountPerFrame.Width = 100;
            // 
            // tbxInputAcquisitionCountPerFrame
            // 
            this.tbxInputAcquisitionCountPerFrame.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxInputAcquisitionCountPerFrame.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxInputAcquisitionCountPerFrame.Name = "tbxInputAcquisitionCountPerFrame";
            this.tbxInputAcquisitionCountPerFrame.ReadOnly = true;
            // 
            // ghOther
            // 
            this.ghOther.Collapsible = true;
            this.ghOther.Name = "ghOther";
            this.ghOther.Text = "其他参数";
            // 
            // lbFPS
            // 
            this.lbFPS.Name = "lbFPS";
            this.lbFPS.Text = "帧率（FPS）：";
            this.lbFPS.Width = 100;
            // 
            // tbxFPS
            // 
            this.tbxFPS.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxFPS.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFPS.Name = "tbxFPS";
            this.tbxFPS.ReadOnly = true;
            // 
            // lbFrameTime
            // 
            this.lbFrameTime.Name = "lbFrameTime";
            this.lbFrameTime.Text = "帧时间：";
            this.lbFrameTime.Width = 100;
            // 
            // tbxFrameTime
            // 
            this.tbxFrameTime.Break = C1.Win.C1InputPanel.BreakType.Group;
            this.tbxFrameTime.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tbxFrameTime.Name = "tbxFrameTime";
            this.tbxFrameTime.ReadOnly = true;
            // 
            // ScanParasView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 561);
            this.ControlBox = false;
            this.Controls.Add(this.panel);
            this.Controls.Add(this.chart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(280, 600);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(280, 400);
            this.Name = "ScanParasView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "参数显示";
            this.Load += new System.EventHandler(this.ScanParasViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.chart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart;
        private C1.Win.C1InputPanel.C1InputPanel panel;
        private C1.Win.C1InputPanel.InputGroupHeader ghOutputPara;
        private C1.Win.C1InputPanel.InputLabel lbOutputSampleRate;
        private C1.Win.C1InputPanel.InputTextBox tbxOutputSampleRate;
        private C1.Win.C1InputPanel.InputLabel lbOutputSampleCountPerRoundTrip;
        private C1.Win.C1InputPanel.InputTextBox tbxOutputSampleCountPerRoundTrip;
        private C1.Win.C1InputPanel.InputLabel lbOutputRoundTripPerFrame;
        private C1.Win.C1InputPanel.InputTextBox tbxOutputRoundTripPerFrame;
        private C1.Win.C1InputPanel.InputLabel lbOutputSampleCountPerFrame;
        private C1.Win.C1InputPanel.InputTextBox tbxOutputSampleCountPerFrame;
        private C1.Win.C1InputPanel.InputGroupHeader ghInputPara;
        private C1.Win.C1InputPanel.InputLabel lbInputSampleRate;
        private C1.Win.C1InputPanel.InputTextBox tbxInputSampleRate;
        private C1.Win.C1InputPanel.InputLabel lbInputSampleCountPerRoundTrip;
        private C1.Win.C1InputPanel.InputTextBox tbxInputSampleCountPerRoundTrip;
        private C1.Win.C1InputPanel.InputLabel lbInputRoundTripCountPerFrame;
        private C1.Win.C1InputPanel.InputTextBox tbxInputRoundTripCountPerFrame;
        private C1.Win.C1InputPanel.InputLabel lbInputSampleCountPerFrame;
        private C1.Win.C1InputPanel.InputTextBox tbxInputSampleCountPerFrame;
        private C1.Win.C1InputPanel.InputLabel lbInputSampleCountPerPixel;
        private C1.Win.C1InputPanel.InputTextBox tbxInputSampleCountPerPixel;
        private C1.Win.C1InputPanel.InputLabel lbInputSampleCountPerAcquisition;
        private C1.Win.C1InputPanel.InputTextBox tbxInputSampleCountPerAcquisition;
        private C1.Win.C1InputPanel.InputLabel lbInputPixelCountPerAcquisition;
        private C1.Win.C1InputPanel.InputTextBox tbxInputPixelCountPerAcquisition;
        private C1.Win.C1InputPanel.InputLabel lbInputRoundTripCountPerAcquisition;
        private C1.Win.C1InputPanel.InputTextBox tbxInputRoundTripCountPerAcquisition;
        private C1.Win.C1InputPanel.InputLabel lbInputAcquisitionCountPerFrame;
        private C1.Win.C1InputPanel.InputTextBox tbxInputAcquisitionCountPerFrame;
        private C1.Win.C1InputPanel.InputGroupHeader ghOther;
        private C1.Win.C1InputPanel.InputLabel lbFPS;
        private C1.Win.C1InputPanel.InputTextBox tbxFPS;
        private C1.Win.C1InputPanel.InputLabel lbFrameTime;
        private C1.Win.C1InputPanel.InputTextBox tbxFrameTime;
    }
}