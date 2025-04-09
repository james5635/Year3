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
            label6 = new Label();
            textBox6 = new TextBox();
            label5 = new Label();
            textBox5 = new TextBox();
            button2 = new Button();
            button1 = new Button();
            dataGridView1 = new DataGridView();
            label3 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox4 = new TextBox();
            label8 = new Label();
            label2 = new Label();
            label1 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(22, 278);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(51, 15);
            label6.TabIndex = 76;
            label6.Text = "Amount";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(106, 275);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(140, 23);
            textBox6.TabIndex = 75;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(22, 239);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(33, 15);
            label5.TabIndex = 74;
            label5.Text = "Price";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(106, 236);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(140, 23);
            textBox5.TabIndex = 73;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.Add;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(709, 199);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 72;
            button2.Text = "Add";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Edit;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(709, 116);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 71;
            button1.Text = "Edit";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(17, 319);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(767, 250);
            dataGridView1.TabIndex = 70;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 199);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(26, 15);
            label3.TabIndex = 69;
            label3.Text = "Qty";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(106, 196);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(140, 23);
            textBox3.TabIndex = 68;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 157);
            label4.Name = "label4";
            label4.Size = new Size(57, 15);
            label4.TabIndex = 67;
            label4.Text = "ProName";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(106, 154);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(242, 23);
            textBox4.TabIndex = 66;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Ink Free", 21.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Blue;
            label8.Location = new Point(255, 9);
            label8.Name = "label8";
            label8.Size = new Size(385, 36);
            label8.TabIndex = 65;
            label8.Text = "ImportDetail's Information";
            label8.Click += label8_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 116);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(53, 15);
            label2.TabIndex = 64;
            label2.Text = "ProCode";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 74);
            label1.Name = "label1";
            label1.Size = new Size(56, 15);
            label1.TabIndex = 63;
            label1.Text = "ImpCode";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(106, 71);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(101, 23);
            textBox1.TabIndex = 62;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(106, 113);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(101, 23);
            textBox2.TabIndex = 77;
            // 
            // frmImportDetail
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 579);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(textBox6);
            Controls.Add(label5);
            Controls.Add(textBox5);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(label3);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox4);
            Controls.Add(label8);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Name = "frmImportDetail";
            Text = "frmImportDetail";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label6;
        private TextBox textBox6;
        private Label label5;
        private TextBox textBox5;
        private Button button2;
        private Button button1;
        private DataGridView dataGridView1;
        private Label label3;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox4;
        private Label label8;
        private Label label2;
        private Label label1;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}