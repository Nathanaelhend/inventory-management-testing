namespace InventoryManagement
{
    partial class PurchaseModuleForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PurchaseModuleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBoxNoOrder = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.dataGridVendor = new System.Windows.Forms.DataGridView();
            this.vendorId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtVendorId = new System.Windows.Forms.TextBox();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.dataGridProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label26 = new System.Windows.Forms.Label();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.lblDisc = new System.Windows.Forms.Label();
            this.lblPPn = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.txtDiscPrs = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.txtPPn = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDpp = new System.Windows.Forms.TextBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.dataGridPurchaseModule = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericQty = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.dateTimePickerOrder = new System.Windows.Forms.DateTimePicker();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProduct)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPurchaseModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 68);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1617, 0);
            this.pictureBox3.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(39, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 23);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(195, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Purchase Detail";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(32, 79);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 25);
            this.label14.TabIndex = 3;
            this.label14.Text = "NO BUKTI";
            // 
            // txtBoxNoOrder
            // 
            this.txtBoxNoOrder.Location = new System.Drawing.Point(175, 79);
            this.txtBoxNoOrder.Margin = new System.Windows.Forms.Padding(4);
            this.txtBoxNoOrder.Name = "txtBoxNoOrder";
            this.txtBoxNoOrder.Size = new System.Drawing.Size(216, 22);
            this.txtBoxNoOrder.TabIndex = 0;
            this.txtBoxNoOrder.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBoxNoOrder_KeyDown);
            this.txtBoxNoOrder.Leave += new System.EventHandler(this.txtBoxNoOrder_Leave);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // dataGridVendor
            // 
            this.dataGridVendor.AllowUserToAddRows = false;
            this.dataGridVendor.BackgroundColor = System.Drawing.Color.White;
            this.dataGridVendor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridVendor.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.vendorId,
            this.Column1});
            this.dataGridVendor.EnableHeadersVisualStyles = false;
            this.dataGridVendor.Location = new System.Drawing.Point(553, 226);
            this.dataGridVendor.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridVendor.Name = "dataGridVendor";
            this.dataGridVendor.RowHeadersVisible = false;
            this.dataGridVendor.RowHeadersWidth = 51;
            this.dataGridVendor.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridVendor.Size = new System.Drawing.Size(401, 250);
            this.dataGridVendor.TabIndex = 3;
            this.dataGridVendor.Visible = false;
            this.dataGridVendor.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridVendor_CellClick);
            this.dataGridVendor.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridVendor_KeyDown);
            // 
            // vendorId
            // 
            this.vendorId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.vendorId.HeaderText = "Vendor Id";
            this.vendorId.MinimumWidth = 6;
            this.vendorId.Name = "vendorId";
            this.vendorId.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 125;
            // 
            // txtVendorId
            // 
            this.txtVendorId.Location = new System.Drawing.Point(175, 143);
            this.txtVendorId.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorId.Name = "txtVendorId";
            this.txtVendorId.Size = new System.Drawing.Size(216, 22);
            this.txtVendorId.TabIndex = 2;
            this.txtVendorId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtVendorId_KeyDown);
            // 
            // txtVendorName
            // 
            this.txtVendorName.Enabled = false;
            this.txtVendorName.Location = new System.Drawing.Point(400, 143);
            this.txtVendorName.Margin = new System.Windows.Forms.Padding(4);
            this.txtVendorName.Multiline = true;
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.Size = new System.Drawing.Size(192, 24);
            this.txtVendorName.TabIndex = 24;
            // 
            // dataGridProduct
            // 
            this.dataGridProduct.AllowUserToAddRows = false;
            this.dataGridProduct.BackgroundColor = System.Drawing.Color.White;
            this.dataGridProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column4,
            this.Price,
            this.Description,
            this.Column2});
            this.dataGridProduct.EnableHeadersVisualStyles = false;
            this.dataGridProduct.Location = new System.Drawing.Point(356, 226);
            this.dataGridProduct.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridProduct.Name = "dataGridProduct";
            this.dataGridProduct.RowHeadersVisible = false;
            this.dataGridProduct.RowHeadersWidth = 51;
            this.dataGridProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridProduct.Size = new System.Drawing.Size(613, 306);
            this.dataGridProduct.TabIndex = 17;
            this.dataGridProduct.Visible = false;
            this.dataGridProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProduct_CellClick);
            this.dataGridProduct.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridProduct_KeyDown);
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Id";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 104;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 125;
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Qty";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            this.Column4.Width = 60;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.MinimumWidth = 6;
            this.Price.Name = "Price";
            this.Price.Width = 125;
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.MinimumWidth = 6;
            this.Description.Name = "Description";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Category";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            this.Column2.Width = 97;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(9, 140);
            this.btnConfirm.Margin = new System.Windows.Forms.Padding(4);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(100, 28);
            this.btnConfirm.TabIndex = 96;
            this.btnConfirm.Text = "CONFIRM";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(5, 110);
            this.label26.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(68, 20);
            this.label26.TabIndex = 95;
            this.label26.Text = "TOTAL";
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.Enabled = false;
            this.txtFinalPrice.Location = new System.Drawing.Point(87, 108);
            this.txtFinalPrice.Margin = new System.Windows.Forms.Padding(4);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.ReadOnly = true;
            this.txtFinalPrice.Size = new System.Drawing.Size(205, 22);
            this.txtFinalPrice.TabIndex = 3;
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisc.Location = new System.Drawing.Point(289, 52);
            this.lblDisc.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(16, 20);
            this.lblDisc.TabIndex = 4;
            this.lblDisc.Text = "-";
            // 
            // lblPPn
            // 
            this.lblPPn.AutoSize = true;
            this.lblPPn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPn.Location = new System.Drawing.Point(289, 82);
            this.lblPPn.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPPn.Name = "lblPPn";
            this.lblPPn.Size = new System.Drawing.Size(16, 20);
            this.lblPPn.TabIndex = 3;
            this.lblPPn.Text = "-";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(184, 81);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(97, 20);
            this.label22.TabIndex = 6;
            this.label22.Text = "PPN Rph :";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(156, 81);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(25, 20);
            this.label23.TabIndex = 90;
            this.label23.Text = "%";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(268, 53);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 20);
            this.label20.TabIndex = 5;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(183, 52);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(99, 20);
            this.label19.TabIndex = 7;
            this.label19.Text = "Disc Rph :";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(155, 52);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(25, 20);
            this.label18.TabIndex = 8;
            this.label18.Text = "%";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(24, 49);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(53, 20);
            this.label17.TabIndex = 86;
            this.label17.Text = "DISC";
            // 
            // txtDiscPrs
            // 
            this.txtDiscPrs.Location = new System.Drawing.Point(88, 48);
            this.txtDiscPrs.Margin = new System.Windows.Forms.Padding(4);
            this.txtDiscPrs.Name = "txtDiscPrs";
            this.txtDiscPrs.Size = new System.Drawing.Size(57, 22);
            this.txtDiscPrs.TabIndex = 1;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(29, 79);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(46, 20);
            this.label16.TabIndex = 84;
            this.label16.Text = "PPN";
            // 
            // txtPPn
            // 
            this.txtPPn.Location = new System.Drawing.Point(87, 78);
            this.txtPPn.Margin = new System.Windows.Forms.Padding(4);
            this.txtPPn.Name = "txtPPn";
            this.txtPPn.Size = new System.Drawing.Size(59, 22);
            this.txtPPn.TabIndex = 2;
            this.txtPPn.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPPn_KeyDown);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(29, 16);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(47, 20);
            this.label15.TabIndex = 82;
            this.label15.Text = "DPP";
            // 
            // txtDpp
            // 
            this.txtDpp.Enabled = false;
            this.txtDpp.Location = new System.Drawing.Point(87, 15);
            this.txtDpp.Margin = new System.Windows.Forms.Padding(4);
            this.txtDpp.Name = "txtDpp";
            this.txtDpp.ReadOnly = true;
            this.txtDpp.Size = new System.Drawing.Size(117, 22);
            this.txtDpp.TabIndex = 0;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(449, 140);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(84, 28);
            this.btnDelete.TabIndex = 80;
            this.btnDelete.Text = "DELETE";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click_1);
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.Location = new System.Drawing.Point(368, 140);
            this.btnSaveDetail.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(73, 28);
            this.btnSaveDetail.TabIndex = 6;
            this.btnSaveDetail.Text = "SAVE";
            this.btnSaveDetail.Click += new System.EventHandler(this.btnSaveDetail_Click);
            // 
            // dataGridPurchaseModule
            // 
            this.dataGridPurchaseModule.AllowUserToAddRows = false;
            this.dataGridPurchaseModule.BackgroundColor = System.Drawing.Color.White;
            this.dataGridPurchaseModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridPurchaseModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pname,
            this.pprice,
            this.pqty,
            this.pTotal});
            this.dataGridPurchaseModule.EnableHeadersVisualStyles = false;
            this.dataGridPurchaseModule.Location = new System.Drawing.Point(39, 178);
            this.dataGridPurchaseModule.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.dataGridPurchaseModule.Name = "dataGridPurchaseModule";
            this.dataGridPurchaseModule.RowHeadersVisible = false;
            this.dataGridPurchaseModule.RowHeadersWidth = 51;
            this.dataGridPurchaseModule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridPurchaseModule.Size = new System.Drawing.Size(811, 268);
            this.dataGridPurchaseModule.TabIndex = 78;
            this.dataGridPurchaseModule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridPurchaseModule_CellClick);
            // 
            // pid
            // 
            this.pid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pid.HeaderText = "Product Id";
            this.pid.MinimumWidth = 6;
            this.pid.Name = "pid";
            this.pid.ReadOnly = true;
            this.pid.Width = 104;
            // 
            // pname
            // 
            this.pname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pname.HeaderText = "Name";
            this.pname.MinimumWidth = 6;
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // pprice
            // 
            this.pprice.HeaderText = "Price";
            this.pprice.MinimumWidth = 6;
            this.pprice.Name = "pprice";
            this.pprice.ReadOnly = true;
            this.pprice.Width = 125;
            // 
            // pqty
            // 
            this.pqty.HeaderText = "Qty";
            this.pqty.MinimumWidth = 6;
            this.pqty.Name = "pqty";
            this.pqty.ReadOnly = true;
            this.pqty.Width = 125;
            // 
            // pTotal
            // 
            this.pTotal.HeaderText = "Total";
            this.pTotal.MinimumWidth = 6;
            this.pTotal.Name = "pTotal";
            this.pTotal.ReadOnly = true;
            this.pTotal.Width = 125;
            // 
            // numericQty
            // 
            this.numericQty.Location = new System.Drawing.Point(80, 86);
            this.numericQty.Name = "numericQty";
            this.numericQty.Size = new System.Drawing.Size(165, 22);
            this.numericQty.TabIndex = 5;
            this.numericQty.ValueChanged += new System.EventHandler(this.numericQty_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(252, 140);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(131, 140);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 28);
            this.btnCreate.TabIndex = 0;
            this.btnCreate.Text = "SAVE";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // dateTimePickerOrder
            // 
            this.dateTimePickerOrder.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerOrder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOrder.Location = new System.Drawing.Point(175, 111);
            this.dateTimePickerOrder.Margin = new System.Windows.Forms.Padding(4);
            this.dateTimePickerOrder.Name = "dateTimePickerOrder";
            this.dateTimePickerOrder.Size = new System.Drawing.Size(216, 22);
            this.dateTimePickerOrder.TabIndex = 1;
            // 
            // txtProductName
            // 
            this.txtProductName.Location = new System.Drawing.Point(107, 42);
            this.txtProductName.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.ReadOnly = true;
            this.txtProductName.Size = new System.Drawing.Size(257, 22);
            this.txtProductName.TabIndex = 10;
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(107, 137);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(124, 20);
            this.txtTotal.TabIndex = 4;
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(80, 60);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(124, 20);
            this.txtPrice.TabIndex = 2;
            // 
            // txtProductId
            // 
            this.txtProductId.Location = new System.Drawing.Point(107, 10);
            this.txtProductId.Margin = new System.Windows.Forms.Padding(4);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(144, 22);
            this.txtProductId.TabIndex = 4;
            this.txtProductId.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtProductId_KeyDown);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 107);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 97;
            this.label2.Text = "TANGGAL";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(33, 140);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(116, 25);
            this.label6.TabIndex = 98;
            this.label6.Text = "SUPPLIER";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtProductName);
            this.panel2.Controls.Add(this.txtProductId);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.numericQty);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSaveDetail);
            this.panel2.Location = new System.Drawing.Point(39, 466);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(555, 188);
            this.panel2.TabIndex = 6;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(24, 138);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 20);
            this.label7.TabIndex = 103;
            this.label7.Text = "NETTO";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(52, 106);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 20);
            this.label5.TabIndex = 102;
            this.label5.Text = "QTY";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(3, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 101;
            this.label4.Text = "@HARGA";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(39, 9);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "KODE";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.txtFinalPrice);
            this.panel3.Controls.Add(this.txtDpp);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtPPn);
            this.panel3.Controls.Add(this.btnConfirm);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.btnCreate);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.txtDiscPrs);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lblDisc);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.lblPPn);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Location = new System.Drawing.Point(601, 466);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(368, 187);
            this.panel3.TabIndex = 100;
            // 
            // PurchaseModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1015, 667);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridPurchaseModule);
            this.Controls.Add(this.dateTimePickerOrder);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtBoxNoOrder);
            this.Controls.Add(this.dataGridVendor);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.txtVendorId);
            this.Controls.Add(this.dataGridProduct);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "PurchaseModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Purchase Detail Form";
            this.Load += new System.EventHandler(this.PurchaseModuleForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridVendor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProduct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridPurchaseModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBoxNoOrder;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.DataGridView dataGridVendor;
        private System.Windows.Forms.TextBox txtVendorName;
        public System.Windows.Forms.TextBox txtVendorId;
        public System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label26;
        public System.Windows.Forms.TextBox txtFinalPrice;
        private System.Windows.Forms.Label lblDisc;
        private System.Windows.Forms.Label lblPPn;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        public System.Windows.Forms.TextBox txtDiscPrs;
        private System.Windows.Forms.Label label16;
        public System.Windows.Forms.TextBox txtPPn;
        private System.Windows.Forms.Label label15;
        public System.Windows.Forms.TextBox txtDpp;
        public System.Windows.Forms.Button btnDelete;
        public System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.DataGridView dataGridPurchaseModule;
        public System.Windows.Forms.NumericUpDown numericQty;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.DateTimePicker dateTimePickerOrder;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.TextBox txtTotal;
        public System.Windows.Forms.TextBox txtPrice;
        public System.Windows.Forms.TextBox txtProductId;
        private System.Windows.Forms.DataGridView dataGridProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridViewTextBoxColumn vendorId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn pqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn pTotal;
    }
}