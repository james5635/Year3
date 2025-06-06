namespace WinFormsAppISAD
{
    partial class frmImportDetail
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
            lblImportDate = new Label();
            dtpImportDate = new DateTimePicker();
            lblStaffID = new Label();
            lblImportDetail = new Label();
            lblStaffName = new Label();
            cboStaffID = new ComboBox();
            txtStaffName = new TextBox();
            txtSupID = new TextBox();
            lblSup = new Label();
            lblSupID = new Label();
            cboSup = new ComboBox();
            txtTotal = new TextBox();
            lblTotal = new Label();
            lview = new ListView();
            txtProCode = new TextBox();
            lblProCode = new Label();
            txtProName = new TextBox();
            lblProName = new Label();
            txtQty = new TextBox();
            lblQty = new Label();
            txtUnitPrice = new TextBox();
            lblUnitPrice = new Label();
            btnAdd = new Button();
            btnDelete = new Button();
            btnSave = new Button();
            SuspendLayout();
            // 
            // lblImportDate
            // 
            lblImportDate.AutoSize = true;
            lblImportDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblImportDate.ForeColor = Color.FromArgb(33, 33, 33);
            lblImportDate.Location = new Point(17, 80);
            lblImportDate.Name = "lblImportDate";
            lblImportDate.Size = new Size(118, 19);
            lblImportDate.TabIndex = 75;
            lblImportDate.Text = "📅 Import Date:";
            // 
            // dtpImportDate
            // 
            dtpImportDate.CalendarMonthBackground = Color.FromArgb(245, 245, 245);
            dtpImportDate.Format = DateTimePickerFormat.Short;
            dtpImportDate.Location = new Point(145, 80);
            dtpImportDate.Name = "dtpImportDate";
            dtpImportDate.Size = new Size(250, 23);
            dtpImportDate.TabIndex = 76;
            // 
            // lblStaffID
            // 
            lblStaffID.AutoSize = true;
            lblStaffID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffID.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffID.Location = new Point(17, 132);
            lblStaffID.Name = "lblStaffID";
            lblStaffID.Size = new Size(95, 19);
            lblStaffID.TabIndex = 77;
            lblStaffID.Text = "\U0001f9d1‍💼 Staff's ID:";
            // 
            // lblImportDetail
            // 
            lblImportDetail.AutoSize = true;
            lblImportDetail.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblImportDetail.ForeColor = Color.FromArgb(0, 150, 136);
            lblImportDetail.Location = new Point(66, 9);
            lblImportDetail.Name = "lblImportDetail";
            lblImportDetail.Size = new Size(477, 45);
            lblImportDetail.TabIndex = 79;
            lblImportDetail.Text = "📋 ImportDetail's Information";
            lblImportDetail.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblStaffName
            // 
            lblStaffName.AutoSize = true;
            lblStaffName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffName.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffName.Location = new Point(262, 132);
            lblStaffName.Name = "lblStaffName";
            lblStaffName.Size = new Size(121, 19);
            lblStaffName.TabIndex = 80;
            lblStaffName.Text = "👤 Staff's Name:";
            // 
            // cboStaffID
            // 
            cboStaffID.FormattingEnabled = true;
            cboStaffID.Location = new Point(117, 132);
            cboStaffID.Name = "cboStaffID";
            cboStaffID.Size = new Size(121, 23);
            cboStaffID.TabIndex = 82;
            cboStaffID.SelectionChangeCommitted += cboStaffID_SelectionChangeCommitted;
            // 
            // txtStaffName
            // 
            txtStaffName.BorderStyle = BorderStyle.FixedSingle;
            txtStaffName.Location = new Point(389, 133);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.ReadOnly = true;
            txtStaffName.Size = new Size(214, 23);
            txtStaffName.TabIndex = 83;
            // 
            // txtSupID
            // 
            txtSupID.BorderStyle = BorderStyle.FixedSingle;
            txtSupID.Location = new Point(132, 186);
            txtSupID.Name = "txtSupID";
            txtSupID.ReadOnly = true;
            txtSupID.Size = new Size(131, 23);
            txtSupID.TabIndex = 87;
            // 
            // lblSup
            // 
            lblSup.AutoSize = true;
            lblSup.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSup.ForeColor = Color.FromArgb(33, 33, 33);
            lblSup.Location = new Point(281, 186);
            lblSup.Name = "lblSup";
            lblSup.Size = new Size(94, 19);
            lblSup.TabIndex = 85;
            lblSup.Text = "📦 Supplier:";
            // 
            // lblSupID
            // 
            lblSupID.AutoSize = true;
            lblSupID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSupID.ForeColor = Color.FromArgb(33, 33, 33);
            lblSupID.Location = new Point(17, 186);
            lblSupID.Name = "lblSupID";
            lblSupID.Size = new Size(111, 19);
            lblSupID.TabIndex = 84;
            lblSupID.Text = "🏢 Supplier ID:";
            // 
            // cboSup
            // 
            cboSup.FormattingEnabled = true;
            cboSup.Location = new Point(379, 186);
            cboSup.Name = "cboSup";
            cboSup.Size = new Size(214, 23);
            cboSup.TabIndex = 88;
            cboSup.SelectionChangeCommitted += cboSup_SelectionChangeCommitted;
            // 
            // txtTotal
            // 
            txtTotal.BorderStyle = BorderStyle.FixedSingle;
            txtTotal.Location = new Point(645, 579);
            txtTotal.Name = "txtTotal";
            txtTotal.ReadOnly = true;
            txtTotal.Size = new Size(131, 23);
            txtTotal.TabIndex = 90;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotal.ForeColor = Color.FromArgb(33, 33, 33);
            lblTotal.Location = new Point(568, 581);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(70, 19);
            lblTotal.TabIndex = 89;
            lblTotal.Text = "\U0001f9ee Total:";
            // 
            // lview
            // 
            lview.FullRowSelect = true;
            lview.HeaderStyle = ColumnHeaderStyle.Nonclickable;
            lview.Location = new Point(17, 321);
            lview.Name = "lview";
            lview.Size = new Size(759, 246);
            lview.TabIndex = 91;
            lview.UseCompatibleStateImageBehavior = false;
            lview.SelectedIndexChanged += lview_SelectedIndexChanged;
            // 
            // txtProCode
            // 
            txtProCode.BorderStyle = BorderStyle.FixedSingle;
            txtProCode.Location = new Point(17, 283);
            txtProCode.Name = "txtProCode";
            txtProCode.Size = new Size(144, 23);
            txtProCode.TabIndex = 93;
            txtProCode.Leave += txtProCode_Leave;
            // 
            // lblProCode
            // 
            lblProCode.AutoSize = true;
            lblProCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProCode.ForeColor = Color.FromArgb(33, 33, 33);
            lblProCode.Location = new Point(19, 255);
            lblProCode.Name = "lblProCode";
            lblProCode.Size = new Size(134, 19);
            lblProCode.TabIndex = 92;
            lblProCode.Text = "🔢 Product's Code";
            // 
            // txtProName
            // 
            txtProName.BorderStyle = BorderStyle.FixedSingle;
            txtProName.Location = new Point(187, 283);
            txtProName.Name = "txtProName";
            txtProName.Size = new Size(258, 23);
            txtProName.TabIndex = 95;
            // 
            // lblProName
            // 
            lblProName.AutoSize = true;
            lblProName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblProName.ForeColor = Color.FromArgb(33, 33, 33);
            lblProName.Location = new Point(258, 255);
            lblProName.Name = "lblProName";
            lblProName.Size = new Size(139, 19);
            lblProName.TabIndex = 94;
            lblProName.Text = "🛍️ Product's Name";
            // 
            // txtQty
            // 
            txtQty.BorderStyle = BorderStyle.FixedSingle;
            txtQty.Location = new Point(461, 283);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(138, 23);
            txtQty.TabIndex = 97;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblQty.ForeColor = Color.FromArgb(33, 33, 33);
            lblQty.Location = new Point(487, 255);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(90, 19);
            lblQty.TabIndex = 96;
            lblQty.Text = "🔢 Quantity";
            // 
            // txtUnitPrice
            // 
            txtUnitPrice.BorderStyle = BorderStyle.FixedSingle;
            txtUnitPrice.Location = new Point(616, 283);
            txtUnitPrice.Name = "txtUnitPrice";
            txtUnitPrice.Size = new Size(160, 23);
            txtUnitPrice.TabIndex = 99;
            // 
            // lblUnitPrice
            // 
            lblUnitPrice.AutoSize = true;
            lblUnitPrice.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblUnitPrice.ForeColor = Color.FromArgb(33, 33, 33);
            lblUnitPrice.Location = new Point(651, 255);
            lblUnitPrice.Name = "lblUnitPrice";
            lblUnitPrice.Size = new Size(98, 19);
            lblUnitPrice.TabIndex = 98;
            lblUnitPrice.Text = "💲 Unit Price";
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(676, 42);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 100;
            btnAdd.Text = "➕ Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
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
            btnDelete.Location = new Point(676, 104);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 101;
            btnDelete.Text = "❌ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
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
            btnSave.Location = new Point(676, 170);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 102;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            btnSave.Click += btnSave_Click;
            // 
            // frmImportDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(793, 611);
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
            Name = "frmImportDetail";
            Text = "📋 ImportDetail's Information";
            Load += frmImportDetail_Load;
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion
        private Label lblImportDate;
        private DateTimePicker dtpImportDate;
        private Label lblStaffID;
        private Label lblImportDetail;
        private Label lblStaffName;
        private ComboBox cboStaffID;
        private TextBox txtStaffName;
        private TextBox txtSupID;
        private Label lblSup;
        private Label lblSupID;
        private ComboBox cboSup;
        private TextBox txtTotal;
        private Label lblTotal;
        private ListView lview;
        private TextBox txtProCode;
        private Label lblProCode;
        private TextBox txtProName;
        private Label lblProName;
        private TextBox txtQty;
        private Label lblQty;
        private TextBox txtUnitPrice;
        private Label lblUnitPrice;
        private Button btnAdd;
        private Button btnDelete;
        private Button btnSave;
    }
}