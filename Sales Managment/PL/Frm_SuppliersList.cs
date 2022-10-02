using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sales_Managment.PL
{
    public partial class Frm_SuppliersList : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Suppliers suppliers = new BL.Cls_Suppliers();
        public Frm_SuppliersList()
        {
            InitializeComponent();
        }

        private void Frm_SuppliersList_Load(object sender, EventArgs e)
        {
            dgvSuppliers.DataSource = suppliers.Get_AllSup_info();
            dgvSuppliers.Columns[6].Visible = false;
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            dgvSuppliers.DataSource = suppliers.Search_suppliers(textSearch.Text);
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}