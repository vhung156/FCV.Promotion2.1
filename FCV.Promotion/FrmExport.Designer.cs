namespace FCV.Promotion
{
    partial class FrmExport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtFileName1 = new System.Windows.Forms.TextBox();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.chkOpen = new System.Windows.Forms.CheckBox();
            this.chkAutosave = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.EpType = new System.Windows.Forms.GroupBox();
            this.radioMulti = new System.Windows.Forms.RadioButton();
            this.radioAll = new System.Windows.Forms.RadioButton();
            this.radioExcel = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnConfig = new System.Windows.Forms.Button();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cboPromotionType = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioDiscount = new System.Windows.Forms.RadioButton();
            this.radioB2B = new System.Windows.Forms.RadioButton();
            this.EpType.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFileName1
            // 
            this.txtFileName1.Location = new System.Drawing.Point(41, 103);
            this.txtFileName1.Name = "txtFileName1";
            this.txtFileName1.Size = new System.Drawing.Size(624, 20);
            this.txtFileName1.TabIndex = 2;
            // 
            // btnFile1
            // 
            this.btnFile1.Location = new System.Drawing.Point(671, 104);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(26, 19);
            this.btnFile1.TabIndex = 3;
            this.btnFile1.Text = "...";
            this.btnFile1.UseVisualStyleBackColor = true;
            this.btnFile1.Click += new System.EventHandler(this.btnFile1_Click);
            // 
            // chkOpen
            // 
            this.chkOpen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkOpen.AutoSize = true;
            this.chkOpen.Checked = true;
            this.chkOpen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOpen.Location = new System.Drawing.Point(7, 42);
            this.chkOpen.Name = "chkOpen";
            this.chkOpen.Size = new System.Drawing.Size(124, 17);
            this.chkOpen.TabIndex = 4;
            this.chkOpen.Text = "Open file after export";
            this.chkOpen.UseVisualStyleBackColor = true;
            this.chkOpen.CheckedChanged += new System.EventHandler(this.chkOpen_CheckedChanged);
            // 
            // chkAutosave
            // 
            this.chkAutosave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkAutosave.AutoSize = true;
            this.chkAutosave.Checked = true;
            this.chkAutosave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAutosave.Location = new System.Drawing.Point(6, 19);
            this.chkAutosave.Name = "chkAutosave";
            this.chkAutosave.Size = new System.Drawing.Size(76, 17);
            this.chkAutosave.TabIndex = 4;
            this.chkAutosave.Text = "Auto Save";
            this.chkAutosave.UseVisualStyleBackColor = true;
            this.chkAutosave.CheckedChanged += new System.EventHandler(this.chkAutosave_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 106);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "File";
            // 
            // EpType
            // 
            this.EpType.Controls.Add(this.radioMulti);
            this.EpType.Controls.Add(this.radioAll);
            this.EpType.Controls.Add(this.radioExcel);
            this.EpType.Location = new System.Drawing.Point(333, 422);
            this.EpType.Name = "EpType";
            this.EpType.Size = new System.Drawing.Size(213, 58);
            this.EpType.TabIndex = 6;
            this.EpType.TabStop = false;
            this.EpType.Text = "Export Type";
            // 
            // radioMulti
            // 
            this.radioMulti.AutoSize = true;
            this.radioMulti.Location = new System.Drawing.Point(20, 38);
            this.radioMulti.Name = "radioMulti";
            this.radioMulti.Size = new System.Drawing.Size(66, 17);
            this.radioMulti.TabIndex = 0;
            this.radioMulti.Text = "Mutil File";
            this.radioMulti.UseVisualStyleBackColor = true;
            this.radioMulti.CheckedChanged += new System.EventHandler(this.radioCsv_CheckedChanged);
            // 
            // radioAll
            // 
            this.radioAll.AutoSize = true;
            this.radioAll.Location = new System.Drawing.Point(20, 14);
            this.radioAll.Name = "radioAll";
            this.radioAll.Size = new System.Drawing.Size(44, 17);
            this.radioAll.TabIndex = 0;
            this.radioAll.Text = "ALL";
            this.radioAll.UseVisualStyleBackColor = true;
            this.radioAll.CheckedChanged += new System.EventHandler(this.radioAll_CheckedChanged);
            // 
            // radioExcel
            // 
            this.radioExcel.AutoSize = true;
            this.radioExcel.Checked = true;
            this.radioExcel.Location = new System.Drawing.Point(105, 37);
            this.radioExcel.Name = "radioExcel";
            this.radioExcel.Size = new System.Drawing.Size(64, 17);
            this.radioExcel.TabIndex = 0;
            this.radioExcel.TabStop = true;
            this.radioExcel.Text = "One File";
            this.radioExcel.UseVisualStyleBackColor = true;
            this.radioExcel.CheckedChanged += new System.EventHandler(this.radioExcel_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkAutosave);
            this.groupBox2.Controls.Add(this.chkOpen);
            this.groupBox2.Location = new System.Drawing.Point(333, 486);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 58);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            // 
            // btnConfig
            // 
            this.btnConfig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfig.Image = global::FCV.Promotion.Properties.Resources.download_56x_icon;
            this.btnConfig.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnConfig.Location = new System.Drawing.Point(3, 516);
            this.btnConfig.Name = "btnConfig";
            this.btnConfig.Size = new System.Drawing.Size(131, 44);
            this.btnConfig.TabIndex = 1;
            this.btnConfig.Text = "Config";
            this.btnConfig.UseVisualStyleBackColor = true;
            this.btnConfig.Click += new System.EventHandler(this.btnConfig_Click);
            // 
            // btnCheckData
            // 
            this.btnCheckData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckData.Image = global::FCV.Promotion.Properties.Resources.tick;
            this.btnCheckData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckData.Location = new System.Drawing.Point(552, 422);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size(145, 55);
            this.btnCheckData.TabIndex = 1;
            this.btnCheckData.Text = "Check Data";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = global::FCV.Promotion.Properties.Resources.internet__2_;
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(552, 483);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(145, 55);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FCV.Promotion.Properties.Resources.FC_NOURISHING_BY_NATURE_01;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(308, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // cboPromotionType
            // 
            this.cboPromotionType.FormattingEnabled = true;
            this.cboPromotionType.Location = new System.Drawing.Point(3, 483);
            this.cboPromotionType.Name = "cboPromotionType";
            this.cboPromotionType.Size = new System.Drawing.Size(10, 21);
            this.cboPromotionType.TabIndex = 7;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioDiscount);
            this.groupBox1.Controls.Add(this.radioB2B);
            this.groupBox1.Location = new System.Drawing.Point(333, 367);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(213, 49);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Promotion Type";
            // 
            // radioDiscount
            // 
            this.radioDiscount.AutoSize = true;
            this.radioDiscount.Location = new System.Drawing.Point(20, 25);
            this.radioDiscount.Name = "radioDiscount";
            this.radioDiscount.Size = new System.Drawing.Size(67, 17);
            this.radioDiscount.TabIndex = 0;
            this.radioDiscount.Text = "Discount";
            this.radioDiscount.UseVisualStyleBackColor = true;
            this.radioDiscount.CheckedChanged += new System.EventHandler(this.radioCsv_CheckedChanged);
            // 
            // radioB2B
            // 
            this.radioB2B.AutoSize = true;
            this.radioB2B.Checked = true;
            this.radioB2B.Location = new System.Drawing.Point(105, 25);
            this.radioB2B.Name = "radioB2B";
            this.radioB2B.Size = new System.Drawing.Size(45, 17);
            this.radioB2B.TabIndex = 0;
            this.radioB2B.TabStop = true;
            this.radioB2B.Text = "B2B";
            this.radioB2B.UseVisualStyleBackColor = true;
            this.radioB2B.CheckedChanged += new System.EventHandler(this.radioExcel_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 559);
            this.Controls.Add(this.cboPromotionType);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.EpType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFile1);
            this.Controls.Add(this.txtFileName1);
            this.Controls.Add(this.btnConfig);
            this.Controls.Add(this.btnCheckData);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FCV.Promotion";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.EpType.ResumeLayout(false);
            this.EpType.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.TextBox txtFileName1;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.CheckBox chkOpen;
        private System.Windows.Forms.CheckBox chkAutosave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCheckData;
        private System.Windows.Forms.GroupBox EpType;
        private System.Windows.Forms.RadioButton radioMulti;
        private System.Windows.Forms.RadioButton radioExcel;
        private System.Windows.Forms.RadioButton radioAll;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnConfig;
        private System.Windows.Forms.ComboBox cboPromotionType;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioDiscount;
        private System.Windows.Forms.RadioButton radioB2B;
    }
}

