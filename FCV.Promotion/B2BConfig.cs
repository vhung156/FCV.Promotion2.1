using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FCV.Promotion
{
    public static class B2BConfig
    {
        public static string B2B_TENCHUONGTRINH_Value = "Tên chương trình";
        public static string B2B_FORMAT_PROMOTIONCODE = "MC7PD_B2B_";

        public static string FORMAT_FILENAME_EXPORT = "_yyyyMMdd_HHmmss";
        public static string FORMATDATE_IN = "MM/dd/yyyy";
        public static string FORMATDATE_OUT = "yyyy/MM/dd";
        public static string DISCOUNT_FORMAT_PROMOTIONCODE = "MC7PD_";
        public static string B2B_SCHEME_ID_Value = "SCHEME";


        public const string B2B_DistributorCode_Key = "B2B_DistributorCode";
        public const string B2B_DistributorName_Key = "B2B_DistributorName";
        public const string B2B_CustomerCode_Key = "B2B_CustomerCode";
        public const string B2B_CustomerName = "B2B_CustomerName";
        public const string B2B_SKUCode_Key = "B2B_SKUCode";
        public const string B2B_DiscountValue_Key = "B2B_DiscountValue";
        public const string B2B_BudgetValue_Key = "B2B_BudgetValue";
        public const string B2B_ColumnListCheck_Key = "B2B_ColumnListCheck";
        public const string B2B_ColumnListCheckDuplicate_Key = "B2B_ColumnListCheckDuplicate";   
       

        public static string MEMO_KENHBANHANG_Value = "Kênh bán hàng";
        public static string MEMO_NGHANHHANG_Value = "Ngành hàng";
        public static string MEMO_SCHEME_ID_Value = "SCHEME ID";
        public static int B2B_UOMName_Index = 0, B2B_UOMCode_Index = 1;

        public static int B2B_DistributorCode_Index = 2, B2B_CustomerCode_Index = 4, B2B_SKUCode_Index = 6, B2B_DiscountValue_Index = 7, B2B_BudgetValue_Index = 8;

        public static string B2B_ColumnListCheck_Value = "";
        public static string B2B_ColumnListCheckDuplicate_Value = "";

        public static void ReadConfig()
        {
            try
            {
                B2BConfig.FORMATDATE_IN = Common.ReadConfigXML(Common.STR_FILECONF, "B2BFORMATDATE_IN");
                B2BConfig.FORMATDATE_OUT = Common.ReadConfigXML(Common.STR_FILECONF, "B2BFORMATDATE_OUT");

                // Load Config Discount Sheet

                int.TryParse(Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_DistributorCode_Key), out B2B_DistributorCode_Index);
                int.TryParse(Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_CustomerCode_Key), out B2B_CustomerCode_Index);
                int.TryParse(Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_SKUCode_Key), out B2B_SKUCode_Index);
                int.TryParse(Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_DiscountValue_Key), out B2B_DiscountValue_Index);
                int.TryParse(Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_BudgetValue_Key), out B2B_BudgetValue_Index);

                B2B_ColumnListCheck_Value = Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_ColumnListCheck_Key);
                B2B_ColumnListCheckDuplicate_Value = Common.ReadConfigXML(Common.STR_FILECONF, B2BConfig.B2B_ColumnListCheckDuplicate_Key);
            }
            catch
            {

            }
        }
    }


}
