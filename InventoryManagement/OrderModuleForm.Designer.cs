namespace InventoryManagement
{
    partial class OrderModuleForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderModuleForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label14 = new System.Windows.Forms.Label();
            this.txtBoxNoOrder = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSaveDetail = new System.Windows.Forms.Button();
            this.dataGridOrderModule = new System.Windows.Forms.DataGridView();
            this.pid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pprice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numericQty = new System.Windows.Forms.NumericUpDown();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.dateTimePickerOrder = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtProductId = new System.Windows.Forms.TextBox();
            this.txtProduct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridProduct = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lblOid = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCustName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCustId = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCust = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridCustomer = new System.Windows.Forms.DataGridView();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.custId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderModule)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProduct)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.MediumSpringGreen;
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.txtBoxNoOrder);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1067, 55);
            this.panel1.TabIndex = 14;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(185, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(63, 15);
            this.label14.TabIndex = 23;
            this.label14.Text = "No Order :";
            // 
            // txtBoxNoOrder
            // 
            this.txtBoxNoOrder.Location = new System.Drawing.Point(249, 18);
            this.txtBoxNoOrder.Name = "txtBoxNoOrder";
            this.txtBoxNoOrder.Size = new System.Drawing.Size(163, 21);
            this.txtBoxNoOrder.TabIndex = 22;
            this.txtBoxNoOrder.Leave += new System.EventHandler(this.txtBoxNoOrder_Leave);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(1038, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 12;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Order Module";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDelete);
            this.panel2.Controls.Add(this.btnSaveDetail);
            this.panel2.Controls.Add(this.dataGridOrderModule);
            this.panel2.Controls.Add(this.numericQty);
            this.panel2.Controls.Add(this.btnClear);
            this.panel2.Controls.Add(this.btnCreate);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.dateTimePickerOrder);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.txtProductName);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.txtTotal);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.txtPrice);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.txtProductId);
            this.panel2.Controls.Add(this.txtProduct);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.dataGridProduct);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel2.Location = new System.Drawing.Point(332, 55);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(735, 533);
            this.panel2.TabIndex = 16;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(660, 386);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 23);
            this.btnDelete.TabIndex = 44;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnSaveDetail
            // 
            this.btnSaveDetail.Location = new System.Drawing.Point(599, 386);
            this.btnSaveDetail.Name = "btnSaveDetail";
            this.btnSaveDetail.Size = new System.Drawing.Size(55, 23);
            this.btnSaveDetail.TabIndex = 43;
            this.btnSaveDetail.Text = "Save";
            this.btnSaveDetail.UseVisualStyleBackColor = true;
            this.btnSaveDetail.Click += new System.EventHandler(this.btnSaveDetail_Click);
            // 
            // dataGridOrderModule
            // 
            this.dataGridOrderModule.AllowUserToAddRows = false;
            this.dataGridOrderModule.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridOrderModule.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridOrderModule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridOrderModule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pid,
            this.pname,
            this.pprice,
            this.pqty,
            this.pTotal});
            this.dataGridOrderModule.EnableHeadersVisualStyles = false;
            this.dataGridOrderModule.Location = new System.Drawing.Point(0, 276);
            this.dataGridOrderModule.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridOrderModule.Name = "dataGridOrderModule";
            this.dataGridOrderModule.RowHeadersVisible = false;
            this.dataGridOrderModule.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridOrderModule.Size = new System.Drawing.Size(545, 203);
            this.dataGridOrderModule.TabIndex = 42;
            this.dataGridOrderModule.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridOrderModule_CellClick);
            // 
            // pid
            // 
            this.pid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.pid.HeaderText = "Product Id";
            this.pid.Name = "pid";
            this.pid.Width = 87;
            // 
            // pname
            // 
            this.pname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pname.HeaderText = "Name";
            this.pname.Name = "pname";
            // 
            // pprice
            // 
            this.pprice.HeaderText = "Price";
            this.pprice.Name = "pprice";
            // 
            // pqty
            // 
            this.pqty.HeaderText = "Qty";
            this.pqty.Name = "pqty";
            // 
            // pTotal
            // 
            this.pTotal.HeaderText = "Total";
            this.pTotal.Name = "pTotal";
            // 
            // numericQty
            // 
            this.numericQty.Location = new System.Drawing.Point(599, 336);
            this.numericQty.Name = "numericQty";
            this.numericQty.Size = new System.Drawing.Size(124, 21);
            this.numericQty.TabIndex = 41;
            this.numericQty.ValueChanged += new System.EventHandler(this.numericQty_ValueChanged);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(602, 480);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(121, 23);
            this.btnClear.TabIndex = 40;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(472, 480);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(121, 23);
            this.btnCreate.TabIndex = 38;
            this.btnCreate.Text = "Create Order";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Visible = false;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 231);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(67, 15);
            this.label13.TabIndex = 37;
            this.label13.Text = "Order Date";
            // 
            // dateTimePickerOrder
            // 
            this.dateTimePickerOrder.CustomFormat = "dd/MM/yyyy";
            this.dateTimePickerOrder.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerOrder.Location = new System.Drawing.Point(2, 249);
            this.dateTimePickerOrder.Name = "dateTimePickerOrder";
            this.dateTimePickerOrder.Size = new System.Drawing.Size(200, 21);
            this.dateTimePickerOrder.TabIndex = 36;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(526, 234);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(86, 15);
            this.label12.TabIndex = 35;
            this.label12.Text = "Product Name";
            // 
            // txtProductName
            // 
            this.txtProductName.Enabled = false;
            this.txtProductName.Location = new System.Drawing.Point(529, 252);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(194, 21);
            this.txtProductName.TabIndex = 34;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(553, 365);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 15);
            this.label11.TabIndex = 33;
            this.label11.Text = "Total :";
            // 
            // txtTotal
            // 
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(599, 359);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.Size = new System.Drawing.Size(124, 21);
            this.txtTotal.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(563, 338);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(30, 15);
            this.label10.TabIndex = 31;
            this.label10.Text = "Qty :";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(552, 310);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 15);
            this.label9.TabIndex = 29;
            this.label9.Text = "Price :";
            // 
            // txtPrice
            // 
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(599, 304);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(124, 21);
            this.txtPrice.TabIndex = 28;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(408, 234);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 15);
            this.label8.TabIndex = 27;
            this.label8.Text = "Product Id";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(345, 218);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 15);
            this.label5.TabIndex = 22;
            this.label5.Text = "Search Box :";
            // 
            // txtProductId
            // 
            this.txtProductId.Enabled = false;
            this.txtProductId.Location = new System.Drawing.Point(411, 252);
            this.txtProductId.Name = "txtProductId";
            this.txtProductId.Size = new System.Drawing.Size(109, 21);
            this.txtProductId.TabIndex = 26;
            // 
            // txtProduct
            // 
            this.txtProduct.Location = new System.Drawing.Point(434, 212);
            this.txtProduct.Name = "txtProduct";
            this.txtProduct.Size = new System.Drawing.Size(289, 21);
            this.txtProduct.TabIndex = 21;
            this.txtProduct.TextChanged += new System.EventHandler(this.txtProduct_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label3.Location = new System.Drawing.Point(2, 206);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 18);
            this.label3.TabIndex = 18;
            this.label3.Text = "PRODUCT";
            // 
            // dataGridProduct
            // 
            this.dataGridProduct.AllowUserToAddRows = false;
            this.dataGridProduct.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridProduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridProduct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProduct.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column4,
            this.Price,
            this.Description,
            this.Column2});
            this.dataGridProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridProduct.EnableHeadersVisualStyles = false;
            this.dataGridProduct.Location = new System.Drawing.Point(0, 0);
            this.dataGridProduct.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridProduct.Name = "dataGridProduct";
            this.dataGridProduct.RowHeadersVisible = false;
            this.dataGridProduct.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridProduct.Size = new System.Drawing.Size(735, 203);
            this.dataGridProduct.TabIndex = 17;
            this.dataGridProduct.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridProduct_CellClick);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 48;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxColumn2.HeaderText = "Product Id";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 87;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Name";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column4
            // 
            this.Column4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column4.HeaderText = "Qty";
            this.Column4.Name = "Column4";
            this.Column4.Width = 49;
            // 
            // Price
            // 
            this.Price.HeaderText = "Price";
            this.Price.Name = "Price";
            // 
            // Description
            // 
            this.Description.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Description.HeaderText = "Description";
            this.Description.Name = "Description";
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column2.HeaderText = "Category";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblOid);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.txtCustName);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.txtCustId);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.txtCust);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.dataGridCustomer);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 55);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(301, 533);
            this.panel3.TabIndex = 17;
            // 
            // lblOid
            // 
            this.lblOid.AutoSize = true;
            this.lblOid.Location = new System.Drawing.Point(19, 505);
            this.lblOid.Name = "lblOid";
            this.lblOid.Size = new System.Drawing.Size(48, 15);
            this.lblOid.TabIndex = 26;
            this.lblOid.Text = "label14";
            this.lblOid.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(43, 329);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 15);
            this.label7.TabIndex = 25;
            this.label7.Text = "Customer Name";
            // 
            // txtCustName
            // 
            this.txtCustName.Enabled = false;
            this.txtCustName.Location = new System.Drawing.Point(46, 347);
            this.txtCustName.Name = "txtCustName";
            this.txtCustName.Size = new System.Drawing.Size(194, 21);
            this.txtCustName.TabIndex = 24;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(43, 283);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 15);
            this.label6.TabIndex = 23;
            this.label6.Text = "Customer Id";
            // 
            // txtCustId
            // 
            this.txtCustId.Enabled = false;
            this.txtCustId.Location = new System.Drawing.Point(46, 301);
            this.txtCustId.Name = "txtCustId";
            this.txtCustId.Size = new System.Drawing.Size(194, 21);
            this.txtCustId.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 15);
            this.label4.TabIndex = 21;
            this.label4.Text = "Search Box :";
            // 
            // txtCust
            // 
            this.txtCust.Location = new System.Drawing.Point(125, 209);
            this.txtCust.Name = "txtCust";
            this.txtCust.Size = new System.Drawing.Size(163, 21);
            this.txtCust.TabIndex = 20;
            this.txtCust.TextChanged += new System.EventHandler(this.txtCust_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(3, 249);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 18);
            this.label2.TabIndex = 19;
            this.label2.Text = "CUSTOMER";
            // 
            // dataGridCustomer
            // 
            this.dataGridCustomer.AllowUserToAddRows = false;
            this.dataGridCustomer.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridCustomer.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column7,
            this.custId,
            this.Column1});
            this.dataGridCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.dataGridCustomer.EnableHeadersVisualStyles = false;
            this.dataGridCustomer.Location = new System.Drawing.Point(0, 0);
            this.dataGridCustomer.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.dataGridCustomer.Name = "dataGridCustomer";
            this.dataGridCustomer.RowHeadersVisible = false;
            this.dataGridCustomer.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridCustomer.Size = new System.Drawing.Size(301, 203);
            this.dataGridCustomer.TabIndex = 17;
            this.dataGridCustomer.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridCustomer_CellClick);
            // 
            // Column7
            // 
            this.Column7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Column7.HeaderText = "No";
            this.Column7.Name = "Column7";
            this.Column7.Width = 48;
            // 
            // custId
            // 
            this.custId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.custId.HeaderText = "Customer Id";
            this.custId.Name = "custId";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Name";
            this.Column1.Name = "Column1";
            // 
            // OrderModuleForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1067, 588);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "OrderModuleForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OrderModuleForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridOrderModule)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericQty)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProduct)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridCustomer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dataGridProduct;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtProduct;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCust;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridCustomer;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn custId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCustName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtProductName;
        private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.Button btnCreate;
        public System.Windows.Forms.Label lblOid;
        public System.Windows.Forms.DateTimePicker dateTimePickerOrder;
        public System.Windows.Forms.TextBox txtProductId;
        public System.Windows.Forms.TextBox txtCustId;
        public System.Windows.Forms.NumericUpDown numericQty;
        public System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.DataGridView dataGridOrderModule;
        public System.Windows.Forms.Button btnSaveDetail;
        private System.Windows.Forms.DataGridViewTextBoxColumn pid;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn pprice;
        private System.Windows.Forms.DataGridViewTextBoxColumn pqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn pTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtBoxNoOrder;
        public System.Windows.Forms.Button btnDelete;
    }
}