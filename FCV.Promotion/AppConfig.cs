using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCV.Promotion
{
    public static class AppConfig
    {

        public static string FORMAT_FILENAME_EXPORT = "_yyyyMMdd_HHmmss";
        public static string FORMATDATE_IN = "dd/MM/yyyy";
        public static string FORMATDATE_OUT = "yyyy/MM/dd";
        public static string DISCOUNT_FORMAT_PROMOTIONCODE = "MC7PD_";

        public const string Budget_SKU = "Budget_SKU";
        public const string Budget_Discount = "Budget_Discount";
        public const string Budget_DistributorCode = "Budget_DistributorCode";
        public const string Budget_BudgetValue = "Budget_BudgetValue";


        public const string Discount_DistributorCode = "Discount_DistributorCode";
        public const string Discount_CustomerCode = "Discount_CustomerCode";
        public const string Discount_SKU = "Discount_SKU";
        public const string Discount_DiscountCode = "Discount_DiscountCode";

        public const string Budget_PromotionCodeForDiscount = "Budget_PromotionCodeForDiscount";
        public const string ProductCodeAndName = "UOM_ProductCodeAndName";

        public const string Discount_MapPromotionCodeFromBudget = "Discount_MapPromotionCodeFromBudget";



        public static string Budget_SKU_Value = string.Empty;
        public static string Budget_Discount_Value = string.Empty;
        public static string Budget_DistributorCode_Value = string.Empty;
        public static string Budget_BudgetValue_Value = string.Empty;


        public static string Discount_DistributorCode_Value = string.Empty;
        public static string Discount_CustomerCode_Value = string.Empty;
        public static string Discount_SKU_Value = string.Empty;
        public static string Discount_DiscountCode_Value = string.Empty;


        public static string Budget_PromotionCodeForDiscount_Value = string.Empty;
        public static string UOM_ProductCodeAndName_Value = string.Empty;
        public static string Discount_MapPromotionCodeFromBudget_Value = string.Empty;

        public static string MEMO_KENHBANHANG_Value = "Kênh bán hàng";
        public static string MEMO_NGHANHHANG_Value = "Ngành hàng";
        public static string MEMO_SCHEME_ID_Value = "SCHEME ID";

        public static int B_iSKU = 0, B_iDiscountCode = 1, B_iDistributorCode = 3, B_iBudgetColumn = 5;
        public static int DIS_iDistributorCode = 2, DIS_iCustomerCode = 4, DIS_iSKU = 6, DIS_iDiscountCode = 7;
        public static int DIS_UOMNameIndex = 5, DIS_UOMCodeIndex = 6;


        public static int B2B_UOMNameIndex = 0, B2B_UOMCodeIndex = 1;
        public static int B2B_iCustomerCode = 4, B2B_iSKU = 6, B2B_iDiscountCode = 7;
        public static int B2B_Bud_iDistributorCode = 1, B2B_Bud_iSKUColumn = 0,B2B_Bud_iBudgetValue = 3;
        public static int B2B_Detail_iDistributorCode = 2, B2B_Detail_iSKUColumn = 6, B2B_Detail_iCustID = 4;

        public static string B2B_TENCHUONGTRINH_Value = "Tên chương trình";
        public static string B2B_FORMAT_PROMOTIONCODE = "MC7PD_B2B_";


        public static void ReadConfig()
        {
            try
            {
                AppConfig.FORMATDATE_IN = Common.ReadConfigXML(Common.STR_FILECONF, "FORMATDATE_IN");
                AppConfig.FORMATDATE_OUT = Common.ReadConfigXML(Common.STR_FILECONF, "FORMATDATE_OUT");

                AppConfig.UOM_ProductCodeAndName_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.ProductCodeAndName);

                AppConfig.Budget_SKU_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_SKU);
                AppConfig.Budget_Discount_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_Discount);
                AppConfig.Budget_BudgetValue_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_BudgetValue);
                AppConfig.Budget_PromotionCodeForDiscount_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_PromotionCodeForDiscount);
                AppConfig.Budget_DistributorCode_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Budget_DistributorCode);
                
                
               
                AppConfig.Discount_DistributorCode_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_DistributorCode);
                AppConfig.Discount_CustomerCode_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_CustomerCode);
                AppConfig.Discount_SKU_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_SKU);
                AppConfig.Discount_DiscountCode_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_DiscountCode);

                AppConfig.Discount_MapPromotionCodeFromBudget_Value = Common.ReadConfigXML(Common.STR_FILECONF, AppConfig.Discount_MapPromotionCodeFromBudget);


                // Order Column Product
                string[] sArray = UOM_ProductCodeAndName_Value.Split(';');
                if (sArray.Length == 2)
                {
                    int.TryParse(sArray[0], out DIS_UOMNameIndex);
                    int.TryParse(sArray[1], out DIS_UOMCodeIndex);
                }

                // Budget

                int.TryParse(Budget_BudgetValue_Value, out B_iBudgetColumn);

                string[] sArray0 = Budget_PromotionCodeForDiscount_Value.Split(';');
                if (sArray0.Length == 2)
                {
                    int.TryParse(sArray0[0], out B_iSKU);
                    int.TryParse(sArray0[1], out B_iDiscountCode);

                }

                string[] sArray1 = Discount_MapPromotionCodeFromBudget_Value.Split(';');
                if (sArray0.Length == 2)
                {
                    int.TryParse(sArray1[0], out B_iDiscountCode);
                    int.TryParse(sArray1[1], out B_iDistributorCode);
                }

                // Load Config Discount Sheet


                int.TryParse(Discount_DistributorCode_Value, out DIS_iDistributorCode);
                int.TryParse(Discount_CustomerCode_Value, out DIS_iCustomerCode);
                int.TryParse(Discount_SKU_Value, out DIS_iSKU);
                int.TryParse(Discount_DiscountCode_Value, out DIS_iDiscountCode);

            }
            catch
            {

            }
        }
    }


}
