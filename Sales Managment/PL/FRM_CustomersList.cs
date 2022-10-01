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
    public partial class FRM_CustomersList : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Customers customers = new BL.Cls_Customers();
        public FRM_CustomersList()
        {
            InitializeComponent();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customers.Search_Customers(textSearch.Text);
        }

        private void FRM_CustomersList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = customers.Get_cust_info();
            dataGridView1.Columns[6].Visible = false;
        }
    }
}