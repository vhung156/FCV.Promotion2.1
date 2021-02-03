namespace FCV.Promotion
{
    partial class FRMCheckDataDuplicate
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
            this.dgvDataDuplicate = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDuplicate)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvDataDuplicate
            // 
            this.dgvDataDuplicate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDataDuplicate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDataDuplicate.Location = new System.Drawing.Point(0, 0);
            this.dgvDataDuplicate.Name = "dgvDataDuplicate";
            this.dgvDataDuplicate.Size = new System.Drawing.Size(942, 610);
            this.dgvDataDuplicate.TabIndex = 0;
            // 
            // FRMCheckData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(942, 610);
            this.Controls.Add(this.dgvDataDuplicate);
            this.Name = "FRMCheckData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FRMCheckData";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDataDuplicate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDataDuplicate;
    }
}