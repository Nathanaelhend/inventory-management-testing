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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.dataGridBill = new System.Windows.Forms.DataGridView();
            this.pname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qty_real = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ref = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.state = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.line_type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBill = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVendorName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dateBill = new System.Windows.Forms.DateTimePicker();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtFinalPrice = new System.Windows.Forms.TextBox();
            this.txtDpp = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPPn = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.txtDiscPrs = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lblDisc = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lblPPn = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).BeginInit();
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
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(977, 55);
            this.panel1.TabIndex = 19;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(952, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(29, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(381, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "Vendor Bill Form";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(370, 62);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(236, 29);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Vendor Bill Module";
            // 
            // dataGridBill
            // 
            this.dataGridBill.AllowUserToAddRows = false;
            this.dataGridBill.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(70)))), ((int)(((byte)(160)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridBill.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridBill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pname,
            this.qty,
            this.qty_real,
            this.Ref,
            this.pcode,
            this.state,
            this.line_type});
            this.dataGridBill.EnableHeadersVisualStyles = false;
            this.dataGridBill.Location = new System.Drawing.Point(0, 185);
            this.dataGridBill.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridBill.Name = "dataGridBill";
            this.dataGridBill.RowHeadersWidth = 51;
            this.dataGridBill.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dataGridBill.Size = new System.Drawing.Size(977, 299);
            this.dataGridBill.TabIndex = 20;
            // 
            // pname
            // 
            this.pname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pname.HeaderText = "Product Name";
            this.pname.MinimumWidth = 6;
            this.pname.Name = "pname";
            this.pname.ReadOnly = true;
            // 
            // qty
            // 
            this.qty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qty.HeaderText = "Qty";
            this.qty.MinimumWidth = 6;
            this.qty.Name = "qty";
            this.qty.ReadOnly = true;
            // 
            // qty_real
            // 
            this.qty_real.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.qty_real.HeaderText = "Qty Real";
            this.qty_real.MinimumWidth = 6;
            this.qty_real.Name = "qty_real";
            // 
            // Ref
            // 
            this.Ref.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Ref.HeaderText = "Ref";
            this.Ref.MinimumWidth = 6;
            this.Ref.Name = "Ref";
            this.Ref.ReadOnly = true;
            // 
            // pcode
            // 
            this.pcode.HeaderText = "Column1";
            this.pcode.MinimumWidth = 6;
            this.pcode.Name = "pcode";
            this.pcode.Visible = false;
            this.pcode.Width = 125;
            // 
            // state
            // 
            this.state.HeaderText = "Column1";
            this.state.Name = "state";
            this.state.Visible = false;
            // 
            // line_type
            // 
            this.line_type.HeaderText = "Column1";
            this.line_type.Name = "line_type";
            this.line_type.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(88, 114);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 39;
            this.btnSave.Text = "Save Data";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBill
            // 
            this.btnBill.Location = new System.Drawing.Point(4, 114);
            this.btnBill.Name = "btnBill";
            this.btnBill.Size = new System.Drawing.Size(82, 23);
            this.btnBill.TabIndex = 40;
            this.btnBill.Text = "Confirm Bill";
            this.btnBill.UseVisualStyleBackColor = true;
            this.btnBill.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(118, 20);
            this.label2.TabIndex = 41;
            this.label2.Text = "Vendor Name";
            // 
            // txtVendorName
            // 
            this.txtVendorName.Location = new System.Drawing.Point(136, 108);
            this.txtVendorName.Name = "txtVendorName";
            this.txtVendorName.ReadOnly = true;
            this.txtVendorName.Size = new System.Drawing.Size(176, 20);
            this.txtVendorName.TabIndex = 42;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(53, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 43;
            this.label3.Text = "Bill Date";
            // 
            // dateBill
            // 
            this.dateBill.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateBill.Location = new System.Drawing.Point(137, 136);
            this.dateBill.Name = "dateBill";
            this.dateBill.Size = new System.Drawing.Size(175, 20);
            this.dateBill.TabIndex = 44;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel3.Controls.Add(this.txtFinalPrice);
            this.panel3.Controls.Add(this.txtDpp);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.txtPPn);
            this.panel3.Controls.Add(this.btnClear);
            this.panel3.Controls.Add(this.btnBill);
            this.panel3.Controls.Add(this.btnSave);
            this.panel3.Controls.Add(this.label16);
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
            this.panel3.Location = new System.Drawing.Point(689, 494);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(276, 152);
            this.panel3.TabIndex = 101;
            // 
            // txtFinalPrice
            // 
            this.txtFinalPrice.Enabled = false;
            this.txtFinalPrice.Location = new System.Drawing.Point(65, 88);
            this.txtFinalPrice.Name = "txtFinalPrice";
            this.txtFinalPrice.ReadOnly = true;
            this.txtFinalPrice.Size = new System.Drawing.Size(155, 20);
            this.txtFinalPrice.TabIndex = 3;
            // 
            // txtDpp
            // 
            this.txtDpp.Enabled = false;
            this.txtDpp.Location = new System.Drawing.Point(65, 12);
            this.txtDpp.Name = "txtDpp";
            this.txtDpp.ReadOnly = true;
            this.txtDpp.Size = new System.Drawing.Size(89, 20);
            this.txtDpp.TabIndex = 0;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(22, 13);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(38, 16);
            this.label15.TabIndex = 82;
            this.label15.Text = "DPP";
            // 
            // txtPPn
            // 
            this.txtPPn.Location = new System.Drawing.Point(65, 63);
            this.txtPPn.Name = "txtPPn";
            this.txtPPn.Size = new System.Drawing.Size(45, 20);
            this.txtPPn.TabIndex = 2;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(189, 114);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "CLEAR";
            this.btnClear.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(22, 64);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(38, 16);
            this.label16.TabIndex = 84;
            this.label16.Text = "PPN";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(4, 89);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 95;
            this.label26.Text = "TOTAL";
            // 
            // txtDiscPrs
            // 
            this.txtDiscPrs.Location = new System.Drawing.Point(66, 39);
            this.txtDiscPrs.Name = "txtDiscPrs";
            this.txtDiscPrs.Size = new System.Drawing.Size(44, 20);
            this.txtDiscPrs.TabIndex = 1;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(18, 40);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(42, 16);
            this.label17.TabIndex = 86;
            this.label17.Text = "DISC";
            // 
            // lblDisc
            // 
            this.lblDisc.AutoSize = true;
            this.lblDisc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDisc.Location = new System.Drawing.Point(217, 42);
            this.lblDisc.Name = "lblDisc";
            this.lblDisc.Size = new System.Drawing.Size(12, 16);
            this.lblDisc.TabIndex = 4;
            this.lblDisc.Text = "-";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(116, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(20, 16);
            this.label18.TabIndex = 8;
            this.label18.Text = "%";
            // 
            // lblPPn
            // 
            this.lblPPn.AutoSize = true;
            this.lblPPn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPPn.Location = new System.Drawing.Point(217, 67);
            this.lblPPn.Name = "lblPPn";
            this.lblPPn.Size = new System.Drawing.Size(12, 16);
            this.lblPPn.TabIndex = 3;
            this.lblPPn.Text = "-";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(137, 42);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(78, 16);
            this.label19.TabIndex = 7;
            this.label19.Text = "Disc Rph :";
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(138, 66);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(78, 16);
            this.label22.TabIndex = 6;
            this.label22.Text = "PPN Rph :";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(201, 43);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(0, 16);
            this.label20.TabIndex = 5;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(117, 66);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(20, 16);
            this.label23.TabIndex = 90;
            this.label23.Text = "%";
            // 
            // BillDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(977, 658);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dateBill);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtVendorName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridBill);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BillDetailForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ReceiptDetailForm";
            this.Load += new System.EventHandler(this.BillDetailForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridBill)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label labelName;
        private System.Windows.Forms.DataGridView dataGridBill;
        private System.Windows.Forms.PictureBox pictureBox3;
        public System.Windows.Forms.Button btnSave;
        public System.Windows.Forms.Button btnBill;
        private System.Windows.Forms.DataGridViewTextBoxColumn pname;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn qty_real;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ref;
        private System.Windows.Forms.DataGridViewTextBoxColumn pcode;
        private System.Windows.Forms.DataGridViewTextBoxColumn state;
        private System.Windows.Forms.DataGridViewTextBoxColumn line_type;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVendorName;
        public System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dateBill;
        private System.Windows.Forms.Panel panel3;
        public System.Windows.Forms.TextBox txtFinalPrice;
        public System.Windows.Forms.TextBox txtDpp;
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
    }
}