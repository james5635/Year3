namespace WinFormsAppISAD
{
    partial class frmInvoiceDetail
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
            btnSave = new Button();
            btnDelete = new Button();
            btnAdd = new Button();
            txtUnitPrice = new TextBox();
            lblUnitPrice = new Label();
            txtQty = new TextBox();
            lblQty = new Label();
            txtProName = new TextBox();
            lblProName = new Label();
            txtProCode = new TextBox();
            lblProCode = new Label();
            lview = new ListView();
            txtTotal = new TextBox();
            lblTotal = new Label();
            cboSup = new ComboBox();
            txtSupID = new TextBox();
            lblSup = new Label();
            lblSupID = new Label();
            txtStaffName = new TextBox();
            cboStaffID = new ComboBox();
            lblStaffName = new Label();
            lblImportDetail = new Label();
            lblStaffID = new Label();
            lblImportDate = new Label();
            dtpImportDate = new DateTimePicker();
            SuspendLayout();
            // 
            // btnSave
            // 
            btnSave.BackColor = Color.FromArgb(0, 150, 136);
            btnSave.Cursor = Cursors.Hand;
            btnSave.Enabled = false;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.ForeColor = Color.White;
            btnSave.ImageAlign = ContentAlignment.MiddleLeft;
            btnSave.Location = new Point(683, 179);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 127;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(244, 67, 54);
            btnDelete.Cursor = Cursors.Hand;
            btnDelete.Enabled = false;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.ForeColor = Color.White;
            btnDelete.ImageAlign = ContentAlignment.MiddleLeft;
            btnDelete.Location = new Point(683, 113);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 126;
            btnDelete.Text = "❌ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(683, 51);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 125;
            btnAdd.Text = "➕ Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BorderStyle = BorderStyle.FixedSingle;
            txtUnitPrice.Location = new Point(623, 292);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(160, 23);
            txtUnitPrice.TabIndex = 124;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnitPrice.ForeColor = Color.FromArgb(33, 33, 33);
            lblUnitPrice.Location = new Point(658, 264);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(98, 19);
            lblUnitPrice.TabIndex = 123;
            lblUnitPrice.Text = "💲 Unit Price";
            // 
            // txtQty
            // 
            txtQty.BorderStyle = BorderStyle.FixedSingle;
            txtQty.Location = new Point(468, 292);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(138, 23);
            txtQty.TabIndex = 122;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQty.ForeColor = Color.FromArgb(33, 33, 33);
            lblQty.Location = new Point(494, 264);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(90, 19);
            lblQty.TabIndex = 121;
            lblQty.Text = "🔢 Quantity";
            // 
            // txtProName
            // 
            txtProName.BorderStyle = BorderStyle.FixedSingle;
            txtProName.Location = new Point(194, 292);
            txtProName.Name = "txtProName";
            txtProName.Size = new Size(258, 23);
            txtProName.TabIndex = 120;
            // 
            // lblProName
            // 
            lblProName.AutoSize = true;
            lblProName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProName.ForeColor = Color.FromArgb(33, 33, 33);
            lblProName.Location = new Point(265, 264);
            lblProName.Name = "lblProName";
            lblProName.Size = new Size(139, 19);
            lblProName.TabIndex = 119;
            lblProName.Text = "🛍️ Product's Name";
            // 
            // txtProCode
            // 
            txtProCode.BorderStyle = BorderStyle.FixedSingle;
            txtProCode.Location = new Point(24, 292);
            txtProCode.Name = "txtProCode";
            txtProCode.Size = new Size(144, 23);
            txtProCode.TabIndex = 118;
            // 
            // lblProCode
            // 
            lblProCode.AutoSize = true;
            lblProCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProCode.ForeColor = Color.FromArgb(33, 33, 33);
            lblProCode.Location = new Point(26, 264);
            lblProCode.Name = "lblProCode";
            lblProCode.Size = new Size(134, 19);
            lblProCode.TabIndex = 117;
            lblProCode.Text = "🔢 Product's Code";
            // 
            // lview
            // 
            lview.Location = new Point(24, 330);
            lview.Name = "lview";
            lview.Size = new Size(759, 246);
            lview.TabIndex = 116;
            lview.UseCompatibleStateImageBehavior = false;
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Location = new Point(652, 588);
            txtTotal.Name = "txtTotal";
            txtTotal.Size = new Size(131, 23);
            txtTotal.TabIndex = 115;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(33, 33, 33);
            lblTotal.Location = new Point(575, 590);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 19);
            lblTotal.TabIndex = 114;
            lblTotal.Text = "\U0001f9ee Total:";
            // 
            // cboSup
            // 
            cboSup.FormattingEnabled = true;
            cboSup.Location = new Point(386, 195);
            cboSup.Name = "cboSup";
            cboSup.Size = new Size(214, 23);
            cboSup.TabIndex = 113;
            // 
            // txtSupID
            // 
            txtSupID.BorderStyle = BorderStyle.FixedSingle;
            txtSupID.Location = new Point(139, 195);
            txtSupID.Name = "txtSupID";
            txtSupID.ReadOnly = true;
            txtSupID.Size = new Size(131, 23);
            txtSupID.TabIndex = 112;
            // 
            // lblSup
            // 
            lblSup.AutoSize = true;
            lblSup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSup.ForeColor = Color.FromArgb(33, 33, 33);
            lblSup.Location = new Point(288, 195);
            lblSup.Name = "lblSup";
            lblSup.Size = new Size(94, 19);
            lblSup.TabIndex = 111;
            lblSup.Text = "📦 Supplier:";
            // 
            // lblSupID
            // 
            lblSupID.AutoSize = true;
            lblSupID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSupID.ForeColor = Color.FromArgb(33, 33, 33);
            lblSupID.Location = new Point(24, 195);
            lblSupID.Name = "lblSupID";
            lblSupID.Size = new Size(111, 19);
            lblSupID.TabIndex = 110;
            lblSupID.Text = "🏢 Supplier ID:";
            // 
            // txtStaffName
            // 
            txtStaffName.BorderStyle = BorderStyle.FixedSingle;
            txtStaffName.Location = new Point(396, 142);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.ReadOnly = true;
            txtStaffName.Size = new Size(214, 23);
            txtStaffName.TabIndex = 109;
            // 
            // cboStaffID
            // 
            cboStaffID.FormattingEnabled = true;
            cboStaffID.Location = new Point(124, 141);
            cboStaffID.Name = "cboStaffID";
            cboStaffID.Size = new Size(121, 23);
            cboStaffID.TabIndex = 108;
            // 
            // lblStaffName
            // 
            lblStaffName.AutoSize = true;
            lblStaffName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffName.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffName.Location = new Point(269, 141);
            lblStaffName.Name = "lblStaffName";
            lblStaffName.Size = new Size(121, 19);
            lblStaffName.TabIndex = 107;
            lblStaffName.Text = "👤 Staff's Name:";
            // 
            // lblImportDetail
            // 
            lblImportDetail.AutoSize = true;
            lblImportDetail.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblImportDetail.ForeColor = Color.FromArgb(0, 150, 136);
            lblImportDetail.Location = new Point(73, 18);
            lblImportDetail.Name = "lblImportDetail";
            lblImportDetail.Size = new Size(477, 45);
            lblImportDetail.TabIndex = 106;
            lblImportDetail.Text = "📋 ImportDetail's Information";
            lblImportDetail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStaffID
            // 
            lblStaffID.AutoSize = true;
            lblStaffID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffID.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffID.Location = new Point(24, 141);
            lblStaffID.Name = "lblStaffID";
            lblStaffID.Size = new Size(95, 19);
            lblStaffID.TabIndex = 105;
            lblStaffID.Text = "\U0001f9d1‍💼 Staff's ID:";
            // 
            // lblImportDate
            // 
            lblImportDate.AutoSize = true;
            lblImportDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImportDate.ForeColor = Color.FromArgb(33, 33, 33);
            lblImportDate.Location = new Point(24, 89);
            lblImportDate.Name = "lblImportDate";
            lblImportDate.Size = new Size(118, 19);
            lblImportDate.TabIndex = 103;
            lblImportDate.Text = "📅 Import Date:";
            // 
            // dtpImportDate
            // 
            dtpImportDate.CalendarMonthBackground = Color.FromArgb(245, 245, 245);
            dtpImportDate.Format = DateTimePickerFormat.Short;
            dtpImportDate.Location = new Point(152, 89);
            dtpImportDate.Name = "dtpImportDate";
            dtpImportDate.Size = new Size(250, 23);
            dtpImportDate.TabIndex = 104;
            // 
            // frmInvoiceDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(798, 628);
            Controls.Add(btnSave);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(txtUnitPrice);
            Controls.Add(lblUnitPrice);
            Controls.Add(txtQty);
            Controls.Add(lblQty);
            Controls.Add(txtProName);
            Controls.Add(lblProName);
            Controls.Add(txtProCode);
            Controls.Add(lblProCode);
            Controls.Add(lview);
            Controls.Add(txtTotal);
            Controls.Add(lblTotal);
            Controls.Add(cboSup);
            Controls.Add(txtSupID);
            Controls.Add(lblSup);
            Controls.Add(lblSupID);
            Controls.Add(txtStaffName);
            Controls.Add(cboStaffID);
            Controls.Add(lblStaffName);
            Controls.Add(lblImportDetail);
            Controls.Add(lblStaffID);
            Controls.Add(lblImportDate);
            Controls.Add(dtpImportDate);
            Name = "frmInvoiceDetail";
            Text = "frmInvoiceDetail";
            Load += frmInvoiceDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSave;
        private Button btnDelete;
        private Button btnAdd;
        private TextBox txtUnitPrice;
        private Label lblUnitPrice;
        private TextBox txtQty;
        private Label lblQty;
        private TextBox txtProName;
        private Label lblProName;
        private TextBox txtProCode;
        private Label lblProCode;
        private ListView lview;
        private TextBox txtTotal;
        private Label lblTotal;
        private ComboBox cboSup;
        private TextBox txtSupID;
        private Label lblSup;
        private Label lblSupID;
        private TextBox txtStaffName;
        private ComboBox cboStaffID;
        private Label lblStaffName;
        private Label lblImportDetail;
        private Label lblStaffID;
        private Label lblImportDate;
        private DateTimePicker dtpImportDate;
    }
}