﻿namespace WinFormsAppISAD
{
    partial class frmStart
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnStaffM = new Button();
            btnSupplierM = new Button();
            btnCustomerM = new Button();
            btnProductM = new Button();
            btnImportDetailInformation = new Button();
            btnInvoiceDetailInformation = new Button();
            SuspendLayout();
            // 
            // btnStaffM
            // 
            btnStaffM.BackColor = Color.FromArgb(76, 175, 80);
            btnStaffM.Cursor = Cursors.Hand;
            btnStaffM.FlatAppearance.BorderSize = 0;
            btnStaffM.FlatStyle = FlatStyle.Flat;
            btnStaffM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnStaffM.ForeColor = Color.White;
            btnStaffM.ImageAlign = ContentAlignment.MiddleLeft;
            btnStaffM.Location = new Point(12, 12);
            btnStaffM.Name = "btnStaffM";
            btnStaffM.Size = new Size(260, 35);
            btnStaffM.TabIndex = 43;
            btnStaffM.Text = "👥 Staff Management";
            btnStaffM.UseVisualStyleBackColor = false;
            btnStaffM.Click += btnStaffM_Click;
            // 
            // btnSupplierM
            // 
            btnSupplierM.BackColor = Color.DarkCyan;
            btnSupplierM.Cursor = Cursors.Hand;
            btnSupplierM.FlatAppearance.BorderSize = 0;
            btnSupplierM.FlatStyle = FlatStyle.Flat;
            btnSupplierM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSupplierM.ForeColor = Color.White;
            btnSupplierM.ImageAlign = ContentAlignment.MiddleLeft;
            btnSupplierM.Location = new Point(12, 70);
            btnSupplierM.Name = "btnSupplierM";
            btnSupplierM.Size = new Size(260, 35);
            btnSupplierM.TabIndex = 44;
            btnSupplierM.Text = "🏢 Supplier Management";
            btnSupplierM.UseVisualStyleBackColor = false;
            btnSupplierM.Click += btnSupplierM_Click;
            // 
            // btnCustomerM
            // 
            btnCustomerM.BackColor = Color.Brown;
            btnCustomerM.Cursor = Cursors.Hand;
            btnCustomerM.FlatAppearance.BorderSize = 0;
            btnCustomerM.FlatStyle = FlatStyle.Flat;
            btnCustomerM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnCustomerM.ForeColor = Color.White;
            btnCustomerM.ImageAlign = ContentAlignment.MiddleLeft;
            btnCustomerM.Location = new Point(12, 130);
            btnCustomerM.Name = "btnCustomerM";
            btnCustomerM.Size = new Size(260, 35);
            btnCustomerM.TabIndex = 45;
            btnCustomerM.Text = "👥 Customer Management";
            btnCustomerM.UseVisualStyleBackColor = false;
            btnCustomerM.Click += btnCustomerM_Click;
            // 
            // btnProductM
            // 
            btnProductM.BackColor = Color.DarkSlateBlue;
            btnProductM.Cursor = Cursors.Hand;
            btnProductM.FlatAppearance.BorderSize = 0;
            btnProductM.FlatStyle = FlatStyle.Flat;
            btnProductM.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnProductM.ForeColor = Color.White;
            btnProductM.ImageAlign = ContentAlignment.MiddleLeft;
            btnProductM.Location = new Point(12, 189);
            btnProductM.Name = "btnProductM";
            btnProductM.Size = new Size(260, 35);
            btnProductM.TabIndex = 46;
            btnProductM.Text = "📦 Product Management";
            btnProductM.UseVisualStyleBackColor = false;
            btnProductM.Click += btnProductM_Click;
            // 
            // btnImportDetailInformation
            // 
            btnImportDetailInformation.BackColor = Color.Olive;
            btnImportDetailInformation.Cursor = Cursors.Hand;
            btnImportDetailInformation.FlatAppearance.BorderSize = 0;
            btnImportDetailInformation.FlatStyle = FlatStyle.Flat;
            btnImportDetailInformation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnImportDetailInformation.ForeColor = Color.White;
            btnImportDetailInformation.ImageAlign = ContentAlignment.MiddleLeft;
            btnImportDetailInformation.Location = new Point(12, 248);
            btnImportDetailInformation.Name = "btnImportDetailInformation";
            btnImportDetailInformation.Size = new Size(260, 35);
            btnImportDetailInformation.TabIndex = 47;
            btnImportDetailInformation.Text = "📋 ImportDetail's Information";
            btnImportDetailInformation.UseVisualStyleBackColor = false;
            btnImportDetailInformation.Click += btnImportDetailInformation_Click;
            // 
            // btnInvoiceDetailInformation
            // 
            btnInvoiceDetailInformation.BackColor = Color.Purple;
            btnInvoiceDetailInformation.Cursor = Cursors.Hand;
            btnInvoiceDetailInformation.FlatAppearance.BorderSize = 0;
            btnInvoiceDetailInformation.FlatStyle = FlatStyle.Flat;
            btnInvoiceDetailInformation.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnInvoiceDetailInformation.ForeColor = Color.White;
            btnInvoiceDetailInformation.ImageAlign = ContentAlignment.MiddleLeft;
            btnInvoiceDetailInformation.Location = new Point(12, 308);
            btnInvoiceDetailInformation.Name = "btnInvoiceDetailInformation";
            btnInvoiceDetailInformation.Size = new Size(260, 35);
            btnInvoiceDetailInformation.TabIndex = 48;
            btnInvoiceDetailInformation.Text = "📄 InvoiceDetail's Information";
            btnInvoiceDetailInformation.UseVisualStyleBackColor = false;
            btnInvoiceDetailInformation.Click += btnInvoiceDetailInformation_Click;
            // 
            // frmStart
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(290, 429);
            Controls.Add(btnInvoiceDetailInformation);
            Controls.Add(btnImportDetailInformation);
            Controls.Add(btnProductM);
            Controls.Add(btnCustomerM);
            Controls.Add(btnSupplierM);
            Controls.Add(btnStaffM);
            Name = "frmStart";
            Text = "Start";
            ResumeLayout(false);
        }

        #endregion

        private Button btnStaffM;
        private Button btnSupplierM;
        private Button btnCustomerM;
        private Button btnProductM;
        private Button btnImportDetailInformation;
        private Button btnInvoiceDetailInformation;
    }
}
