namespace WinFormsAppISAD
{
    partial class frmPayments
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblOrderCode = new Label();
            lblStaffName = new Label();
            txtStaffName = new TextBox();
            lblStaffID = new Label();
            lblPaymentDate = new Label();
            lblAmount = new Label();
            txtAmount = new TextBox();
            dtpPaymentDate = new DateTimePicker();
            cboStaffID = new ComboBox();
            cboOrderCode = new ComboBox();
            lblDeposit = new Label();
            txtDeposit = new TextBox();
            lblRemaining = new Label();
            txtRemaining = new TextBox();
            btnSave = new Button();
            lblPaymentInformation = new Label();
            SuspendLayout();
            // 
            // lblOrderCode
            // 
            lblOrderCode.AutoSize = true;
            lblOrderCode.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblOrderCode.ForeColor = Color.FromArgb(33, 33, 33);
            lblOrderCode.Location = new Point(17, 198);
            lblOrderCode.Name = "lblOrderCode";
            lblOrderCode.Size = new Size(116, 19);
            lblOrderCode.TabIndex = 58;
            lblOrderCode.Text = "📦 Order Code:";
            // 
            // lblStaffName
            // 
            lblStaffName.AutoSize = true;
            lblStaffName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffName.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffName.Location = new Point(292, 153);
            lblStaffName.Name = "lblStaffName";
            lblStaffName.Size = new Size(112, 19);
            lblStaffName.TabIndex = 53;
            lblStaffName.Text = "👤 Staff Name:";
            // 
            // txtStaffName
            // 
            txtStaffName.BorderStyle = BorderStyle.FixedSingle;
            txtStaffName.Location = new Point(418, 152);
            txtStaffName.Name = "txtStaffName";
            txtStaffName.ReadOnly = true;
            txtStaffName.Size = new Size(140, 23);
            txtStaffName.TabIndex = 52;
            // 
            // lblStaffID
            // 
            lblStaffID.AutoSize = true;
            lblStaffID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffID.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffID.Location = new Point(17, 150);
            lblStaffID.Name = "lblStaffID";
            lblStaffID.Size = new Size(86, 19);
            lblStaffID.TabIndex = 51;
            lblStaffID.Text = "🆔 Staff ID:";
            // 
            // lblPaymentDate
            // 
            lblPaymentDate.AutoSize = true;
            lblPaymentDate.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPaymentDate.ForeColor = Color.FromArgb(33, 33, 33);
            lblPaymentDate.Location = new Point(17, 100);
            lblPaymentDate.Name = "lblPaymentDate";
            lblPaymentDate.RightToLeft = RightToLeft.No;
            lblPaymentDate.Size = new Size(131, 19);
            lblPaymentDate.TabIndex = 48;
            lblPaymentDate.Text = "📅 Payment Date:";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAmount.ForeColor = Color.FromArgb(33, 33, 33);
            lblAmount.Location = new Point(290, 199);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(90, 19);
            lblAmount.TabIndex = 60;
            lblAmount.Text = "💰 Amount:";
            // 
            // txtAmount
            // 
            txtAmount.BorderStyle = BorderStyle.FixedSingle;
            txtAmount.Location = new Point(388, 198);
            txtAmount.Name = "txtAmount";
            txtAmount.ReadOnly = true;
            txtAmount.Size = new Size(140, 23);
            txtAmount.TabIndex = 59;
            // 
            // dtpPaymentDate
            // 
            dtpPaymentDate.Location = new Point(173, 100);
            dtpPaymentDate.Name = "dtpPaymentDate";
            dtpPaymentDate.Size = new Size(200, 23);
            dtpPaymentDate.TabIndex = 61;
            dtpPaymentDate.ValueChanged += dtpPaymentDate_ValueChanged;
            // 
            // cboStaffID
            // 
            cboStaffID.FormattingEnabled = true;
            cboStaffID.Location = new Point(120, 150);
            cboStaffID.Name = "cboStaffID";
            cboStaffID.Size = new Size(121, 23);
            cboStaffID.TabIndex = 62;
            // 
            // cboOrderCode
            // 
            cboOrderCode.FormattingEnabled = true;
            cboOrderCode.Location = new Point(140, 198);
            cboOrderCode.Name = "cboOrderCode";
            cboOrderCode.Size = new Size(121, 23);
            cboOrderCode.TabIndex = 63;
            // 
            // lblDeposit
            // 
            lblDeposit.AutoSize = true;
            lblDeposit.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblDeposit.ForeColor = Color.FromArgb(33, 33, 33);
            lblDeposit.Location = new Point(17, 250);
            lblDeposit.Name = "lblDeposit";
            lblDeposit.Size = new Size(88, 19);
            lblDeposit.TabIndex = 65;
            lblDeposit.Text = "💵 Deposit:";
            // 
            // txtDeposit
            // 
            txtDeposit.BorderStyle = BorderStyle.FixedSingle;
            txtDeposit.Location = new Point(119, 250);
            txtDeposit.Name = "txtDeposit";
            txtDeposit.Size = new Size(140, 23);
            txtDeposit.TabIndex = 64;
            // 
            // lblRemaining
            // 
            lblRemaining.AutoSize = true;
            lblRemaining.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblRemaining.ForeColor = Color.FromArgb(33, 33, 33);
            lblRemaining.Location = new Point(289, 252);
            lblRemaining.Name = "lblRemaining";
            lblRemaining.Size = new Size(108, 19);
            lblRemaining.TabIndex = 67;
            lblRemaining.Text = "💳 Remaining:";
            // 
            // txtRemaining
            // 
            txtRemaining.BorderStyle = BorderStyle.FixedSingle;
            txtRemaining.Location = new Point(411, 251);
            txtRemaining.Name = "txtRemaining";
            txtRemaining.ReadOnly = true;
            txtRemaining.Size = new Size(140, 23);
            txtRemaining.TabIndex = 66;
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
            btnSave.Location = new Point(458, 71);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(100, 35);
            btnSave.TabIndex = 128;
            btnSave.Text = "💾 Save";
            btnSave.UseVisualStyleBackColor = false;
            // 
            // lblPaymentInformation
            // 
            lblPaymentInformation.AutoSize = true;
            lblPaymentInformation.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPaymentInformation.ForeColor = Color.FromArgb(0, 150, 136);
            lblPaymentInformation.Location = new Point(27, 14);
            lblPaymentInformation.Name = "lblPaymentInformation";
            lblPaymentInformation.Size = new Size(414, 45);
            lblPaymentInformation.TabIndex = 129;
            lblPaymentInformation.Text = "💳 Payment's Information";
            lblPaymentInformation.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmPayments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 298);
            Controls.Add(lblPaymentInformation);
            Controls.Add(btnSave);
            Controls.Add(lblRemaining);
            Controls.Add(txtRemaining);
            Controls.Add(lblDeposit);
            Controls.Add(txtDeposit);
            Controls.Add(cboOrderCode);
            Controls.Add(cboStaffID);
            Controls.Add(dtpPaymentDate);
            Controls.Add(lblAmount);
            Controls.Add(txtAmount);
            Controls.Add(lblOrderCode);
            Controls.Add(lblStaffName);
            Controls.Add(txtStaffName);
            Controls.Add(lblStaffID);
            Controls.Add(lblPaymentDate);
            Name = "frmPayments";
            Text = "💳 Payment's Information";
            Load += frmPayments_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblOrderCode;
        private Label lblStaffName;
        private TextBox txtStaffName;
        private Label lblStaffID;
        private Label lblPaymentDate;
        private Label lblAmount;
        private TextBox txtAmount;
        private DateTimePicker dtpPaymentDate;
        private ComboBox cboStaffID;
        private ComboBox cboOrderCode;
        private Label lblDeposit;
        private TextBox txtDeposit;
        private Label lblRemaining;
        private TextBox txtRemaining;
        private Button btnSave;
        private Label lblPaymentInformation;
    }
}
