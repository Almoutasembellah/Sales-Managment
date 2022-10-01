using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Sales_Managment
{
    public partial class Frm_Suppliers : DevExpress.XtraEditors.XtraForm
    {
        int ID, position;
        BL.Cls_Suppliers suppliers = new BL.Cls_Suppliers();
        public Frm_Suppliers()
        {
            InitializeComponent();
        }

       
        private void CLEARFIELDS()
        {
            txtName.Clear();
            txtNotes.Clear();
            txtPhone.Clear();
            txtAddress.Clear();
            txtCmpID.Clear();
            Picture_customer.Image = null;
            txtName.Enabled = true;
            txtPhone.Enabled = true;
            txtCmpID.Enabled = true;
            txtAddress.Enabled = true;
            txtNotes.Enabled = true;
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnEdit.Enabled = true;
            btnDelete.Enabled = true;
            grbNAVIGATION.Enabled = false;

        }
        void navigation(int index)
        {
            try
            {
                Picture_customer.Image = null;

                DataRowCollection DRC = suppliers.Get_AllSup_info().Rows;
                ID = Convert.ToInt32(DRC[index][0]);
                txtID.Text= DRC[index][0].ToString();
                txtName.Text = DRC[index][1].ToString();
                txtPhone.Text = DRC[index][2].ToString();
                txtCmpID.Text = DRC[index][3].ToString();
                txtAddress.Text = DRC[index][4].ToString();
                txtNotes.Text = DRC[index][5].ToString();
                byte[] picture = (byte[])DRC[index][6];
                MemoryStream ms = new MemoryStream(picture);
                Picture_customer.Image = Image.FromStream(ms);
            }
            catch
            {
                return;
            }
        }

       
        private void Frm_Suppliers_Load(object sender, EventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    MessageBox.Show("العميل المراد تعديله غير موجود");
                }
                byte[] img;
                if (Picture_customer.Image == null)
                {
                    //اعطاء قيمة للصورة هنا من اجل التحايل فقط لان القيمة دي مش هتتبعت بناءا علي الشرط اللي في الاجراء المخزن
                    img = new byte[16];
                    suppliers.Edit_Suppliers(txtName.Text, txtPhone.Text, txtCmpID.Text, txtAddress.Text, txtNotes.Text, img, "without_image", ID);
                    MessageBox.Show("تم التعديل بنجاح", "عملية التعديل بدون صورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   // this.dataGridView1.DataSource = customers.get_all_customers();
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    Picture_customer.Image.Save(ms, Picture_customer.Image.RawFormat);
                    img = ms.ToArray();

                    suppliers.Edit_Suppliers(txtName.Text, txtPhone.Text, txtCmpID.Text, txtAddress.Text, txtNotes.Text, img, "without_image", ID);

                    MessageBox.Show("تم التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.dataGridView1.DataSource = customers.get_all_customers();
                }
            }
            catch
            {
                return;
            }


        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            position = 0;
            navigation(position);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = suppliers.Get_AllSup_info().Rows.Count - 1;
            navigation(position);
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //لو وصل لاخر عنصر في الجدول قله خلاص شطبنا مفيش التالي لما تدوس علي ذر التالي لان ده اخر عنصر
            if (position == suppliers.Get_AllSup_info().Rows.Count - 1)
            {
                MessageBox.Show(" this is the last item in table ", "the last", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position += 1;
            navigation(position);
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            position -= 1;
            navigation(position);
            if (position == 0)
            {
                MessageBox.Show(" this is the first item in table ", "the first ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CLEARFIELDS();
            txtID.Text = suppliers.get_SupplyerID().Rows[0][0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtName.Text == String.Empty)
            {
                MessageBox.Show("يجب إدخال اسم المورد ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtName.Focus();
                return;
            }
            if (txtPhone.Text == String.Empty)
            {
                MessageBox.Show("يجب إدخال هاتف المورد ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtPhone.Focus();
                return;
            }
            if (txtAddress.Text == String.Empty)
            {
                MessageBox.Show("يجب إدخال  عنوان المورد ", "تحذير", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtAddress.Focus();
                return;
            }
          

                byte[] img;
                if (Picture_customer.Image == null)
                {
                    //اعطاء قيمة للصورة هنا من اجل التحايل فقط لان القيمة دي مش هتتبعت بناءا علي الشرط اللي في الاجراء المخزن
                    img = new byte[16];
                    suppliers.ADD_Suppliers(txtName.Text, txtPhone.Text, txtCmpID.Text, txtAddress.Text,txtNotes.Text, img, "without_image",Convert.ToInt32 (txtID.Text));

                    MessageBox.Show("تمت الإضافة بنجاح", "عملية الإضافة بدون صورة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                   
                }
                else
                {
                    MemoryStream ms = new MemoryStream();
                    Picture_customer.Image.Save(ms, Picture_customer.Image.RawFormat);
                    img = ms.ToArray();

                    suppliers.ADD_Suppliers(txtName.Text, txtPhone.Text, txtCmpID.Text, txtAddress.Text, txtNotes.Text, img, "without_image", Convert.ToInt32(txtID.Text));

                    MessageBox.Show("تمت الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                  
                }
                btnNew.Enabled = true;
                grbNAVIGATION.Enabled = true;
                btnSave.Enabled = false;
            }
            catch
            {
                return;

            }
            finally
            {
                btnNew.Enabled = true;
                btnSave.Enabled = false;
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                suppliers.Delete_Suppliers(Convert.ToInt32(txtID.Text));
                MessageBox.Show("تم مسح بيانات المورد بنجاح", " عملية المسح", MessageBoxButtons.OK, MessageBoxIcon.Information);
           
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            PL.Frm_SuppliersList frm = new PL.Frm_SuppliersList();
           frm.ShowDialog();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
           

          
        }

        private void Frm_Suppliers_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode ==Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtPhone.Focus();
            }
        }

        private void txtPhone_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtCmpID.Focus();
            }
        }

        private void txtCmpID_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtAddress.Focus();
            }
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                txtNotes.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}