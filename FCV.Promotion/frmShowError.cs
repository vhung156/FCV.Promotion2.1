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
    public partial class frmShowError : Form
    {
        public frmShowError()
        {
            InitializeComponent();
        }
        public void Load(DataTable dtLoad,string labeltext)
        {

            var dtdata = dtLoad
                      .AsEnumerable()
                      .Distinct(DataRowComparer.Default)
                      .CopyToDataTable<DataRow>();
            dgvData1.DataSource = dtdata;
            lblErrorMessage.Text = labeltext;
            for (int i = 0; i < dgvData1.Columns.Count - 1; i++)
            {
                dgvData1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvData1.Columns[dgvData1.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }
    }
}
