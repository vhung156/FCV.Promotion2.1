using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;

namespace FCV.Promotion
{
    public partial class FRMCheckData : Form
    {
        DataTable dtMaster;
        DataTable dtCheck ;
        public FRMCheckData()
        {
            InitializeComponent();
        }

        public void LoadForm()
        {
            LoadConFig();

        }
        public void Load0(DataTable dataTable1,DataTable dataTable2)
        {
            LoadConFig();

            dgvData1.DataSource = dataTable1;
            for (int i = 0; i < dgvData1.Columns.Count - 1; i++)
            {
                dgvData1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvData1.Columns[dgvData1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            ////////////
            dgvData2.DataSource = dataTable2;
            for (int i = 0; i < dgvData2.Columns.Count - 1; i++)
            {
                dgvData2.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvData2.Columns[dgvData2.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;


            dtMaster = dataTable1;
            dtCheck = dataTable2;
        }
        private void LoadConFig()
        {
            string ColumnCheck0 = Common.ReadConfigXML(Common.STR_FILECONF, "ColumnSheet0");
            string ColumnCheck1 = Common.ReadConfigXML(Common.STR_FILECONF, "ColumnSheet1");


            txtColumnSheet1.Text = ColumnCheck0;
            txtColumnSheet2.Text = ColumnCheck1;
        }
        private void FRMCheckData_Load(object sender, EventArgs e)
        {

        }

        private void btnCheckData_Click(object sender, EventArgs e)
        {
            DataTable dtDuplicate = dtMaster.Clone();

            foreach (DataRow dr in dtMaster.Rows)
            {
                //string StrMaster = dr[5].ToString() + "_" + dr[7].ToString();
                string StrMaster = Common.GetDataFromColumnList(dr, txtColumnSheet1.Text);
                foreach (DataRow drC in dtCheck.Rows)
                {
                    //string StrCheck = drC[0].ToString() + "_" + drC[1].ToString();
                    string StrCheck = Common.GetDataFromColumnList(drC, this.txtColumnSheet2.Text);
                    if (StrMaster == StrCheck)
                    {
                        dtDuplicate.Rows.Add(dr.ItemArray);
                    }
                }

            }
            if(dtDuplicate != null && dtDuplicate.Rows.Count > 0)
            {
                FRMCheckDataDuplicate fCheck = new FRMCheckDataDuplicate();
                fCheck.Load(dtDuplicate);
                fCheck.ShowDialog();
            }


        }

        private void btnFile1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Excel Files(.xlsx)|*.xlsx;*.xls;*.xlsm";
            of.ShowDialog();

            txtFileName1.Text = of.FileName;

            DataTable dtMaster = clsExcel.ReadExcel(txtFileName1.Text, 0);
            DataTable dtCheck = clsExcel.ReadExcel(txtFileName1.Text, 1);

            Load0(dtMaster, dtCheck);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Common.WtiteConfigXML(Common.STR_FILECONF, "ColumnSheet0", txtColumnSheet1.Text);
            Common.WtiteConfigXML(Common.STR_FILECONF, "ColumnSheet1", txtColumnSheet2.Text);
        }
    }
}
