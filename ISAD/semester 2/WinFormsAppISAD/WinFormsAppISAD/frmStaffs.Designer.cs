namespace WinFormsAppISAD
{
    partial class frmStaffs
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise.</param>
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            btnUpdate = new Button();
            txtId = new TextBox();
            lblStaffID = new Label();
            lblFN = new Label();
            txtFName = new TextBox();
            rdoF = new RadioButton();
            lblGen = new Label();
            rdoM = new RadioButton();
            lblBod = new Label();
            dtpDOB = new DateTimePicker();
            lblPos = new Label();
            txtPos = new TextBox();
            lblSalary = new Label();
            txtSalary = new TextBox();
            lblStatus = new Label();
            chkStatus = new CheckBox();
            pBox = new PictureBox();
            lblSM = new Label();
            btnAdd = new Button();
            dgv = new DataGridView();
            btnEdit = new Button();
            btnDelete = new Button();
            genderPanel = new Panel();
            photoLabel = new Label();
            btnView = new Button();
            ((System.ComponentModel.ISupportInitialize)pBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            genderPanel.SuspendLayout();
            SuspendLayout();
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 150, 136);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Enabled = false;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.ForeColor = Color.White;
            btnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdate.Location = new Point(730, 177);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 17;
            btnUpdate.Text = "✏️ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // txtId
            // 
            txtId.BackColor = Color.FromArgb(245, 245, 245);
            txtId.BorderStyle = BorderStyle.FixedSingle;
            txtId.Location = new Point(120, 74);
            txtId.Name = "txtId";
            txtId.ReadOnly = true;
            txtId.Size = new Size(150, 23);
            txtId.TabIndex = 2;
            // 
            // lblStaffID
            // 
            lblStaffID.AutoSize = true;
            lblStaffID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStaffID.ForeColor = Color.FromArgb(33, 33, 33);
            lblStaffID.Location = new Point(23, 77);
            lblStaffID.Name = "lblStaffID";
            lblStaffID.Size = new Size(86, 19);
            lblStaffID.TabIndex = 1;
            lblStaffID.Text = "🆔 Staff ID:";
            // 
            // lblFN
            // 
            lblFN.AutoSize = true;
            lblFN.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblFN.ForeColor = Color.FromArgb(33, 33, 33);
            lblFN.Location = new Point(23, 119);
            lblFN.Name = "lblFN";
            lblFN.Size = new Size(104, 19);
            lblFN.TabIndex = 3;
            lblFN.Text = "👤 Full Name:";
            // 
            // txtFName
            // 
            txtFName.BackColor = Color.FromArgb(245, 245, 245);
            txtFName.BorderStyle = BorderStyle.FixedSingle;
            txtFName.Location = new Point(132, 116);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(250, 23);
            txtFName.TabIndex = 4;

            // 
            // rdoF
            // 
            rdoF.ForeColor = Color.FromArgb(33, 33, 33);
            rdoF.Location = new Point(10, 5);
            rdoF.Name = "rdoF";
            rdoF.Size = new Size(100, 19);
            rdoF.TabIndex = 0;
            rdoF.Text = "👩 Female";
            // 
            // lblGen
            // 
            lblGen.AutoSize = true;
            lblGen.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblGen.ForeColor = Color.FromArgb(33, 33, 33);
            lblGen.Location = new Point(23, 164);
            lblGen.Name = "lblGen";
            lblGen.Size = new Size(80, 19);
            lblGen.TabIndex = 5;
            lblGen.Text = "⚤ Gender:";
            // 
            // rdoM
            // 
            rdoM.ForeColor = Color.FromArgb(33, 33, 33);
            rdoM.Location = new Point(120, 5);
            rdoM.Name = "rdoM";
            rdoM.Size = new Size(100, 19);
            rdoM.TabIndex = 1;
            rdoM.Text = "👨 Male";
            // 
            // lblBod
            // 
            lblBod.AutoSize = true;
            lblBod.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblBod.ForeColor = Color.FromArgb(33, 33, 33);
            lblBod.Location = new Point(23, 206);
            lblBod.Name = "lblBod";
            lblBod.Size = new Size(104, 19);
            lblBod.TabIndex = 7;
            lblBod.Text = "📅 Birth Date:";
            // 
            // dtpDOB
            // 
            dtpDOB.CalendarMonthBackground = Color.FromArgb(245, 245, 245);
            dtpDOB.Format = DateTimePickerFormat.Short;
            dtpDOB.Location = new Point(130, 203);
            dtpDOB.Name = "dtpDOB";
            dtpDOB.Size = new Size(250, 23);
            dtpDOB.TabIndex = 8;
            // 
            // lblPos
            // 
            lblPos.AutoSize = true;
            lblPos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblPos.ForeColor = Color.FromArgb(33, 33, 33);
            lblPos.Location = new Point(23, 253);
            lblPos.Name = "lblPos";
            lblPos.Size = new Size(91, 19);
            lblPos.TabIndex = 9;
            lblPos.Text = "💼 Position:";
            // 
            // txtPos
            // 
            txtPos.BackColor = Color.FromArgb(245, 245, 245);
            txtPos.BorderStyle = BorderStyle.FixedSingle;
            txtPos.Location = new Point(120, 250);
            txtPos.Name = "txtPos";
            txtPos.Size = new Size(250, 23);
            txtPos.TabIndex = 10;
            // 
            // lblSalary
            // 
            lblSalary.AutoSize = true;
            lblSalary.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSalary.ForeColor = Color.FromArgb(33, 33, 33);
            lblSalary.Location = new Point(23, 297);
            lblSalary.Name = "lblSalary";
            lblSalary.Size = new Size(80, 19);
            lblSalary.TabIndex = 11;
            lblSalary.Text = "💰 Salary:";
            // 
            // txtSalary
            // 
            txtSalary.BackColor = Color.FromArgb(245, 245, 245);
            txtSalary.BorderStyle = BorderStyle.FixedSingle;
            txtSalary.Location = new Point(120, 294);
            txtSalary.Name = "txtSalary";
            txtSalary.Size = new Size(250, 23);
            txtSalary.TabIndex = 12;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblStatus.ForeColor = Color.FromArgb(33, 33, 33);
            lblStatus.Location = new Point(23, 337);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(77, 19);
            lblStatus.TabIndex = 13;
            lblStatus.Text = "🔄 Status:";
            // 
            // txtStatus
            // 
            chkStatus.ForeColor = Color.FromArgb(33, 33, 33);
            chkStatus.Location = new Point(120, 337);
            chkStatus.Name = "txtStatus";
            chkStatus.Size = new Size(100, 20);
            chkStatus.TabIndex = 14;
            chkStatus.Text = "Inactive";
            // 
            // pBox
            // 
            pBox.BackColor = Color.FromArgb(245, 245, 245);
            pBox.BorderStyle = BorderStyle.FixedSingle;
            pBox.Cursor = Cursors.Hand;
            pBox.Location = new Point(450, 74);
            pBox.Name = "pBox";
            pBox.Size = new Size(232, 283);
            pBox.SizeMode = PictureBoxSizeMode.Zoom;
            pBox.TabIndex = 16;
            pBox.TabStop = false;
            pBox.Click += pBox_Click;
            // 
            // lblSM
            // 
            lblSM.AutoSize = true;
            lblSM.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblSM.ForeColor = Color.FromArgb(0, 150, 136);
            lblSM.Location = new Point(20, 7);
            lblSM.Name = "lblSM";
            lblSM.Size = new Size(351, 45);
            lblSM.TabIndex = 0;
            lblSM.Text = "👥 Staff Management";
            lblSM.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.ForeColor = Color.White;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(730, 33);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 18;
            btnAdd.Text = "➕ Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dataGridViewCellStyle2.SelectionForeColor = Color.White;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgv.DefaultCellStyle = dataGridViewCellStyle2;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.Location = new Point(30, 398);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.Height = 30;
            dgv.Size = new Size(800, 190);
            dgv.TabIndex = 21;
            dgv.CellClick += dgv_CellClick;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(63, 81, 181);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.ForeColor = Color.White;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(730, 103);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 19;
            btnEdit.Text = "🔍 Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
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
            btnDelete.Location = new Point(730, 321);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(100, 35);
            btnDelete.TabIndex = 20;
            btnDelete.Text = "❌ Delete";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // genderPanel
            // 
            genderPanel.BackColor = Color.FromArgb(245, 245, 245);
            genderPanel.Controls.Add(rdoF);
            genderPanel.Controls.Add(rdoM);
            genderPanel.Location = new Point(120, 162);
            genderPanel.Name = "genderPanel";
            genderPanel.Size = new Size(250, 30);
            genderPanel.TabIndex = 6;
            // 
            // photoLabel
            // 
            photoLabel.AutoSize = true;
            photoLabel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            photoLabel.ForeColor = Color.FromArgb(33, 33, 33);
            photoLabel.Location = new Point(502, 33);
            photoLabel.Name = "photoLabel";
            photoLabel.Size = new Size(108, 19);
            photoLabel.TabIndex = 15;
            photoLabel.Text = "📸 Staff Photo";
            // 
            // btnView
            // 
            btnView.BackColor = Color.DarkOrange;
            btnView.Cursor = Cursors.Hand;
            btnView.Enabled = false;
            btnView.FlatAppearance.BorderSize = 0;
            btnView.FlatStyle = FlatStyle.Flat;
            btnView.ForeColor = Color.White;
            btnView.ImageAlign = ContentAlignment.MiddleLeft;
            btnView.Location = new Point(730, 250);
            btnView.Name = "btnView";
            btnView.Size = new Size(100, 35);
            btnView.TabIndex = 22;
            btnView.Text = "🖼️ View";
            btnView.UseVisualStyleBackColor = false;
            btnView.Click += btnView_Click;
            // 
            // frmStaffs
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(850, 600);
            Controls.Add(btnView);
            Controls.Add(lblSM);
            Controls.Add(lblStaffID);
            Controls.Add(txtId);
            Controls.Add(lblFN);
            Controls.Add(txtFName);
            Controls.Add(lblGen);
            Controls.Add(genderPanel);
            Controls.Add(lblBod);
            Controls.Add(dtpDOB);
            Controls.Add(lblPos);
            Controls.Add(txtPos);
            Controls.Add(lblSalary);
            Controls.Add(txtSalary);
            Controls.Add(lblStatus);
            Controls.Add(chkStatus);
            Controls.Add(photoLabel);
            Controls.Add(pBox);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(dgv);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "frmStaffs";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "👥 Staff Management";
         
            ((System.ComponentModel.ISupportInitialize)pBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            genderPanel.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnUpdate;
        private TextBox txtId;
        private Label lblStaffID;
        private Label lblFN;
        private TextBox txtFName;
        private RadioButton rdoF;
        private Label lblGen;
        private RadioButton rdoM;
        private Label lblBod;
        private DateTimePicker dtpDOB;
        private Label lblPos;
        private TextBox txtPos;
        private Label lblSalary;
        private TextBox txtSalary;
        private Label lblStatus;
        private CheckBox chkStatus;
        private PictureBox pBox;
        private Label lblSM;
        private Button btnAdd;
        private DataGridView dgv;
        private Button btnEdit;
        private Button btnDelete;
        private Panel genderPanel;
        private Label photoLabel;
        private Button btnView;
    }
}