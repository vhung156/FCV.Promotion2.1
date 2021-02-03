namespace FCV.Promotion
{
    partial class FormConfig
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
            this.tabConfig = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDiscount_SKU = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtDiscount_DiscountCode = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDiscount_DistributorCode = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtDiscount_CustomerCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBudget_BudgetValue = new System.Windows.Forms.TextBox();
            this.txtBudget_DistributorCode = new System.Windows.Forms.TextBox();
            this.txtBudget_Discount = new System.Windows.Forms.TextBox();
            this.txtBudget_SKU = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFORMATDATE_OUT = new System.Windows.Forms.TextBox();
            this.txtFORMATDATE_IN = new System.Windows.Forms.TextBox();
            this.btnCheckData = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtB2BFORMATDATE_OUT = new System.Windows.Forms.TextBox();
            this.txtB2BFORMATDATE_IN = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.txtB2B_BudgetValue = new System.Windows.Forms.TextBox();
            this.txtB2B_DistributorCode = new System.Windows.Forms.TextBox();
            this.txtB2B_DiscountValue = new System.Windows.Forms.TextBox();
            this.txtB2B_SKUCode = new System.Windows.Forms.TextBox();
            this.txtB2B_CustomerCode = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tabConfig.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabConfig
            // 
            this.tabConfig.Controls.Add(this.tabPage3);
            this.tabConfig.Controls.Add(this.tabPage2);
            this.tabConfig.Controls.Add(this.tabPage1);
            this.tabConfig.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabConfig.Location = new System.Drawing.Point(0, 48);
            this.tabConfig.Name = "tabConfig";
            this.tabConfig.SelectedIndex = 0;
            this.tabConfig.Size = new System.Drawing.Size(800, 559);
            this.tabConfig.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(792, 533);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Product UOM";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox3);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Discount";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.txtDiscount_SKU);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.txtDiscount_DiscountCode);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.txtDiscount_DistributorCode);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.txtDiscount_CustomerCode);
            this.groupBox3.Location = new System.Drawing.Point(6, 366);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(695, 169);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Discount";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(97, 52);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 13);
            this.label10.TabIndex = 1;
            this.label10.Text = "CustomerCode";
            // 
            // txtDiscount_SKU
            // 
            this.txtDiscount_SKU.Location = new System.Drawing.Point(264, 72);
            this.txtDiscount_SKU.Name = "txtDiscount_SKU";
            this.txtDiscount_SKU.Size = new System.Drawing.Size(301, 20);
            this.txtDiscount_SKU.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(97, 26);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "DistributorCode";
            // 
            // txtDiscount_DiscountCode
            // 
            this.txtDiscount_DiscountCode.Location = new System.Drawing.Point(264, 98);
            this.txtDiscount_DiscountCode.Name = "txtDiscount_DiscountCode";
            this.txtDiscount_DiscountCode.Size = new System.Drawing.Size(301, 20);
            this.txtDiscount_DiscountCode.TabIndex = 0;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(97, 105);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 1;
            this.label8.Text = "Discount";
            // 
            // txtDiscount_DistributorCode
            // 
            this.txtDiscount_DistributorCode.Location = new System.Drawing.Point(264, 19);
            this.txtDiscount_DistributorCode.Name = "txtDiscount_DistributorCode";
            this.txtDiscount_DistributorCode.Size = new System.Drawing.Size(301, 20);
            this.txtDiscount_DistributorCode.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(97, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "SKU";
            // 
            // txtDiscount_CustomerCode
            // 
            this.txtDiscount_CustomerCode.Location = new System.Drawing.Point(264, 45);
            this.txtDiscount_CustomerCode.Name = "txtDiscount_CustomerCode";
            this.txtDiscount_CustomerCode.Size = new System.Drawing.Size(301, 20);
            this.txtDiscount_CustomerCode.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBudget_BudgetValue);
            this.groupBox2.Controls.Add(this.txtBudget_DistributorCode);
            this.groupBox2.Controls.Add(this.txtBudget_Discount);
            this.groupBox2.Controls.Add(this.txtBudget_SKU);
            this.groupBox2.Location = new System.Drawing.Point(8, 191);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(693, 169);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Budget";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(95, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "BudgetValue";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(95, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "DistributorCode";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(95, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Discount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(95, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "SKU";
            // 
            // txtBudget_BudgetValue
            // 
            this.txtBudget_BudgetValue.Location = new System.Drawing.Point(262, 97);
            this.txtBudget_BudgetValue.Name = "txtBudget_BudgetValue";
            this.txtBudget_BudgetValue.Size = new System.Drawing.Size(301, 20);
            this.txtBudget_BudgetValue.TabIndex = 0;
            // 
            // txtBudget_DistributorCode
            // 
            this.txtBudget_DistributorCode.Location = new System.Drawing.Point(262, 71);
            this.txtBudget_DistributorCode.Name = "txtBudget_DistributorCode";
            this.txtBudget_DistributorCode.Size = new System.Drawing.Size(301, 20);
            this.txtBudget_DistributorCode.TabIndex = 0;
            // 
            // txtBudget_Discount
            // 
            this.txtBudget_Discount.Location = new System.Drawing.Point(262, 45);
            this.txtBudget_Discount.Name = "txtBudget_Discount";
            this.txtBudget_Discount.Size = new System.Drawing.Size(301, 20);
            this.txtBudget_Discount.TabIndex = 0;
            // 
            // txtBudget_SKU
            // 
            this.txtBudget_SKU.Location = new System.Drawing.Point(262, 19);
            this.txtBudget_SKU.Name = "txtBudget_SKU";
            this.txtBudget_SKU.Size = new System.Drawing.Size(301, 20);
            this.txtBudget_SKU.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtFORMATDATE_OUT);
            this.groupBox1.Controls.Add(this.txtFORMATDATE_IN);
            this.groupBox1.Location = new System.Drawing.Point(8, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(693, 169);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Memo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(85, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Format Date Output";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Format Date Input";
            // 
            // txtFORMATDATE_OUT
            // 
            this.txtFORMATDATE_OUT.Location = new System.Drawing.Point(262, 45);
            this.txtFORMATDATE_OUT.Name = "txtFORMATDATE_OUT";
            this.txtFORMATDATE_OUT.Size = new System.Drawing.Size(301, 20);
            this.txtFORMATDATE_OUT.TabIndex = 0;
            // 
            // txtFORMATDATE_IN
            // 
            this.txtFORMATDATE_IN.Location = new System.Drawing.Point(262, 19);
            this.txtFORMATDATE_IN.Name = "txtFORMATDATE_IN";
            this.txtFORMATDATE_IN.Size = new System.Drawing.Size(301, 20);
            this.txtFORMATDATE_IN.TabIndex = 0;
            // 
            // btnCheckData
            // 
            this.btnCheckData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckData.Image = global::FCV.Promotion.Properties.Resources.tick;
            this.btnCheckData.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnCheckData.Location = new System.Drawing.Point(643, 9);
            this.btnCheckData.Name = "btnCheckData";
            this.btnCheckData.Size = new System.Drawing.Size(145, 33);
            this.btnCheckData.TabIndex = 2;
            this.btnCheckData.Text = "Save";
            this.btnCheckData.UseVisualStyleBackColor = true;
            this.btnCheckData.Click += new System.EventHandler(this.btnCheckData_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(792, 533);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "B2B";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.label12);
            this.groupBox4.Controls.Add(this.txtB2BFORMATDATE_OUT);
            this.groupBox4.Controls.Add(this.txtB2BFORMATDATE_IN);
            this.groupBox4.Location = new System.Drawing.Point(8, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(693, 169);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Memo";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(85, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 13);
            this.label11.TabIndex = 1;
            this.label11.Text = "Format Date Output";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(85, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(92, 13);
            this.label12.TabIndex = 1;
            this.label12.Text = "Format Date Input";
            // 
            // txtB2BFORMATDATE_OUT
            // 
            this.txtB2BFORMATDATE_OUT.Location = new System.Drawing.Point(262, 45);
            this.txtB2BFORMATDATE_OUT.Name = "txtB2BFORMATDATE_OUT";
            this.txtB2BFORMATDATE_OUT.Size = new System.Drawing.Size(301, 20);
            this.txtB2BFORMATDATE_OUT.TabIndex = 0;
            // 
            // txtB2BFORMATDATE_IN
            // 
            this.txtB2BFORMATDATE_IN.Location = new System.Drawing.Point(262, 19);
            this.txtB2BFORMATDATE_IN.Name = "txtB2BFORMATDATE_IN";
            this.txtB2BFORMATDATE_IN.Size = new System.Drawing.Size(301, 20);
            this.txtB2BFORMATDATE_IN.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.txtB2B_BudgetValue);
            this.groupBox5.Controls.Add(this.txtB2B_DistributorCode);
            this.groupBox5.Controls.Add(this.txtB2B_DiscountValue);
            this.groupBox5.Controls.Add(this.txtB2B_CustomerCode);
            this.groupBox5.Controls.Add(this.txtB2B_SKUCode);
            this.groupBox5.Location = new System.Drawing.Point(8, 178);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(693, 307);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Budget";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(95, 182);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(68, 13);
            this.label13.TabIndex = 1;
            this.label13.Text = "BudgetValue";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(95, 78);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(79, 13);
            this.label14.TabIndex = 1;
            this.label14.Text = "DistributorCode";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(95, 156);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(49, 13);
            this.label15.TabIndex = 1;
            this.label15.Text = "Discount";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(95, 130);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(29, 13);
            this.label16.TabIndex = 1;
            this.label16.Text = "SKU";
            // 
            // txtB2B_BudgetValue
            // 
            this.txtB2B_BudgetValue.Location = new System.Drawing.Point(262, 175);
            this.txtB2B_BudgetValue.Name = "txtB2B_BudgetValue";
            this.txtB2B_BudgetValue.Size = new System.Drawing.Size(301, 20);
            this.txtB2B_BudgetValue.TabIndex = 0;
            // 
            // txtB2B_DistributorCode
            // 
            this.txtB2B_DistributorCode.Location = new System.Drawing.Point(262, 71);
            this.txtB2B_DistributorCode.Name = "txtB2B_DistributorCode";
            this.txtB2B_DistributorCode.Size = new System.Drawing.Size(301, 20);
            this.txtB2B_DistributorCode.TabIndex = 0;
            // 
            // txtB2B_DiscountValue
            // 
            this.txtB2B_DiscountValue.Location = new System.Drawing.Point(262, 149);
            this.txtB2B_DiscountValue.Name = "txtB2B_DiscountValue";
            this.txtB2B_DiscountValue.Size = new System.Drawing.Size(301, 20);
            this.txtB2B_DiscountValue.TabIndex = 0;
            // 
            // txtB2B_SKUCode
            // 
            this.txtB2B_SKUCode.Location = new System.Drawing.Point(262, 123);
            this.txtB2B_SKUCode.Name = "txtB2B_SKUCode";
            this.txtB2B_SKUCode.Size = new System.Drawing.Size(301, 20);
            this.txtB2B_SKUCode.TabIndex = 0;
            // 
            // txtB2B_CustomerCode
            // 
            this.txtB2B_CustomerCode.Location = new System.Drawing.Point(262, 97);
            this.txtB2B_CustomerCode.Name = "txtB2B_CustomerCode";
            this.txtB2B_CustomerCode.Size = new System.Drawing.Size(301, 20);
            this.txtB2B_CustomerCode.TabIndex = 0;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(95, 104);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(76, 13);
            this.label17.TabIndex = 1;
            this.label17.Text = "CustomerCode";
            // 
            // FormConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 607);
            this.Controls.Add(this.btnCheckData);
            this.Controls.Add(this.tabConfig);
            this.Name = "FormConfig";
            this.Text = "FormConfig";
            this.Load += new System.EventHandler(this.FormConfig_Load);
            this.tabConfig.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabConfig;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCheckData;
        private System.Windows.Forms.TextBox txtFORMATDATE_OUT;
        private System.Windows.Forms.TextBox txtFORMATDATE_IN;
        private System.Windows.Forms.TextBox txtBudget_BudgetValue;
        private System.Windows.Forms.TextBox txtBudget_DistributorCode;
        private System.Windows.Forms.TextBox txtBudget_Discount;
        private System.Windows.Forms.TextBox txtBudget_SKU;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDiscount_SKU;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDiscount_DiscountCode;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDiscount_DistributorCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtDiscount_CustomerCode;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtB2B_BudgetValue;
        private System.Windows.Forms.TextBox txtB2B_DistributorCode;
        private System.Windows.Forms.TextBox txtB2B_DiscountValue;
        private System.Windows.Forms.TextBox txtB2B_SKUCode;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtB2BFORMATDATE_OUT;
        private System.Windows.Forms.TextBox txtB2BFORMATDATE_IN;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtB2B_CustomerCode;
    }
}