using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsAppISAD
{
    public partial class frmCustomers : Form
    {
        const string connStr = "Server=.;Database=WinFormsAppISAD; User=sa; Password=james@2025; TrustServerCertificate=True;";
        private bool isEditing = false;
        private TextBox txtSearch = null!;

        public frmCustomers()
        {
            InitializeComponent();
            InitializeSearchBox();
            ConfigureDataGridView();
            SqlDependency.Start(connStr);
            loadData();
            ClearForm();

            // Set placeholder texts
            textBox1.PlaceholderText = "Enter Customer ID";
            textBox2.PlaceholderText = "Enter Customer Name";
            textBox3.PlaceholderText = "Enter Contact Number";

            // Add keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown!;
        }

        private void InitializeSearchBox()
        {
            txtSearch = new TextBox();
            txtSearch.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y - 30);
            txtSearch.Size = new Size(200, 23);
            txtSearch.PlaceholderText = "Search customers...";
            txtSearch.TextChanged += TxtSearch_TextChanged!;
            this.Controls.Add(txtSearch);
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersHeight = 40;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                string searchStr = string.Format("Name LIKE '%{0}%' OR Phone LIKE '%{0}%'",
                    txtSearch.Text.Replace("'", "''"));
                dt.DefaultView.RowFilter = searchStr;
            }
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.A:
                        button2.PerformClick(); // Add
                        break;
                    case Keys.E:
                        button1.PerformClick(); // Edit
                        break;
                }
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ClearForm();
            }
        }

        private void loadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                using (SqlCommand com = new SqlCommand("spGetAllCustomer", conn))
                {
                    com.CommandType = CommandType.StoredProcedure;

                    SqlDependency dep = new SqlDependency(com);
                    dep.OnChange += new OnChangeEventHandler(
                        (sender, e) => Invoke(new Action(loadData))
                    );

                    SqlDataAdapter dap = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    dataGridView1.DataSource = dt;

                    if (dataGridView1.Columns.Count > 0)
                    {
                        dataGridView1.Columns["cusID"].HeaderText = "ID";
                        dataGridView1.Columns["Name"].HeaderText = "Customer Name";
                        dataGridView1.Columns["Phone"].HeaderText = "Contact";
                    }
                }
            }
        }

        private void ClearForm()
        {
            isEditing = false;
            textBox1.Clear(); // ID
            textBox2.Clear(); // Name
            textBox3.Clear(); // Contact
            textBox1.Enabled = true;
            button2.Text = "➕ Add";
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                throw new Exception("Customer ID is required.");
            if (!int.TryParse(textBox1.Text, out _))
                throw new Exception("Customer ID must be a number.");
            if (string.IsNullOrWhiteSpace(textBox2.Text))
                throw new Exception("Customer Name is required.");
            if (string.IsNullOrWhiteSpace(textBox3.Text))
                throw new Exception("Contact number is required.");
            if (textBox3.Text.Length > 15)
                throw new Exception("Contact number cannot exceed 15 characters.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                using SqlConnection conn = new(connStr);
                string query = isEditing ? "spUpdateCustomer" : "spInsertCustomer";

                using SqlCommand cmd = new(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@cusName", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@cusContact", textBox3.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        isEditing ? "Customer updated successfully! 🎉" : "Customer added successfully! 🎉",
                        "Success",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var row = dataGridView1.CurrentRow;
                textBox1.Text = row.Cells["cusID"].Value?.ToString() ?? "";
                textBox2.Text = row.Cells["Name"].Value?.ToString() ?? "";
                textBox3.Text = row.Cells["Phone"].Value?.ToString() ?? "";

                isEditing = true;
                textBox1.Enabled = false;
                button2.Text = "✏️ Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading customer data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(connStr);
            loadData();
        }
    }
}
