
namespace NanoInsight.Viewer.View
{
    partial class ThemeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ThemeView));
            this.c1ThemeController = new C1.Win.C1Themes.C1ThemeController();
            this.btnConfirm = new C1.Win.C1Input.C1Button();
            this.btnQuit = new C1.Win.C1Input.C1Button();
            this.btnApply = new C1.Win.C1Input.C1Button();
            this.ctdbgThemes = new C1.Win.C1TrueDBGrid.C1TrueDBGrid();
            this.label2 = new C1.Win.C1Input.C1Label();
            this.tbApplicationTheme = new C1.Win.C1Input.C1TextBox();
            this.label = new C1.Win.C1Input.C1Label();
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctdbgThemes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbApplicationTheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnConfirm.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnConfirm.Location = new System.Drawing.Point(156, 358);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 15;
            this.btnConfirm.Text = "确认";
            this.c1ThemeController.SetTheme(this.btnConfirm, "(default)");
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnConfirm.Click += new System.EventHandler(this.ConfirmClick);
            // 
            // btnQuit
            // 
            this.btnQuit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnQuit.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnQuit.Location = new System.Drawing.Point(237, 358);
            this.btnQuit.Name = "btnQuit";
            this.btnQuit.Size = new System.Drawing.Size(75, 23);
            this.btnQuit.TabIndex = 14;
            this.btnQuit.Text = "退出";
            this.c1ThemeController.SetTheme(this.btnQuit, "(default)");
            this.btnQuit.UseVisualStyleBackColor = true;
            this.btnQuit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            this.btnQuit.Click += new System.EventHandler(this.QuitClick);
            // 
            // btnApply
            // 
            this.btnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnApply.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.btnApply.Location = new System.Drawing.Point(12, 358);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 13;
            this.btnApply.Text = "预览";
            this.c1ThemeController.SetTheme(this.btnApply, "(default)");
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // ctdbgThemes
            // 
            this.ctdbgThemes.AllowColMove = false;
            this.ctdbgThemes.AllowUpdate = false;
            this.ctdbgThemes.AlternatingRows = true;
            this.ctdbgThemes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ctdbgThemes.BackColor = System.Drawing.Color.Gray;
            this.ctdbgThemes.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.ctdbgThemes.CaptionHeight = 17;
            this.ctdbgThemes.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ctdbgThemes.ForeColor = System.Drawing.Color.White;
            this.ctdbgThemes.GroupByCaption = "将列头拖拽到这里以便按照该列进行分组";
            this.ctdbgThemes.Images.Add(((System.Drawing.Image)(resources.GetObject("ctdbgThemes.Images"))));
            this.ctdbgThemes.Location = new System.Drawing.Point(12, 52);
            this.ctdbgThemes.Name = "ctdbgThemes";
            this.ctdbgThemes.PreviewInfo.Caption = "PrintPreview窗口";
            this.ctdbgThemes.PreviewInfo.Location = new System.Drawing.Point(0, 0);
            this.ctdbgThemes.PreviewInfo.Size = new System.Drawing.Size(0, 0);
            this.ctdbgThemes.PreviewInfo.ZoomFactor = 75D;
            this.ctdbgThemes.PrintInfo.PageSettings = ((System.Drawing.Printing.PageSettings)(resources.GetObject("ctdbgThemes.PrintInfo.PageSettings")));
            this.ctdbgThemes.PropBag = resources.GetString("ctdbgThemes.PropBag");
            this.ctdbgThemes.RowDivider.Color = System.Drawing.Color.Gray;
            this.ctdbgThemes.RowDivider.Style = C1.Win.C1TrueDBGrid.LineStyleEnum.Single;
            this.ctdbgThemes.RowHeight = 15;
            this.ctdbgThemes.RowSubDividerColor = System.Drawing.Color.Gray;
            this.ctdbgThemes.Size = new System.Drawing.Size(300, 300);
            this.ctdbgThemes.TabIndex = 12;
            this.c1ThemeController.SetTheme(this.ctdbgThemes, "(default)");
            this.ctdbgThemes.UseCompatibleTextRendering = false;
            this.ctdbgThemes.DoubleClick += new System.EventHandler(this.ThemesDoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(12, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 19);
            this.label2.TabIndex = 11;
            this.label2.Tag = null;
            this.label2.Text = "可选的主题：";
            this.label2.TextDetached = true;
            this.c1ThemeController.SetTheme(this.label2, "(default)");
            this.label2.UseCompatibleTextRendering = true;
            // 
            // tbApplicationTheme
            // 
            this.tbApplicationTheme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbApplicationTheme.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.tbApplicationTheme.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbApplicationTheme.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(101)))), ((int)(((byte)(101)))), ((int)(((byte)(101)))));
            this.tbApplicationTheme.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.tbApplicationTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.tbApplicationTheme.Location = new System.Drawing.Point(118, 9);
            this.tbApplicationTheme.Name = "tbApplicationTheme";
            this.tbApplicationTheme.ReadOnly = true;
            this.tbApplicationTheme.Size = new System.Drawing.Size(194, 20);
            this.tbApplicationTheme.TabIndex = 10;
            this.tbApplicationTheme.Tag = null;
            this.c1ThemeController.SetTheme(this.tbApplicationTheme, "(default)");
            this.tbApplicationTheme.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2010Blue;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.label.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.label.ForeColor = System.Drawing.Color.Black;
            this.label.Location = new System.Drawing.Point(12, 11);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(96, 19);
            this.label.TabIndex = 9;
            this.label.Tag = null;
            this.label.Text = "当前应用的主题：";
            this.label.TextDetached = true;
            this.c1ThemeController.SetTheme(this.label, "(default)");
            this.label.UseCompatibleTextRendering = true;
            // 
            // ThemeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(87)))), ((int)(((byte)(87)))), ((int)(((byte)(87)))));
            this.ClientSize = new System.Drawing.Size(324, 391);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnQuit);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.ctdbgThemes);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbApplicationTheme);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "ThemeView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "主题管理器";
            this.Load += new System.EventHandler(this.ThemeViewLoad);
            ((System.ComponentModel.ISupportInitialize)(this.c1ThemeController)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnConfirm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnQuit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ctdbgThemes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbApplicationTheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private C1.Win.C1Themes.C1ThemeController c1ThemeController;
        private C1.Win.C1Input.C1Button btnConfirm;
        private C1.Win.C1Input.C1Button btnQuit;
        private C1.Win.C1Input.C1Button btnApply;
        private C1.Win.C1TrueDBGrid.C1TrueDBGrid ctdbgThemes;
        private C1.Win.C1Input.C1Label label2;
        private C1.Win.C1Input.C1TextBox tbApplicationTheme;
        private C1.Win.C1Input.C1Label label;
    }
}