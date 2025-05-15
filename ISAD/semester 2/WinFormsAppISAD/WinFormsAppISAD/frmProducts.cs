using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsAppISAD
{
    public partial class frmProducts : Form
    {
        const string connStr = "Server=.;Database=WinFormsAppISAD; User=sa; Password=james@2025; TrustServerCertificate=True;";
        private bool isEditing = false;
        private TextBox txtSearch = null!;

        public frmProducts()
        {
            InitializeComponent();
            InitializeSearchBox();
            ConfigureDataGridView();
            SqlDependency.Start(connStr);
            loadData();
            ClearForm();

            // Set placeholder texts
            textBox1.PlaceholderText = "Enter Product Code";
            textBox2.PlaceholderText = "Enter Product Name";
            textBox3.PlaceholderText = "Enter Quantity";
            textBox4.PlaceholderText = "Enter Unit Price (Stock)";
            textBox5.PlaceholderText = "Enter Sale Price";

            // Add keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown!;
        }

        private void InitializeSearchBox()
        {
            txtSearch = new TextBox();
            txtSearch.Location = new Point(dataGridView1.Location.X, dataGridView1.Location.Y - 30);
            txtSearch.Size = new Size(200, 23);
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.TextChanged += TxtSearch_TextChanged!;
            this.Controls.Add(txtSearch);
        }

        private void ConfigureDataGridView()
        {
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80);
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.White;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.BorderStyle = BorderStyle.None;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
            dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dataGridView1.ColumnHeadersHeight = 40;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dataGridView1.DataSource is DataTable dt)
            {
                string searchStr = string.Format("Name LIKE '%{0}%'", 
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

                using (SqlCommand com = new SqlCommand("spGetAllProduct", conn))
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
                        dataGridView1.Columns["Product code"].HeaderText = "Code";
                        dataGridView1.Columns["Name"].HeaderText = "Product Name";
                        dataGridView1.Columns["Quantity"].HeaderText = "Stock Qty";
                        dataGridView1.Columns["Unit price in stock"].HeaderText = "Unit Price";
                        dataGridView1.Columns["Sale unit price"].HeaderText = "Sale Price";

                        // Format currency columns
                        dataGridView1.Columns["Unit price in stock"].DefaultCellStyle.Format = "C2";
                        dataGridView1.Columns["Sale unit price"].DefaultCellStyle.Format = "C2";
                    }
                }
            }
        }

        private void ClearForm()
        {
            isEditing = false;
            textBox1.Clear(); // Product Code
            textBox2.Clear(); // Name
            textBox3.Clear(); // Quantity
            textBox4.Clear(); // Unit Price
            textBox5.Clear(); // Sale Price
            textBox1.Enabled = true;
            button2.Text = "➕ Add";
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
                throw new Exception("Product Code is required.");
            if (!int.TryParse(textBox1.Text, out _))
                throw new Exception("Product Code must be a number.");
            if (string.IsNullOrWhiteSpace(textBox2.Text))
                throw new Exception("Product Name is required.");
            if (string.IsNullOrWhiteSpace(textBox3.Text) || !short.TryParse(textBox3.Text, out short qty) || qty < 0)
                throw new Exception("Quantity must be a valid non-negative number.");
            if (string.IsNullOrWhiteSpace(textBox4.Text) || !decimal.TryParse(textBox4.Text, out decimal upis) || upis < 0)
                throw new Exception("Unit Price must be a valid non-negative number.");
            if (string.IsNullOrWhiteSpace(textBox5.Text) || !decimal.TryParse(textBox5.Text, out decimal sup) || sup < 0)
                throw new Exception("Sale Price must be a valid non-negative number.");
            if (sup < upis)
                throw new Exception("Sale Price cannot be less than Unit Price.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                using SqlConnection conn = new(connStr);
                string query = isEditing ? "spUpdateProduct" : "spInsertProduct";

                using SqlCommand cmd = new(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@code", int.Parse(textBox1.Text));
                cmd.Parameters.AddWithValue("@name", textBox2.Text.Trim());
                cmd.Parameters.AddWithValue("@qty", short.Parse(textBox3.Text));
                cmd.Parameters.AddWithValue("@UPIS", decimal.Parse(textBox4.Text));
                cmd.Parameters.AddWithValue("@SUP", decimal.Parse(textBox5.Text));

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        isEditing ? "Product updated successfully! 🎉" : "Product added successfully! 🎉",
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
                MessageBox.Show("Please select a product to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {                var row = dataGridView1.CurrentRow;
                textBox1.Text = row.Cells["Product code"].Value?.ToString() ?? "";
                textBox2.Text = row.Cells["Name"].Value?.ToString() ?? "";
                textBox3.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                textBox4.Text = row.Cells["Unit price in stock"].Value?.ToString() ?? "";
                textBox5.Text = row.Cells["Sale unit price"].Value?.ToString() ?? "";

                isEditing = true;
                textBox1.Enabled = false;
                button2.Text = "✏️ Update";
                textBox2.Text = row.Cells["Name"].Value?.ToString() ?? "";
                textBox3.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                textBox4.Text = row.Cells["Unit price in stock"].Value?.ToString() ?? "";
                textBox5.Text = row.Cells["Sale unit price"].Value?.ToString() ?? "";

                isEditing = true;
                textBox1.Enabled = false;
                button2.Text = "✏️ Update";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading product data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmProducts_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
