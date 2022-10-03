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
    public partial class FRM_ProductList : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Products product = new BL.Cls_Products();
        public FRM_ProductList()
        {
            InitializeComponent();
        }

        private void FRM_ProductList_Load(object sender, EventArgs e)
        {
            dgvProdList.DataSource = product.get_all_Products();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            dgvProdList.DataSource = product.Search_product(textSearch.Text);
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void dgvProdList_DoubleClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}