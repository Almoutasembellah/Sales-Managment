using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sales_Managment
{
    public partial class Frm_DeservedReport : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Expenses expenses = new BL.Cls_Expenses();
        void invoice_Sum()
        {
            txtTotal.Text =
                (from DataGridViewRow row in DgvSearch.Rows
                 where row.Cells[2].FormattedValue.ToString() != String.Empty
                 select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
        }
        public Frm_DeservedReport()
        {
            InitializeComponent();
        }



        private void Frm_DeservedReport_Load(object sender, EventArgs e)
        {
            DtpFrom.Text = DateTime.Now.ToShortDateString();
            DtpTo.Text = DateTime.Now.ToShortDateString();
            DtpFrom.CustomFormat = "dd-MM-yyyy";
            DtpTo.CustomFormat = "dd-MM-yyyy";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");
            DgvSearch.DataSource = expenses.get_all_expnsStatementsReport(date1, date2);
            invoice_Sum();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string date1;
            string date2;
            date1 = DtpFrom.Value.ToString("yyyy-MM-dd");
            date2 = DtpTo.Value.ToString("yyyy-MM-dd");
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                expenses.deleteReport_expnsStatementsReport(date1, date2);
               
            }
        }
    }
}