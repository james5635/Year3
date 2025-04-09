namespace WinFormsAppISAD
{
    partial class frmPayments
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
            label6 = new Label();
            textBox6 = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(17, 238);
            label5.Name = "label5";
            label5.RightToLeft = RightToLeft.Yes;
            label5.Size = new Size(55, 15);
            label5.TabIndex = 58;
            label5.Text = "OrdCode";
            // 
            // textBox5
            // 
            textBox5.Location = new Point(101, 235);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(140, 23);
            textBox5.TabIndex = 57;
            // 
            // button2
            // 
            button2.Image = Properties.Resources.Add;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(704, 198);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 56;
            button2.Text = "Add";
            button2.TextAlign = ContentAlignment.MiddleRight;
            button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            button1.Image = Properties.Resources.Edit;
            button1.ImageAlign = ContentAlignment.MiddleLeft;
            button1.Location = new Point(704, 115);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 55;
            button1.Text = "Edit";
            button1.TextAlign = ContentAlignment.MiddleRight;
            button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(12, 318);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(767, 250);
            dataGridView1.TabIndex = 54;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(17, 198);
            label3.Name = "label3";
            label3.RightToLeft = RightToLeft.Yes;
            label3.Size = new Size(58, 15);
            label3.TabIndex = 53;
            label3.Text = "FullName";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(101, 195);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(140, 23);
            textBox3.TabIndex = 52;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(17, 156);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 51;
            label4.Text = "staffID";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(101, 153);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(242, 23);
            textBox4.TabIndex = 50;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Ink Free", 21.7499962F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Blue;
            label8.Location = new Point(250, 8);
            label8.Name = "label8";
            label8.Size = new Size(318, 36);
            label8.TabIndex = 49;
            label8.Text = "Payment's Information";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(17, 115);
            label2.Name = "label2";
            label2.RightToLeft = RightToLeft.Yes;
            label2.Size = new Size(50, 15);
            label2.TabIndex = 48;
            label2.Text = "PayDate";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(17, 73);
            label1.Name = "label1";
            label1.Size = new Size(54, 15);
            label1.TabIndex = 46;
            label1.Text = "PayCode";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(101, 70);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(101, 23);
            textBox1.TabIndex = 45;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(17, 277);
            label6.Name = "label6";
            label6.RightToLeft = RightToLeft.Yes;
            label6.Size = new Size(51, 15);
            label6.TabIndex = 60;
            label6.Text = "Amount";
            // 
            // textBox6
            // 
            textBox6.Location = new Point(101, 274);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(140, 23);
            textBox6.TabIndex = 59;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(110, 115);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 61;
            // 
            // frmPayments
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 580);
            Controls.Add(dateTimePicker1);
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
            Name = "frmPayments";
            Text = "frmPayments";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

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
        private Label label6;
        private TextBox textBox6;
        private DateTimePicker dateTimePicker1;
    }
}