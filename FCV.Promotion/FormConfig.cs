using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCV.Promotion
{
    public partial class FormConfig : Form
    {
        //string FORMATDATE_IN = "dd/MM/yyyy";
        //string FORMATDATE_OUT = "yyyy/MM/dd";
        int UOMNameIndex = 5;
        int UOMCodeIndex = 6;
        int B_iSKU = 0, B_iDiscountCode = 1, B_iDistributorCode = 3, B_iBudgetColumn = 5;
        int DIS_iDistributorCode = 2, DIS_iCustomerCode = 4, DIS_iSKU = 6, DIS_iDiscountCode = 7;

        public FormConfig()
        {
            InitializeComponent();
        }

        private void FormConfig_Load(object sender, EventArgs e)
        {
            LoadConfig();
        }
        private void LoadConfig()
        {

            
            //Memo Sheet
            //AppConfig.FORMATDATE_IN = Common.ReadConfigXML(Common.STR_FILECONF, "FORMATDATE_IN");
            //AppConfig.FORMATDATE_OUT = Common.ReadConfigXML(Common.STR_FILECONF, "FORMATDATE_OUT");

            txtFORMATDATE_IN.Text = AppConfig.FORMATDATE_IN;
            txtFORMATDATE_OUT.Text = AppConfig.FORMATDATE_OUT;


            // Budget Sheet

            txtBudget_SKU.Text =AppConfig.Budget_SKU_Value;
            txtBudget_Discount.Text = AppConfig.Budget_Discount_Value;
            txtBudget_DistributorCode.Text =  AppConfig.Budget_DistributorCode_Value;
            txtBudget_BudgetValue.Text =  AppConfig.Budget_BudgetValue_Value;

            //txtBudget_SKU.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_SKU);
            //txtBudget_Discount.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_Discount);
            //txtBudget_DistributorCode.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_DistributorCode);
            //txtBudget_BudgetValue.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_BudgetValue);

            // Discount Sheet

            txtDiscount_DistributorCode.Text = AppConfig.Discount_DistributorCode_Value;
            txtDiscount_CustomerCode.Text = AppConfig.Discount_CustomerCode_Value;
            txtDiscount_SKU.Text = AppConfig.Discount_SKU_Value;
            txtDiscount_DiscountCode.Text =AppConfig.Discount_DiscountCode_Value;

            //txtDiscount_DistributorCode.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_DistributorCode);
            //txtDiscount_CustomerCode.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_CustomerCode);
            //txtDiscount_SKU.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_SKU);
            //txtDiscount_DiscountCode.Text = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_DiscountCode);
            // Column Excel




            // B2B Sheet


            txtB2BFORMATDATE_IN.Text = B2BConfig.FORMATDATE_IN;
            txtB2BFORMATDATE_OUT.Text = B2BConfig.FORMATDATE_OUT;

            txtB2B_DistributorCode.Text = B2BConfig.B2B_DistributorCode_Index.ToString();
            txtB2B_CustomerCode.Text = B2BConfig.B2B_CustomerCode_Index.ToString();
            txtB2B_SKUCode.Text = B2BConfig.B2B_SKUCode_Index.ToString();
            txtB2B_DiscountValue.Text = B2BConfig.B2B_DiscountValue_Index.ToString();
            txtB2B_BudgetValue.Text = B2BConfig.B2B_BudgetValue_Index.ToString();

        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            try
            {
                Common.WtiteConfigXML(Common.STR_FILECONF, "FORMATDATE_IN", txtFORMATDATE_IN.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, "FORMATDATE_OUT", txtFORMATDATE_OUT.Text);


                // Budget sheet

                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Budget_SKU, txtBudget_SKU.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Budget_Discount, txtBudget_Discount.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Budget_DistributorCode, txtBudget_DistributorCode.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Budget_BudgetValue, txtBudget_BudgetValue.Text);

                //Discount sheet

                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Discount_DistributorCode, txtDiscount_DistributorCode.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Discount_CustomerCode, txtDiscount_CustomerCode.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Discount_SKU, txtDiscount_SKU.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, AppConfig.Discount_DiscountCode, txtDiscount_DiscountCode.Text);

                AppConfig.ReadConfig();



                //Discount sheet

                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.FORMATDATE_IN, txtB2BFORMATDATE_IN.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.FORMATDATE_OUT, txtB2BFORMATDATE_OUT.Text);


                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.B2B_DistributorCode_Key, txtB2B_DistributorCode.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.B2B_CustomerCode_Key, txtB2B_CustomerCode.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.B2B_SKUCode_Key, txtB2B_SKUCode.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.B2B_DiscountValue_Key, txtB2B_DiscountValue.Text);
                Common.WtiteConfigXML(Common.STR_FILECONF, B2BConfig.B2B_BudgetValue_Key, txtB2B_BudgetValue.Text);
                B2BConfig.ReadConfig();

                MessageBox.Show("Saved");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
