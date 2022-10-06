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
    public partial class Frm_SupplierReport : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Suppliers suppliers = new BL.Cls_Suppliers();

        void invoice_Sum()
        {
          txtTotal.Text =
                (from DataGridViewRow row in DgvSearch.Rows
                 where row.Cells[2].FormattedValue.ToString() != String.Empty
                 select Convert.ToDouble(row.Cells[2].FormattedValue)).Sum().ToString();
        }
        public Frm_SupplierReport()
        {
            InitializeComponent();
        }
     
        DataTable tbl = new DataTable();



        private void FillSupplier()
        {

            cbxSupplier.DataSource = suppliers.Get_AllSup_info();
            cbxSupplier.DisplayMember = "اسم المورد";
            cbxSupplier.ValueMember = "Sup_ID";
        }
        private void Frm_SupplierReport_Load(object sender, EventArgs e)
        {
            FillSupplier();
            DtpDate.Text = DateTime.Now.ToShortDateString();


            tbl.Clear();
            tbl = suppliers.get_suppPayHistory();

            DgvSearch.DataSource = tbl;
            invoice_Sum();
            //txtTotal.Text = Math.Round(invoice_Sum(), 2).ToString();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            if (rbtnAllSup.Checked == true)
            {
                tbl = suppliers.get_suppPayHistory();
            }
            else if (rbtnOneSupplier.Checked == true)
            {
                tbl = suppliers.get_ONEsuppPayHistory(Convert.ToInt32(cbxSupplier.SelectedValue));
            }
            DgvSearch.DataSource = tbl;

            invoice_Sum();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DgvSearch.Rows.Count >= 1)
            {
                if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (rbtnOneSupplier.Checked == true)
                    {

                        suppliers.delete_supPayRecoed(Convert.ToInt32(DgvSearch.CurrentRow.Cells[0].Value.ToString()));
                        MessageBox.Show("تمت عملية المسح بنجاح", "عملية المسح ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                       

                    }
                    
                }
            }
            else { MessageBox.Show("لايوجد سجل لمسحه", "تنبية"); return; }
        }

        private void DgvSearch_SelectionChanged(object sender, EventArgs e)
        {
            //cbxSupplier.Text = DgvSearch.CurrentRow.Cells[1].Value.ToString();
        }
    }
}