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
        int  position;
        string ID;
        BL.Cls_Products product = new BL.Cls_Products();
       



        private void CLEARFIELDS()
        {
            txtID.Clear();
            txtProName.Clear();
            txtBarcode.Clear();
            NudBuyPrice.Value = 0;
            NudSalePrice.Value = 0;
            NudMAxDiscount.Value = 0;
            NudMinQty.Value = 0;
            NudQty.Value = 0;
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            gbxMOVEarrows.Enabled = false;

        }
        void navigation(int index)
        {
            //try
            //{
                

                DataRowCollection DRC = product.get_all_Products().Rows;

                ID = (DRC[index][0]).ToString();
                txtID.Text = DRC[index][0].ToString();
                txtProName.Text= DRC[index][1].ToString();
                NudQty.Value =Convert.ToInt32( DRC[index][2].ToString());
                NudBuyPrice.Value=Convert.ToDecimal(DRC[index][3].ToString());
                NudSalePrice.Value = Convert.ToDecimal(DRC[index][4].ToString());
                txtBarcode.Text = DRC[index][6].ToString();
                NudMinQty.Value = Convert.ToDecimal(DRC[index][7].ToString());
                NudMAxDiscount.Value= Convert.ToDecimal(DRC[index][8].ToString());
                cbxCategory.SelectedValue = DRC[index][5].ToString();
            //}
            //catch
            //{
            //    return;
            //}
        }


        private void FillType()
        {
            cbxCategory.DataSource = product.get_Categories();
            cbxCategory.ValueMember = "ID_CAT";
            cbxCategory.DisplayMember = "CAT_DESCRIPTION";
        }
        public Frm_Products()
        {
            InitializeComponent();
        }
       
        private void FillPro()
        {
            
        }
        private void Frm_Products_Load(object sender, EventArgs e)
        {
            try
            {
                FillType();
            }
            catch (Exception) { }
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            position = 0;
            navigation(position);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            position -= 1;
            if (position < 0)
            {
                position = 0;
            }
            navigation(position);
            if (position == 0)
            {
                MessageBox.Show(" هذا اول عنصر في القائمة ", "العنصر الاول ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //لو وصل لاخر عنصر في الجدول قله خلاص شطبنا مفيش التالي لما تدوس علي ذر التالي لان ده اخر عنصر
            if (position == product.get_all_Products().Rows.Count - 1)
            {
                MessageBox.Show(" هذا آخر عنصر في القائمة ", "العنصر الاخير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position += 1;
            navigation(position);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = product.get_all_Products().Rows.Count - 1;
            navigation(position);
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CLEARFIELDS();
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtID.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل كود المنتج اولا");
                    return;
                }
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
                if (NudMAxDiscount.Value >= (NudSalePrice.Value - NudBuyPrice.Value))
                {
                    MessageBox.Show("لا يمكن ان يكون الخصم المسموح اكبر من المكسب");
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
                product.ADD_Product(txtID.Text, txtProName.Text, Convert.ToInt32(NudQty.Value), NudBuyPrice.Value, NudSalePrice.Value,
                    txtBarcode.Text, NudMinQty.Value, NudMAxDiscount.Value, Convert.ToInt32(cbxCategory.SelectedValue), "with_image");
                MessageBox.Show("تمت الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
           
                btnAdd.Enabled = false;
                btnNew.Enabled = true;
                gbxMOVEarrows.Enabled = true;
           
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
            product.EDIT_Product(txtID.Text, txtProName.Text, Convert.ToInt32(NudQty.Value), NudBuyPrice.Value, NudSalePrice.Value,
                txtBarcode.Text, NudMinQty.Value, NudMAxDiscount.Value, Convert.ToInt32(cbxCategory.SelectedValue), "with_image");
            MessageBox.Show("تم التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                product.Delete_Product(txtID.Text);
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
           
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            //if (txtProNameSearch.Text != "")
            //{

            //    DataTable tblSearch = new DataTable();
            //    tblSearch.Clear();

            //    tblSearch = db.readData("select * from Products where Pro_Name Like N'%" + txtProNameSearch.Text + "%' ", "");


            //    if (tblSearch.Rows.Count <= 0)
            //    {
            //        MessageBox.Show("لا يوجد منتج بهذا الاسم");
            //    }
            //    else
            //    {
            //        try
            //        {
            //            txtID.Text = tblSearch.Rows[0][0].ToString();
            //            txtProName.Text = tblSearch.Rows[0][1].ToString();
            //            NudQty.Value = Convert.ToDecimal(tblSearch.Rows[0][2]);
            //            NudBuyPrice.Value = Convert.ToDecimal(tblSearch.Rows[0][3]);
            //            NudSalePrice.Value = Convert.ToDecimal(tblSearch.Rows[0][4]);
            //            txtBarcode.Text = tblSearch.Rows[0][5].ToString();
            //            NudMinQty.Value = Convert.ToDecimal(tblSearch.Rows[0][6]);
            //            NudMAxDiscount.Value = Convert.ToDecimal(tblSearch.Rows[0][7]);
            //        }
            //        catch (Exception) { }
            //    }

            //    btnAdd.Enabled = false;
            //    btnNew.Enabled = true;
            //    btnDelete.Enabled = true;
            //    btnDeleteAll.Enabled = true;
            //    btnSave.Enabled = true;
            //}
        }

        private void cbxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {

            

        }

        private void btnDeleteAll_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                product.Delete_ALLProductS();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            PL.FRM_ProductList FRM = new PL.FRM_ProductList();
            FRM.ShowDialog();
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                txtProName.Focus();
            }
        }

        private void txtProName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NudQty.Focus();
            }
        }

        private void NudQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NudMinQty.Focus();
            }
        }

        private void NudMinQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               NudBuyPrice.Focus();
            }
        }

        private void NudBuyPrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               NudSalePrice.Focus();
            }
        }

        private void NudSalePrice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
               txtBarcode.Focus();
            }
        }

        private void txtBarcode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                NudMAxDiscount.Focus();
            }
        }

        private void cbxProducts_SelectionChangeCommitted(object sender, EventArgs e)
        {

            //if (cbxProducts.Items.Count >= 1)
            //{

            //    DataTable tblSearch = new DataTable();
            //    tblSearch.Clear();



            //    tblSearch = db.readData("select * from Products where Pro_ID = " + cbxProducts.SelectedValue + " ", "");



            //    if (tblSearch.Rows.Count <= 0)
            //    {

            //    }
            //    else
            //    {
            //        try
            //        {
            //            txtID.Text = tblSearch.Rows[0][0].ToString();
            //            txtProName.Text = tblSearch.Rows[0][1].ToString();
            //            NudQty.Value = Convert.ToDecimal(tblSearch.Rows[0][2]);
            //            NudBuyPrice.Value = Convert.ToDecimal(tblSearch.Rows[0][3]);
            //            NudSalePrice.Value = Convert.ToDecimal(tblSearch.Rows[0][4]);
            //            txtBarcode.Text = tblSearch.Rows[0][5].ToString();
            //            NudMinQty.Value = Convert.ToDecimal(tblSearch.Rows[0][6]);
            //            NudMAxDiscount.Value = Convert.ToDecimal(tblSearch.Rows[0][7]);
            //        }
            //        catch (Exception) { }
            //    }

            //    btnAdd.Enabled = false;
            //    btnNew.Enabled = true;
            //    btnDelete.Enabled = true;
            //    btnDeleteAll.Enabled = true;
            //    btnSave.Enabled = true;
            //}
        }
    }
}