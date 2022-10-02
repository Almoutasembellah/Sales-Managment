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

namespace Sales_Managment.PL
{
    public partial class FRM_BuyOrder : DevExpress.XtraEditors.XtraForm
    {
       // BL.Class_ORDERS orders = new BL.Class_ORDERS();
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
            text_CUSTO_CODE.Clear();
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
                 where row.Cells[6].FormattedValue.ToString() != String.Empty
                 select Convert.ToDouble(row.Cells[6].FormattedValue)).Sum().ToString();
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

                    text_CUSTO_CODE.Text = frm.dgvSuppliers.CurrentRow.Cells[0].Value.ToString();
                    textNname.Text = frm.dgvSuppliers.CurrentRow.Cells[1].Value.ToString();
                    textPhone.Text = frm.dgvSuppliers.CurrentRow.Cells[2].Value.ToString();
                    txtSupCmpID.Text = frm.dgvSuppliers.CurrentRow.Cells[3].Value.ToString();
                    txtAdress.Text = frm.dgvSuppliers.CurrentRow.Cells[4].Value.ToString();
                    Picture_customer.Image = null;
                    return;
                }
                text_CUSTO_CODE.Text = frm.dgvSuppliers.CurrentRow.Cells[0].Value.ToString();
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

        }

        private void btnNewBuy_Click(object sender, EventArgs e)
        {

        }
    }
}