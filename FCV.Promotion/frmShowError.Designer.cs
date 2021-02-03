namespace FCV.Promotion
{
    partial class frmShowError
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
            this.lblErrorMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvData1
            // 
            this.dgvData1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvData1.Location = new System.Drawing.Point(0, 52);
            this.dgvData1.Name = "dgvData1";
            this.dgvData1.ReadOnly = true;
            this.dgvData1.Size = new System.Drawing.Size(483, 206);
            this.dgvData1.TabIndex = 1;
            // 
            // lblErrorMessage
            // 
            this.lblErrorMessage.AutoSize = true;
            this.lblErrorMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.lblErrorMessage.Location = new System.Drawing.Point(13, 13);
            this.lblErrorMessage.Name = "lblErrorMessage";
            this.lblErrorMessage.Size = new System.Drawing.Size(51, 16);
            this.lblErrorMessage.TabIndex = 2;
            this.lblErrorMessage.Text = "label1";
            // 
            // frmShowError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 258);
            this.Controls.Add(this.lblErrorMessage);
            this.Controls.Add(this.dgvData1);
            this.Name = "frmShowError";
            this.Text = "frmShowError";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvData1;
        private System.Windows.Forms.Label lblErrorMessage;
    }
}