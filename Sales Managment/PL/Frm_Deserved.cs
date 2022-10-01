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
    public partial class Frm_Deserved : DevExpress.XtraEditors.XtraForm
    {
        int ID, position;
        BL.Cls_Expenses expenses = new BL.Cls_Expenses();
        public Frm_Deserved()
        {
            InitializeComponent();
        }
       
        


        private void CLEARFIELDS()
        {
            txtID.Clear();
            txtID.Clear();
            btnAdd.Enabled = true;

        }
        void navigation(int index)
        {
            try
            {


                DataRowCollection DRC = expenses.get_all_expnsStatements().Rows;
                
                ID = Convert.ToInt32(DRC[index][0]);
                txtID.Text = DRC[index][0].ToString();
                DateTime dtime = DateTime.ParseExact(DRC[index][1].ToString(), "dd/MM/yyyy", null);
                DtpDate.Value = dtime;
                NudPrice.Value =  Convert.ToDecimal( DRC[index][2].ToString());
                cbxType.SelectedValue = DRC[index][3].ToString();
                txtNote.Text= DRC[index][4].ToString();


            }
            catch
            {
                return;
            }
        }
      
       
        private void  FillType()
        {
            cbxType.DataSource =expenses.get_all_expenses();
            cbxType.ValueMember = "كود البند";
            cbxType.DisplayMember = "وصف البند";
        }
        private void Frm_Deserved_Load(object sender, EventArgs e)
        {
            DtpDate.Text= DateTime.Now.ToShortDateString();
            DtpDate.CustomFormat = "dd-MM-yyyy";
            FillType();

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            btnNew.Enabled = true;
            if (cbxType.Items.Count <=0)
            {
                MessageBox.Show("من فضلك ادخل الانواع اولا");
                return;
            }
            string d = DtpDate.Value.ToString("dd/MM/yyyy");
            expenses.Add_ExpnsStatement(Convert.ToInt32(txtID.Text), d, NudPrice.Value, txtNote.Text, Convert.ToInt32(cbxType.SelectedValue));
            MessageBox.Show("تمت الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                MessageBox.Show(" هذا اول عنصر في القائمة ", "العنصر الاول ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            //لو وصل لاخر عنصر في الجدول قله خلاص شطبنا مفيش التالي لما تدوس علي ذر التالي لان ده اخر عنصر
            if (position == expenses.get_all_expnsStatements().Rows.Count - 1)
            {
                MessageBox.Show(" هذا آخر عنصر في القائمة ", "العنصر الاخير", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            position += 1;
            navigation(position);
        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            position = expenses.get_all_expnsStatements().Rows.Count - 1;
            navigation(position);

        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            CLEARFIELDS();
            txtID.Text = expenses.get_Expens_StatementID().Rows[0][0].ToString();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(NudPrice.Value <= 0)
            {

                MessageBox.Show("لا يمكن ادخال اقل من 1","تاكيد");
                return;
            }
            string d = DtpDate.Value.ToString("dd/MM/yyyy");
            expenses.Edit_ExpnsStatement( d, NudPrice.Value, txtNote.Text, Convert.ToInt32(cbxType.SelectedValue),Convert.ToInt32(txtID.Text));
            MessageBox.Show("تم التعديل بنجاح", "عملية التعديل ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("هل انتا متاكد من مسح البيانات", "تاكيد", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                expenses.Delete_expnsStatements(Convert.ToInt32(txtID.Text));
                MessageBox.Show("تم مسح بيانات المورد بنجاح", " عملية المسح", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PL.FRM_ExpnsStatementList frm = new PL.FRM_ExpnsStatementList();
            frm.ShowDialog();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}