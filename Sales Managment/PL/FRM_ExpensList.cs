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
    public partial class FRM_ExpensList : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Expenses expenses = new BL.Cls_Expenses();
        public FRM_ExpensList()
        {
            InitializeComponent();
        }

        private void FRM_ExpensList_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = expenses.get_all_expenses();
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = expenses.Search_expens(textSearch.Text);
        }
    }
}