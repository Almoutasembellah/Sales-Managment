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
    public partial class Frm_Sales : DevExpress.XtraEditors.XtraForm
    {


        private static Frm_Sales frm;
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static Frm_Sales GetFormSales
        {
            get
            {
                if (frm == null)
                {
                    frm = new Frm_Sales();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }

        public Frm_Sales()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
        }
        Database db = new Database();
        DataTable tbl = new DataTable();



        private void FillItems()
        {

            cbxItems.DataSource = db.readData("select * from Products", "");
            cbxItems.DisplayMember = "Pro_Name";
            cbxItems.ValueMember = "Pro_ID";

        }

        public void FillCustomer()
        {

            cbxCustomer.DataSource = db.readData("select * from Customers", "");
            cbxCustomer.DisplayMember = "Cust_Name";
            cbxCustomer.ValueMember = "Cust_ID";
        }
        private void Frm_Sales_Load(object sender, EventArgs e)
        {
            FillItems();
            FillCustomer();
            DtpDate.Text = DateTime.Now.ToShortDateString();
            DtpReminder.Text = DateTime.Now.ToShortDateString();
            rbtnCustNakdy_CheckedChanged(null, null);

            
            try {

                AutoNumber();
            } catch (Exception) { }
        }
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select max (Order_ID) from Sales", "");

            if ((tbl.Rows[0][0].ToString() == DBNull.Value.ToString()))
            {

                txtID.Text = "1";
            }
            else
            {

                txtID.Text = (Convert.ToInt32(tbl.Rows[0][0]) + 1).ToString();
            }
            DtpDate.Text = DateTime.Now.ToShortDateString();
            DtpReminder.Text = DateTime.Now.ToShortDateString();
            try
            {
                cbxItems.SelectedIndex = 0;
                cbxCustomer.SelectedIndex = 0;
            }
            catch (Exception) { };
            cbxItems.Text = "اختر منتج";
            DgvSale.Rows.Clear();
            rbtnCustNakdy.Checked = true;
            txtbarcode.Clear();
            txtbarcode.Focus();
            txtTotal.Clear();

        }
        private void rbtnCustNakdy_CheckedChanged(object sender, EventArgs e)
        {
            try {

                cbxCustomer.Enabled = false;
                btnCustomerBrowes.Enabled = false;
                DtpReminder.Enabled = false;

            } catch (Exception) { }
        }

        private void rbtnCustAagel_CheckedChanged(object sender, EventArgs e)
        {
            try
            {

                cbxCustomer.Enabled = true;
                btnCustomerBrowes.Enabled = true;
                DtpReminder.Enabled = true;

            }
            catch (Exception) { }
        }

        private void btnCustomerBrowes_Click(object sender, EventArgs e)
        {
            //Frm_Customer frm = new Frm_Customer();
            //frm.ShowDialog();
        }

        private void btnItems_Click(object sender, EventArgs e)
        {
            if (cbxItems.Text == "اختر منتج")
            {
                MessageBox.Show("من فضلك اختر منتج", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (cbxItems.Items.Count <= 0)
            {
                MessageBox.Show("من فضلك ادخل المنتجات اولا", "تاكيد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataTable tblItems = new DataTable();
            tblItems.Clear();

            tblItems = db.readData("select * from Products where Pro_ID=" + cbxItems.SelectedValue + "", "");
            if (tblItems.Rows.Count >= 1)
            {
                try
                {
                    string Product_ID = tblItems.Rows[0][0].ToString();
                    string Product_Name = tblItems.Rows[0][1].ToString();
                    string Product_Qty = "1";
                    string Product_Price = tblItems.Rows[0][4].ToString();
                    decimal Discount = 0;

                    decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(tblItems.Rows[0][4]);

                    DgvSale.Rows.Add(1);
                    int rowindex = DgvSale.Rows.Count - 1;

                    DgvSale.Rows[rowindex].Cells[0].Value = Product_ID;
                    DgvSale.Rows[rowindex].Cells[1].Value = Product_Name;
                    DgvSale.Rows[rowindex].Cells[2].Value = Product_Qty;
                    DgvSale.Rows[rowindex].Cells[3].Value = Product_Price;
                    DgvSale.Rows[rowindex].Cells[4].Value = Discount;
                    DgvSale.Rows[rowindex].Cells[5].Value = total;
                }
                catch (Exception) { }


                try
                {
                    decimal TotalOrder = 0;
                    for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                    {

                        TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[5].Value);
                        DgvSale.ClearSelection();
                        DgvSale.FirstDisplayedScrollingRowIndex = DgvSale.Rows.Count - 1;
                        DgvSale.Rows[DgvSale.Rows.Count - 1].Selected = true;
                    }


                    txtTotal.Text = Math.Round(TotalOrder, 2).ToString();
                    lblItemsCount.Text = (DgvSale.Rows.Count).ToString();

                }
                catch (Exception) { }
            }

        }

        private void Frm_Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.F2)
            {

                btnItems_Click(null,null);

            } else if (e.KeyCode == Keys.F1)
            {

                txtbarcode.Clear();
                txtbarcode.Focus();
            }
        }

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                DataTable tblItems = new DataTable();
                tblItems.Clear();

                tblItems = db.readData("select * from Products where Barcode='" + txtbarcode.Text + "'", "");
                if (tblItems.Rows.Count >= 1)
                {
                    try
                    {
                        string Product_ID = tblItems.Rows[0][0].ToString();
                        string Product_Name = tblItems.Rows[0][1].ToString();
                        string Product_Qty = "1";
                        string Product_Price = tblItems.Rows[0][4].ToString();
                        decimal Discount = 0;

                        decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(tblItems.Rows[0][4]);

                        DgvSale.Rows.Add(1);
                        int rowindex = DgvSale.Rows.Count - 1;

                        DgvSale.Rows[rowindex].Cells[0].Value = Product_ID;
                        DgvSale.Rows[rowindex].Cells[1].Value = Product_Name;
                        DgvSale.Rows[rowindex].Cells[2].Value = Product_Qty;
                        DgvSale.Rows[rowindex].Cells[3].Value = Product_Price;
                        DgvSale.Rows[rowindex].Cells[4].Value = Discount;
                        DgvSale.Rows[rowindex].Cells[5].Value = total;
                    }
                    catch (Exception) { }


                    try
                    {
                        decimal TotalOrder = 0;
                        for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                        {

                            TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[5].Value);
                            DgvSale.ClearSelection();
                            DgvSale.FirstDisplayedScrollingRowIndex = DgvSale.Rows.Count - 1;
                            DgvSale.Rows[DgvSale.Rows.Count - 1].Selected = true;
                        }


                        txtTotal.Text = Math.Round(TotalOrder, 2).ToString();
                        lblItemsCount.Text = (DgvSale.Rows.Count).ToString();

                    }
                    catch (Exception) { }
                }

            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (DgvSale.Rows.Count >= 1)
            {

                int index = DgvSale.SelectedRows[0].Index;

                DgvSale.Rows.RemoveAt(index);


                if (DgvSale.Rows.Count <= 0)
                {

                    txtTotal.Text = "0";
                }

                try
                {
                    decimal TotalOrder = 0;
                    for (int i = 0; i <= DgvSale.Rows.Count - 1; i++)
                    {

                        TotalOrder += Convert.ToDecimal(DgvSale.Rows[i].Cells[5].Value);
                        DgvSale.ClearSelection();
                        DgvSale.FirstDisplayedScrollingRowIndex = DgvSale.Rows.Count - 1;
                        DgvSale.Rows[DgvSale.Rows.Count - 1].Selected = true;
                    }


                    txtTotal.Text = Math.Round(TotalOrder, 2).ToString();
                    lblItemsCount.Text = (DgvSale.Rows.Count).ToString();

                }
                catch (Exception) { }
            }
        }
    }
}