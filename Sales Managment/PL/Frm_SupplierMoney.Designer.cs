namespace Sales_Managment
{
    partial class Frm_SupplierMoney
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frm_SupplierMoney));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.rbtnOneSupplier = new System.Windows.Forms.RadioButton();
            this.rbtnAllSup = new System.Windows.Forms.RadioButton();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.DgvSearch = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnPayPart = new System.Windows.Forms.RadioButton();
            this.rbtnPayAll = new System.Windows.Forms.RadioButton();
            this.NudPrice = new System.Windows.Forms.NumericUpDown();
            this.btnPay = new DevExpress.XtraEditors.SimpleButton();
            this.dtIMENextPayment = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(331, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(217, 29);
            this.label2.TabIndex = 12;
            this.label2.Text = "المبالغ المتبقيه للموردين";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.DtpDate);
            this.groupBox1.Controls.Add(this.btnPrint);
            this.groupBox1.Controls.Add(this.btnAdd);
            this.groupBox1.Controls.Add(this.rbtnOneSupplier);
            this.groupBox1.Controls.Add(this.rbtnAllSup);
            this.groupBox1.Controls.Add(this.cbxSupplier);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1041, 100);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            // 
            // DtpDate
            // 
            this.DtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.DtpDate.Location = new System.Drawing.Point(425, 41);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(139, 29);
            this.DtpDate.TabIndex = 22;
            // 
            // btnPrint
            // 
            this.btnPrint.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Appearance.Options.UseFont = true;
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btnPrint.Location = new System.Drawing.Point(6, 28);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(165, 46);
            this.btnPrint.TabIndex = 13;
            this.btnPrint.Text = "طباعة تقرير مفصل";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.ImageOptions.Image")));
            this.btnAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btnAdd.Location = new System.Drawing.Point(202, 28);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(125, 46);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "بحث";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // rbtnOneSupplier
            // 
            this.rbtnOneSupplier.AutoSize = true;
            this.rbtnOneSupplier.ForeColor = System.Drawing.Color.Blue;
            this.rbtnOneSupplier.Location = new System.Drawing.Point(776, 41);
            this.rbtnOneSupplier.Name = "rbtnOneSupplier";
            this.rbtnOneSupplier.Size = new System.Drawing.Size(95, 28);
            this.rbtnOneSupplier.TabIndex = 11;
            this.rbtnOneSupplier.Text = "مورد محدد";
            this.rbtnOneSupplier.UseVisualStyleBackColor = true;
            // 
            // rbtnAllSup
            // 
            this.rbtnAllSup.AutoSize = true;
            this.rbtnAllSup.Checked = true;
            this.rbtnAllSup.ForeColor = System.Drawing.Color.Blue;
            this.rbtnAllSup.Location = new System.Drawing.Point(876, 41);
            this.rbtnAllSup.Name = "rbtnAllSup";
            this.rbtnAllSup.Size = new System.Drawing.Size(106, 28);
            this.rbtnAllSup.TabIndex = 10;
            this.rbtnAllSup.TabStop = true;
            this.rbtnAllSup.Text = "كل الموردين";
            this.rbtnAllSup.UseVisualStyleBackColor = true;
            this.rbtnAllSup.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cbxSupplier.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Location = new System.Drawing.Point(618, 40);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(152, 32);
            this.cbxSupplier.TabIndex = 9;
            // 
            // DgvSearch
            // 
            this.DgvSearch.AllowUserToAddRows = false;
            this.DgvSearch.AllowUserToDeleteRows = false;
            this.DgvSearch.AllowUserToResizeColumns = false;
            this.DgvSearch.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvSearch.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvSearch.BackgroundColor = System.Drawing.Color.White;
            this.DgvSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.Beige;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Yellow;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvSearch.DefaultCellStyle = dataGridViewCellStyle1;
            this.DgvSearch.Location = new System.Drawing.Point(12, 145);
            this.DgvSearch.Name = "DgvSearch";
            this.DgvSearch.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvSearch.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.DgvSearch.RowHeadersWidth = 51;
            this.DgvSearch.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.DgvSearch.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.DgvSearch.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Blue;
            this.DgvSearch.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvSearch.Size = new System.Drawing.Size(1041, 274);
            this.DgvSearch.TabIndex = 14;
            this.DgvSearch.SelectionChanged += new System.EventHandler(this.DgvSearch_SelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(750, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 24);
            this.label3.TabIndex = 15;
            this.label3.Text = "اجمالى المبالغ :";
            // 
            // txtTotal
            // 
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Location = new System.Drawing.Point(858, 431);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(195, 29);
            this.txtTotal.TabIndex = 16;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnPayPart);
            this.groupBox2.Controls.Add(this.rbtnPayAll);
            this.groupBox2.Controls.Add(this.NudPrice);
            this.groupBox2.Location = new System.Drawing.Point(12, 412);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 59);
            this.groupBox2.TabIndex = 17;
            this.groupBox2.TabStop = false;
            // 
            // rbtnPayPart
            // 
            this.rbtnPayPart.AutoSize = true;
            this.rbtnPayPart.ForeColor = System.Drawing.Color.Blue;
            this.rbtnPayPart.Location = new System.Drawing.Point(108, 19);
            this.rbtnPayPart.Name = "rbtnPayPart";
            this.rbtnPayPart.Size = new System.Drawing.Size(119, 28);
            this.rbtnPayPart.TabIndex = 13;
            this.rbtnPayPart.Text = "تسديد جزء منه";
            this.rbtnPayPart.UseVisualStyleBackColor = true;
            this.rbtnPayPart.CheckedChanged += new System.EventHandler(this.rbtnPayPart_CheckedChanged);
            // 
            // rbtnPayAll
            // 
            this.rbtnPayAll.AutoSize = true;
            this.rbtnPayAll.Checked = true;
            this.rbtnPayAll.ForeColor = System.Drawing.Color.Blue;
            this.rbtnPayAll.Location = new System.Drawing.Point(231, 19);
            this.rbtnPayAll.Name = "rbtnPayAll";
            this.rbtnPayAll.Size = new System.Drawing.Size(134, 28);
            this.rbtnPayAll.TabIndex = 12;
            this.rbtnPayAll.TabStop = true;
            this.rbtnPayAll.Text = "تسديد المبلغ كامل";
            this.rbtnPayAll.UseVisualStyleBackColor = true;
            // 
            // NudPrice
            // 
            this.NudPrice.DecimalPlaces = 2;
            this.NudPrice.Location = new System.Drawing.Point(17, 19);
            this.NudPrice.Maximum = new decimal(new int[] {
            1215752192,
            23,
            0,
            0});
            this.NudPrice.Name = "NudPrice";
            this.NudPrice.Size = new System.Drawing.Size(85, 29);
            this.NudPrice.TabIndex = 18;
            this.NudPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NudPrice.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // btnPay
            // 
            this.btnPay.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPay.Appearance.Options.UseFont = true;
            this.btnPay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPay.ImageOptions.Image")));
            this.btnPay.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.RightTop;
            this.btnPay.Location = new System.Drawing.Point(398, 425);
            this.btnPay.Name = "btnPay";
            this.btnPay.Size = new System.Drawing.Size(150, 46);
            this.btnPay.TabIndex = 14;
            this.btnPay.Text = "تسديد المحدد";
            this.btnPay.Click += new System.EventHandler(this.btnPay_Click);
            // 
            // dtIMENextPayment
            // 
            this.dtIMENextPayment.Enabled = false;
            this.dtIMENextPayment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIMENextPayment.Location = new System.Drawing.Point(246, 477);
            this.dtIMENextPayment.Name = "dtIMENextPayment";
            this.dtIMENextPayment.Size = new System.Drawing.Size(139, 29);
            this.dtIMENextPayment.TabIndex = 23;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(122, 477);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "ميعاد التسديد القادم:";
            // 
            // Frm_SupplierMoney
            // 
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1065, 518);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtIMENextPayment);
            this.Controls.Add(this.btnPay);
            this.Controls.Add(this.DgvSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Frm_SupplierMoney";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "حسابات الموردين أجل";
            this.Load += new System.EventHandler(this.Frm_SupplierMoney_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvSearch)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxSupplier;
        private System.Windows.Forms.RadioButton rbtnOneSupplier;
        private System.Windows.Forms.RadioButton rbtnAllSup;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private System.Windows.Forms.DataGridView DgvSearch;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnPayPart;
        private System.Windows.Forms.RadioButton rbtnPayAll;
        private System.Windows.Forms.NumericUpDown NudPrice;
        private DevExpress.XtraEditors.SimpleButton btnPay;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.DateTimePicker dtIMENextPayment;
        private System.Windows.Forms.Label label1;
    }
}