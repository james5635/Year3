namespace WinFormsAppISAD
{
    partial class frmProducts
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
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            dgv = new DataGridView();
            lblUPIS = new Label();
            txtUPIS = new TextBox();
            lblQty = new Label();
            txtQty = new TextBox();
            lblProductM = new Label();
            lblName = new Label();
            txtName = new TextBox();
            lblCode = new Label();
            txtCode = new TextBox();
            lblSUP = new Label();
            txtSUP = new TextBox();
            btnUpdate = new Button();
            btnAdd = new Button();
            btnEdit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
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
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            dgv.ColumnHeadersHeight = 40;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.Location = new Point(14, 326);
            dgv.Name = "dgv";
            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dgv.RowTemplate.Height = 30;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new Size(655, 254);
            dgv.TabIndex = 40;
            // 
            // lblUPIS
            // 
            lblUPIS.AutoSize = true;
            lblUPIS.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblUPIS.ForeColor = Color.FromArgb(33, 33, 33);
            lblUPIS.Location = new Point(17, 201);
            lblUPIS.Name = "lblUPIS";
            lblUPIS.Size = new Size(81, 15);
            lblUPIS.TabIndex = 39;
            lblUPIS.Text = "💰 Unit Price:";
            // 
            // txtUPIS
            // 
            txtUPIS.BackColor = Color.FromArgb(245, 245, 245);
            txtUPIS.BorderStyle = BorderStyle.FixedSingle;
            txtUPIS.Location = new Point(117, 198);
            txtUPIS.Name = "txtUPIS";
            txtUPIS.Size = new Size(146, 23);
            txtUPIS.TabIndex = 38;
            // 
            // lblQty
            // 
            lblQty.AutoSize = true;
            lblQty.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblQty.ForeColor = Color.FromArgb(33, 33, 33);
            lblQty.Location = new Point(17, 159);
            lblQty.Name = "lblQty";
            lblQty.Size = new Size(74, 15);
            lblQty.TabIndex = 37;
            lblQty.Text = "📊 Quantity:";
            // 
            // txtQty
            // 
            txtQty.BackColor = Color.FromArgb(245, 245, 245);
            txtQty.BorderStyle = BorderStyle.FixedSingle;
            txtQty.Location = new Point(106, 156);
            txtQty.Name = "txtQty";
            txtQty.Size = new Size(120, 23);
            txtQty.TabIndex = 36;
            // 
            // lblProductM
            // 
            lblProductM.AutoSize = true;
            lblProductM.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductM.ForeColor = Color.FromArgb(0, 150, 136);
            lblProductM.Location = new Point(65, 9);
            lblProductM.Name = "lblProductM";
            lblProductM.Size = new Size(400, 45);
            lblProductM.TabIndex = 35;
            lblProductM.Text = "📦 Product Management";
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
            lblName.Text = "📝 Name:";
            // 
            // txtName
            // 
            txtName.BackColor = Color.FromArgb(245, 245, 245);
            txtName.BorderStyle = BorderStyle.FixedSingle;
            txtName.Location = new Point(95, 115);
            txtName.Name = "txtName";
            txtName.Size = new Size(250, 23);
            txtName.TabIndex = 33;
            // 
            // lblCode
            // 
            lblCode.AutoSize = true;
            lblCode.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCode.ForeColor = Color.FromArgb(33, 33, 33);
            lblCode.Location = new Point(17, 76);
            lblCode.Name = "lblCode";
            lblCode.Size = new Size(54, 15);
            lblCode.TabIndex = 32;
            lblCode.Text = "🔑 Code:";
            // 
            // txtCode
            // 
            txtCode.BackColor = Color.FromArgb(245, 245, 245);
            txtCode.BorderStyle = BorderStyle.FixedSingle;
            txtCode.Location = new Point(87, 73);
            txtCode.Name = "txtCode";
            txtCode.ReadOnly = true;
            txtCode.Size = new Size(120, 23);
            txtCode.TabIndex = 31;
            // 
            // lblSUP
            // 
            lblSUP.AutoSize = true;
            lblSUP.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblSUP.ForeColor = Color.FromArgb(33, 33, 33);
            lblSUP.Location = new Point(17, 251);
            lblSUP.Name = "lblSUP";
            lblSUP.Size = new Size(80, 15);
            lblSUP.TabIndex = 44;
            lblSUP.Text = "💰 Sale Price:";
            // 
            // txtSUP
            // 
            txtSUP.BackColor = Color.FromArgb(245, 245, 245);
            txtSUP.BorderStyle = BorderStyle.FixedSingle;
            txtSUP.Location = new Point(109, 248);
            txtSUP.Name = "txtSUP";
            txtSUP.Size = new Size(142, 23);
            txtSUP.TabIndex = 43;
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
            btnUpdate.Location = new Point(569, 225);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(100, 35);
            btnUpdate.TabIndex = 47;
            btnUpdate.Text = "✏️ Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnAddOrUp_Click;
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
            btnAdd.Location = new Point(569, 84);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(100, 35);
            btnAdd.TabIndex = 46;
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
            btnEdit.Location = new Point(569, 155);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(100, 35);
            btnEdit.TabIndex = 45;
            btnEdit.Text = "✏️ Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 592);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(lblSUP);
            Controls.Add(txtSUP);
            Controls.Add(lblUPIS);
            Controls.Add(txtUPIS);
            Controls.Add(lblQty);
            Controls.Add(txtQty);
            Controls.Add(lblProductM);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblCode);
            Controls.Add(txtCode);
            Controls.Add(dgv);
            Name = "frmProducts";
            Text = "📦 Product Management";
            Load += frmProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private DataGridView dgv;
        private Label lblUPIS;
        private TextBox txtUPIS;
        private Label lblQty;
        private TextBox txtQty;
        private Label lblProductM;
        private Label lblName;
        private TextBox txtName;
        private Label lblCode;
        private TextBox txtCode;
        private Label lblSUP;
        private TextBox txtSUP;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnEdit;
    }
}