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
    public partial class FRMCheckDataDuplicate : Form
    {
        public FRMCheckDataDuplicate()
        {
            InitializeComponent();
        }
        public void Load(DataTable dataTable)
        {
            dgvDataDuplicate.DataSource = dataTable;
            //dgvDataDuplicate.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //dgvDataDuplicate.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            for (int i = 0; i < dgvDataDuplicate.Columns.Count - 1; i++)
            {
                dgvDataDuplicate.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
            dgvDataDuplicate.Columns[dgvDataDuplicate.Columns.Count - 1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            //for (int i = 0; i < dgvDataDuplicate.Columns.Count; i++)
            //{
            //    int colw = dgvDataDuplicate.Columns[i].Width;
            //    dgvDataDuplicate.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            //    dgvDataDuplicate.Columns[i].Width = colw;
            //}
        }
    }
}
