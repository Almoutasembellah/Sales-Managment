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
    public partial class Frm_PayBuy : DevExpress.XtraEditors.XtraForm
    {
        public Frm_PayBuy()
        {
            InitializeComponent();
        }

        private void Frm_PayBuy_Load(object sender, EventArgs e)
        {

            try
            {

                txtMatloub.Text = (Properties.Settings.Default.TOtalMatloub).ToString();

            }
            catch (Exception) { }

            txtMadfou3.Text = "0.0";
            txtBaky.Text = "0.0";
            txtMadfou3.Focus();
        }

        private void txtMadfou3_TextChanged(object sender, EventArgs e)
        {
            try
            {

                decimal baky = Convert.ToDecimal(txtMatloub.Text) - Convert.ToDecimal(txtMadfou3.Text);

                txtBaky.Text = Math.Round(baky, 2).ToString();

            }
            catch (Exception) { }
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.btnStatus = "Save";

            if (Properties.Settings.Default.CheckButton == false)
            {
                if (Convert.ToDouble(txtBaky.Text) > 0)
                {
                    MessageBox.Show("يجب دفع كامل قيمة الفاتورة لإنك  اخترت طريقة الدفع كاش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMadfou3.Focus();
                    return;
                }
                if (Convert.ToInt32(txtMadfou3.Text) == 0) { MessageBox.Show("من فضلك ادخل المبلغ المدفوع", "تاكيد"); return; }

                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDouble(txtBaky.Text);
                Properties.Settings.Default.Save();

                Close();
            }


            else if (Properties.Settings.Default.CheckButton == true)
            {
                if (Convert.ToDouble(txtBaky.Text) == 0)
                {
                    MessageBox.Show("لا يصح دفع كامل قيمة الفاتورة لإنك  اخترت طريقة الدفع آجل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMadfou3.Focus();
                    return;
                }
                if (Convert.ToInt32(txtMadfou3.Text) == 0)
                {
                    MessageBox.Show("من فضلك ادخل المبلغ المدفوع", "تاكيد");

                    txtMadfou3.Focus();
                    return;
                }

                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDouble(txtBaky.Text);




                Properties.Settings.Default.Save();

                Close();
            }
        }
        private void Frm_PayBuy_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                if (txtMadfou3.Text == "") { MessageBox.Show("من فضلك ادخل المبلغ المدفوع", "تاكيد"); return; }
                Properties.Settings.Default.SaveAndPrint = false;
                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDouble(txtBaky.Text);
                Properties.Settings.Default.CheckButton = true;
                Properties.Settings.Default.Save();

                Close();
            }
            else if (e.KeyCode == Keys.F12)
            {
                Properties.Settings.Default.CheckButton = false;
                Properties.Settings.Default.Save();
                Close();
            }
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.btnStatus = "return";

            Close();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.btnStatus = "SavePrint";
            Properties.Settings.Default.SaveAndPrint = true;

            if (Properties.Settings.Default.CheckButton == false)
            {
                if (Convert.ToDouble(txtBaky.Text) > 0)
                {
                    MessageBox.Show("يجب دفع كامل قيمة الفاتورة لإنك  اخترت طريقة الدفع كاش", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMadfou3.Focus();
                    return;
                }

                if (Convert.ToDecimal(txtMadfou3.Text) == 0)
                {
                    MessageBox.Show("من فضلك ادخل المبلغ المدفوع", "تاكيد"); return;
                }

                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDouble(txtBaky.Text);



                Properties.Settings.Default.Save();

                Close();
            }
            else if (Properties.Settings.Default.CheckButton == true)
            {
                if (Convert.ToDouble(txtBaky.Text) == 0)
                {
                    MessageBox.Show("لا يصح دفع كامل قيمة الفاتورة لإنك  اخترت طريقة الدفع آجل", "خطأ", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtMadfou3.Focus();
                    return;
                }
                if (Convert.ToInt32(txtMadfou3.Text) == 0)
                {
                    MessageBox.Show("من فضلك ادخل المبلغ المدفوع", "تاكيد");

                    txtMadfou3.Focus();
                    return;
                }

                Properties.Settings.Default.Madfou3 = Convert.ToDecimal(txtMadfou3.Text);
                Properties.Settings.Default.Bakey = Convert.ToDouble(txtBaky.Text);
                Properties.Settings.Default.Save();

                Close();
            }
        }
    }
}