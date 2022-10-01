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
    public partial class Frm_Products : DevExpress.XtraEditors.XtraForm
    {
        public Frm_Products()
        {
            InitializeComponent();
        }
        Database db = new Database();
        DataTable tbl = new DataTable();
        private void AutoNumber()
        {
            tbl.Clear();
            tbl = db.readData("select max (Pro_ID) from Products", "");

            if ((tbl.Rows[0][0].ToString() == DBNull.Value.ToString()))
            {

                txtID.Text = "1";
            }
            else
            {

                txtID.Text = (Convert.ToInt32(tbl.Rows[0][0]) + 1).ToString();
            }

            txtBarcode.Clear();
            txtProName.Clear();
            txtProNameSearch.Clear();
            NudBuyPrice.Value = 1;
            NudSalePrice.Value = 1;
            NudMinQty.Value = 0;
            NudMAxDiscount.Value = 0;
            NudQty.Value = 0;
            try
            {
                FillPro();
            }
            catch (Exception) { }
            btnAdd.Enabled = true;
            btnNew.Enabled = true;
            btnDelete.Enabled = false;
            btnDeleteAll.Enabled = false;
            btnSave.Enabled = false;

        }

        int row;
        private void Show()
        {
            tbl.Clear();
            tbl = db.readData("select * from Products", "");

            if (tbl.Rows.Count <= 0)
            {
                MessageBox.Show("لا يوجد بيانات فى هذه الشاشه");
            }
            else
            {
                try
                {
                    txtID.Text = tbl.Rows[row][0].ToString();
                    txtProName.Text =tbl.Rows[row][1].ToString();
                    NudQty.Value = Convert.ToDecimal(tbl.Rows[row][2]);
                    NudBuyPrice.Value = Convert.ToDecimal(tbl.Rows[row][3]);
                    NudSalePrice.Value = Convert.ToDecimal(tbl.Rows[row][4]);
                    txtBarcode.Text= tbl.Rows[row][5].ToString();
                    NudMinQty.Value= Convert.ToDecimal(tbl.Rows[row][6]);
                    NudMAxDiscount.Value= Convert.ToDecimal(tbl.Rows[row][7]);
                }
                catch (Exception) { }
            }

            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            btnDelete.Enabled = true;
            btnDeleteAll.Enabled = true;
            btnSave.Enabled = true;
        }

        private void FillPro()
        {
            cbxProducts.DataSource = db.readData("select * from Products", "");
            cbxProducts.DisplayMember = "Pro_Name";
            cbxProducts.ValueMember = "Pro_ID";
        }
        private void Frm_Products_Load(object sender, EventArgs e)
        {
            try
            {
                AutoNumber();
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            row = 0;
            Show();
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            if (row == 0)
            {
                tbl.Clear();
                tbl = db.readData("select count(Pro_ID) from Products", "");
                row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
                Show();
            }
            else
            {


                row--;
                Show();
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count(Pro_ID) from Products", "");
            if (Convert.ToInt32(tbl.Rows[0][0]) - 1 == row)
            {
                row = 0;
                Show();
            }
            else
            {
                row++;
                Show();
            }
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            tbl.Clear();
            tbl = db.readData("select count(Pro_ID) from Products", "");
            row = Convert.ToInt32(tbl.Rows[0][0]) - 1;
            Show();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            AutoNumber(); 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtProName.Text =="")
            {
                MessageBox.Show("من فضلك ادخل اسم المنتج اولا");
                return;
            }
            if (NudBuyPrice.Value <= 0)
            {
                MessageBox.Show("لا يمكن ان يكون سعر الشراء اقل من 1");
                return;
            }
            if (NudSalePrice.Value <= 0)
            {
                MessageBox.Show("لا يمكن ان يكون سعر البيع اقل من 1");
                return;
            }
            if (NudMAxDiscount.Value >= NudSalePrice.Value)
            {
                MessageBox.Show("لا يمكن ان يكون الخصم المسموح اكبر من سعر البيع");
                return;
            }
            if (NudBuyPrice.Value > NudSalePrice.Value)
            {
                MessageBox.Show("لا يمكن ان يكون سعرالشراء اكبر من سعر البيع");
                return;
            }
            if (NudMinQty.Value > NudQty.Value)
            {
                MessageBox.Show("لا يمكن ان يكون حد الطلب اكبر من الكميه الموجوده");
                return;
            }
            db.exceuteData("insert into Products Values (" + txtID.Text + " ,N'"+txtProName.Text+"' ,"+NudQty.Value+" ,"+NudBuyPrice.Value+" ,"+NudSalePrice.Value+" ,N'"+txtBarcode.Text+"' ,"+NudMinQty.Value+" ,"+NudMAxDiscount.Value+")", "تم الادخال بنجاح");

            AutoNumber();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProName.Text == "")
            {
                MessageBox.Show("من فضلك ادخل اسم المنتج اولا");
                return;
            }
            if (NudBuyPrice.Value <= 0)
            {
                MessageBox.Show("لا يمكن ان يكون سعر الشراء اقل من 1");
                return;
            }
            if (NudSalePrice.Value <= 0)
            {
                MessageBox.Show("لا يمكن ان يكون سعر البيع اقل من 1");
                return;
            }
            if (NudMAxDiscount.Value >= NudSalePrice.Value)
            {
                MessageBox.Show("لا يمكن ان يكون الخصم المسموح اكبر من سعر البيع");
                return;
            }
            if (NudBuyPrice.Value > NudSalePrice.Value)
            {
                MessageBox.Show("لا يمكن ان يكون سعرالشراء اكبر من سعر البيع");
                return;
            }
            if (NudMinQty.Value > NudQty.Value)
            {
                MessageBox.Show("لا يمكن ان يكون حد الطلب اكبر من الكميه الموجوده");
                return;
            }
            db.exceuteData("update  Products set  Pro_Name=N'" + txtProName.Text + "' ,Qty=" + NudQty.Value + " ,Buy_Price=" + NudBuyPrice.Value + " ,Sale_Price=" + NudSalePrice.Value + " ,Barcode=N'" + txtBarcode.Text + "' ,MinQty=" + NudMinQty.Value + " ,MaxDiscount=" + NudMAxDiscount.Value + " where Pro_ID=" + txtID.Text + " ", "تم التعديل بنجاح");

            AutoNumber();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products where Pro_ID=" + txtID.Text + "", "تم مسح البيانات بنجاح");
                AutoNumber();
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                db.readData("delete from Products", "تم مسح البيانات بنجاح");
                AutoNumber();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtProNameSearch.Text != "") {

                DataTable tblSearch = new DataTable();
                tblSearch.Clear();

                tblSearch = db.readData("select * from Products where Pro_Name Like N'%"+txtProNameSearch.Text+"%' ", "");

                if (tblSearch.Rows.Count <= 0)
                {
                    MessageBox.Show("لا يوجد منتج بهذا الاسم");
                }
                else
                {
                    try
                    {
                        txtID.Text = tblSearch.Rows[0][0].ToString();
                        txtProName.Text = tblSearch.Rows[0][1].ToString();
                        NudQty.Value = Convert.ToDecimal(tblSearch.Rows[0][2]);
                        NudBuyPrice.Value = Convert.ToDecimal(tblSearch.Rows[0][3]);
                        NudSalePrice.Value = Convert.ToDecimal(tblSearch.Rows[0][4]);
                        txtBarcode.Text = tblSearch.Rows[0][5].ToString();
                        NudMinQty.Value = Convert.ToDecimal(tblSearch.Rows[0][6]);
                        NudMAxDiscount.Value = Convert.ToDecimal(tblSearch.Rows[0][7]);
                    }
                    catch (Exception) { }
                }

                btnAdd.Enabled = false;
                btnNew.Enabled = true;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
            }
        }

        private void cbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }

        private void cbxProducts_SelectionChangeCommitted(object sender, EventArgs e)
        {

            if (cbxProducts.Items.Count >= 1)
            {

                DataTable tblSearch = new DataTable();
                tblSearch.Clear();



                tblSearch = db.readData("select * from Products where Pro_ID = " + cbxProducts.SelectedValue + " ", "");



                if (tblSearch.Rows.Count <= 0)
                {

                }
                else
                {
                    try
                    {
                        txtID.Text = tblSearch.Rows[0][0].ToString();
                        txtProName.Text = tblSearch.Rows[0][1].ToString();
                        NudQty.Value = Convert.ToDecimal(tblSearch.Rows[0][2]);
                        NudBuyPrice.Value = Convert.ToDecimal(tblSearch.Rows[0][3]);
                        NudSalePrice.Value = Convert.ToDecimal(tblSearch.Rows[0][4]);
                        txtBarcode.Text = tblSearch.Rows[0][5].ToString();
                        NudMinQty.Value = Convert.ToDecimal(tblSearch.Rows[0][6]);
                        NudMAxDiscount.Value = Convert.ToDecimal(tblSearch.Rows[0][7]);
                    }
                    catch (Exception) { }
                }

                btnAdd.Enabled = false;
                btnNew.Enabled = true;
                btnDelete.Enabled = true;
                btnDeleteAll.Enabled = true;
                btnSave.Enabled = true;
            }
        }
    }
}