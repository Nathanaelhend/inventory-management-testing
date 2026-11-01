namespace InventoryManagement
{
    partial class MainForm
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
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.panelNavScroll = new System.Windows.Forms.Panel();
            this.btnNavCOA = new System.Windows.Forms.Button();
            this.btnNavPayment = new System.Windows.Forms.Button();
            this.btnNavBill = new System.Windows.Forms.Button();
            this.lblSectionFinance = new System.Windows.Forms.Label();
            this.btnNavDelivery = new System.Windows.Forms.Button();
            this.btnNavStockMove = new System.Windows.Forms.Button();
            this.btnNavOrder = new System.Windows.Forms.Button();
            this.btnNavPurchase = new System.Windows.Forms.Button();
            this.lblSectionTransaction = new System.Windows.Forms.Label();
            this.btnNavUser = new System.Windows.Forms.Button();
            this.btnNavCategories = new System.Windows.Forms.Button();
            this.btnNavCustomer = new System.Windows.Forms.Button();
            this.btnNavProduct = new System.Windows.Forms.Button();
            this.lblSectionMaster = new System.Windows.Forms.Label();
            this.panelSidebarFooter = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblVersion = new System.Windows.Forms.Label();
            this.panelBrand = new System.Windows.Forms.Panel();
            this.lblBrandName = new System.Windows.Forms.Label();
            this.panelTopHeader = new System.Windows.Forms.Panel();
            this.lblUserRole = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblModuleSubtitle = new System.Windows.Forms.Label();
            this.lblModuleTitle = new System.Windows.Forms.Label();
            this.panelBottomStatus = new System.Windows.Forms.Panel();
            this.lblStatusText = new System.Windows.Forms.Label();
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelSidebar.SuspendLayout();
            this.panelNavScroll.SuspendLayout();
            this.panelSidebarFooter.SuspendLayout();
            this.panelBrand.SuspendLayout();
            this.panelTopHeader.SuspendLayout();
            this.panelBottomStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelSidebar
            // 
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.panelSidebar.Controls.Add(this.panelNavScroll);
            this.panelSidebar.Controls.Add(this.panelSidebarFooter);
            this.panelSidebar.Controls.Add(this.panelBrand);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(230, 680);
            this.panelSidebar.TabIndex = 0;
            // 
            // panelNavScroll
            // 
            this.panelNavScroll.AutoScroll = true;
            this.panelNavScroll.Controls.Add(this.btnNavCOA);
            this.panelNavScroll.Controls.Add(this.btnNavPayment);
            this.panelNavScroll.Controls.Add(this.btnNavBill);
            this.panelNavScroll.Controls.Add(this.lblSectionFinance);
            this.panelNavScroll.Controls.Add(this.btnNavDelivery);
            this.panelNavScroll.Controls.Add(this.btnNavStockMove);
            this.panelNavScroll.Controls.Add(this.btnNavOrder);
            this.panelNavScroll.Controls.Add(this.btnNavPurchase);
            this.panelNavScroll.Controls.Add(this.lblSectionTransaction);
            this.panelNavScroll.Controls.Add(this.btnNavUser);
            this.panelNavScroll.Controls.Add(this.btnNavCategories);
            this.panelNavScroll.Controls.Add(this.btnNavCustomer);
            this.panelNavScroll.Controls.Add(this.btnNavProduct);
            this.panelNavScroll.Controls.Add(this.lblSectionMaster);
            this.panelNavScroll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNavScroll.Location = new System.Drawing.Point(0, 70);
            this.panelNavScroll.Name = "panelNavScroll";
            this.panelNavScroll.Padding = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.panelNavScroll.Size = new System.Drawing.Size(230, 558);
            this.panelNavScroll.TabIndex = 1;
            // 
            // btnNavCOA
            // 
            this.btnNavCOA.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCOA.FlatAppearance.BorderSize = 0;
            this.btnNavCOA.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCOA.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCOA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavCOA.Location = new System.Drawing.Point(0, 484);
            this.btnNavCOA.Name = "btnNavCOA";
            this.btnNavCOA.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavCOA.Size = new System.Drawing.Size(230, 38);
            this.btnNavCOA.TabIndex = 14;
            this.btnNavCOA.Text = "Master COA";
            this.btnNavCOA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCOA.UseVisualStyleBackColor = true;
            this.btnNavCOA.Click += new System.EventHandler(this.btnNavCOA_Click);
            // 
            // btnNavPayment
            // 
            this.btnNavPayment.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavPayment.FlatAppearance.BorderSize = 0;
            this.btnNavPayment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPayment.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPayment.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavPayment.Location = new System.Drawing.Point(0, 446);
            this.btnNavPayment.Name = "btnNavPayment";
            this.btnNavPayment.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavPayment.Size = new System.Drawing.Size(230, 38);
            this.btnNavPayment.TabIndex = 13;
            this.btnNavPayment.Text = "Vendor Payment";
            this.btnNavPayment.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPayment.UseVisualStyleBackColor = true;
            this.btnNavPayment.Click += new System.EventHandler(this.btnNavPayment_Click);
            // 
            // btnNavBill
            // 
            this.btnNavBill.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavBill.FlatAppearance.BorderSize = 0;
            this.btnNavBill.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavBill.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavBill.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavBill.Location = new System.Drawing.Point(0, 408);
            this.btnNavBill.Name = "btnNavBill";
            this.btnNavBill.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavBill.Size = new System.Drawing.Size(230, 38);
            this.btnNavBill.TabIndex = 12;
            this.btnNavBill.Text = "Vendor Bill";
            this.btnNavBill.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavBill.UseVisualStyleBackColor = true;
            this.btnNavBill.Click += new System.EventHandler(this.btnNavBill_Click);
            // 
            // lblSectionFinance
            // 
            this.lblSectionFinance.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSectionFinance.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionFinance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSectionFinance.Location = new System.Drawing.Point(0, 376);
            this.lblSectionFinance.Name = "lblSectionFinance";
            this.lblSectionFinance.Padding = new System.Windows.Forms.Padding(18, 12, 0, 4);
            this.lblSectionFinance.Size = new System.Drawing.Size(230, 32);
            this.lblSectionFinance.TabIndex = 11;
            this.lblSectionFinance.Text = "KEUANGAN";
            // 
            // btnNavDelivery
            // 
            this.btnNavDelivery.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavDelivery.FlatAppearance.BorderSize = 0;
            this.btnNavDelivery.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavDelivery.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavDelivery.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavDelivery.Location = new System.Drawing.Point(0, 338);
            this.btnNavDelivery.Name = "btnNavDelivery";
            this.btnNavDelivery.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavDelivery.Size = new System.Drawing.Size(230, 38);
            this.btnNavDelivery.TabIndex = 10;
            this.btnNavDelivery.Text = "Pengiriman (Delivery)";
            this.btnNavDelivery.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavDelivery.UseVisualStyleBackColor = true;
            this.btnNavDelivery.Click += new System.EventHandler(this.btnNavDelivery_Click);
            // 
            // btnNavStockMove
            // 
            this.btnNavStockMove.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavStockMove.FlatAppearance.BorderSize = 0;
            this.btnNavStockMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavStockMove.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavStockMove.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavStockMove.Location = new System.Drawing.Point(0, 300);
            this.btnNavStockMove.Name = "btnNavStockMove";
            this.btnNavStockMove.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavStockMove.Size = new System.Drawing.Size(230, 38);
            this.btnNavStockMove.TabIndex = 9;
            this.btnNavStockMove.Text = "Stock Move";
            this.btnNavStockMove.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavStockMove.UseVisualStyleBackColor = true;
            this.btnNavStockMove.Click += new System.EventHandler(this.btnNavStockMove_Click);
            // 
            // btnNavOrder
            // 
            this.btnNavOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavOrder.FlatAppearance.BorderSize = 0;
            this.btnNavOrder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavOrder.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavOrder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavOrder.Location = new System.Drawing.Point(0, 262);
            this.btnNavOrder.Name = "btnNavOrder";
            this.btnNavOrder.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavOrder.Size = new System.Drawing.Size(230, 38);
            this.btnNavOrder.TabIndex = 8;
            this.btnNavOrder.Text = "Sales Order";
            this.btnNavOrder.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavOrder.UseVisualStyleBackColor = true;
            this.btnNavOrder.Click += new System.EventHandler(this.btnNavOrder_Click);
            // 
            // btnNavPurchase
            // 
            this.btnNavPurchase.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavPurchase.FlatAppearance.BorderSize = 0;
            this.btnNavPurchase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavPurchase.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavPurchase.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavPurchase.Location = new System.Drawing.Point(0, 224);
            this.btnNavPurchase.Name = "btnNavPurchase";
            this.btnNavPurchase.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavPurchase.Size = new System.Drawing.Size(230, 38);
            this.btnNavPurchase.TabIndex = 7;
            this.btnNavPurchase.Text = "Purchase Order";
            this.btnNavPurchase.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavPurchase.UseVisualStyleBackColor = true;
            this.btnNavPurchase.Click += new System.EventHandler(this.btnNavPurchase_Click);
            // 
            // lblSectionTransaction
            // 
            this.lblSectionTransaction.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSectionTransaction.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionTransaction.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSectionTransaction.Location = new System.Drawing.Point(0, 192);
            this.lblSectionTransaction.Name = "lblSectionTransaction";
            this.lblSectionTransaction.Padding = new System.Windows.Forms.Padding(18, 12, 0, 4);
            this.lblSectionTransaction.Size = new System.Drawing.Size(230, 32);
            this.lblSectionTransaction.TabIndex = 6;
            this.lblSectionTransaction.Text = "TRANSAKSI & LOGISTIK";
            // 
            // btnNavUser
            // 
            this.btnNavUser.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavUser.FlatAppearance.BorderSize = 0;
            this.btnNavUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavUser.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavUser.Location = new System.Drawing.Point(0, 154);
            this.btnNavUser.Name = "btnNavUser";
            this.btnNavUser.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavUser.Size = new System.Drawing.Size(230, 38);
            this.btnNavUser.TabIndex = 5;
            this.btnNavUser.Text = "Pengguna (Users)";
            this.btnNavUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavUser.UseVisualStyleBackColor = true;
            this.btnNavUser.Click += new System.EventHandler(this.btnNavUser_Click);
            // 
            // btnNavCategories
            // 
            this.btnNavCategories.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCategories.FlatAppearance.BorderSize = 0;
            this.btnNavCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCategories.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCategories.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavCategories.Location = new System.Drawing.Point(0, 116);
            this.btnNavCategories.Name = "btnNavCategories";
            this.btnNavCategories.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavCategories.Size = new System.Drawing.Size(230, 38);
            this.btnNavCategories.TabIndex = 4;
            this.btnNavCategories.Text = "Kategori";
            this.btnNavCategories.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCategories.UseVisualStyleBackColor = true;
            this.btnNavCategories.Click += new System.EventHandler(this.btnNavCategories_Click);
            // 
            // btnNavCustomer
            // 
            this.btnNavCustomer.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavCustomer.FlatAppearance.BorderSize = 0;
            this.btnNavCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavCustomer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavCustomer.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavCustomer.Location = new System.Drawing.Point(0, 78);
            this.btnNavCustomer.Name = "btnNavCustomer";
            this.btnNavCustomer.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavCustomer.Size = new System.Drawing.Size(230, 38);
            this.btnNavCustomer.TabIndex = 3;
            this.btnNavCustomer.Text = "Partner / Customer";
            this.btnNavCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavCustomer.UseVisualStyleBackColor = true;
            this.btnNavCustomer.Click += new System.EventHandler(this.btnNavCustomer_Click);
            // 
            // btnNavProduct
            // 
            this.btnNavProduct.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnNavProduct.FlatAppearance.BorderSize = 0;
            this.btnNavProduct.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNavProduct.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNavProduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(163)))), ((int)(((byte)(184)))));
            this.btnNavProduct.Location = new System.Drawing.Point(0, 40);
            this.btnNavProduct.Name = "btnNavProduct";
            this.btnNavProduct.Padding = new System.Windows.Forms.Padding(18, 0, 0, 0);
            this.btnNavProduct.Size = new System.Drawing.Size(230, 38);
            this.btnNavProduct.TabIndex = 2;
            this.btnNavProduct.Text = "Data Produk";
            this.btnNavProduct.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNavProduct.UseVisualStyleBackColor = true;
            this.btnNavProduct.Click += new System.EventHandler(this.btnNavProduct_Click);
            // 
            // lblSectionMaster
            // 
            this.lblSectionMaster.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSectionMaster.Font = new System.Drawing.Font("Segoe UI", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSectionMaster.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSectionMaster.Location = new System.Drawing.Point(0, 8);
            this.lblSectionMaster.Name = "lblSectionMaster";
            this.lblSectionMaster.Padding = new System.Windows.Forms.Padding(18, 12, 0, 4);
            this.lblSectionMaster.Size = new System.Drawing.Size(230, 32);
            this.lblSectionMaster.TabIndex = 1;
            this.lblSectionMaster.Text = "MASTER DATA";
            // 
            // panelSidebarFooter
            // 
            this.panelSidebarFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(6)))), ((int)(((byte)(23)))));
            this.panelSidebarFooter.Controls.Add(this.btnExit);
            this.panelSidebarFooter.Controls.Add(this.lblVersion);
            this.panelSidebarFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSidebarFooter.Location = new System.Drawing.Point(0, 628);
            this.panelSidebarFooter.Name = "panelSidebarFooter";
            this.panelSidebarFooter.Size = new System.Drawing.Size(230, 52);
            this.panelSidebarFooter.TabIndex = 2;
            // 
            // btnExit
            // 
            this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnExit.Location = new System.Drawing.Point(145, 12);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(72, 28);
            this.btnExit.TabIndex = 1;
            this.btnExit.Text = "Keluar";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVersion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblVersion.Location = new System.Drawing.Point(16, 20);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(58, 13);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "IMS v1.0.0";
            // 
            // panelBrand
            // 
            this.panelBrand.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(6)))), ((int)(((byte)(23)))));
            this.panelBrand.Controls.Add(this.lblBrandName);
            this.panelBrand.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelBrand.Location = new System.Drawing.Point(0, 0);
            this.panelBrand.Name = "panelBrand";
            this.panelBrand.Size = new System.Drawing.Size(230, 70);
            this.panelBrand.TabIndex = 0;
            // 
            // lblBrandName
            // 
            this.lblBrandName.AutoSize = true;
            this.lblBrandName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBrandName.ForeColor = System.Drawing.Color.White;
            this.lblBrandName.Location = new System.Drawing.Point(17, 16);
            this.lblBrandName.Name = "lblBrandName";
            this.lblBrandName.Size = new System.Drawing.Size(136, 21);
            this.lblBrandName.TabIndex = 0;
            this.lblBrandName.Text = "IMS ENTERPRISE";
            // 
            // panelTopHeader
            // 
            this.panelTopHeader.BackColor = System.Drawing.Color.White;
            this.panelTopHeader.Controls.Add(this.lblUserRole);
            this.panelTopHeader.Controls.Add(this.lblUserName);
            this.panelTopHeader.Controls.Add(this.lblModuleSubtitle);
            this.panelTopHeader.Controls.Add(this.lblModuleTitle);
            this.panelTopHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopHeader.Location = new System.Drawing.Point(230, 0);
            this.panelTopHeader.Name = "panelTopHeader";
            this.panelTopHeader.Size = new System.Drawing.Size(870, 56);
            this.panelTopHeader.TabIndex = 1;
            this.panelTopHeader.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTopHeader_Paint);
            // 
            // lblUserRole
            // 
            this.lblUserRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserRole.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.lblUserRole.Location = new System.Drawing.Point(670, 31);
            this.lblUserRole.Name = "lblUserRole";
            this.lblUserRole.Size = new System.Drawing.Size(185, 15);
            this.lblUserRole.TabIndex = 3;
            this.lblUserRole.Text = "● Administrator (Online)";
            this.lblUserRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUserName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblUserName.Location = new System.Drawing.Point(670, 10);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(185, 18);
            this.lblUserName.TabIndex = 2;
            this.lblUserName.Text = "Admin User";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblModuleSubtitle
            // 
            this.lblModuleSubtitle.AutoSize = true;
            this.lblModuleSubtitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblModuleSubtitle.Location = new System.Drawing.Point(24, 32);
            this.lblModuleSubtitle.Name = "lblModuleSubtitle";
            this.lblModuleSubtitle.Size = new System.Drawing.Size(220, 13);
            this.lblModuleSubtitle.TabIndex = 1;
            this.lblModuleSubtitle.Text = "Manajemen data barang, stok, dan harga";
            // 
            // lblModuleTitle
            // 
            this.lblModuleTitle.AutoSize = true;
            this.lblModuleTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModuleTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblModuleTitle.Location = new System.Drawing.Point(23, 9);
            this.lblModuleTitle.Name = "lblModuleTitle";
            this.lblModuleTitle.Size = new System.Drawing.Size(105, 21);
            this.lblModuleTitle.TabIndex = 0;
            this.lblModuleTitle.Text = "Data Produk";
            // 
            // panelBottomStatus
            // 
            this.panelBottomStatus.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.panelBottomStatus.Controls.Add(this.lblStatusText);
            this.panelBottomStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelBottomStatus.Location = new System.Drawing.Point(230, 656);
            this.panelBottomStatus.Name = "panelBottomStatus";
            this.panelBottomStatus.Size = new System.Drawing.Size(870, 24);
            this.panelBottomStatus.TabIndex = 2;
            this.panelBottomStatus.Paint += new System.Windows.Forms.PaintEventHandler(this.panelBottomStatus_Paint);
            // 
            // lblStatusText
            // 
            this.lblStatusText.AutoSize = true;
            this.lblStatusText.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblStatusText.Location = new System.Drawing.Point(12, 5);
            this.lblStatusText.Name = "lblStatusText";
            this.lblStatusText.Size = new System.Drawing.Size(180, 13);
            this.lblStatusText.TabIndex = 0;
            this.lblStatusText.Text = "Sistem Siap • Database Terkoneksi";
            this.lblStatusText.Click += new System.EventHandler(this.lblStatusText_Click);
            // 
            // panelMain
            // 
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(230, 56);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(870, 600);
            this.panelMain.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.panelBottomStatus);
            this.Controls.Add(this.panelTopHeader);
            this.Controls.Add(this.panelSidebar);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(1000, 600);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inventory Management System - Enterprise";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panelSidebar.ResumeLayout(false);
            this.panelNavScroll.ResumeLayout(false);
            this.panelSidebarFooter.ResumeLayout(false);
            this.panelSidebarFooter.PerformLayout();
            this.panelBrand.ResumeLayout(false);
            this.panelBrand.PerformLayout();
            this.panelTopHeader.ResumeLayout(false);
            this.panelTopHeader.PerformLayout();
            this.panelBottomStatus.ResumeLayout(false);
            this.panelBottomStatus.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Panel panelBrand;
        private System.Windows.Forms.Label lblBrandName;
        private System.Windows.Forms.Panel panelNavScroll;
        private System.Windows.Forms.Panel panelSidebarFooter;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblSectionMaster;
        private System.Windows.Forms.Button btnNavProduct;
        private System.Windows.Forms.Button btnNavCustomer;
        private System.Windows.Forms.Button btnNavCategories;
        private System.Windows.Forms.Button btnNavUser;
        private System.Windows.Forms.Label lblSectionTransaction;
        private System.Windows.Forms.Button btnNavPurchase;
        private System.Windows.Forms.Button btnNavOrder;
        private System.Windows.Forms.Button btnNavStockMove;
        private System.Windows.Forms.Button btnNavDelivery;
        private System.Windows.Forms.Label lblSectionFinance;
        private System.Windows.Forms.Button btnNavBill;
        private System.Windows.Forms.Button btnNavPayment;
        private System.Windows.Forms.Button btnNavCOA;
        private System.Windows.Forms.Panel panelTopHeader;
        private System.Windows.Forms.Label lblModuleTitle;
        private System.Windows.Forms.Label lblModuleSubtitle;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserRole;
        private System.Windows.Forms.Panel panelBottomStatus;
        private System.Windows.Forms.Label lblStatusText;
        private System.Windows.Forms.Panel panelMain;
    }
}