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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label8 = new Label();
            label2 = new Label();
            textBox2 = new TextBox();
            label1 = new Label();
            textBox1 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            //            // button2
            // 
            button2.BackColor = Color.FromArgb(76, 175, 80);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button2.ForeColor = Color.White;
            button2.Image = Properties.Resources.Add;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(502, 243);
            button2.Name = "button2";
            button2.Size = new Size(100, 35);
            button2.TabIndex = 42;            button2.Text = "➕ Add";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            //            // button1
            // 
            button1.BackColor = Color.FromArgb(33, 150, 243);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button1.ForeColor = Color.White;
            button1.Image = Properties.Resources.Edit;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(502, 197);
            button1.Name = "button1";
            button1.Size = new Size(100, 35);
            button1.TabIndex = 41;            button1.Text = "✏️ Edit";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            button1.Click += button1_Click;
            //            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridViewCellStyle1.SelectionForeColor = Color.White;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dataGridView1.ColumnHeadersHeight = 40;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.            Location = new Point(12, 297);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;            dataGridView1.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridView1.RowTemplate.Height = 30;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(657, 250);
            dataGridView1.TabIndex = 40;
            //            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(33, 33, 33);
            label3.Location = new Point(17, 201);
            label3.Name = "label3";
            label3.Size = new Size(31, 15);
            label3.TabIndex = 39;
            label3.Text = "💰 Unit Price:";
            //            // textBox3
            // 
            textBox3.BackColor = Color.FromArgb(245, 245, 245);
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(120, 198);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(120, 23);
            textBox3.TabIndex = 38;
            //            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label4.ForeColor = Color.FromArgb(33, 33, 33);
            label4.Location = new Point(17, 159);
            label4.Name = "label4";
            label4.Size = new Size(26, 15);
            label4.TabIndex = 37;
            label4.Text = "📊 Quantity:";
            //            // textBox4
            // 
            textBox4.BackColor = Color.FromArgb(245, 245, 245);
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(120, 156);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(120, 23);
            textBox4.TabIndex = 36;
            //            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.FromArgb(0, 150, 136);
            label8.Location = new Point(192, 9);
            label8.Name = "label8";
            label8.Size = new Size(306, 36);
            label8.TabIndex = 35;
            label8.Text = "📦 Product Management";
            //            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label2.ForeColor = Color.FromArgb(33, 33, 33);
            label2.Location = new Point(17, 118);
            label2.Name = "label2";
            label2.Size = new Size(57, 15);
            label2.TabIndex = 34;
            label2.Text = "📝 Name:";
            //            // textBox2
            // 
            textBox2.BackColor = Color.FromArgb(245, 245, 245);
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(120, 115);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(250, 23);
            textBox2.TabIndex = 33;
            //            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label1.ForeColor = Color.FromArgb(33, 33, 33);
            label1.Location = new Point(17, 76);
            label1.Name = "label1";
            label1.Size = new Size(53, 15);
            label1.TabIndex = 32;
            label1.Text = "🔑 Code:";
            //            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(245, 245, 245);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(120, 73);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(120, 23);
            textBox1.TabIndex = 31;
            //            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(33, 33, 33);
            label5.Location = new Point(17, 251);
            label5.Name = "label5";
            label5.Size = new Size(28, 15);
            label5.TabIndex = 44;
            label5.Text = "🏢 Supplier:";
            //            // textBox5
            // 
            textBox5.BackColor = Color.FromArgb(245, 245, 245);
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(120, 248);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(120, 23);
            textBox5.TabIndex = 43;
            // 
            // frmProducts
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(681, 559);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(dataGridView1);            Name = "frmProducts";
            Text = "📦 Product Management";
            Load += frmProducts_Load;
            Load += frmProducts_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label8;
        private Label label2;
        private TextBox textBox2;
        private Label label1;
        private TextBox textBox1;
        private Label label5;
        private TextBox textBox5;
    }
}