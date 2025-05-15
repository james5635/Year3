namespace WinFormsAppISAD
{
    partial class frmSuppliers
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
            lblManagement = new Label();
            lblSupName = new Label();
            txtSupName = new TextBox();
            lblSupID = new Label();
            txtSupID = new TextBox();
            lblCont = new Label();
            txtCont = new TextBox();
            lblAddr = new Label();
            txtAddr = new TextBox();
            dgv = new DataGridView();
            btnAdd = new Button();
            btnEdit = new Button();
            btnUpdate = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // lblManagement
            // 
            lblManagement.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblManagement.ForeColor = Color.FromArgb(0, 150, 136);
            lblManagement.Location = new Point(20, 7);
            lblManagement.Name = "lblManagement";
            lblManagement.Size = new Size(426, 45);
            lblManagement.TabIndex = 23;
            lblManagement.Text = "🏢 Supplier Management";
            // 
            // lblSupName
            // 
            lblSupName.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSupName.ForeColor = Color.FromArgb(33, 33, 33);
            lblSupName.Location = new Point(23, 116);
            lblSupName.Name = "lblSupName";
            lblSupName.Size = new Size(141, 19);
            lblSupName.TabIndex = 22;
            lblSupName.Text = "👥 Supplier Name:";
            // 
            // txtSupName
            // 
            txtSupName.BackColor = Color.FromArgb(245, 245, 245);
            txtSupName.BorderStyle = BorderStyle.FixedSingle;
            txtSupName.Location = new Point(172, 116);
            txtSupName.Name = "txtSupName";
            txtSupName.Size = new Size(411, 23);
            txtSupName.TabIndex = 21;
            // 
            // lblSupID
            // 
            lblSupID.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblSupID.ForeColor = Color.FromArgb(33, 33, 33);
            lblSupID.Location = new Point(23, 74);
            lblSupID.Name = "lblSupID";
            lblSupID.Size = new Size(125, 19);
            lblSupID.TabIndex = 20;
            lblSupID.Text = "🆔 Supplier ID:";
            // 
            // txtSupID
            // 
            txtSupID.BackColor = Color.FromArgb(245, 245, 245);
            txtSupID.BorderStyle = BorderStyle.FixedSingle;
            txtSupID.Location = new Point(153, 74);
            txtSupID.Name = "txtSupID";
            txtSupID.ReadOnly = true;
            txtSupID.Size = new Size(150, 23);
            txtSupID.TabIndex = 19;
            // 
            // lblCont
            // 
            lblCont.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblCont.ForeColor = Color.FromArgb(33, 33, 33);
            lblCont.Location = new Point(23, 199);
            lblCont.Name = "lblCont";
            lblCont.Size = new Size(90, 19);
            lblCont.TabIndex = 27;
            lblCont.Text = "📞 Contact:";
            // 
            // txtCont
            // 
            txtCont.BackColor = SystemColors.Control;
            txtCont.BorderStyle = BorderStyle.FixedSingle;
            txtCont.Location = new Point(120, 196);
            txtCont.Name = "txtCont";
            txtCont.Size = new Size(463, 23);
            txtCont.TabIndex = 26;
            // 
            // lblAddr
            // 
            lblAddr.BackColor = SystemColors.Control;
            lblAddr.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblAddr.ForeColor = Color.Black;
            lblAddr.Location = new Point(23, 157);
            lblAddr.Name = "lblAddr";
            lblAddr.Size = new Size(113, 19);
            lblAddr.TabIndex = 25;
            lblAddr.Text = "📍  Address:";
            // 
            // txtAddr
            // 
            txtAddr.BackColor = Color.FromArgb(245, 245, 245);
            txtAddr.BorderStyle = BorderStyle.FixedSingle;
            txtAddr.Location = new Point(153, 157);
            txtAddr.Name = "txtAddr";
            txtAddr.Size = new Size(430, 23);
            txtAddr.TabIndex = 24;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new Point(21, 274);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.Size = new Size(702, 320);
            dgv.TabIndex = 28;
            dgv.CellClick += dgv_CellClick;
            dgv.CellContentClick += dgv_CellContentClick;
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
            btnAdd.Location = new Point(624, 58);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 30;
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
            btnEdit.Location = new Point(623, 121);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 29;
            btnEdit.Text = "✏️ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
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
            btnUpdate.Location = new Point(623, 183);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 31;
            btnUpdate.Text = "✏️ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnAddOrUp_Click;
            // 
            // frmSuppliers
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(736, 606);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(dgv);
            Controls.Add(lblCont);
            Controls.Add(txtCont);
            Controls.Add(lblAddr);
            Controls.Add(txtAddr);
            Controls.Add(lblManagement);
            Controls.Add(lblSupName);
            Controls.Add(txtSupName);
            Controls.Add(lblSupID);
            Controls.Add(txtSupID);
            Name = "frmSuppliers";
            Text = "frmSuppliers";
            Load += frmSuppliers_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblManagement;
        private Label lblSupName;
        private TextBox txtSupName;
        private Label lblSupID;
        private TextBox txtSupID;
        private Label lblCont;
        private TextBox txtCont;
        private Label lblAddr;
        private TextBox txtAddr;
        private DataGridView dgv;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnUpdate;
    }
}