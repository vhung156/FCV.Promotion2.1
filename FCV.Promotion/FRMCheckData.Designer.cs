namespace FCV.Promotion
{
    partial class FRMCheckData
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
            this.dgvData1 = new System.Windows.Forms.DataGridView();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvData2 = new System.Windows.Forms.DataGridView();
            this.txtColumnSheet1 = new System.Windows.Forms.TextBox();
            this.txtColumnSheet2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFile1 = new System.Windows.Forms.Button();
            this.txtFileName1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCheckData = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData2)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData1
            // 
            this.dgvData1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData1.Location = new System.Drawing.Point(0, 0);
            this.dgvData1.Name = "dgvData1";
            this.dgvData1.Size = new System.Drawing.Size(471, 541);
            this.dgvData1.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 69);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvData1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvData2);
            this.splitContainer1.Size = new System.Drawing.Size(942, 541);
            this.splitContainer1.SplitterDistance = 471;
            this.splitContainer1.TabIndex = 1;
            // 
            // dgvData2
            // 
            this.dgvData2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvData2.Location = new System.Drawing.Point(0, 0);
            this.dgvData2.Name = "dgvData2";
            this.dgvData2.Size = new System.Drawing.Size(467, 541);
            this.dgvData2.TabIndex = 1;
            // 
            // txtColumnSheet1
            // 
            this.txtColumnSheet1.Location = new System.Drawing.Point(70, 39);
            this.txtColumnSheet1.Name = "txtColumnSheet1";
            this.txtColumnSheet1.Size = new System.Drawing.Size(164, 20);
            this.txtColumnSheet1.TabIndex = 2;
            // 
            // txtColumnSheet2
            // 
            this.txtColumnSheet2.Location = new System.Drawing.Point(531, 43);
            this.txtColumnSheet2.Name = "txtColumnSheet2";
            this.txtColumnSheet2.Size = new System.Drawing.Size(164, 20);
            this.txtColumnSheet2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(23, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "File";
            // 
            // btnFile1
            // 
            this.btnFile1.Location = new System.Drawing.Point(670, 6);
            this.btnFile1.Name = "btnFile1";
            this.btnFile1.Size = new System.Drawing.Size(26, 19);
            this.btnFile1.TabIndex = 7;
            this.btnFile1.Text = "...";
            this.btnFile1.UseVisualStyleBackColor = true;
            this.btnFile1.Click += new System.EventHandler(this.btnFile1_Click);
            // 
            // txtFileName1
            // 
            this.txtFileName1.Location = new System.Drawing.Point(70, 5);
            this.txtFileName1.Name = "txtFileName1";
            this.txtFileName1.Size = new System.Drawing.Size(594, 20);
            this.txtFileName1.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Columns 1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(472, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Columns 2";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = global::FCV.Promotion.Properties.Resources.save;
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(797, 44);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(31, 20);
            this.btnSave.TabIndex = 3;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCheckData
            // 
            this.btnCheckData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckData.Image = global::FCV.Promotion.Properties.Resources.tick;
            this.btnCheckData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckData.Location = new System.Drawing.Point(797, 5);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size(145, 33);
            this.btnCheckData.TabIndex = 3;
            this.btnCheckData.Text = "Check Data";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // FRMCheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 610);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFile1);
            this.Controls.Add(this.txtFileName1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCheckData);
            this.Controls.Add(this.txtColumnSheet2);
            this.Controls.Add(this.txtColumnSheet1);
            this.Controls.Add(this.splitContainer1);
            this.Name = "FRMCheckData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMCheckData";
            this.Load += new System.EventHandler(this.FRMCheckData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData1)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvData2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgvData2;
        private System.Windows.Forms.TextBox txtColumnSheet1;
        private System.Windows.Forms.TextBox txtColumnSheet2;
        private System.Windows.Forms.Button btnCheckData;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFile1;
        private System.Windows.Forms.TextBox txtFileName1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
    }
}