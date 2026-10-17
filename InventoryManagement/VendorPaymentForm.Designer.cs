namespace InventoryManagement
{
    partial class VendorPaymentForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNoBukti = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboType = new System.Windows.Forms.ComboBox();
            this.datePickerPayment = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.txtJumBayar = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtTotalBayar = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtTotalNota = new System.Windows.Forms.TextBox();
            this.dateTimeNota = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNoNota = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.txtTotalPembayaran = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.dataGridVendor = new System.Windows.Forms.DataGridView();
            this.sequence = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridBill = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amountNota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.btnDeleteDetail = new System.Windows.Forms.Button();
            this.btnClearDetail = new System.Windows.Forms.Button();
            this.dataGridPayment = new System.Windows.Forms.DataGridView();
            this.noBukti = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nama = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type_payment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridListBill = new System.Windows.Forms.DataGridView();
            this.noBukt = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_pay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.amount_due = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total_ak_bayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jml_bayar = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPayment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListBill)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(9, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "NO BUKTI";
            // 
            // txtNoBukti
            // 
            this.txtNoBukti.Location = new System.Drawing.Point(87, 11);
            this.txtNoBukti.Name = "txtNoBukti";
            this.txtNoBukti.ReadOnly = true;
            this.txtNoBukti.Size = new System.Drawing.Size(97, 20);
            this.txtNoBukti.TabIndex = 1;
            this.txtNoBukti.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoBukti_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(191, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "TYPE PAYMENT";
            // 
            // comboType
            // 
            this.comboType.FormattingEnabled = true;
            this.comboType.Items.AddRange(new object[] {
            "TUNAI",
            "TRANSFER"});
            this.comboType.Location = new System.Drawing.Point(296, 10);
            this.comboType.Name = "comboType";
            this.comboType.Size = new System.Drawing.Size(64, 21);
            this.comboType.TabIndex = 4;
            this.comboType.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboType_KeyDown);
            // 
            // datePickerPayment
            // 
            this.datePickerPayment.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.datePickerPayment.Location = new System.Drawing.Point(87, 37);
            this.datePickerPayment.Name = "datePickerPayment";
            this.datePickerPayment.Size = new System.Drawing.Size(97, 20);
            this.datePickerPayment.TabIndex = 5;
            this.datePickerPayment.Value = new System.DateTime(2026, 9, 19, 0, 0, 0, 0);
            this.datePickerPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.datePickerPayment_KeyDown);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(8, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "TANGGAL";
            // 
            // txtVendorId
            // 
            this.txtVendorId.Location = new System.Drawing.Point(87, 63);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(97, 20);
            this.txtVendorId.TabIndex = 7;
            this.txtVendorId.TextChanged += new System.EventHandler(this.txtVendorId_TextChanged);
            this.txtVendorId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendorId_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(5, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "SUPPLIER";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(197, 63);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(97, 20);
            this.txtVendorName.TabIndex = 9;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.txtJumBayar);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtTotalBayar);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.txtTotalNota);
            this.panel1.Controls.Add(this.dateTimeNota);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtNoNota);
            this.panel1.Location = new System.Drawing.Point(5, 97);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(227, 144);
            this.panel1.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(24, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(85, 13);
            this.label9.TabIndex = 20;
            this.label9.Text = "JML PEMBYR";
            // 
            // txtJumBayar
            // 
            this.txtJumBayar.Location = new System.Drawing.Point(110, 112);
            this.txtJumBayar.Name = "txtJumBayar";
            this.txtJumBayar.Size = new System.Drawing.Size(97, 20);
            this.txtJumBayar.TabIndex = 19;
            this.txtJumBayar.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJumBayar_KeyDown);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(31, 91);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 18;
            this.label8.Text = "AK PEMBYR";
            // 
            // txtTotalBayar
            // 
            this.txtTotalBayar.Location = new System.Drawing.Point(110, 86);
            this.txtTotalBayar.Name = "txtTotalBayar";
            this.txtTotalBayar.ReadOnly = true;
            this.txtTotalBayar.Size = new System.Drawing.Size(97, 20);
            this.txtTotalBayar.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(41, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(68, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "JML NOTA";
            // 
            // txtTotalNota
            // 
            this.txtTotalNota.Location = new System.Drawing.Point(110, 60);
            this.txtTotalNota.Name = "txtTotalNota";
            this.txtTotalNota.ReadOnly = true;
            this.txtTotalNota.Size = new System.Drawing.Size(97, 20);
            this.txtTotalNota.TabIndex = 15;
            // 
            // dateTimeNota
            // 
            this.dateTimeNota.Enabled = false;
            this.dateTimeNota.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeNota.Location = new System.Drawing.Point(111, 34);
            this.dateTimeNota.Name = "dateTimeNota";
            this.dateTimeNota.Size = new System.Drawing.Size(97, 20);
            this.dateTimeNota.TabIndex = 12;
            this.dateTimeNota.Value = new System.DateTime(2026, 9, 19, 0, 0, 0, 0);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(44, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "TANGGAL";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(46, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "NO NOTA";
            // 
            // txtNoNota
            // 
            this.txtNoNota.Location = new System.Drawing.Point(111, 8);
            this.txtNoNota.Name = "txtNoNota";
            this.txtNoNota.Size = new System.Drawing.Size(97, 20);
            this.txtNoNota.TabIndex = 12;
            this.txtNoNota.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtNoNota_KeyDown);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.txtTotalPembayaran);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.textBox5);
            this.panel2.Location = new System.Drawing.Point(5, 297);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(227, 80);
            this.panel2.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(24, 36);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(85, 13);
            this.label10.TabIndex = 20;
            this.label10.Text = "JML PEMBYR";
            // 
            // txtTotalPembayaran
            // 
            this.txtTotalPembayaran.Location = new System.Drawing.Point(109, 34);
            this.txtTotalPembayaran.Name = "txtTotalPembayaran";
            this.txtTotalPembayaran.ReadOnly = true;
            this.txtTotalPembayaran.Size = new System.Drawing.Size(97, 20);
            this.txtTotalPembayaran.TabIndex = 19;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(7, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(102, 13);
            this.label14.TabIndex = 13;
            this.label14.Text = "TOTAL PEMBYR";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(109, 8);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(97, 20);
            this.textBox5.TabIndex = 12;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSave.Location = new System.Drawing.Point(74, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "SAVE";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoad.Location = new System.Drawing.Point(381, 11);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(55, 23);
            this.btnLoad.TabIndex = 23;
            this.btnLoad.Text = "LOAD";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // btnNew
            // 
            this.btnNew.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNew.Location = new System.Drawing.Point(442, 12);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(55, 23);
            this.btnNew.TabIndex = 24;
            this.btnNew.Text = "NEW";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // dataGridVendor
            // 
            this.dataGridVendor.AllowUserToAddRows = false;
            this.dataGridVendor.BackgroundColor = System.Drawing.Color.White;
            this.dataGridVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVendor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sequence,
            this.vendorId,
            this.name});
            this.dataGridVendor.EnableHeadersVisualStyles = false;
            this.dataGridVendor.Location = new System.Drawing.Point(187, 97);
            this.dataGridVendor.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridVendor.Name = "dataGridVendor";
            this.dataGridVendor.RowHeadersVisible = false;
            this.dataGridVendor.RowHeadersWidth = 51;
            this.dataGridVendor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridVendor.Size = new System.Drawing.Size(301, 203);
            this.dataGridVendor.TabIndex = 25;
            this.dataGridVendor.Visible = false;
            this.dataGridVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridVendor_KeyDown);
            this.dataGridVendor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVendor_CellClick);
            // 
            // sequence
            // 
            this.sequence.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.sequence.HeaderText = "Column1";
            this.sequence.Name = "sequence";
            this.sequence.ReadOnly = true;
            this.sequence.Visible = false;
            // 
            // vendorId
            // 
            this.vendorId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vendorId.HeaderText = "Vendor Id";
            this.vendorId.MinimumWidth = 6;
            this.vendorId.Name = "vendorId";
            this.vendorId.ReadOnly = true;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Name";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // dataGridBill
            // 
            this.dataGridBill.AllowUserToAddRows = false;
            this.dataGridBill.BackgroundColor = System.Drawing.Color.White;
            this.dataGridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.dateNota,
            this.noNota,
            this.amountNota});
            this.dataGridBill.EnableHeadersVisualStyles = false;
            this.dataGridBill.Location = new System.Drawing.Point(336, 124);
            this.dataGridBill.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridBill.Name = "dataGridBill";
            this.dataGridBill.RowHeadersVisible = false;
            this.dataGridBill.RowHeadersWidth = 51;
            this.dataGridBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridBill.Size = new System.Drawing.Size(301, 203);
            this.dataGridBill.TabIndex = 26;
            this.dataGridBill.Visible = false;
            this.dataGridBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridBill_KeyDown);
            this.dataGridBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridBill_CellClick);
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "Column1";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // dateNota
            // 
            this.dateNota.HeaderText = "Column1";
            this.dateNota.Name = "dateNota";
            this.dateNota.Visible = false;
            // 
            // noNota
            // 
            this.noNota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noNota.HeaderText = "No Nota";
            this.noNota.MinimumWidth = 6;
            this.noNota.Name = "noNota";
            this.noNota.ReadOnly = true;
            // 
            // amountNota
            // 
            this.amountNota.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amountNota.HeaderText = "Amount";
            this.amountNota.MinimumWidth = 6;
            this.amountNota.Name = "amountNota";
            this.amountNota.ReadOnly = true;
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSaveDetail.Location = new System.Drawing.Point(5, 247);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(70, 25);
            this.btnSaveDetail.TabIndex = 27;
            this.btnSaveDetail.Text = "SAVE";
            this.btnSaveDetail.UseVisualStyleBackColor = true;
            this.btnSaveDetail.Click += new System.EventHandler(this.btnSaveDetail_Click);
            // 
            // btnDeleteDetail
            // 
            this.btnDeleteDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnDeleteDetail.Location = new System.Drawing.Point(82, 247);
            this.btnDeleteDetail.Name = "btnDeleteDetail";
            this.btnDeleteDetail.Size = new System.Drawing.Size(70, 25);
            this.btnDeleteDetail.TabIndex = 30;
            this.btnDeleteDetail.Text = "DELETE";
            this.btnDeleteDetail.UseVisualStyleBackColor = true;
            this.btnDeleteDetail.Click += new System.EventHandler(this.btnDeleteDetail_Click);
            // 
            // btnClearDetail
            // 
            this.btnClearDetail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnClearDetail.Location = new System.Drawing.Point(159, 247);
            this.btnClearDetail.Name = "btnClearDetail";
            this.btnClearDetail.Size = new System.Drawing.Size(73, 25);
            this.btnClearDetail.TabIndex = 31;
            this.btnClearDetail.Text = "CLEAR";
            this.btnClearDetail.UseVisualStyleBackColor = true;
            this.btnClearDetail.Click += new System.EventHandler(this.btnClearDetail_Click);
            // 
            // dataGridPayment
            // 
            this.dataGridPayment.AllowUserToAddRows = false;
            this.dataGridPayment.BackgroundColor = System.Drawing.Color.White;
            this.dataGridPayment.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPayment.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noBukti,
            this.date,
            this.kode,
            this.nama,
            this.jumlah,
            this.type_payment});
            this.dataGridPayment.EnableHeadersVisualStyles = false;
            this.dataGridPayment.Location = new System.Drawing.Point(327, 213);
            this.dataGridPayment.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridPayment.Name = "dataGridPayment";
            this.dataGridPayment.RowHeadersVisible = false;
            this.dataGridPayment.RowHeadersWidth = 51;
            this.dataGridPayment.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridPayment.Size = new System.Drawing.Size(301, 203);
            this.dataGridPayment.TabIndex = 28;
            this.dataGridPayment.Visible = false;
            this.dataGridPayment.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridPayment_KeyDown);
            this.dataGridPayment.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPayment_CellClick);
            // 
            // noBukti
            // 
            this.noBukti.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noBukti.HeaderText = "No. BUKTI";
            this.noBukti.Name = "noBukti";
            this.noBukti.ReadOnly = true;
            // 
            // date
            // 
            this.date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.date.HeaderText = "TANGGAL";
            this.date.Name = "date";
            this.date.ReadOnly = true;
            // 
            // kode
            // 
            this.kode.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.kode.HeaderText = "KODE";
            this.kode.Name = "kode";
            this.kode.ReadOnly = true;
            // 
            // nama
            // 
            this.nama.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nama.HeaderText = "NAMA";
            this.nama.Name = "nama";
            this.nama.ReadOnly = true;
            // 
            // jumlah
            // 
            this.jumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jumlah.HeaderText = "JUMLAH";
            this.jumlah.Name = "jumlah";
            this.jumlah.ReadOnly = true;
            // 
            // type_payment
            // 
            this.type_payment.HeaderText = "Type Payment";
            this.type_payment.Name = "type_payment";
            this.type_payment.ReadOnly = true;
            this.type_payment.Visible = false;
            // 
            // dataGridListBill
            // 
            this.dataGridListBill.AllowUserToAddRows = false;
            this.dataGridListBill.BackgroundColor = System.Drawing.Color.White;
            this.dataGridListBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridListBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noBukt,
            this.date_pay,
            this.amount_due,
            this.total_ak_bayar,
            this.jml_bayar});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridListBill.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridListBill.EnableHeadersVisualStyles = false;
            this.dataGridListBill.Location = new System.Drawing.Point(249, 97);
            this.dataGridListBill.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridListBill.Name = "dataGridListBill";
            this.dataGridListBill.RowHeadersVisible = false;
            this.dataGridListBill.RowHeadersWidth = 51;
            this.dataGridListBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridListBill.Size = new System.Drawing.Size(414, 296);
            this.dataGridListBill.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridListBill_CellClick);
            this.dataGridListBill.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridListBill_KeyDown);
            // 
            // noBukt
            // 
            this.noBukt.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.noBukt.HeaderText = "NO. Bukti";
            this.noBukt.Name = "noBukt";
            this.noBukt.ReadOnly = true;
            // 
            // date_pay
            // 
            this.date_pay.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.date_pay.HeaderText = "TANGGAL";
            this.date_pay.Name = "date_pay";
            this.date_pay.ReadOnly = true;
            // 
            // amount_due
            // 
            this.amount_due.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.amount_due.HeaderText = "TAGIHAN";
            this.amount_due.Name = "amount_due";
            this.amount_due.ReadOnly = true;
            // 
            // total_ak_bayar
            // 
            this.total_ak_bayar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.total_ak_bayar.HeaderText = "AK. PEMBY";
            this.total_ak_bayar.Name = "total_ak_bayar";
            this.total_ak_bayar.ReadOnly = true;
            // 
            // jml_bayar
            // 
            this.jml_bayar.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.jml_bayar.HeaderText = "JML. PEMBY";
            this.jml_bayar.Name = "jml_bayar";
            this.jml_bayar.ReadOnly = true;
            // 
            // VendorPaymentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(675, 464);
            this.Controls.Add(this.dataGridPayment);
            this.Controls.Add(this.btnSaveDetail);
            this.Controls.Add(this.btnDeleteDetail);
            this.Controls.Add(this.btnClearDetail);
            this.Controls.Add(this.dataGridBill);
            this.Controls.Add(this.dataGridVendor);
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.btnLoad);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtVendorId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.datePickerPayment);
            this.Controls.Add(this.comboType);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNoBukti);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridListBill);
            this.ForeColor = System.Drawing.Color.Transparent;
            this.Name = "VendorPaymentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Vendor Payment";
            this.Load += new System.EventHandler(this.VendorPaymentForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPayment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridListBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNoBukti;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboType;
        private System.Windows.Forms.DateTimePicker datePickerPayment;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVendorId;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVendorName;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtTotalNota;
        private System.Windows.Forms.DateTimePicker dateTimeNota;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNoNota;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtJumBayar;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtTotalBayar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtTotalPembayaran;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dataGridVendor;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridView dataGridBill;
        private System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.Button btnDeleteDetail;
        private System.Windows.Forms.Button btnClearDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn sequence;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn noNota;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountNota;
        private System.Windows.Forms.DataGridView dataGridPayment;
        private System.Windows.Forms.DataGridViewTextBoxColumn noBukti;
        private System.Windows.Forms.DataGridViewTextBoxColumn date;
        private System.Windows.Forms.DataGridViewTextBoxColumn kode;
        private System.Windows.Forms.DataGridViewTextBoxColumn nama;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn type_payment;
        private System.Windows.Forms.DataGridView dataGridListBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn noBukt;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_pay;
        private System.Windows.Forms.DataGridViewTextBoxColumn amount_due;
        private System.Windows.Forms.DataGridViewTextBoxColumn total_ak_bayar;
        private System.Windows.Forms.DataGridViewTextBoxColumn jml_bayar;
    }
}