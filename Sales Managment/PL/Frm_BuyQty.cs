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
    public partial class Frm_BuyQty : DevExpress.XtraEditors.XtraForm
    {
        public Frm_BuyQty()
        {
            InitializeComponent();
        }

        private void Frm_BuyQty_Load(object sender, EventArgs e)
        {

            txtQty.Text =( Properties.Settings.Default.Item_Qty).ToString();
            txtBuyPrice.Text = (Properties.Settings.Default.Item_BuyPrice).ToString();
            txtDiscount.Text = (Properties.Settings.Default.Item_Discount).ToString();
            txtQty.Focus();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if(txtQty.Text == "") { MessageBox.Show("من فضلك ادخل الكمية","تاكيد"); return; }
            if (txtBuyPrice.Text == "") { MessageBox.Show("من فضلك ادخل سعر الشراء", "تاكيد"); return; }
            if (txtDiscount.Text == "") { MessageBox.Show("من فضلك ادخل  الخصم", "تاكيد"); return; }
            Properties.Settings.Default.Item_Qty =Convert.ToDecimal( txtQty.Text);
            Properties.Settings.Default.Item_Discount = Convert.ToDecimal(txtDiscount.Text);
            Properties.Settings.Default.Item_BuyPrice= Convert.ToDecimal(txtBuyPrice.Text);
            Properties.Settings.Default.Save();

            Close();
        }

        private void Frm_BuyQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) {

                if (txtQty.Text == "") { MessageBox.Show("من فضلك ادخل الكمية", "تاكيد"); return; }
                if (txtBuyPrice.Text == "") { MessageBox.Show("من فضلك ادخل سعر الشراء", "تاكيد"); return; }
                if (txtDiscount.Text == "") { MessageBox.Show("من فضلك ادخل  الخصم", "تاكيد"); return; }
                Properties.Settings.Default.Item_Qty = Convert.ToDecimal(txtQty.Text);
                Properties.Settings.Default.Item_Discount = Convert.ToDecimal(txtDiscount.Text);
                Properties.Settings.Default.Item_BuyPrice = Convert.ToDecimal(txtBuyPrice.Text);
                Properties.Settings.Default.Save();

                Close();

            }
        }

        private void Frm_BuyQty_FormClosing(object sender, FormClosingEventArgs e)
        {
            try {

                int index = Frm_Buy.GetFormBuy.DgvBuy.SelectedRows[0].Index;

                Frm_Buy.GetFormBuy.DgvBuy.Rows[index].Cells[2].Value = Properties.Settings.Default.Item_Qty;
                Frm_Buy.GetFormBuy.DgvBuy.Rows[index].Cells[3].Value = Properties.Settings.Default.Item_BuyPrice;
                Frm_Buy.GetFormBuy.DgvBuy.Rows[index].Cells[4].Value = Properties.Settings.Default.Item_Discount;

            } catch(Exception) { }
        }
    }
}