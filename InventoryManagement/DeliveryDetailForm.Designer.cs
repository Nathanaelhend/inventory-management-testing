namespace InventoryManagement
{
    partial class DeliveryDetailForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeliveryDetailForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelDocHeader = new System.Windows.Forms.Panel();
            this.labelName = new System.Windows.Forms.Label();
            this.lblDocTitle = new System.Windows.Forms.Label();
            this.labelState = new System.Windows.Forms.Label();
            this.dataGridDelivery = new System.Windows.Forms.DataGridView();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_real = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelFooter = new System.Windows.Forms.Panel();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.panelDocHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDelivery)).BeginInit();
            this.panelFooter.SuspendLayout();
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
            this.panel1.Size = new System.Drawing.Size(920, 50);
            this.panel1.TabIndex = 0;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(882, 13);
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
            this.label1.Size = new System.Drawing.Size(277, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Detail Pengiriman Barang (Delivery DO)";
            // 
            // panelDocHeader
            // 
            this.panelDocHeader.BackColor = System.Drawing.Color.White;
            this.panelDocHeader.Controls.Add(this.labelState);
            this.panelDocHeader.Controls.Add(this.labelName);
            this.panelDocHeader.Controls.Add(this.lblDocTitle);
            this.panelDocHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDocHeader.Location = new System.Drawing.Point(0, 50);
            this.panelDocHeader.Name = "panelDocHeader";
            this.panelDocHeader.Size = new System.Drawing.Size(920, 64);
            this.panelDocHeader.TabIndex = 1;
            // 
            // labelState
            // 
            this.labelState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelState.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.labelState.Location = new System.Drawing.Point(750, 28);
            this.labelState.Name = "labelState";
            this.labelState.Size = new System.Drawing.Size(150, 25);
            this.labelState.TabIndex = 2;
            this.labelState.Text = "DRAFT";
            this.labelState.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.labelName.Location = new System.Drawing.Point(18, 30);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(130, 25);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "WH/OUT/0000";
            // 
            // lblDocTitle
            // 
            this.lblDocTitle.AutoSize = true;
            this.lblDocTitle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDocTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDocTitle.Location = new System.Drawing.Point(20, 11);
            this.lblDocTitle.Name = "lblDocTitle";
            this.lblDocTitle.Size = new System.Drawing.Size(121, 13);
            this.lblDocTitle.TabIndex = 0;
            this.lblDocTitle.Text = "NOMOR PENGIRIMAN";
            // 
            // dataGridDelivery
            // 
            this.dataGridDelivery.AllowUserToAddRows = false;
            this.dataGridDelivery.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridDelivery.BackgroundColor = System.Drawing.Color.White;
            this.dataGridDelivery.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridDelivery.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridDelivery.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pname,
            this.qty,
            this.qty_real,
            this.Ref,
            this.pcode,
            this.state,
            this.line_type});
            this.dataGridDelivery.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridDelivery.Location = new System.Drawing.Point(0, 114);
            this.dataGridDelivery.Name = "dataGridDelivery";
            this.dataGridDelivery.RowHeadersWidth = 30;
            this.dataGridDelivery.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridDelivery.Size = new System.Drawing.Size(920, 370);
            this.dataGridDelivery.TabIndex = 2;
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
            this.qty.HeaderText = "Qty Pesanan";
            this.qty.MinimumWidth = 6;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // qty_real
            // 
            this.qty_real.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.qty_real.HeaderText = "Qty Terkirim";
            this.qty_real.MinimumWidth = 6;
            this.qty_real.Name = "qty_real";
            // 
            // Ref
            // 
            this.Ref.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ref.HeaderText = "No Referensi SO";
            this.Ref.MinimumWidth = 6;
            this.Ref.Name = "Ref";
            this.Ref.ReadOnly = true;
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
            // panelFooter
            // 
            this.panelFooter.BackColor = System.Drawing.Color.White;
            this.panelFooter.Controls.Add(this.btnSave);
            this.panelFooter.Controls.Add(this.btnConfirm);
            this.panelFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelFooter.Location = new System.Drawing.Point(0, 484);
            this.panelFooter.Name = "panelFooter";
            this.panelFooter.Size = new System.Drawing.Size(920, 56);
            this.panelFooter.TabIndex = 3;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(604, 10);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 36);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Simpan Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(734, 10);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(170, 36);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "Konfirmasi Pengiriman";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // DeliveryDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(920, 540);
            this.Controls.Add(this.dataGridDelivery);
            this.Controls.Add(this.panelDocHeader);
            this.Controls.Add(this.panelFooter);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DeliveryDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "DeliveryDetailForm";
            this.Load += new System.EventHandler(this.DeliveryDetailForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.panelDocHeader.ResumeLayout(false);
            this.panelDocHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridDelivery)).EndInit();
            this.panelFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelName;
        public System.Windows.Forms.Label labelState;
        private System.Windows.Forms.DataGridView dataGridDelivery;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_real;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ref;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_type;
        private System.Windows.Forms.Panel panelDocHeader;
        private System.Windows.Forms.Label lblDocTitle;
        private System.Windows.Forms.Panel panelFooter;
    }
}