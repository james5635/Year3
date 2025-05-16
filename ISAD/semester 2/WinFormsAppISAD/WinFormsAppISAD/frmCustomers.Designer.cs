namespace WinFormsAppISAD
{
    partial class frmCustomers
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            btnAdd = new Button();
            btnEdit = new Button();
            dgv = new DataGridView();
            lblCont = new Label();
            txtCont = new TextBox();
            lblCM = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblID = new Label();
            txtID = new TextBox();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(76, 175, 80);
            btnAdd.Cursor = Cursors.Hand;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(388, 57);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 42;
            btnAdd.Text = "➕ Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAddOrUp_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(63, 81, 181);
            btnEdit.Cursor = Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = FlatStyle.Flat;
            btnEdit.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnEdit.ForeColor = Color.White;
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(388, 101);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 41;
            btnEdit.Text = "✏️ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles = false;
            dgv.GridColor = Color.FromArgb(224, 224, 224);
            dgv.Location = new Point(17, 236);
            dgv.Name = "dgv";
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dgv.RowTemplate.Height = 30;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(471, 283);
            dgv.TabIndex = 40;
            // 
            // lblCont
            // 
            lblCont.AutoSize = true;
            lblCont.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCont.ForeColor = Color.FromArgb(33, 33, 33);
            lblCont.Location = new Point(17, 160);
            lblCont.Name = "lblCont";
            lblCont.Size = new Size(69, 15);
            lblCont.TabIndex = 39;
            lblCont.Text = "📞 Contact:";
            // 
            // txtCont
            // 
            txtCont.BackColor = Color.FromArgb(245, 245, 245);
            txtCont.BorderStyle = BorderStyle.FixedSingle;
            txtCont.Location = new Point(99, 156);
            txtCont.Name = "txtCont";
            txtCont.Size = new Size(192, 23);
            txtCont.TabIndex = 38;
            // 
            // lblCM
            // 
            lblCM.AutoSize = true;
            lblCM.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCM.ForeColor = Color.FromArgb(0, 150, 136);
            lblCM.Location = new Point(17, 4);
            lblCM.Name = "lblCM";
            lblCM.Size = new Size(425, 45);
            lblCM.TabIndex = 35;
            lblCM.Text = "👥 Customer Management";
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(33, 33, 33);
            lblName.Location = new Point(17, 118);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 15);
            lblName.TabIndex = 34;
            lblName.Text = "👤 Name:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(245, 245, 245);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Location = new Point(91, 113);
            txtName.Name = "txtName";
            txtName.Size = new Size(200, 23);
            txtName.TabIndex = 33;
            // 
            // lblID
            // 
            lblID.AutoSize = true;
            lblID.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblID.ForeColor = Color.FromArgb(33, 33, 33);
            lblID.Location = new Point(17, 76);
            lblID.Name = "lblID";
            lblID.Size = new Size(39, 15);
            lblID.TabIndex = 32;
            lblID.Text = "🆔 ID:";
            // 
            // txtID
            // 
            txtID.BackColor = Color.FromArgb(245, 245, 245);
            txtID.BorderStyle = BorderStyle.FixedSingle;
            txtID.Enabled = false;
            txtID.Location = new Point(71, 74);
            txtID.Name = "txtID";
            txtID.ReadOnly = true;
            txtID.Size = new Size(100, 23);
            txtID.TabIndex = 31;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.FromArgb(0, 150, 136);
            btnUpdate.Cursor = Cursors.Hand;
            btnUpdate.Enabled = false;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.ImageAlign = ContentAlignment.MiddleLeft;
            btnUpdate.Location = new Point(388, 148);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 43;
            btnUpdate.Text = "✏️ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnAddOrUp_Click;
            // 
            // frmCustomers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 531);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(dgv);
            Controls.Add(lblCont);
            Controls.Add(txtCont);
            Controls.Add(lblCM);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblID);
            Controls.Add(txtID);
            Name = "frmCustomers";
            Text = "👥 Customer Management";
            Load += frmCustomers_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAdd;
        private Button btnEdit;
        private DataGridView dgv;
        private Label lblCont;
        private TextBox txtCont;
        private Label lblCM;
        private Label lblName;
        private TextBox txtName;
        private Label lblID;
        private TextBox txtID;
        private Button btnUpdate;
    }
}