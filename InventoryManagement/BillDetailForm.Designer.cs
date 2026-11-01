namespace InventoryManagement
{
    partial class BillDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BillDetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDocHeader = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.lblDocTitle = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateBill = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.dataGridBill = new System.Windows.Forms.DataGridView();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_real = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jumlah = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discPrs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discRph = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.txtJumlah = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDiscPrs = new System.Windows.Forms.TextBox();
            this.lblDisc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDpp = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPPn = new System.Windows.Forms.TextBox();
            this.lblPPn = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelDocHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1000, 50);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(962, 13);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(16, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(243, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detail Tagihan Vendor (Vendor Bill)";
            // 
            // panelDocHeader
            // 
            this.panelDocHeader.BackColor = System.Drawing.Color.White;
            this.panelDocHeader.Controls.Add(this.labelState);
            this.panelDocHeader.Controls.Add(this.label5);
            this.panelDocHeader.Controls.Add(this.dateBill);
            this.panelDocHeader.Controls.Add(this.label3);
            this.panelDocHeader.Controls.Add(this.txtVendorName);
            this.panelDocHeader.Controls.Add(this.label2);
            this.panelDocHeader.Controls.Add(this.labelName);
            this.panelDocHeader.Controls.Add(this.lblDocTitle);
            this.panelDocHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDocHeader.Location = new System.Drawing.Point(0, 50);
            this.panelDocHeader.Name = "panelDocHeader";
            this.panelDocHeader.Size = new System.Drawing.Size(1000, 68);
            this.panelDocHeader.TabIndex = 1;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.labelName.Location = new System.Drawing.Point(16, 32);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(127, 21);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "BILL/2026/0000";
            // 
            // lblDocTitle
            // 
            this.lblDocTitle.AutoSize = true;
            this.lblDocTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDocTitle.Location = new System.Drawing.Point(18, 12);
            this.lblDocTitle.Name = "lblDocTitle";
            this.lblDocTitle.Size = new System.Drawing.Size(95, 13);
            this.lblDocTitle.TabIndex = 0;
            this.lblDocTitle.Text = "NOMOR TAGIHAN";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(220, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "VENDOR";
            // 
            // txtVendorName
            // 
            this.txtVendorName.BackColor = System.Drawing.Color.White;
            this.txtVendorName.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVendorName.Location = new System.Drawing.Point(220, 31);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(220, 25);
            this.txtVendorName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(470, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "TANGGAL";
            // 
            // dateBill
            // 
            this.dateBill.CustomFormat = "dd/MM/yyyy";
            this.dateBill.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateBill.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateBill.Location = new System.Drawing.Point(470, 31);
            this.dateBill.Name = "dateBill";
            this.dateBill.Size = new System.Drawing.Size(150, 25);
            this.dateBill.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(936, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "STATUS";
            // 
            // labelState
            // 
            this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.labelState.Location = new System.Drawing.Point(830, 30);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(150, 25);
            this.labelState.TabIndex = 7;
            this.labelState.Text = "DRAFT";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridBill
            // 
            this.dataGridBill.AllowUserToAddRows = false;
            this.dataGridBill.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridBill.BackgroundColor = System.Drawing.Color.White;
            this.dataGridBill.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pname,
            this.qty,
            this.qty_real,
            this.price,
            this.jumlah,
            this.discPrs,
            this.discRph,
            this.total,
            this.Ref,
            this.pcode,
            this.state,
            this.line_type});
            this.dataGridBill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridBill.Location = new System.Drawing.Point(0, 118);
            this.dataGridBill.Name = "dataGridBill";
            this.dataGridBill.RowHeadersWidth = 30;
            this.dataGridBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridBill.Size = new System.Drawing.Size(1000, 442);
            this.dataGridBill.TabIndex = 2;
            // 
            // pname
            // 
            this.pname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pname.HeaderText = "Nama Barang";
            this.pname.MinimumWidth = 6;
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qty.HeaderText = "Qty Pesan";
            this.qty.MinimumWidth = 6;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // qty_real
            // 
            this.qty_real.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qty_real.HeaderText = "Qty Realisasi";
            this.qty_real.MinimumWidth = 6;
            this.qty_real.Name = "qty_real";
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.price.HeaderText = "Harga";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // jumlah
            // 
            this.jumlah.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.jumlah.HeaderText = "Jumlah";
            this.jumlah.MinimumWidth = 6;
            this.jumlah.Name = "jumlah";
            this.jumlah.ReadOnly = true;
            // 
            // discPrs
            // 
            this.discPrs.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.discPrs.HeaderText = "Disc %";
            this.discPrs.MinimumWidth = 6;
            this.discPrs.Name = "discPrs";
            this.discPrs.ReadOnly = true;
            // 
            // discRph
            // 
            this.discRph.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.discRph.HeaderText = "Disc (Rp)";
            this.discRph.MinimumWidth = 6;
            this.discRph.Name = "discRph";
            this.discRph.ReadOnly = true;
            // 
            // total
            // 
            this.total.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.total.HeaderText = "Total";
            this.total.MinimumWidth = 6;
            this.total.Name = "total";
            this.total.ReadOnly = true;
            // 
            // Ref
            // 
            this.Ref.HeaderText = "Ref";
            this.Ref.Name = "Ref";
            this.Ref.ReadOnly = true;
            this.Ref.Visible = false;
            // 
            // pcode
            // 
            this.pcode.HeaderText = "pcode";
            this.pcode.Name = "pcode";
            this.pcode.Visible = false;
            // 
            // state
            // 
            this.state.HeaderText = "state";
            this.state.Name = "state";
            this.state.Visible = false;
            // 
            // line_type
            // 
            this.line_type.HeaderText = "line_type";
            this.line_type.Name = "line_type";
            this.line_type.Visible = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.txtFinalPrice);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.lblPPn);
            this.panel3.Controls.Add(this.txtPPn);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.txtDpp);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.lblDisc);
            this.panel3.Controls.Add(this.txtDiscPrs);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.txtJumlah);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 560);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1000, 110);
            this.panel3.TabIndex = 3;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label15.Location = new System.Drawing.Point(18, 12);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(60, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "SUBTOTAL";
            // 
            // txtJumlah
            // 
            this.txtJumlah.BackColor = System.Drawing.Color.White;
            this.txtJumlah.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJumlah.Location = new System.Drawing.Point(18, 28);
            this.txtJumlah.Name = "txtJumlah";
            this.txtJumlah.ReadOnly = true;
            this.txtJumlah.Size = new System.Drawing.Size(110, 23);
            this.txtJumlah.TabIndex = 1;
            this.txtJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label17.Location = new System.Drawing.Point(140, 12);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(46, 13);
            this.label17.TabIndex = 2;
            this.label17.Text = "DISC %";
            // 
            // txtDiscPrs
            // 
            this.txtDiscPrs.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiscPrs.Location = new System.Drawing.Point(140, 28);
            this.txtDiscPrs.Name = "txtDiscPrs";
            this.txtDiscPrs.Size = new System.Drawing.Size(50, 23);
            this.txtDiscPrs.TabIndex = 3;
            this.txtDiscPrs.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDisc.Location = new System.Drawing.Point(195, 33);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(11, 13);
            this.lblDisc.TabIndex = 4;
            this.lblDisc.Text = "-";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(280, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "DPP";
            // 
            // txtDpp
            // 
            this.txtDpp.BackColor = System.Drawing.Color.White;
            this.txtDpp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDpp.Location = new System.Drawing.Point(280, 28);
            this.txtDpp.Name = "txtDpp";
            this.txtDpp.ReadOnly = true;
            this.txtDpp.Size = new System.Drawing.Size(110, 23);
            this.txtDpp.TabIndex = 6;
            this.txtDpp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.label16.Location = new System.Drawing.Point(405, 12);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(43, 13);
            this.label16.TabIndex = 7;
            this.label16.Text = "PPN %";
            // 
            // txtPPn
            // 
            this.txtPPn.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPPn.Location = new System.Drawing.Point(405, 28);
            this.txtPPn.Name = "txtPPn";
            this.txtPPn.Size = new System.Drawing.Size(50, 23);
            this.txtPPn.TabIndex = 8;
            this.txtPPn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblPPn
            // 
            this.lblPPn.AutoSize = true;
            this.lblPPn.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPPn.Location = new System.Drawing.Point(460, 33);
            this.lblPPn.Name = "lblPPn";
            this.lblPPn.Size = new System.Drawing.Size(11, 13);
            this.lblPPn.TabIndex = 9;
            this.lblPPn.Text = "-";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.label26.Location = new System.Drawing.Point(550, 11);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(84, 15);
            this.label26.TabIndex = 10;
            this.label26.Text = "TOTAL AKHIR";
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.BackColor = System.Drawing.Color.White;
            this.txtFinalPrice.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFinalPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.txtFinalPrice.Location = new System.Drawing.Point(550, 28);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.ReadOnly = true;
            this.txtFinalPrice.Size = new System.Drawing.Size(150, 27);
            this.txtFinalPrice.TabIndex = 11;
            this.txtFinalPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Location = new System.Drawing.Point(620, 65);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(90, 34);
            this.btnClear.TabIndex = 12;
            this.btnClear.Text = "Tutup";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(718, 65);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(110, 34);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Simpan Data";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(836, 65);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(150, 34);
            this.btnConfirm.TabIndex = 14;
            this.btnConfirm.Text = "Konfirmasi Tagihan";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(0, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(0, 13);
            this.label18.TabIndex = 15;
            this.label18.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(0, 13);
            this.label19.TabIndex = 16;
            this.label19.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(0, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 13);
            this.label20.TabIndex = 17;
            this.label20.Visible = false;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(0, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(0, 13);
            this.label22.TabIndex = 18;
            this.label22.Visible = false;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(0, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(0, 13);
            this.label23.TabIndex = 19;
            this.label23.Visible = false;
            // 
            // BillDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1000, 670);
            this.Controls.Add(this.dataGridBill);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panelDocHeader);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "BillDetailForm";
            this.Load += new System.EventHandler(this.BillDetailForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelDocHeader.ResumeLayout(false);
            this.panelDocHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridBill;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnConfirm;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendorName;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateBill;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtFinalPrice;
        public System.Windows.Forms.TextBox txtJumlah;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtPPn;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.TextBox txtDiscPrs;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblDisc;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label lblPPn;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_real;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn jumlah;
        private System.Windows.Forms.DataGridViewTextBoxColumn discPrs;
        private System.Windows.Forms.DataGridViewTextBoxColumn discRph;
        private System.Windows.Forms.DataGridViewTextBoxColumn total;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ref;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_type;
        public System.Windows.Forms.TextBox txtDpp;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label labelState;
        public System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panelDocHeader;
        private System.Windows.Forms.Label lblDocTitle;
    }
}