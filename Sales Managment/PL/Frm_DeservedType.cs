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
    public partial class Frm_DeservedType : DevExpress.XtraEditors.XtraForm
    {
        int ID, position;
        BL.Cls_Expenses expenses = new BL.Cls_Expenses();
       

        private void CLEARFIELDS()
        {
            txtName.Clear();
            txtID.Clear();
            txtID.Focus();
            btnSave.Enabled = true;
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            btnDelete.Enabled = true;

        }
        void navigation(int index)
        {
            try
            {
               

                DataRowCollection DRC = expenses.get_all_expenses().Rows;
                ID = Convert.ToInt32(DRC[index][0]);
                txtID.Text = DRC[index][0].ToString();
                txtName.Text = DRC[index][1].ToString();
               
            }
            catch
            {
                return;
            }
        }
        public Frm_DeservedType()
        {
            InitializeComponent();
        }




    
       
   
        private void Frm_DeservedType_Load(object sender, EventArgs e)
        {
           
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            position = 0;
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

        private void btnNext_Click(object sender, EventArgs e)
        {
            //لو وصل لاخر عنصر في الجدول قله خلاص شطبنا مفيش التالي لما تدوس علي ذر التالي لان ده اخر عنصر
            if (position == expenses.get_all_expenses().Rows.Count - 1)
            {
                MessageBox.Show(" هذا آخر عنصر في القائمة ", "العنصر الاخير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position += 1;
            navigation(position);

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = expenses.get_all_expenses().Rows.Count - 1;
            navigation(position);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                btnNew.Enabled = true;
                if (txtName.Text == "")
                {
                    MessageBox.Show("من فضلك ادخل اسم النوع");
                    return;
                }
                expenses.add_expense(Convert.ToInt32(txtID.Text), txtName.Text);
                MessageBox.Show("تمت الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }


        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CLEARFIELDS();
            txtID.Text = expenses.get_ExpensID().Rows[0][0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (ID == 0)
                {
                    MessageBox.Show("العميل المراد تعديله غير موجود");
                }

                expenses.Edit_expense(txtName.Text, Convert.ToInt32(txtID.Text));
                MessageBox.Show("تم التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {

            }
            }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                expenses.Delete_expens(Convert.ToInt32(txtID.Text));
                MessageBox.Show("تم مسح بيانات المورد بنجاح", " عملية المسح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode== Keys.Enter)
            {
                txtName.Focus();
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PL.FRM_ExpensList frm = new PL.FRM_ExpensList();
            frm.ShowDialog();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}