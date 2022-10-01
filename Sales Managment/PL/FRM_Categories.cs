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
using System.Data.SqlClient;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.Shared;
namespace Sales_Managment.PL
{
    public partial class FRM_Categories : DevExpress.XtraEditors.XtraForm
    {
        SqlConnection sqlconect = new SqlConnection(@"Server= " + Properties.Settings.Default.Server + ";Database=" + Properties.Settings.Default.Database +
                   ";Integrated Security=True ");
        SqlDataAdapter da;
        DataTable dt = new DataTable();
        BindingManagerBase bmb;
        SqlCommandBuilder sqlbuilder;
        public FRM_Categories()
        {
            InitializeComponent();
            da = new SqlDataAdapter("select ID_CAT as'كود الصنف',CAT_DESCRIPTION as 'وصف الصنف' from CATEGORIES", sqlconect);
            da.Fill(dt);
            dGRID_CAT_LIST.DataSource = dt;
            //الداتا بيندنج هو ربط الحقول الخاصة بجداول قواعد البيانات مع الكنترولز علي الفورم 
            textID_CAT.DataBindings.Add("Text", dt, "كود الصنف");
            textDESCR_CAT.DataBindings.Add("Text", dt, "وصف الصنف");
            //ربط البيندنج مانجر بالداتا تابل اللي اتملي باستخدام الداتا ادابتر من الجدول في قاعدة البيانات الاصليه
            bmb = this.BindingContext[dt];
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void FRM_Categories_Load(object sender, EventArgs e)
        {

        }

        private void btnLast_Click(object sender, EventArgs e)
        {
            bmb.Position = bmb.Count;
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnFirst_Click(object sender, EventArgs e)
        {
            bmb.Position = 0;
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            bmb.Position += 1;
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            bmb.Position -= 1;
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            bmb.AddNew();
            btnNew.Enabled = false;
            btnAdd.Enabled = true;
            dGRID_CAT_LIST.Enabled = false;
            int id = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][0]) + 1;
            textID_CAT.Text = id.ToString();
            textDESCR_CAT.Focus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            sqlbuilder = new SqlCommandBuilder(da);
            da.Update(dt);
            btnAdd.Enabled = false;
            btnNew.Enabled = true;
            dGRID_CAT_LIST.Enabled = true;
            MessageBox.Show("تمت عملية الإضافة بنجاح", "عملية الإضافة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            bmb.RemoveAt(bmb.Position);
            bmb.EndCurrentEdit();
            sqlbuilder = new SqlCommandBuilder(da);
            da.Update(dt);
            MessageBox.Show("تمت عملية الحذف بنجاح", "عملية الحذف", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bmb.EndCurrentEdit();
            sqlbuilder = new SqlCommandBuilder(da);
            da.Update(dt);

            MessageBox.Show("تمت عملية التعديل بنجاح", "عملية التعديل", MessageBoxButtons.OK, MessageBoxIcon.Information);
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            // frm = new Reports.FRM_PROD_REPORT();
            //Reports.rpt_single_category rpt = new Reports.rpt_single_category();
            //rpt.SetParameterValue("@ID", Convert.ToInt32(textID_CAT.Text));
            //frm.crystalReportViewer1.Reportsource = rpt;
            //frm.ShowDialog();
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            //Reports.FRM_PROD_REPORT frm = new Reports.FRM_PROD_REPORT();
            //Reports.rpt_all_categories rpt = new Reports.rpt_all_categories();
            //rpt.Refresh();
            //frm.crystalReportViewer1.Reportsource = rpt;
            //frm.ShowDialog();
        }

        private void simpleButton6_Click(object sender, EventArgs e)
        {

            //Reports.rpt_all_categories myreport = new Reports.rpt_all_categories();
            ////creat export options
            //ExportOptions export = new ExportOptions();
            ////creat object for destination
            //DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            ////create object for pdf format
            //PdfFormatOptions pdfFormat = new PdfFormatOptions();
            ////set the path
            //dfoptions.DiskFileName = @"D:\ALLcategories.pdf";
            //export = myreport.ExportOptions;
            ////set  destination type 
            //export.ExportDestinationType = ExportDestinationType.DiskFile;
            //export.ExportDestinationOptions = dfoptions;
            //export.ExportFormatOptions = pdfFormat;
            //export.ExportFormatType = ExportFormatType.PortableDocFormat;
            //myreport.Refresh();
            //myreport.Export();
            //MessageBox.Show("file exported sucsessfuly !", "export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //    Reports.rpt_single_category myreport = new Reports.rpt_single_category();
            //    //creat export options
            //    ExportOptions export = new ExportOptions();
            //    //creat object for destination
            //    DiskFileDestinationOptions dfoptions = new DiskFileDestinationOptions();
            //    //create object for pdf format
            //    PdfFormatOptions pdfFormat = new PdfFormatOptions();
            //    //set the path
            //    dfoptions.DiskFileName = @"D:\singlecategory.pdf";
            //    export = myreport.ExportOptions;
            //    //set  destination type 
            //    export.ExportDestinationType = ExportDestinationType.DiskFile;
            //    export.ExportDestinationOptions = dfoptions;
            //    export.ExportFormatOptions = pdfFormat;
            //    export.ExportFormatType = ExportFormatType.PortableDocFormat;
            //    myreport.SetParameterValue("@id", Convert.ToInt32(textID_CAT.Text));
            //    myreport.Export();
            //    MessageBox.Show("file exported sucsessfuly !", "export", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dGRID_CAT_LIST_SelectionChanged(object sender, EventArgs e)
        {
            lblPageOrder.Text = (bmb.Position + 1) + " / " + bmb.Count;
        }

        private void lblPageOrder_Click(object sender, EventArgs e)
        {

        }
    }
}  
