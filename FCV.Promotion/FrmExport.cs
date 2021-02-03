using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCV.Promotion
{
    public partial class FrmExport : Form
    {
        //string STR_FILECONF = Application.StartupPath + @"\FCV.Promotion.exe.config";
        const string STR_CONF = @"TEMPLATE\FCV_PRO_CONF.xlsx";
        const string STR_SKU_CONF = @"TEMPLATE\Template SKU code.xlsx";     
        DataSet dsDISExport,dsB2BExport;
        DataTable dtBudgetMemo, dtDiscountMemo,dtSKUCODE,dtNullPromotionCode;
        DataTable dtB2BMemo, dtB2RawData,dtB2BSKUCode;
        //int UOMNameIndex = 5, UOMCodeIndex = 6;
        int B_iSKU = 0, B_iDiscountCode = 1,B_iDistributorCode = 3, B_iBudgetColumn = 5;
        int DIS_iDistributorCode = 2, DIS_iCustomerCode = 4, DIS_iSKU = 6, DIS_iDiscountCode = 7, DIS_iBudget = 7;

        //frmProgress myWait;
        Thread myProcess;


        public FrmExport()
        {
            InitializeComponent();
            Aspose.Cells.License licenseKey = new Aspose.Cells.License();
            licenseKey.SetLicense(LicenseKeyAsposeCells.LStream);
            LoadConfig();
            LoadStructure();
        } 
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void LoadConfig()
        {

            B2BConfig.ReadConfig();
            // Column Excel of Budget
          
            int.TryParse(AppConfig.Budget_BudgetValue_Value, out this.B_iBudgetColumn);

            string[] sArray0 = AppConfig.Budget_PromotionCodeForDiscount_Value.Split(';');
            if (sArray0.Length == 2)
            {
                int.TryParse(sArray0[0], out this.B_iSKU);
                int.TryParse(sArray0[1], out this.B_iDiscountCode);
                
            }

            string[] sArray1 = AppConfig.Discount_MapPromotionCodeFromBudget_Value.Split(';');
            if (sArray0.Length == 2)
            {
                int.TryParse(sArray1[0], out this.B_iDiscountCode);
                int.TryParse(sArray1[1], out this.B_iDistributorCode);
            }

            // Load Config Discount Sheet

            int.TryParse(AppConfig.Discount_DistributorCode_Value, out this.DIS_iDistributorCode);
            int.TryParse(AppConfig.Discount_CustomerCode_Value, out this.DIS_iCustomerCode);
            int.TryParse(AppConfig.Discount_SKU_Value, out this.DIS_iSKU);
            int.TryParse(AppConfig.Discount_DiscountCode_Value, out this.DIS_iDiscountCode);


            //Combobox

            DataTable dtCboCode = new DataTable();
            dtCboCode.Columns.Add("Code", typeof(string));
            dtCboCode.Columns.Add("Label", typeof(string));
            dtCboCode.Rows.Add("DIS", "Discount");
            dtCboCode.Rows.Add("B2B", "B2B");
            cboPromotionType.DataSource = dtCboCode;
            cboPromotionType.DisplayMember = "Label";
            cboPromotionType.ValueMember = "Code";
            cboPromotionType.SelectedIndex = 0;
            // Checkbox
            chkAutosave.Checked = 0 == string.Compare("Yes", Common.ReadConfigXML(Common.STR_FILECONF, "IsAutoSave"), true);
            chkOpen.Checked = 0 == string.Compare("Yes", Common.ReadConfigXML(Common.STR_FILECONF, "IsOpen"), true);

            string sSaveType = Common.ReadConfigXML(Common.STR_FILECONF, "SaveType");


            if (sSaveType == "E")
            {
                radioExcel.Checked = true;
                radioMulti.Checked = false;
                radioAll.Checked = false;
            }
            else if (sSaveType == "C")
            {
                radioExcel.Checked = false;
                radioMulti.Checked = true;
                radioAll.Checked = false;
            }
            else
            {
                radioExcel.Checked = false;
                radioMulti.Checked = false;
                radioAll.Checked = true;
            }
        }
       
        private void LoadStructure()
        {
            string strFileStructure = Application.StartupPath + @"\" + STR_CONF;
            DataSet dsStruct = clsExcel.ReadExcelToDataSet(strFileStructure);

        }


        private DataTable GetDuplicateData(DataTable dtData)
        {
            

            DataTable resultTable = new DataTable();
            resultTable.Columns.Add(new DataColumn("Key"));
            resultTable.Columns.Add(new DataColumn("Value"));

            var result = from c in dtData.AsEnumerable()
                         group c by new
                         {
                             Key = c.Field<string>(0),   //column names for checking duplicate values.
                             Value = c.Field<string>(1)
                             //LastName = c.Field<string>("LastName"),
                             //Quality = c.Field<string>("Quality")
                         } into g
                         where g.Count() > 1
                         select new
                         {
                             g.Key.Key,
                             g.Key.Value
                             //g.Key.LastName,
                             //g.Key.Quality
                         };

            for (int i = 0; i < result.ToList().Count; i++)
            {
                var item = result.ToList()[i];
                resultTable.Rows.Add(item.Key, item.Value);
            }

            return resultTable;
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string PathExport;
                if (!File.Exists(txtFileName1.Text))
                {
                    MessageBox.Show("File không tồn tại!");
                    return;
                }
                this.dtBudgetMemo = null;
                this.dtDiscountMemo = null;
                DataSet dsMemo = clsExcel.ReadExcelToDataSet(txtFileName1.Text);
                string strFileStructure = Application.StartupPath + @"\" + STR_CONF;
                this.dtSKUCODE = clsExcel.ReadExcel(Application.StartupPath + @"\" + STR_SKU_CONF, true);
                if (radioDiscount.Checked)///cboPromotionType.SelectedValue.ToString() == "DIS"
                {
                    if(!dsMemo.Tables.Contains("Discount"))
                    {
                        MessageBox.Show("Không tồn tài sheet Discount");
                        return;
                    }
                    PathExport = Application.StartupPath + @"\Export\DIS\Excel\";
                    this.dsDISExport = new DataSet();                  
                    DIS_CreatDataForExport(dsMemo);
                    
                    if (radioExcel.Checked)
                    {
                        ExportExcel(this.dsDISExport, PathExport);
                     
                    }
                    else if (radioMulti.Checked)
                    {
                        ExportExcelMutilFile(this.dsDISExport, PathExport);
                        MessageBox.Show("Done!");
                    }
                    else if (radioAll.Checked)
                    {
                        ExportExcelMutilFile(this.dsDISExport, PathExport);
                        ExportExcel(this.dsDISExport, PathExport);

                    }
                }
                else if (radioB2B.Checked)//cboPromotionType.SelectedValue.ToString() == "B2B"
                {
                    if (!dsMemo.Tables.Contains("RawData"))
                    {
                        MessageBox.Show("Không tồn tài RawData");
                        return;
                    }

                    if (!dsMemo.Tables.Contains("SKUCode"))
                    {
                        MessageBox.Show("Không tồn tài SKUCode");
                        return;
                    }
                    PathExport = Application.StartupPath + @"\Export\B2B\Excel\";
                    this.dsDISExport = new DataSet();    
                    B2B_CreatDataForExport(dsMemo);
                    if (dtNullPromotionCode.Rows.Count > 0)
                    {
                        frmShowError frm = new frmShowError();
                        frm.Load(dtNullPromotionCode, "B2B: Lỗi khi tính dữ liệu");
                        frm.ShowDialog();
                        return;
                    }
                    if (radioExcel.Checked)
                    {
                        ExportExcel(this.dsB2BExport, PathExport);
                    }
                    else if (radioMulti.Checked)
                    {
                        ExportExcelMutilFile(this.dsB2BExport, PathExport);
                        MessageBox.Show("Done!");
                    }
                    else if (radioAll.Checked)
                    {
                        ExportExcelMutilFile(this.dsB2BExport, PathExport);
                        ExportExcel(this.dsB2BExport, PathExport);

                    }
                }
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        
        #region Discount
        private void DIS_CreatDataForExport(DataSet dsMemo)
        {
            //
            dtNullPromotionCode = new DataTable();
            dtNullPromotionCode.Columns.Add("DistributorCode", typeof(string));
            dtNullPromotionCode.Columns.Add("Discount", typeof(string));
            dtNullPromotionCode.Columns.Add("ErrorMessage", typeof(string));

            DataSet dsStruct = clsExcel.ReadExcelToDataSet(Application.StartupPath + @"\" + STR_CONF);
            DataTable dtSumBudgetMemo = DIS_CreatePromCode(dsMemo); //dsMemo.Tables["Data"];
            foreach (DataTable dtStructure in dsStruct.Tables)
            {  
                //DataTable dtBudgetMemo = CreatePromCode(dsMemo);

                dtStructure.Rows.Clear();
                if (dtStructure.TableName.ToUpper().Contains("HEADER"))
                {
                    // Getdata from MemoSheet
                    string sRef = this.DIS_GetReferenceNumber(dsMemo);
                    string SNotes = this.DIS_GetGLNotes(dsMemo);
                    string Promotion_Category = this.DIS_GetDataFromMemoSheet(dsMemo, AppConfig.MEMO_NGHANHHANG_Value, 0, 1);
                    DateTime sStartDate = this.DIS_GetStartDate(dsMemo);
                    DateTime sEndDate = this.DIS_GetEndDate(dsMemo);
                    DateTime sClaimDate = DateTime.ParseExact("17/" + sEndDate.AddMonths(4).Month.ToString("00") + "/"+sEndDate.AddMonths(4).Year.ToString(), AppConfig.FORMATDATE_IN, null);

                    foreach (DataRow drDataMemo in dtSumBudgetMemo.Rows)
                    {

                        DataRow drHeader = dtStructure.NewRow();
                        string code = drDataMemo["Code"].ToString();
                        drHeader[0] = "HQ"; // Distributor Code
                        drHeader[1] = code; // Promotion Code
                        drHeader[2] = drDataMemo["Description"]; // Promotion Description
                        drHeader[3] = "A"; // Promotion Status
                        drHeader[4] = sStartDate.ToString(AppConfig.FORMATDATE_OUT); // Start Date
                        drHeader[5] = sEndDate.ToString(AppConfig.FORMATDATE_OUT); ; // End Date
                        drHeader[6] = "1"; // Claimable Ind
                        drHeader[7] = sClaimDate.ToString(AppConfig.FORMATDATE_OUT); // Claim End Day
                        drHeader[8] = ""; // Tplan Number
                        drHeader[9] = "D"; // Type
                        drHeader[10] = Promotion_Category; // Promotion Category
                        drHeader[11] = ""; // SpaceBuy Type
                        drHeader[12] = drDataMemo["Budget"];   // Budget
                        drHeader[13] = sRef; // Reference Number oR Scheme ID
                        drHeader[14] = "Q"; // Detail Type 
                        drHeader[15] = "CU"; // Total Buy UOM Code 
                        drHeader[16] = "ZZC4"; // Claim Type
                        drHeader[17] = "Y"; // Taxable Ind
                        drHeader[18] = "1"; // Auto Checked
                        drHeader[19] =  sClaimDate.AddDays(-1).ToString(AppConfig.FORMATDATE_OUT);  // Spacebuy End Date
                        drHeader[20] = SNotes; // Notes
                        drHeader[21] = "10"; // Tax
                        dtStructure.Rows.Add(drHeader);
                    }


                }
                if (dtStructure.TableName.ToUpper().Contains("DETAIL"))
                {
                    foreach (DataRow drDataMemo in dtSumBudgetMemo.Rows)
                    {

                        DataRow drdetail = dtStructure.NewRow();
                        string code = drDataMemo["Code"].ToString();
                        double dbPercent = Convert.ToDouble(drDataMemo["Discount"].ToString().Replace("%", "").Replace(",", "."));

                        drdetail[0] = "HQ"; // Distributor Code
                        drdetail[1] = code; // Promotion Code
                        drdetail[2] = "1"; // Promotion Description
                        drdetail[3] = "3"; // Promotion Status
                        drdetail[4] = "1";
                        drdetail[5] = dbPercent;
                        drdetail[6] = "2"; // Claimable Ind                       
                        dtStructure.Rows.Add(drdetail);
                    }
                }

                if (dtStructure.TableName.ToUpper().Contains("BUDGET"))
                {
                    foreach (DataRow drDataMemo in this.dtBudgetMemo.Rows)
                    {
                        DataRow drBudget = dtStructure.NewRow();
                        string sRef = drDataMemo["SKU"].ToString() + drDataMemo["Discount"].ToString();
                        string code = this.DIS_GetPromotionCodeForBudget(dtSumBudgetMemo, sRef);

                        drBudget[0] = "HQ"; // Distributor Code
                        drBudget[1] = code; // Promotion Cod
                        drBudget[2] = "3"; // Promotion Description
                        drBudget[3] = drDataMemo[this.B_iDistributorCode].ToString().Trim(); // Promotion Status
                        drBudget[4] = "";
                        drBudget[5] = drDataMemo[this.B_iBudgetColumn].ToString().Trim();       //Budget (n25,4)
                        dtStructure.Rows.Add(drBudget);
                    }
                }
                if (dtStructure.TableName.ToUpper().Contains("PRODUCT"))
                {
                    foreach (DataRow drDiscountMemo in this.dtDiscountMemo.Rows)
                    {
                       
                        string UOMcode = this.DIS_GetUOMCode(this.dtSKUCODE, drDiscountMemo[this.DIS_iSKU].ToString().Trim());

                        string[] sArrayCode = UOMcode.Split(';');
                        foreach (string itemCode in sArrayCode)
                        {
                            DataRow drPRODUCT = dtStructure.NewRow();
                            drPRODUCT[0] = "HQ"; // Distributor Code
                            drPRODUCT[1] = drDiscountMemo["PromotionCode"]; // Promotion Cod
                            drPRODUCT[2] = "1"; // Promotion Index(int)
                            drPRODUCT[3] = "3"; // Product Category Level 
                            drPRODUCT[4] = itemCode; // Product Category
                            drPRODUCT[5] = "CU"; //UOM Code
                            drPRODUCT[6] = "1";       //Parent Code 
                            drPRODUCT[7] = "0";       //Must Ind                     0 = No1 = Yes(c1)
                            dtStructure.Rows.Add(drPRODUCT);
                        }
                    }
                }

                if (dtStructure.TableName.ToUpper().Contains("ASSIGND"))
                {
                    foreach (DataRow drDataMemo in this.dtBudgetMemo.Rows)
                    {
                        DataRow drBudget = dtStructure.NewRow();
                       
                        drBudget[0] = "HQ"; // Distributor Code
                        drBudget[1] = drDataMemo["PromotionCode"]; // Promotion Cod
                        drBudget[2] = "D"; // Assignment type
                        drBudget[3] = ""; // Promotion Status
                        drBudget[4] = drDataMemo[this.B_iDistributorCode].ToString().Trim(); //Assignment Code
                        drBudget[5] = "";       //Parent Code 
                        dtStructure.Rows.Add(drBudget);
                    }
                }

                if (dtStructure.TableName.ToUpper().Contains("ASSIGNC"))
                {
                    foreach (DataRow drDiscountMemo in this.dtDiscountMemo.Rows)
                    {
                        DataRow drBudget = dtStructure.NewRow();
                      
                        drBudget[0] = "HQ"; // Distributor Code
                        drBudget[1] = drDiscountMemo["PromotionCode"]; // Promotion Cod
                        drBudget[2] = "C"; // Assignment type
                        drBudget[3] = ""; // Promotion Status
                        drBudget[4] = drDiscountMemo[this.DIS_iCustomerCode].ToString().Trim(); //Assignment Code (Customer Code)
                        drBudget[5] = drDiscountMemo[this.DIS_iDistributorCode].ToString().Trim();       //Parent Code  (Distributor Code)
                        dtStructure.Rows.Add(drBudget);
                    }
                }

                
            }

            dsDISExport = dsStruct;
        }
        private string DIS_GetDataFromMemoSheet(DataSet dsMemo, String Data, int R, int C)
        {
            string sRef = string.Empty;

            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("MEMO"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString() == Data)
                            {
                                return dtStructure.Rows[i + R][j + C].ToString();
                            }
                        }
                    }

                }
            }
            return sRef;

        }
        private string DIS_GetReferenceNumber(DataSet dsMemo)
        {
            string sRef = string.Empty;

            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("MEMO"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString().ToUpper().Contains(AppConfig.MEMO_SCHEME_ID_Value))
                            {
                                return dtStructure.Rows[i + 1][j].ToString();
                            }
                        }
                    }

                }
            }
            return sRef;
        }

        private string DIS_GetGLNotes(DataSet dsMemo)
        {
            string sRef = string.Empty;

            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("MEMO"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString() == "GL")
                            {
                                return dtStructure.Rows[i + 1][j].ToString();
                            }
                        }
                    }

                }
            }
            return sRef;

        }
        private string DIS_GetPromotionCodeForBudget(DataTable dtData, string Code)
        {
            string sProCode = string.Empty;

            DataRow[] rows = dtData.Select("Ref = '" + Code + "'");
            if (rows.Length > 0)
                return rows[0]["Code"].ToString();
            return sProCode;

        }
        private string DIS_GetUOMCode(DataTable dtData, string Code)
        {
            string sUOMCode = string.Empty;

            var rows = dtData.AsEnumerable().Where
             (row => row.Field<string>(AppConfig.DIS_UOMNameIndex) == Code.ToUpper()).ToArray();
           

            if (rows.Length > 0)
            {
                sUOMCode = rows[0].Field<string>(AppConfig.DIS_UOMCodeIndex);
                if (rows[0].Field<string>(AppConfig.DIS_UOMCodeIndex + 1) != null && rows[0].Field<string>(AppConfig.DIS_UOMCodeIndex + 1).Trim() != string.Empty)
                    sUOMCode += ";" + rows[0].Field<string>(AppConfig.DIS_UOMCodeIndex + 1).Trim();
            }
            return sUOMCode;

        }
        private string DIS_GetPromotionCodeForDistributor(DataTable dtData, string DistributorCode,string DiscountCode)
        {


            string sProCode = string.Empty;

            var rows = dtData.AsEnumerable().Where
             (row => row.Field<string>(AppConfig.DIS_iDistributorCode) == DistributorCode && row.Field<string>(this.B_iDiscountCode) == DiscountCode).ToArray();


            if(rows.Length>0)
            {
                sProCode = rows[0].Field<string>("PromotionCode");
            }

            if(sProCode == string.Empty)
            {
                dtNullPromotionCode.Rows.Add(DistributorCode, DiscountCode, "Không gán được mã CTKM vào sheet Discount");
                //MessageBox.Show("Promocode is blank: (DistributorCode :" + DistributorCode + "; DiscountCode:" + DiscountCode + ")");
            }

            return sProCode;

        }
        private DateTime DIS_GetEndDate(DataSet dsMemo)
        {
            DateTime dte = DateTime.Now;
            //DateTime date = DateTime.ParseExact(strDate, "dd/MM/YYYY", null)
            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("MEMO"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString().ToUpper() == "ĐẾN NGÀY")
                            {
                                return DateTime.ParseExact(dtStructure.Rows[i][j + 1].ToString(), AppConfig.FORMATDATE_IN, null);
                            }
                        }
                    }

                    //}
                }
            }
            return dte;
        }
        private DateTime DIS_GetStartDate(DataSet dsMemo)
        {
            DateTime dte = DateTime.Now;

            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("MEMO"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString().ToUpper() == "TỪ NGÀY")
                            {
                                return DateTime.ParseExact(dtStructure.Rows[i][j + 1].ToString(), AppConfig.FORMATDATE_IN, null);
                            }
                        }
                    }

                }
            }
            return dte;
        }
        private DataTable DIS_CreatePromCode(DataSet dsMemo)
        {
            DataTable dtCode = new DataTable();
            dtCode.Columns.Add("Code", typeof(string));
            dtCode.Columns.Add("Description", typeof(string));
            dtCode.Columns.Add("SKU", typeof(string));
            dtCode.Columns.Add("Discount", typeof(string));
            dtCode.Columns.Add("Ref", typeof(string));
            dtCode.Columns.Add("Ref4D", typeof(string));
            dtCode.Columns.Add("Budget", typeof(double));
            dtCode.Columns.Add("No", typeof(int));
            

            DateTime dteStardate = this.DIS_GetStartDate(dsMemo);
            string SCode = AppConfig.DISCOUNT_FORMAT_PROMOTIONCODE;
            SCode += this.DIS_GetDataFromMemoSheet(dsMemo, AppConfig.MEMO_KENHBANHANG_Value, 0, 1) + "_" + dteStardate.ToString("MMyy") + "_";



            if (this.dtBudgetMemo == null)
                foreach (DataTable dtDatainMemo in dsMemo.Tables)
                {

                    if (dtDatainMemo.TableName.Contains("Budget"))
                    {
                        this.dtBudgetMemo = dtDatainMemo;
                        this.dtBudgetMemo.Columns.Add("NSValue", typeof(double));
                        this.dtBudgetMemo.Columns.Add("PromotionCode", typeof(string));

                    }
                    if (dtDatainMemo.TableName.Contains("Discount"))
                    {
                        this.dtDiscountMemo = dtDatainMemo;
                        this.dtDiscountMemo.Columns.Add("PromotionCode", typeof(string));
                    }
                }

            for (int i = 0; i < this.dtBudgetMemo.Columns.Count; i++)
            {
                string Name = this.dtBudgetMemo.Columns[i].ColumnName.ToUpper().Replace(" ", "");

                if (Name.Contains("SKU"))
                    this.B_iSKU = i;

                if (Name.Contains("MÃNPP"))
                    this.B_iDistributorCode = i;

                if (Name.Contains("BUDGET"))
                    this.B_iBudgetColumn = i;

                if (Name.Contains("DISCOUNT"))
                    this.B_iDiscountCode = i;

            }


            for (int i = 0; i < this.dtDiscountMemo.Columns.Count; i++)
            {
                string Name = this.dtDiscountMemo.Columns[i].ColumnName.ToUpper().Replace(" ", "");

                if (Name.Contains("SKU"))
                    this.DIS_iSKU = i;

                if (Name.Contains("MÃNPP"))
                    this.DIS_iDistributorCode = i;

                if (Name.Contains("BUDGET"))
                    this.DIS_iBudget = i;

                if (Name.Contains("DISCOUNT"))
                    this.DIS_iDiscountCode = i;

            }

            foreach (DataRow dr in this.dtBudgetMemo.Rows)
            {
                dr["NSValue"] = Convert.ToDouble(dr[this.B_iBudgetColumn]);
            }


            var distinctRows = (from row in this.dtBudgetMemo.AsEnumerable()
                                group row by new
                                {
                                    SKU = row.Field<string>(this.B_iSKU),
                                    Discount = row.Field<string>(this.B_iDiscountCode)
                                    //Distributor = row.Field<string>(4),
                                }
                   into g
                                select new
                                {
                                    g.Key.SKU,
                                    g.Key.Discount,
                                    Budget = g.Sum(x => x.Field<double>("NSValue"))
                                }).ToArray();

        

            int iNo = 1;
            foreach (var row in distinctRows)
            {
                DataRow dr = dtCode.NewRow();
                dr["Code"] = SCode + iNo.ToString();
                dr["Description"] = dteStardate.ToString("MM/yy") + " Mua " + row.SKU.ToString() + " + CK " + row.Discount.ToString();
                dr["SKU"] = row.SKU.ToString();
                dr["Discount"] = row.Discount.ToString();
                dr["Ref"] = row.SKU.ToString() + row.Discount.ToString();
                dr["Ref4D"] = row.SKU.ToString() + row.Discount.ToString();
                dr["Budget"] = row.Budget;
                dr["No"] = iNo;
                dtCode.Rows.Add(dr);
                iNo++;

            }


            // Add promotionCode to Table dtBudgetMemo

            foreach (DataRow drBudgetMemo in this.dtBudgetMemo.Rows)
            {
                string sRef = drBudgetMemo["SKU"].ToString() + drBudgetMemo["Discount"].ToString();
                drBudgetMemo["PromotionCode"] = this.DIS_GetPromotionCodeForBudget(dtCode, sRef);
                drBudgetMemo.AcceptChanges();
            }

            // Add promotionCode to Table dtDiscoutMemo

            foreach (DataRow drDiscountMemo in this.dtDiscountMemo.Rows)
            {             
                string DistributorCode = drDiscountMemo[this.DIS_iDistributorCode].ToString();
                string DiscountCode = drDiscountMemo[this.DIS_iDiscountCode].ToString();
                drDiscountMemo["PromotionCode"] = this.DIS_GetPromotionCodeForDistributor(this.dtBudgetMemo, DistributorCode, DiscountCode);
                drDiscountMemo.AcceptChanges();
            }

            if(dtNullPromotionCode.Rows.Count >0)
            {
                frmShowError frm = new frmShowError();
                frm.Load(dtNullPromotionCode,"Không gán được mã CTKM vào sheet Discount");
                frm.ShowDialog();
            }

            return dtCode;
        }
        #endregion

        #region B2B
        
        private string B2B_GetPromotionInfo(DataSet dsMemo,string LookupText)
        {
            string sRef = string.Empty;

            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("RawData".ToUpper()))
                {
                    for (int i = 0; i < 20; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < 2; j++)
                        {
                            string ss = dtStructure.Rows[i][j].ToString().ToUpper();
                            if (dtStructure.Rows[i][j].ToString().ToUpper().Contains(LookupText.ToUpper()))
                            {
                                return dtStructure.Rows[i][j+1].ToString();
                            }
                        }
                    }

                }
            }
            return sRef;

        }
        private string B2B_GetUOMCode(DataSet dsMemo, string Code)
        { 
            DataTable dtData = null;  
            string sUOMCode = string.Empty;
            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("SKU"))
                { dtData = dtStructure;
                    break;
                }
            }
                 
            if( dtData == null)
                 return sUOMCode;

            var rows = dtData.AsEnumerable().Where
             (row => row.Field<string>(B2BConfig.B2B_UOMName_Index).Trim().ToUpper() == Code.Trim().ToUpper()).ToArray();


            if (rows.Length > 0)
            {
                sUOMCode = rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex).Trim();
                sUOMCode += (rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex + 1) != null && rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex + 1).Trim() != "" ? ";" + rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex + 1).Trim() : "");
                sUOMCode += (rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex + 2) != null && rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex + 2).ToString().Trim() != "" ? ";" + rows[0].Field<string>(AppConfig.B2B_UOMCodeIndex + 2).Trim() : "");
            }
          
           
            return sUOMCode;

        }
        private string B2B_GetPromotionCodeForDistributor(DataTable dtData, string PromotionCodeRef)
        {
            string sProCode = string.Empty;

            var rows = dtData.AsEnumerable().Where
             (row => row.Field<string>("PromotionCodeRef") == PromotionCodeRef).ToArray();


            if (rows.Length > 0)
            {
                sProCode = rows[0].Field<string>("PromotionCode");
            }

            if (sProCode == string.Empty)
            {
                dtNullPromotionCode.Rows.Add(PromotionCodeRef, "","");
            }

            return sProCode;

        }
        private double B2B_GetBudgetByPromotionCode(DataTable dtDataBudget, string PromotionCode)
        {
            string sProCode = string.Empty;

            double sum = dtDataBudget.AsEnumerable()
                   .Where(r => r.Field<string>("PromotionCode") == PromotionCode)
                   .Sum(x => x.Field<double>("Value"));
            return sum;
          
        }
        private string B2B_PromotionCodeRef(DataRow row,string ListCode)
        {
            string PromotionCodeRef = string.Empty;

            string[] sArrayCode = ListCode.Split(';');
            foreach (string itemCode in sArrayCode)
            {
                int iColumnIndex = -1;
                int.TryParse(Common.ReadConfigXML(Common.STR_FILECONF, itemCode), out iColumnIndex);
                if(iColumnIndex >-1)
                {
                    PromotionCodeRef += PromotionCodeRef == string.Empty ? row[iColumnIndex].ToString().ToUpper().Trim() : "-" + row[iColumnIndex].ToString().ToUpper().Trim();
                }    

            }

                return PromotionCodeRef;

        }
        private string B2B_GetPromotionCodeForBudget(DataTable dtData, string Code)
        {
            string sProCode = string.Empty;

            DataRow[] rows = dtData.Select("PromotionCodeRef = '" + Code + "'");
            if (rows.Length > 0)
                return rows[0]["PromotionCode"].ToString();
            return sProCode;

        }
        private string B2B_GetDataByRefCode(DataTable dtData, int CodeIndex,string ValueCode)
        {
            string sProCode = string.Empty;

            DataRow[] rows = dtData.Select("PromotionCodeRef = '" + ValueCode + "'");
            if (rows.Length > 0)
                return rows[0][CodeIndex].ToString();
            return sProCode;

        }
        private double B2B_GetDiscountValueByRefCode(DataTable dtData, string ValueCode)
        {
            string sProCode = string.Empty;
            double dbDiscount = 0;
            DataRow[] rows = dtData.Select("PromotionCodeRef = '" + ValueCode + "'");
            if (rows.Length > 0)
            {
                double.TryParse(rows[0][B2BConfig.B2B_DiscountValue_Index].ToString(), out dbDiscount);
            }
            return dbDiscount * 100;

        }
        private DateTime B2B_GetEndDate(DataSet dsMemo)
        {
            DateTime dte = DateTime.Now;
            //DateTime date = DateTime.ParseExact(strDate, "dd/MM/YYYY", null)
            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("PIVOTDATA"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString().ToUpper().Contains("KẾT THÚC"))
                            {
                                return DateTime.ParseExact(dtStructure.Rows[i][j + 1].ToString(), B2BConfig.FORMATDATE_IN, null);
                            }
                        }
                    }

                    //}
                }
            }
            return dte;
        }
        private DateTime B2B_GetStartDate(DataSet dsMemo)
        {
            DateTime dte = DateTime.Now;

            foreach (DataTable dtStructure in dsMemo.Tables)
            {
                if (dtStructure.TableName.ToUpper().Contains("PIVOTDATA"))
                {
                    for (int i = 0; i < dtStructure.Rows.Count; i++)
                    {                        //Duyet Cot
                        for (int j = 0; j < dtStructure.Columns.Count; j++)
                        {
                            if (dtStructure.Rows[i][j].ToString().ToUpper().Contains("BẮT ĐẦU"))
                            {
                                return DateTime.ParseExact(dtStructure.Rows[i][j + 1].ToString(), B2BConfig.FORMATDATE_IN, null);
                            }
                        }
                    }

                }
            }
            return dte;
        }
        private DataTable B2B_CreatePromCode(DataSet dsMemo)
        {
            DataTable dtCode = new DataTable();
            dtCode.Columns.Add("PromotionCode", typeof(string));
            dtCode.Columns.Add("Description", typeof(string));
            dtCode.Columns.Add("StartDate", typeof(string));
            dtCode.Columns.Add("EndDate", typeof(string)); 
            dtCode.Columns.Add("ClaimDate", typeof(string));
            dtCode.Columns.Add("ClaimDate0", typeof(string));
            dtCode.Columns.Add("SKU", typeof(string));
            dtCode.Columns.Add("DiscountValue", typeof(string));
            dtCode.Columns.Add("Ref", typeof(string));
            dtCode.Columns.Add("PromotionCodeRef", typeof(string));
            dtCode.Columns.Add("GL", typeof(string));
            dtCode.Columns.Add("PromotionCategory", typeof(string));
            dtCode.Columns.Add("DetailType", typeof(string));
            dtCode.Columns.Add("UOMCode", typeof(string));
            dtCode.Columns.Add("ClaimType", typeof(string));
            dtCode.Columns.Add("Ref4D", typeof(string));
            dtCode.Columns.Add("BudgetValue", typeof(double));
            dtCode.Columns.Add("No", typeof(int));


            

            DateTime sStartDate = this.B2B_GetStartDate(dsMemo);
            DateTime sEndDate = this.B2B_GetEndDate(dsMemo);
            string sRef = this.B2B_GetPromotionInfo(dsMemo,B2BConfig.B2B_SCHEME_ID_Value);
            string SNotes = this.B2B_GetPromotionInfo(dsMemo,"Notes");
            string strPromotionCategory = this.B2B_GetPromotionInfo(dsMemo, "Promotion");
            string strDetailType = this.B2B_GetPromotionInfo(dsMemo, "Detail");
            string strUOMCode = this.B2B_GetPromotionInfo(dsMemo, "UOM");
            string strClaimType = this.B2B_GetPromotionInfo(dsMemo, "Claim");
            string SCode = B2BConfig.B2B_FORMAT_PROMOTIONCODE + sStartDate.ToString("MMyy") + "_";
            DateTime sClaimDate = DateTime.ParseExact("17/" + sEndDate.AddMonths(4).Month.ToString("00") + "/" + sEndDate.AddMonths(4).Year.ToString(), AppConfig.FORMATDATE_IN, null);
            DateTime sClaimDate0 = DateTime.ParseExact("16/" + sEndDate.AddMonths(4).Month.ToString("00") + "/" + sEndDate.AddMonths(4).Year.ToString(), AppConfig.FORMATDATE_IN, null);

            if (this.dtBudgetMemo == null)
                foreach (DataTable dtDataInMemo in dsMemo.Tables)
                {

                    if (dtDataInMemo.TableName.Contains("RawData"))
                    {
                        this.dtB2RawData = dtDataInMemo;
                        this.dtB2RawData.Columns.Add("PromotionCode", typeof(string));
                        this.dtB2RawData.Columns.Add("PromotionCodeRef", typeof(string));
                        this.dtB2RawData.Columns.Add("CheckDuplicateRawData", typeof(string));
                        this.dtB2RawData.Columns.Add("BudgetValue", typeof(double));
                        this.dtB2RawData.Columns.Add("DiscountValue", typeof(double));
                        break;
                    }                    
                }

            foreach (DataRow drRaw in dtB2RawData.Rows)
            {
               
                double Budget = 0;
                double.TryParse(drRaw[B2BConfig.B2B_BudgetValue_Index].ToString(), out Budget);
                drRaw["BudgetValue"] = Budget;
                double.TryParse(drRaw[B2BConfig.B2B_DiscountValue_Index].ToString(), out Budget);
                drRaw["DiscountValue"] = Budget*100;
                //drRaw["PromotionCodeRef"] = drRaw[B2BConfig.B2B_SKUCode_Index].ToString().ToUpper() + "-" + drRaw[B2BConfig.B2B_DiscountValue_Index].ToString().ToUpper();
                drRaw["PromotionCodeRef"] = this.B2B_PromotionCodeRef(drRaw, B2BConfig.B2B_ColumnListCheck_Value);
                drRaw["CheckDuplicateRawData"] = this.B2B_PromotionCodeRef(drRaw, B2BConfig.B2B_ColumnListCheckDuplicate_Value);
            }

            var distinctRows = (from row in this.dtB2RawData.AsEnumerable()
                                group row by new
                                {
                                    CodeRef = row.Field<string>("PromotionCodeRef"),
                                    //SKU = row.Field<string>(B2BConfig.B2B_SKUCode_Index),
                                    //Discount = row.Field<string>(B2BConfig.B2B_DiscountValue_Index)

                                }
                                
                  into g
                                select new
                                {
                                    g.Key.CodeRef,
                                    //g.Key.SKU,
                                    //g.Key.Discount,
                                    Budget = g.Sum(x => x.Field<double>("BudgetValue"))
                                })
                                .OrderBy(s=> s.CodeRef)
                                .ToArray();


            int iNo = 1;
            foreach (var row in distinctRows)
            {                
                DataRow dr = dtCode.NewRow();
                dr["PromotionCode"] = SCode + iNo.ToString();
               
                dr["SKU"] = B2B_GetDataByRefCode(dtB2RawData, B2BConfig.B2B_SKUCode_Index, row.CodeRef);
                dr["DiscountValue"] = B2B_GetDiscountValueByRefCode(dtB2RawData, row.CodeRef);
                dr["Description"] = sStartDate.ToString("MM/yy") + " Mua " + dr["SKU"] + " +CK " + dr["DiscountValue"] + "%";
                dr["PromotionCodeRef"] = row.CodeRef;
                dr["Ref"] = sRef;
                dr["PromotionCategory"] = strPromotionCategory; 
                dr["GL"] = SNotes;
                dr["DetailType"] = strDetailType; 
                dr["UOMCode"] = strUOMCode;   
                dr["ClaimType"] = strClaimType;
                dr["Ref4D"] = "";
                //double Budget = 0;
                //double.TryParse(row.Budget, out Budget);
                dr["BudgetValue"] = row.Budget;
                dr["No"] = iNo; 
                dr["StartDate"] = sStartDate.ToString(AppConfig.FORMATDATE_OUT);
                dr["EndDate"] = sEndDate.ToString(AppConfig.FORMATDATE_OUT);
                dr["ClaimDate"] = sClaimDate.ToString(AppConfig.FORMATDATE_OUT);
                dr["ClaimDate0"] = sClaimDate0.ToString(AppConfig.FORMATDATE_OUT);
                dtCode.Rows.Add(dr);
                iNo++;

            }


            // Add promotionCode to Table dtBudgetMemo

            foreach (DataRow drRaw in this.dtB2RawData.Rows)
            {
                string sB2bRef = drRaw["PromotionCodeRef"].ToString();
                drRaw["PromotionCode"] = this.B2B_GetPromotionCodeForBudget(dtCode, sB2bRef);               
                drRaw.AcceptChanges();
            }


            return dtCode;
        }
        private void B2B_CreatDataForExport(DataSet dsB2BMemo)
        {
            //
            dtNullPromotionCode = new DataTable();
            dtNullPromotionCode.Columns.Add("PromotionCode", typeof(string));
            dtNullPromotionCode.Columns.Add("SKUCode", typeof(string));
            dtNullPromotionCode.Columns.Add("ErrorMessage", typeof(string));


            this.dsB2BExport = new DataSet();
            string strFileStructure = Application.StartupPath + @"\" + STR_CONF;
            DataSet dsStruct = clsExcel.ReadExcelToDataSet(strFileStructure);
            //this.dtSKUCODE = clsExcel.ReadExcel(Application.StartupPath + @"\" + STR_SKU_CONF, true);
            DataTable dtB2BMemo = B2B_CreatePromCode(dsB2BMemo); //dsMemo.Tables["Data"];

            // Check Duplicate
            var duplicates = this.dtB2RawData.AsEnumerable().GroupBy(r => r["CheckDuplicateRawData"]).Where(gr => gr.Count() > 1).ToArray();
            if(duplicates.Length > 0)
            {
                foreach (var item in duplicates)
                {
                    dtNullPromotionCode.Rows.Add(item.Key, "", "Duplicate Data"); 
                }    
            }    




            foreach (DataTable dtStructure in dsStruct.Tables)
            {
                dtStructure.Rows.Clear();
                if (dtStructure.TableName.ToUpper().Contains("HEADER"))
                {
                    // Getdata from MemoSheet                   
                    //string Promotion_Category = this.DIS_GetDataFromMemoSheet(dsMemo, AppConfig.MEMO_NGHANHHANG_Value, 0, 1);                    
                    foreach (DataRow drDataMemo in dtB2BMemo.Rows)
                    {
                        DataRow drHeader = dtStructure.NewRow();
                        //double dbSumBudget = B2B_GetBudgetByPromotionCode(dtB2RawData, drDataMemo["PromotionCode"].ToString());
                        string code = drDataMemo["PromotionCode"].ToString();
                        drHeader[0] = "HQ"; // Distributor Code
                        drHeader[1] = code; // Promotion Code
                        drHeader[2] = drDataMemo["Description"]; // Promotion Description
                        drHeader[3] = "A"; // Promotion Status
                        drHeader[4] = drDataMemo["StartDate"];// Start Date
                        drHeader[5] = drDataMemo["EndDate"]; // End Date
                        drHeader[6] = "1"; // Claimable Ind
                        drHeader[7] = drDataMemo["ClaimDate"]; // Claim End Day
                        drHeader[8] = ""; // Tplan Number
                        drHeader[9] = "D"; // Type
                        drHeader[10] = drDataMemo["PromotionCategory"]; ; // Promotion Category
                        drHeader[11] = ""; // SpaceBuy Type
                        drHeader[12] = drDataMemo["BudgetValue"]; ;   // Budget
                        drHeader[13] = drDataMemo["Ref"]; // Reference Number oR Scheme ID
                        drHeader[14] = drDataMemo["DetailType"]; ; // Detail Type 
                        drHeader[15] = drDataMemo["UOMCode"]; ; // Total Buy UOM Code 
                        drHeader[16] = drDataMemo["ClaimType"]; // Claim Type
                        drHeader[17] = "Y"; // Taxable Ind
                        drHeader[18] = "1"; // Auto Checked
                        drHeader[19] = drDataMemo["ClaimDate0"]; ; // Spacebuy End Date
                        drHeader[20] = drDataMemo["GL"];  // Notes
                        drHeader[21] = "10"; // Tax
                        dtStructure.Rows.Add(drHeader);
                    }

                }
                if (dtStructure.TableName.ToUpper().Contains("DETAIL"))
                {
                    foreach (DataRow drRaw in dtB2BMemo.Rows)
                    {

                        DataRow drdetail = dtStructure.NewRow();
                       
                        drdetail[0] = "HQ"; // Distributor Code
                        drdetail[1] = drRaw["PromotionCode"].ToString(); // Promotion Code
                        drdetail[2] = "1"; // Promotion Description
                        drdetail[3] = Convert.ToDouble(drRaw["DiscountValue"]) < 100? "3": "2"; // Promotion Status
                        drdetail[4] = "1";
                        drdetail[5] = drRaw["DiscountValue"];
                        drdetail[6] = drdetail[3].ToString() == "3"?"2":"1"; // Claimable Ind                       
                        dtStructure.Rows.Add(drdetail);
                    }
                }

                if (dtStructure.TableName.ToUpper().Contains("BUDGET"))
                {

                    var budget = (from row in this.dtB2RawData.AsEnumerable()
                                        group row by new
                                        {
                                            PromotionCode = row.Field<string>("PromotionCode"),
                                            DistributorCode = row.Field<string>(B2BConfig.B2B_DistributorCode_Index),
                                            //Discount = row.Field<string>(B2BConfig.B2B_DiscountValue_Index)

                                        }

                  into g
                                        select new
                                        {
                                            g.Key.PromotionCode,
                                            g.Key.DistributorCode,
                                            //g.Key.Discount,
                                            BudgetValue = g.Sum(x => x.Field<double>("BudgetValue"))
                                        })
                                .OrderBy(s => s.PromotionCode)
                                .ToArray();


                    foreach (var drRaw in budget)
                    {
                       
                        DataRow drBudget = dtStructure.NewRow();
                        drBudget[0] = "HQ"; // Distributor Code
                        drBudget[1] = drRaw.PromotionCode; // Promotion Cod
                        drBudget[2] = "3"; // Assignment Level
                        drBudget[3] = drRaw.DistributorCode; // Distributor Code
                        drBudget[4] = ""; //Parent Code (v20)
                        drBudget[5] = drRaw.BudgetValue;       //Budget (n25,4)
                        dtStructure.Rows.Add(drBudget);
                    }
                }
                if (dtStructure.TableName.ToUpper().Contains("PRODUCT"))
                {

                    var PRODUCT = this.dtB2RawData.AsEnumerable()
                       .Select(row => new {
                           PromotionCode = row.Field<string>("PromotionCode"),
                           PromotionCodeRef = row.Field<string>("PromotionCodeRef"),
                           SKUCode = row.Field<string>(B2BConfig.B2B_SKUCode_Index)
                       })
                       .Distinct();

                    foreach (var draw in PRODUCT)
                    {

                        string UOMcode = this.B2B_GetUOMCode(dsB2BMemo, draw.SKUCode);
                        if (UOMcode == string.Empty)
                        {
                            dtNullPromotionCode.Rows.Add(draw.PromotionCode, draw.PromotionCodeRef, "Không tìm thấy SKU Code");
                        }
                        string[] sArrayCode = UOMcode.Split(';');
                        foreach (string itemCode in sArrayCode)
                        {
                            DataRow drPRODUCT = dtStructure.NewRow();
                            drPRODUCT[0] = "HQ"; // Distributor Code
                            drPRODUCT[1] = draw.PromotionCode; // Promotion Cod
                            drPRODUCT[2] = "1"; // Promotion Index(int)
                            drPRODUCT[3] = "3"; // Product Category Level 
                            drPRODUCT[4] = itemCode; // Product Category
                            drPRODUCT[5] = "CU"; //UOM Code
                            drPRODUCT[6] = "1";       //Parent Code 
                            drPRODUCT[7] = "0";       //Must Ind                     0 = No1 = Yes(c1)
                            dtStructure.Rows.Add(drPRODUCT);
                        }
                    }
                }

                if (dtStructure.TableName.ToUpper().Contains("ASSIGNC"))
                {
                    foreach (DataRow drRaw in this.dtB2RawData.Rows)
                    {
                        
                        DataRow drASSIGNC = dtStructure.NewRow();
                        drASSIGNC[0] = "HQ"; // Distributor Code
                        drASSIGNC[1] = drRaw["PromotionCode"]; // Promotion Cod
                        drASSIGNC[2] = "C"; // Assignment type
                        drASSIGNC[3] = "6"; // Promotion Status
                        drASSIGNC[5] = drRaw[B2BConfig.B2B_CustomerCode_Index].ToString().Trim(); //Assignment Code (Customer Code)
                        drASSIGNC[4] = drRaw[B2BConfig.B2B_DistributorCode_Index].ToString().Trim();       //Parent Code  (Distributor Code)
                        dtStructure.Rows.Add(drASSIGNC);
                    }
                }

                if (dtStructure.TableName.ToUpper().Contains("ASSIGND"))
                {
                    var ASSIGND = this.dtB2RawData.AsEnumerable()
                        .Select(row => new {
                            PromotionCode = row.Field<string>("PromotionCode"),
                            AssignmentCode = row.Field<string>(B2BConfig.B2B_DistributorCode_Index)
                        })
                        .Distinct();

                    foreach (var draw in ASSIGND)
                    {
                      
                        DataRow drASSIGND = dtStructure.NewRow();
                        drASSIGND[0] = "HQ"; // Distributor Code
                        drASSIGND[1] = draw.PromotionCode; // Promotion Cod
                        drASSIGND[2] = "D"; // Assignment type
                        drASSIGND[3] = ""; // Promotion Status
                        drASSIGND[4] = draw.AssignmentCode; //Assignment Code (Customer Code)
                        drASSIGND[5] = "";       //Parent Code  (Distributor Code)
                        dtStructure.Rows.Add(drASSIGND);
                    }
                   
                }


            }

            this.dsB2BExport = dsStruct;
            //this.dsB2BExport.Tables.Remove("ASSIGNC");

            //if (dtNullPromotionCode.Rows.Count > 0)
            //{
            //    frmShowError frm = new frmShowError();
            //    frm.Load(dtNullPromotionCode, "B2B: Lỗi khi tính dữ liệu");
            //    frm.ShowDialog();
            //    return;
            //}

        }

        #endregion
        #region Export
        private void ExportCsv(DataSet dsExport)
        {
            string strFileOutPut = string.Empty;
            try
            {
                DataTable dtInput = clsExcel.ReadExcel(txtFileName1.Text);
                FolderBrowserDialog saveFolderDialog = new FolderBrowserDialog();
                if (!chkAutosave.Checked)
                {
                    saveFolderDialog.ShowDialog();
                    strFileOutPut = saveFolderDialog.SelectedPath;
                }
                else
                {
                    strFileOutPut = Application.StartupPath + @"\Export\CSV\";
                }


                if (strFileOutPut != string.Empty)
                {
                    //clsExcel.ExportExcel(dtInput, saveFileDialog.FileName);                                
                    // Calculate Data to DS Struct
                    foreach (DataTable data in dsExport.Tables)
                    {
                        string tbName = data.TableName;
                        clsExcel.ExportToCsvFile(data, strFileOutPut + tbName + ".csv");
                    }

                }
            }
            catch (Exception ex)
            {
                //myWait.Close();
                MessageBox.Show(ex.Message);
            }
        }

        private void ExportExcelMutilFile(DataSet dsExport,string strPathOutPut)
        {
            string strFileOutPut = string.Empty;
            try
            {
                DataTable dtInput = clsExcel.ReadExcel(txtFileName1.Text);
                FolderBrowserDialog saveFolderDialog = new FolderBrowserDialog();
                if (!chkAutosave.Checked)
                {
                    saveFolderDialog.ShowDialog();
                    strFileOutPut = saveFolderDialog.SelectedPath;
                }
                else
                {
                    strFileOutPut = strPathOutPut;
                }


                if (strFileOutPut != string.Empty)
                {
                    
                    foreach (DataTable data in dsExport.Tables)
                    {
                        string tbName = data.TableName;
                        clsExcel.ExportExcel(data, strFileOutPut + tbName + ".xlsx");
                    }
                    

                }
            }
            catch (Exception ex)
            {
                //myWait.Close();
                MessageBox.Show(ex.Message);
            }
        }
        private void ExportExcel(DataSet dsExport,string strPath)
        {
            string strFileOutPut = string.Empty;
            try
            {

                //string strFileOutPut = @"C:\Hung\Personal\Ouput.xlsx";
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                if (!chkAutosave.Checked)
                {
                    saveFileDialog.Filter = "Excel files |*.xlsx;*.xls";
                    saveFileDialog.FilterIndex = 0;
                    saveFileDialog.RestoreDirectory = true;
                    saveFileDialog.CreatePrompt = false;
                    saveFileDialog.Title = "Export Excel File To";
                    saveFileDialog.ShowDialog();
                    strFileOutPut = saveFileDialog.FileName;
                }
                else
                {
                    strFileOutPut = strPath + "Promotion" + DateTime.Now.ToString("_yyyyMMdd_HHmmss") + ".xlsx";
                }
                if (strFileOutPut != string.Empty)
                {
                    //clsExcel.ExportExcel(dtInput, saveFileDialog.FileName);                    
                    // Calculate Data to DS Struct
                    clsExcel.ExportExcel(dsExport, strFileOutPut);
                    MessageBox.Show("Done!");
                    if (chkOpen.Checked)
                    {
                        Process.Start(new ProcessStartInfo("excel.exe", " /select, " + strFileOutPut.Replace("\\\\", "\\")));
                    }
                }
                //if (myWait.InvokeRequired)
                //{
                //    myWait.BeginInvoke((MethodInvoker)delegate () { closeWaitForm(); });
                //}
                //else
                //{
                //    myWait.Close();//Fault tolerance this code should never be executed
                //}

            }
            catch (Exception ex)
            {
                //myWait.Close();
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        #region Event
        private void btnFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel Files(.xlsx)|*.xlsx;*.xls;*.xlsm";
            of.ShowDialog();
            txtFileName1.Text = of.FileName;
        }

        private void chkAutosave_CheckedChanged(object sender, EventArgs e)
        {
            Common.WtiteConfigXML(Common.STR_FILECONF, "IsAutoSave", chkAutosave.Checked ? "Yes" : "No");
        }

        private void chkOpen_CheckedChanged(object sender, EventArgs e)
        {
            Common.WtiteConfigXML(Common.STR_FILECONF, "IsOpen", chkOpen.Checked ? "Yes" : "No");
        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {



            this.dtSKUCODE = clsExcel.ReadExcel(Application.StartupPath + @"\" + STR_SKU_CONF, true);


            FRMCheckData fCheck = new FRMCheckData();
            fCheck.LoadForm();
            fCheck.ShowDialog();

        }

        private void btnConfig_Click(object sender, EventArgs e)
        {
            FormConfig frm = new FormConfig();
            frm.ShowDialog();
        }

        private void btHung_Click(object sender, EventArgs e)
        {

        }

        private void radioExcel_CheckedChanged(object sender, EventArgs e)
        {
            if (radioExcel.Checked)
                Common.WtiteConfigXML(Common.STR_FILECONF, "SaveType", "E");
        }

        private void radioCsv_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMulti.Checked)
                Common.WtiteConfigXML(Common.STR_FILECONF, "SaveType", "C");
        }
        private void radioAll_CheckedChanged(object sender, EventArgs e)
        {
            if (radioAll.Checked)
                Common.WtiteConfigXML(Common.STR_FILECONF, "SaveType", "A");
        }

        private void closeWaitForm()
        {
            //myWait.Close();
        }
        #endregion
    }
}
