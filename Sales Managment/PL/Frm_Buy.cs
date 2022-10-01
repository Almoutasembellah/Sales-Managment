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
    public partial class Frm_Buy : DevExpress.XtraEditors.XtraForm
    {

        private static Frm_Buy frm;
        static void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            frm = null;
        }
        public static Frm_Buy GetFormBuy
        {
            get
            {
                if (frm == null)
                {
                    frm = new Frm_Buy();
                    frm.FormClosed += new FormClosedEventHandler(frm_FormClosed);
                }
                return frm;
            }
        }


        public Frm_Buy()
        {
            InitializeComponent();
            if (frm == null)
                frm = this;
        }





        Database db = new Database();
        DataTable tbl = new DataTable();
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select max (Order_ID) from Buy", "");

            if ((tbl.Rows[0][0].ToString() == DBNull.Value.ToString()))
            {

                txtID.Text = "1";
            }
            else
            {

                txtID.Text = (Convert.ToInt32(tbl.Rows[0][0]) + 1).ToString();
            }
            DtpDate.Text = DateTime.Now.ToShortDateString();
            DtpAagel.Text = DateTime.Now.ToShortDateString();
            try
            {
                cbxItems.SelectedIndex = 0;
                cbxSupplier.SelectedIndex = 0;
            }
            catch (Exception) { };
            cbxItems.Text = "اختر منتج";
            DgvBuy.Rows.Clear();
            rbtnCash.Checked = true;
            txtbarcode.Clear();
            txtbarcode.Focus();
            txtTotal.Clear();

        }


        private void FillItems()
        {

            cbxItems.DataSource = db.readData("select * from Products", "");
            cbxItems.DisplayMember = "Pro_Name";
            cbxItems.ValueMember = "Pro_ID";

        }
        public void FillSupplier()
        {

            cbxSupplier.DataSource = db.readData("select * from Suppliers", "");
            cbxSupplier.DisplayMember = "Sup_Name";
            cbxSupplier.ValueMember = "Sup_ID";
        }
        private void Frm_Buy_Load(object sender, EventArgs e)
        {
            FillItems();
            FillSupplier();
            try
            {
                AutoNumber();
            }
            catch (Exception) { }


        }

        private void btnSupplierbrowse_Click(object sender, EventArgs e)
        {
            Frm_Suppliers frm = new Frm_Suppliers();
            frm.ShowDialog();
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
                    string Product_Price = tblItems.Rows[0][3].ToString();
                    decimal Discount = 0;

                    decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(tblItems.Rows[0][3]);

                    DgvBuy.Rows.Add(1);
                    int rowindex = DgvBuy.Rows.Count - 1;

                    DgvBuy.Rows[rowindex].Cells[0].Value = Product_ID;
                    DgvBuy.Rows[rowindex].Cells[1].Value = Product_Name;
                    DgvBuy.Rows[rowindex].Cells[2].Value = Product_Qty;
                    DgvBuy.Rows[rowindex].Cells[3].Value = Product_Price;
                    DgvBuy.Rows[rowindex].Cells[4].Value = Discount;
                    DgvBuy.Rows[rowindex].Cells[5].Value = total;
                }
                catch (Exception) { }


                try
                {
                    decimal TotalOrder = 0;
                    for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                    {

                        TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);
                        DgvBuy.ClearSelection();
                        DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                        DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;
                    }


                    txtTotal.Text = Math.Round(TotalOrder, 2).ToString();
                    lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();

                }
                catch (Exception) { }
            }
        }

        private void btnDeleteItem_Click(object sender, EventArgs e)
        {
            if (DgvBuy.Rows.Count >= 1)
            {

                int index = DgvBuy.SelectedRows[0].Index;

                DgvBuy.Rows.RemoveAt(index);


                if (DgvBuy.Rows.Count <= 0)
                {

                    txtTotal.Text = "0";
                }

                try
                {
                    decimal TotalOrder = 0;
                    for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                    {

                        TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);
                        DgvBuy.ClearSelection();
                        DgvBuy.FirstDisplayedScrollingRowIndex = DgvBuy.Rows.Count - 1;
                        DgvBuy.Rows[DgvBuy.Rows.Count - 1].Selected = true;
                    }


                    txtTotal.Text = Math.Round(TotalOrder, 2).ToString();
                    lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();

                }
                catch (Exception) { }
            }
        }

        private void txtbarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {

                DataTable tblItems = new DataTable();
                tblItems.Clear();

                tblItems = db.readData("select * from Products where Barcode=N'" + txtbarcode.Text + "'", "");
                if (tblItems.Rows.Count >= 1)
                {
                    try
                    {
                        string Product_ID = tblItems.Rows[0][0].ToString();
                        string Product_Name = tblItems.Rows[0][1].ToString();
                        string Product_Qty = "1";
                        string Product_Price = tblItems.Rows[0][3].ToString();
                        decimal Discount = 0;

                        decimal total = Convert.ToDecimal(Product_Qty) * Convert.ToDecimal(tblItems.Rows[0][3]);

                        DgvBuy.Rows.Add(1);
                        int rowindex = DgvBuy.Rows.Count - 1;

                        DgvBuy.Rows[rowindex].Cells[0].Value = Product_ID;
                        DgvBuy.Rows[rowindex].Cells[1].Value = Product_Name;
                        DgvBuy.Rows[rowindex].Cells[2].Value = Product_Qty;
                        DgvBuy.Rows[rowindex].Cells[3].Value = Product_Price;
                        DgvBuy.Rows[rowindex].Cells[4].Value = Discount;
                        DgvBuy.Rows[rowindex].Cells[5].Value = total;
                    }
                    catch (Exception) { }


                    try
                    {
                        decimal TotalOrder = 0;
                        for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                        {

                            TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);

                        }


                        txtTotal.Text = Math.Round(TotalOrder, 2).ToString();
                        lblItemsCount.Text = (DgvBuy.Rows.Count).ToString();

                    }
                    catch (Exception) { }
                }
            }
        }

        private void PayOrder()
        {

            if (DgvBuy.Rows.Count >= 1)
            {
                if (cbxSupplier.Items.Count <= 0) { MessageBox.Show("من فضلك اختر مورد اولا", "تاكيد"); return; }
                try
                {
                    if (DgvBuy.Rows.Count >= 1)
                    {
                        Properties.Settings.Default.TotalOrder =Convert.ToDecimal( txtTotal.Text);
                        Properties.Settings.Default.Madfou3 = 0;
                        Properties.Settings.Default.Bakey = 0;
                        Properties.Settings.Default.Save(); 

                        Frm_PayBuy frm = new Frm_PayBuy();
                        frm.ShowDialog();

                    }

                    if (Properties.Settings.Default.CheckButton == true)
                    {
                        string d = DtpDate.Value.ToString("dd/MM/yyyy");
                        string dreminder = DtpAagel.Value.ToString("dd/MM/yyyy");
                        db.exceuteData("insert into Buy values (" + txtID.Text + " , N'" + d + "' ," + cbxSupplier.SelectedValue + ")", "");

                        for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                        {

                            db.exceuteData("insert into Buy_Detalis values (" + txtID.Text + " , " + cbxSupplier.SelectedValue + " ," + DgvBuy.Rows[i].Cells[0].Value + " ,N'" + d + "' , " + DgvBuy.Rows[i].Cells[2].Value + " ,'123' ," + DgvBuy.Rows[i].Cells[3].Value + " , " + DgvBuy.Rows[i].Cells[4].Value + " , " + DgvBuy.Rows[i].Cells[5].Value + " , " + txtTotal.Text + " , " + Properties.Settings.Default.Madfou3 + " , " + Properties.Settings.Default.Bakey + ")", "");
                            db.exceuteData("update Products set Qty = Qty + "+DgvBuy.Rows[i].Cells[2].Value+" where Pro_ID="+ DgvBuy.Rows[i].Cells[0].Value + "", "");

                        }


                        if (rbtnCash.Checked == true)
                        {
                            db.exceuteData("insert into Supplier_Report values (" + txtID.Text + " ," + Properties.Settings.Default.Madfou3 + " , '" + d + "' , " + cbxSupplier.SelectedValue + ")", "");

                        }
                        else if (rbtnAagel.Checked == true)
                        {
                            db.exceuteData("insert into Supplier_Money values (" + txtID.Text + " , " + cbxSupplier.SelectedValue + " , " + Properties.Settings.Default.Bakey + " ,'" + d + "' ,'" + dreminder + "')", "");

                            if (Properties.Settings.Default.Madfou3 >= 1)
                            {
                                db.exceuteData("insert into Supplier_Report values (" + txtID.Text + " ," + Properties.Settings.Default.Madfou3 + " , '" + d + "' , " + cbxSupplier.SelectedValue + ")", "");
                            }
                        }

                        
                            Print();
                        
                        AutoNumber();
                    }
                }
                catch (Exception) { }


            }
        }
        //to print 8 cm order
        private void Print()
        {
            int id =Convert.ToInt32( txtID.Text);
            DataTable tblRpt = new DataTable();
          
            tblRpt.Clear();
            tblRpt = db.readData("SELECT [Order_ID] as 'رقم الفاتورة', Suppliers.Sup_Name as 'اسم المورد', Products.Pro_Name as 'اسم المنتج',[Date] as 'تاريخ الفاتورة',[Buy_Detalis].[Qty] as 'الكمية',[User_Name] as 'اسم المستخدم',[Price] as 'السعر',[Discount] as 'الخصم',[Total] as 'اجمالى الصنف',[TotalOrder] as 'الاجمالى العام',[Madfou3] as 'المدفوع',[Baky] as 'المبلغ المتبقى' FROM[dbo].[Buy_Detalis], Suppliers, Products where  Suppliers.Sup_ID =[Buy_Detalis].Sup_ID and Products.Pro_ID =[Buy_Detalis].Pro_ID and Order_ID="+id+"","");
            try
            {
            Frm_Print frm = new Frm_Print();
            
            frm.crystalReportViewer1.RefreshReport();
            
            RptOrderBuy rpt = new RptOrderBuy();
            

                rpt.SetDatabaseLogon("", "", @".\SQLEXPRESS", "Sales_System");
                rpt.SetDataSource(tblRpt);
                rpt.SetParameterValue("ID" ,id);
                frm.crystalReportViewer1.ReportSource = rpt;

                System.Drawing.Printing.PrintDocument printDocument = new System.Drawing.Printing.PrintDocument();
                rpt.PrintOptions.PrinterName = printDocument.PrinterSettings.PrinterName;
                rpt.PrintToPrinter(1, true, 0, 0);
                // frm.ShowDialog();
            }
            catch (Exception) { }
        }



        private void UpdateQty()
        {

            if (DgvBuy.Rows.Count >= 1)
            {

                Properties.Settings.Default.Item_Qty =Convert.ToDecimal( DgvBuy.CurrentRow.Cells[2].Value);
                Properties.Settings.Default.Item_BuyPrice = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[3].Value); ;
                Properties.Settings.Default.Item_Discount = Convert.ToDecimal(DgvBuy.CurrentRow.Cells[4].Value); ;

                Properties.Settings.Default.Save(); 


                Frm_BuyQty frm = new Frm_BuyQty();
                frm.ShowDialog();

            }

        }


        private void Frm_Buy_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F12)
            {

                PayOrder();

            }
            else if (e.KeyCode == Keys.F11)
            {

                UpdateQty();

                try
                {

                    int index = DgvBuy.SelectedRows[0].Index;

                    DgvBuy.Rows[index].Cells[2].Value = Properties.Settings.Default.Item_Qty;
                    DgvBuy.Rows[index].Cells[3].Value = Properties.Settings.Default.Item_BuyPrice;
                    DgvBuy.Rows[index].Cells[4].Value = Properties.Settings.Default.Item_Discount;

                }
                catch (Exception) { }

            }
        }

        private void DgvBuy_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            decimal Item_Qty = 0 ,Item_BuyPrice= 0 ,Item_Discount =0;
            try {

                int index = DgvBuy.SelectedRows[0].Index;

                Item_Qty =Convert.ToDecimal( DgvBuy.Rows[index].Cells[2].Value);
                Item_BuyPrice = Convert.ToDecimal(DgvBuy.Rows[index].Cells[3].Value);
                Item_Discount = Convert.ToDecimal(DgvBuy.Rows[index].Cells[4].Value);

                decimal Total = 0;

                Total = (Item_Qty * Item_BuyPrice) - Item_Discount;

                DgvBuy.Rows[index].Cells[5].Value = Total;



                decimal TotalOrder = 0;
                for (int i = 0; i <= DgvBuy.Rows.Count - 1; i++)
                {

                    TotalOrder += Convert.ToDecimal(DgvBuy.Rows[i].Cells[5].Value);

                }


                txtTotal.Text = Math.Round(TotalOrder, 2).ToString();

            } catch(Exception) { }
        }
    }

        
    }