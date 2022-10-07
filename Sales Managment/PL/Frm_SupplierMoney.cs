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
    public partial class Frm_SupplierMoney : DevExpress.XtraEditors.XtraForm
    {
        BL.Cls_Suppliers suppliers = new BL.Cls_Suppliers();
        BL.Class_ORDERS orders = new BL.Class_ORDERS();
        void invoice_Sum()
        {
            txtTotal.Text =
                (from DataGridViewRow row in DgvSearch.Rows
                 where row.Cells[1].FormattedValue.ToString() != String.Empty
                 select Convert.ToDouble(row.Cells[1].FormattedValue)).Sum().ToString();
        }
        public Frm_SupplierMoney()
        {
            InitializeComponent();
        }

        
        DataTable tbl = new DataTable();
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }
      private void FillSupplier()
        {

            cbxSupplier.DataSource = suppliers.Get_AllSup_info();
            cbxSupplier.DisplayMember = "اسم المورد";
            cbxSupplier.ValueMember = "Sup_ID" ;
        }
        private void Frm_SupplierMoney_Load(object sender, EventArgs e)
        {
            try
            {
            FillSupplier();
            }catch(Exception) { }

            DtpDate.Text = DateTime.Now.ToShortDateString();
            DgvSearch.DataSource = suppliers.getSup_Deservied_money();
            invoice_Sum();
           // txtTotal.Text =Math.Round( txtTotal  , 2).ToString();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tbl.Clear();

            if (rbtnAllSup.Checked == true)
            {
                tbl = suppliers.getSup_Deservied_money();
            }
            else if (rbtnOneSupplier.Checked == true)
            {
                tbl = suppliers.getONESup_Deservied_money(Convert.ToInt32( cbxSupplier.SelectedValue));


            }
            DgvSearch.DataSource = tbl;

            invoice_Sum();
            //txtTotal.Text = Math.Round(totalPrice, 2).ToString();
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            if(DgvSearch.Rows.Count >= 1)
            {
              

                string d = DtpDate.Value.ToString("dd/MM/yyyy");
                string dateNext=dtIMENextPayment.Value.ToString("dd/MM/yyyy");

                if (rbtnPayAll.Checked == true)
                {
                    if (NudPrice.Value != Convert.ToDecimal(DgvSearch.CurrentRow.Cells[1].Value.ToString()))
                    {
                        MessageBox.Show("يجب تسديد كامل المبلغ لإنك اخترت تسديد المبلغ بالكامل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NudPrice.Focus();
                        return;
                    }
                   suppliers.ADD_SupPayHistory(Convert.ToInt32(DgvSearch.CurrentRow.Cells[3].Value), Convert.ToInt32(cbxSupplier.SelectedValue),
                        NudPrice.Value, d);
                    orders.Delete_DesirvedSupMoney(Convert.ToInt32(DgvSearch.CurrentRow.Cells[3].Value));
                    MessageBox.Show(" تم التسديد بنجاح", "عملية ناجحة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvSearch.DataSource = suppliers.getSup_Deservied_money();
                }
                else if (rbtnPayPart.Checked == true)
                {
                    if (NudPrice.Value == Convert.ToDecimal(DgvSearch.CurrentRow.Cells[1].Value.ToString()))
                    {
                        MessageBox.Show("لا يصح تسديد كامل المبلغ لإنك اخترت تسديد جزء من المبلغ بالكامل ", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        NudPrice.Focus();
                        return;
                    }
                    suppliers.ADD_SupPayHistory(Convert.ToInt32(DgvSearch.CurrentRow.Cells[3].Value), Convert.ToInt32(cbxSupplier.SelectedValue),
                      NudPrice.Value, d);
                   suppliers.update_SupMoney(NudPrice.Value, dateNext, Convert.ToInt32(DgvSearch.CurrentRow.Cells[3].Value));
                    MessageBox.Show(" تم التسديد بنجاح", "عملية ناجحة ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DgvSearch.DataSource = suppliers.getSup_Deservied_money();
                }
                    
            }
        }
        private void PrintOneSupplier()
        {
            int id = Convert.ToInt32(cbxSupplier.SelectedValue);
            DataTable tblRpt = new DataTable();

            tblRpt.Clear();
            //tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة',Suppliers.Sup_Name as 'اسم المورد',[Price] as 'السعر',[Order_Date] as 'تاريخ الفاتورة',[Reminder_Date] as 'تاريخ الاستحقاق' FROM [dbo].[Supplier_Money],Suppliers where Suppliers.Sup_ID =[Supplier_Money].Sup_ID and Suppliers.Sup_ID=" + id + "", "");
            try
            {
                //Frm_Print frm = new Frm_Print();

                //frm.crystalReportViewer1.RefreshReport();

                RptSupplierMonry rpt = new RptSupplierMonry();


                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");
                rpt.SetDataSource(tblRpt);
                rpt.SetParameterValue("ID", id);
                //frm.crystalReportViewer1.ReportSource = rpt;

                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                rpt.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                ////rpt.PrintToPrinter(1, true, 0, 0);
                // frm.ShowDialog();
            }
            catch (Exception) { }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (rbtnOneSupplier.Checked == true)
            {
                if(DgvSearch.Rows.Count >= 1)
                {
                    PrintOneSupplier();

                }
            }
        }

        private void DgvSearch_SelectionChanged(object sender, EventArgs e)
        {
            cbxSupplier.Text = DgvSearch.CurrentRow.Cells[0].Value.ToString();
        }

        private void rbtnPayPart_CheckedChanged(object sender, EventArgs e)
        {
            dtIMENextPayment.Enabled = true;
        }
    }
}