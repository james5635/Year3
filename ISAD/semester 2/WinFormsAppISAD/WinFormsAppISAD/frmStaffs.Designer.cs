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
            label1 = new Label();
            label2 = new Label();
            txtFName = new TextBox();
            rdoF = new RadioButton();
            label3 = new Label();
            rdoM = new RadioButton();
            label4 = new Label();
            dtpDOB = new DateTimePicker();
            label5 = new Label();
            txtPos = new TextBox();
            label6 = new Label();
            txtSalary = new TextBox();
            label7 = new Label();
            txtStatus = new CheckBox();
            pBox = new PictureBox();
            label8 = new Label();
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
            txtId.Size = new Size(150, 23);
            txtId.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 33, 33);
            label1.Location = new Point(23, 77);
            label1.Name = "label1";
            label1.Size = new Size(86, 19);
            label1.TabIndex = 1;
            label1.Text = "🆔 Staff ID:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(23, 119);
            label2.Name = "label2";
            label2.Size = new Size(104, 19);
            label2.TabIndex = 3;
            label2.Text = "👤 Full Name:";
            // 
            // txtFName
            // 
            txtFName.BackColor = Color.FromArgb(245, 245, 245);
            txtFName.BorderStyle = BorderStyle.FixedSingle;
            txtFName.Location = new Point(132, 116);
            txtFName.Name = "txtFName";
            txtFName.Size = new Size(250, 23);
            txtFName.TabIndex = 4;
            txtFName.TextChanged += textBox2_TextChanged;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(23, 164);
            label3.Name = "label3";
            label3.Size = new Size(80, 19);
            label3.TabIndex = 5;
            label3.Text = "⚤ Gender:";
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
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(33, 33, 33);
            label4.Location = new Point(23, 206);
            label4.Name = "label4";
            label4.Size = new Size(104, 19);
            label4.TabIndex = 7;
            label4.Text = "📅 Birth Date:";
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
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(33, 33, 33);
            label5.Location = new Point(23, 253);
            label5.Name = "label5";
            label5.Size = new Size(91, 19);
            label5.TabIndex = 9;
            label5.Text = "💼 Position:";
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
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label6.ForeColor = Color.FromArgb(33, 33, 33);
            label6.Location = new Point(23, 297);
            label6.Name = "label6";
            label6.Size = new Size(80, 19);
            label6.TabIndex = 11;
            label6.Text = "💰 Salary:";
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
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(33, 33, 33);
            label7.Location = new Point(23, 337);
            label7.Name = "label7";
            label7.Size = new Size(77, 19);
            label7.TabIndex = 13;
            label7.Text = "🔄 Status:";
            // 
            // txtStatus
            // 
            txtStatus.ForeColor = Color.FromArgb(33, 33, 33);
            txtStatus.Location = new Point(120, 337);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(100, 20);
            txtStatus.TabIndex = 14;
            txtStatus.Text = "Inactive";
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
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(0, 150, 136);
            label8.Location = new Point(20, 7);
            label8.Name = "label8";
            label8.Size = new Size(351, 45);
            label8.TabIndex = 0;
            label8.Text = "👥 Staff Management";
            label8.TextAlign = ContentAlignment.MiddleCenter;
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
            Controls.Add(label8);
            Controls.Add(label1);
            Controls.Add(txtId);
            Controls.Add(label2);
            Controls.Add(txtFName);
            Controls.Add(label3);
            Controls.Add(genderPanel);
            Controls.Add(label4);
            Controls.Add(dtpDOB);
            Controls.Add(label5);
            Controls.Add(txtPos);
            Controls.Add(label6);
            Controls.Add(txtSalary);
            Controls.Add(label7);
            Controls.Add(txtStatus);
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
        private Label label1;
        private Label label2;
        private TextBox txtFName;
        private RadioButton rdoF;
        private Label label3;
        private RadioButton rdoM;
        private Label label4;
        private DateTimePicker dtpDOB;
        private Label label5;
        private TextBox txtPos;
        private Label label6;
        private TextBox txtSalary;
        private Label label7;
        private CheckBox txtStatus;
        private PictureBox pBox;
        private Label label8;
        private Button btnAdd;
        private DataGridView dgv;
        private Button btnEdit;
        private Button btnDelete;
        private Panel genderPanel;
        private Label photoLabel;
        private Button btnView;
    }
}