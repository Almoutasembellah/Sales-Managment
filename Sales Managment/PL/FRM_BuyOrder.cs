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
using System.IO;
using System.Globalization;

namespace Sales_Managment.PL
{
    public partial class FRM_BuyOrder : DevExpress.XtraEditors.XtraForm
    {
       BL.Class_ORDERS orders = new BL.Class_ORDERS();
        BL.Cls_Products products = new BL.Cls_Products();
        BL.Cls_Suppliers suppliers = new BL.Cls_Suppliers();
        DataTable dt =new DataTable();
        void creatDataTable()
        {
            dt.Columns.Add("كودالمنتج");
            dt.Columns.Add("اسم المنتج");
            dt.Columns.Add("الوحدة");
            dt.Columns.Add("سعر الوحدة");
            dt.Columns.Add("الكمية");
            dt.Columns.Add("الثمن الكلي");
            dt.Columns.Add("الخصم");
            dt.Columns.Add("الإجمالي");
            dataGridView1.DataSource = dt;
            

        }
        void ResizeDGV()
        {
            this.dataGridView1.RowHeadersWidth = 160;
            this.dataGridView1.Columns[0].Width = 107;
            this.dataGridView1.Columns[1].Width = 186;
            this.dataGridView1.Columns[2].Width = 102;
            this.dataGridView1.Columns[3].Width = 96;
            this.dataGridView1.Columns[4].Width = 66;
            this.dataGridView1.Columns[5].Width = 76;
            this.dataGridView1.Columns[6].Width = 81;
            this.dataGridView1.Columns[7].Width = 185;

        }
        void calculate_amount()
        {
            if (txtPrdUnitPrice.Text != String.Empty && txtPrdQTY.Text != String.Empty)
            {
                double Amount;
                Amount = Convert.ToDouble(txtPrdUnitPrice.Text)*Convert.ToInt32(txtPrdQTY.Text);
                txtPrdAmount.Text = Amount.ToString();  
            }
        }
        void calculate_Totalamount()
        {
            if (txtPrdUnitPrice.Text != String.Empty && txtPrdQTY.Text != String.Empty&&txtPrdDixcount.Text!=String.Empty)
            {
        
                double Amount;
                double discound = Convert.ToDouble(txtPrdDixcount.Text);
                Amount = Convert.ToDouble(txtPrdUnitPrice.Text) * Convert.ToInt32(txtPrdQTY.Text);
                txtPrdTotalAmount.Text =( Amount - (Amount * (discound / 100))).ToString(); 
                
            }
        }
        void clearBOXES()
        {
           
            txtPrdID.Clear();
            txtPrdAmount.Clear();
            txtPrdName.Clear();
            txtPrdUnitPrice.Clear();
            txtPrdDixcount.Clear();
            txtPrdQTY.Clear();
            txtUNIT.Clear();
            txtPrdTotalAmount.Clear();
            btnprdSelectLIST.Focus();
        }
        void clear_frm_boxes()
        {
            textInvoice_NUM.Clear();
            textinvoice_descr.Clear();
            dateInvoice.ResetText();
            text_SUP_CODE.Clear();
            textNname.Clear();
            txtSupCmpID.Clear();
            textPhone.Clear();
            txtAdress.Clear();
            textInvoiceSum.Clear();
            Picture_customer.Image = null;
            dt.Clear();
            dataGridView1.DataSource = null;
            clearBOXES();   
        }
        void invoice_Sum()
        {
            textInvoiceSum.Text =
                (from DataGridViewRow row in dataGridView1.Rows
                 where row.Cells[7].FormattedValue.ToString() != String.Empty
                 select Convert.ToDouble(row.Cells[7].FormattedValue)).Sum().ToString();
        }
        public FRM_BuyOrder()
        {
            InitializeComponent();
            creatDataTable();
            ResizeDGV();
            btnprdSelectLIST.Enabled = false;
           // txtsallerName.Text = Program.SALLER_NAME;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void btnSelectSup_Click(object sender, EventArgs e)
        {
            Frm_SuppliersList frm = new Frm_SuppliersList();
            frm.ShowDialog();
            try
            {
                if (frm.dgvSuppliers.CurrentRow.Cells[6].Value is DBNull)
                {
                    MessageBox.Show("هذا العميل ليس له صورة");

                    text_SUP_CODE.Text = frm.dgvSuppliers.CurrentRow.Cells[0].Value.ToString();
                    textNname.Text = frm.dgvSuppliers.CurrentRow.Cells[1].Value.ToString();
                    textPhone.Text = frm.dgvSuppliers.CurrentRow.Cells[2].Value.ToString();
                    txtSupCmpID.Text = frm.dgvSuppliers.CurrentRow.Cells[3].Value.ToString();
                    txtAdress.Text = frm.dgvSuppliers.CurrentRow.Cells[4].Value.ToString();
                    Picture_customer.Image = null;
                    return;
                }
                text_SUP_CODE.Text = frm.dgvSuppliers.CurrentRow.Cells[0].Value.ToString();
                textNname.Text = frm.dgvSuppliers.CurrentRow.Cells[1].Value.ToString();
                textPhone.Text = frm.dgvSuppliers.CurrentRow.Cells[2].Value.ToString();
                txtSupCmpID.Text = frm.dgvSuppliers.CurrentRow.Cells[3].Value.ToString();
                txtAdress.Text = frm.dgvSuppliers.CurrentRow.Cells[4].Value.ToString();
                byte[] picture = (byte[])frm.dgvSuppliers.CurrentRow.Cells[6].Value;
                MemoryStream ms = new MemoryStream(picture);
                Picture_customer.Image = Image.FromStream(ms);
            }
            catch
            {

            }

        }

        private void FRM_BuyOrder_Load(object sender, EventArgs e)
        {
            lblProductCount.Text = "0";
            dateInvoice.Format = DateTimePickerFormat.Custom;
            dtPayTime.Format = DateTimePickerFormat.Custom;
            dateInvoice.CustomFormat = "dd-MM-yyyy";
            dtPayTime.CustomFormat= "dd-MM-yyyy";
        }

        private void btnNewBuy_Click(object sender, EventArgs e)
        {
  
            PL.FRM_ProductList frm = new FRM_ProductList();
            frm.ShowDialog();
            txtPrdID.Text = frm.dgvProdList.CurrentRow.Cells[0].Value.ToString();
            txtPrdName.Text = frm.dgvProdList.CurrentRow.Cells[1].Value.ToString();
            txtPrdUnitPrice.Text = frm.dgvProdList.CurrentRow.Cells[3].Value.ToString();
            txtPrdQTY.Focus();

        }

        private void btnNew_Click(object sender, EventArgs e)
        {

            clearBOXES();
            clear_frm_boxes();
            btnprdSelectLIST.Enabled = true;
            btnNew.Enabled = false;
            textInvoice_NUM.Text = orders.get_invoice_num().Rows[0][0].ToString();
        }

        private void txtPrdQTY_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPrdQTY.Text != String.Empty)

            {
                txtPrdDixcount.Focus();
            }
        }

        private void txtPrdQTY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8)// 8 is ASCII code of backspace btn
            {
                e.Handled = true;//لا تسمح بالكتابة
            }
        }

        private void txtPrdUnitPrice_TextChanged(object sender, EventArgs e)
        {
            calculate_amount();
            calculate_Totalamount();
        }

        private void txtPrdUnitPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && txtPrdUnitPrice.Text != String.Empty)

            {
                txtPrdQTY.Focus();
            }
        }

        private void txtPrdUnitPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            //اخر شرط ده لجلب الفاصلة اللي موجوده في الاعدادات بتاعت الجهاز سواء كانت نقطة او فاصلة
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != 8 && e.KeyChar != Convert.ToChar(CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator) && e.KeyChar != 37 && e.KeyChar != 39)
            {
                e.Handled = true;
            }
        }

        private void txtPrdQTY_TextChanged(object sender, EventArgs e)
        {
            calculate_amount();
            calculate_Totalamount();
        }

        private void txtPrdDixcount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {

                if (txtPrdQTY.Text == String.Empty)
                {
                    MessageBox.Show("يجب إدخال الكمية ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (txtPrdDixcount.Text == String.Empty)
                {
                    MessageBox.Show("يجب إدخال نسبة الخصم ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (orders.verify_qty_in_stock(txtPrdID.Text, Convert.ToInt32(txtPrdQTY.Text)).Rows.Count < 1)
                {
                    MessageBox.Show("الكمية المطلوبة غير متوفرة بالمخزن ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == txtPrdID.Text)
                    {
                        MessageBox.Show("هذا المنتج موجود في الفاتورة بالفعل ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        clearBOXES();
                        return;
                    }

                }
                DataRow r = dt.NewRow();
                r[0] = txtPrdID.Text;
                r[1] = txtPrdName.Text;
                r[3] = txtPrdUnitPrice.Text;
                r[4] = txtPrdQTY.Text;
                r[5] = txtPrdAmount.Text;
                r[6] = txtPrdDixcount.Text;
                r[7] = txtPrdTotalAmount.Text;
                dt.Rows.Add(r);
                dataGridView1.DataSource = dt;
                clearBOXES();
                invoice_Sum();
                lblProductCount.Text = (dataGridView1.Rows.Count-1).ToString();

            }
        }

        private void txtPrdDixcount_TextChanged(object sender, EventArgs e)
        {
            calculate_Totalamount();
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {

            if (txtPrdID.Text != String.Empty && txtPrdName.Text != String.Empty && txtPrdUnitPrice.Text != String.Empty && txtPrdQTY.Text != String.Empty
               && txtPrdAmount.Text != String.Empty && txtPrdDixcount.Text != String.Empty && txtPrdTotalAmount.Text != String.Empty)
            {
                MessageBox.Show("من فضلك قم بانهاء التعديل الحالي أولاً ", "انهاء التعديل الحالي", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            txtPrdID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtPrdName.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtPrdUnitPrice.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtPrdQTY.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtPrdAmount.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtPrdDixcount.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtPrdTotalAmount.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);

        }

        private void dataGridView1_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            invoice_Sum();
        }

        private void تعديلمنتجفيالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1_DoubleClick(sender, e);
        }

        private void حذفمنتجمنالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
        }

        private void حذفكلالمنتجاتمنالفاتورةToolStripMenuItem_Click(object sender, EventArgs e)
        {
            dt.Clear();
            dataGridView1.Refresh();
        }

        private void txtBarcode_MouseDown(object sender, MouseEventArgs e)
        {
           
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                DataTable dt = new DataTable();
                dt = products.get_PRDCTS_ByBarcode(txtBarcode.Text);
                txtPrdID.Text =  dt.Rows[0][0].ToString();
                txtPrdName.Text = dt.Rows[0][1].ToString();
                txtPrdUnitPrice.Text = dt.Rows[0][3].ToString(); 
                txtPrdQTY.Focus();
            }
        }

        private void rdbtnCash_CheckedChanged(object sender, EventArgs e)
        {
            dtPayTime.Enabled = false;
            Properties.Settings.Default.CheckButton = false;
        }

        private void rdbtnAGEL_CheckedChanged(object sender, EventArgs e)
        {
            dtPayTime.Enabled = true;
            Properties.Settings.Default.CheckButton = true;
        }

        private void btnPayInvoice_Click(object sender, EventArgs e)
        {
           
                decimal madfou3 = Properties.Settings.Default.Madfou3;
                double baky = Properties.Settings.Default.Bakey;
                Properties.Settings.Default.TOtalMatloub = Convert.ToDecimal(textInvoiceSum.Text);
                Properties.Settings.Default.Save();

               
                    if (textInvoice_NUM.Text == String.Empty)
                    {
                        MessageBox.Show("يجب إدخال رقم الفاتورة ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (text_SUP_CODE.Text == String.Empty)
                    {
                        MessageBox.Show("يجب إدخال كود العميل ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (textinvoice_descr.Text == String.Empty)
                    {
                        MessageBox.Show("يجب إدخال وصف الفاتورة ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    if (dataGridView1.Rows.Count < 1)
                    {
                        MessageBox.Show("يجب إدخال منتج للفاتورة ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
              
            }
            Frm_PayBuy frm = new Frm_PayBuy();
            frm.ShowDialog();
            if (Properties.Settings.Default.btnStatus == "Save")
            {
                if (Properties.Settings.Default.SaveAndPrint == false)
            {

                    string order_date = dateInvoice.Value.ToString("dd/MM/yyyy");
                    string PayDate = dtPayTime.Value.ToString("dd/MM/yyyy");                 
                    orders.Add_BuyOrder(Convert.ToInt16(textInvoice_NUM.Text), textinvoice_descr.Text, order_date,
                    Convert.ToInt16(text_SUP_CODE.Text), txtsallerName.Text, Convert.ToDecimal(textInvoiceSum.Text));
                    suppliers.ADD_SupPayHistory(Convert.ToInt16(textInvoice_NUM.Text), Convert.ToInt16(text_SUP_CODE.Text), madfou3, order_date);
                    orders.ADD_Supplier_Money(Convert.ToInt16(textInvoice_NUM.Text), Convert.ToInt16(text_SUP_CODE.Text), baky, order_date, PayDate);

                    for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                    {
                        orders.Add_Buyorder_details(dataGridView1.Rows[i].Cells[0].Value.ToString(),
                                                Convert.ToInt32(textInvoice_NUM.Text),
                                               Convert.ToInt32(dataGridView1.Rows[i].Cells[4].Value),
                                                dataGridView1.Rows[i].Cells[3].Value.ToString(),
                                              Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value),
                                                dataGridView1.Rows[i].Cells[5].Value.ToString(),
                                                dataGridView1.Rows[i].Cells[7].Value.ToString());


                    }
                    MessageBox.Show("تمت عملية الحفظ بنجاح", "عملية الحفظ ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_frm_boxes();

                    btnNew.Enabled = true;
                }
            }

        }
    }


}