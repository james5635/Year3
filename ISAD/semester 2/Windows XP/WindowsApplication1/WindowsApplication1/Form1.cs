using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Microsoft.VisualBasic;
namespace WindowsApplication1
{
    public class InputBox : Form
    {
        private TextBox inputTextBox;
        private Button okButton;
        private Button cancelButton;
        private Label promptLabel;

        public string userInput;
        public string UserInput { get { return userInput; } set { userInput = value; } }

        public InputBox(string prompt)
    {
        this.Text = "Input Required";
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Width = 300;
        this.Height = 150;

        promptLabel = new Label();
            
        promptLabel.Text = prompt;
           promptLabel.Left = 10;
           promptLabel.Top = 10;
           promptLabel.Width = 260;
        inputTextBox = new TextBox();
        inputTextBox.Left = 10;
           inputTextBox.Top = 35;
           inputTextBox.Width = 260 ;

        okButton = new Button();
           okButton.Text = "OK";
           okButton.Left = 75;
           okButton.Top = 70;
           okButton. Width = 70 ;
        cancelButton = new Button ();
            cancelButton. Text = "Cancel";
           cancelButton. Left = 155;
           cancelButton. Top = 70;
           cancelButton. Width = 70 ;

        okButton.Click += delegate (object sender,EventArgs e){ UserInput = inputTextBox.Text; this.DialogResult = DialogResult.OK; };
        cancelButton.Click += delegate (object sender,EventArgs e)  { this.DialogResult = DialogResult.Cancel; };

        this.Controls.Add(promptLabel);
        this.Controls.Add(inputTextBox);
        this.Controls.Add(okButton);
        this.Controls.Add(cancelButton);
    }
     
        public static string Show(string prompt)
        {
            using (InputBox inputBox = new InputBox(prompt))
            {
                return inputBox.ShowDialog() == DialogResult.OK ? inputBox.UserInput : string.Empty;
            }
        }
    }


    public partial class Form1 : Form
    {
        string connectionString = "Server=localhost\\SQLEXPRESS;Database=Test;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT * FROM Person";
                //using (SqlCommand cmd = new SqlCommand(sql, conn))
                //{
                //    using (SqlDataReader reader = cmd.ExecuteReader()){
                //        while (reader.Read())
                //        {
                //            MessageBox.Show(reader[0] + " - " + reader[1]);
                //        }
                //    }
                //}
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string name = InputBox.Show("Enter name");
                string sql = String.Format("INSERT INTO Person VALUES('{0}')", name);
                using(SqlCommand cmd = new SqlCommand(sql, conn)){
                    cmd.ExecuteNonQuery();
                }
                
            }
        }
    }
}
