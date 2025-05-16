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
            txtName.PlaceholderText = "Enter Product Name";
            txtUPIS.PlaceholderText = "Enter Quantity";
            txtQty.PlaceholderText = "Enter Unit Price (Stock)";
            txtSUP.PlaceholderText = "Enter Sale Price";

            // Add keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown!;
        }

        private void InitializeSearchBox()
        {
            txtSearch = new TextBox();
            txtSearch.Location = new Point(dgv.Location.X, dgv.Location.Y - 30);
            txtSearch.Size = new Size(200, 23);
            txtSearch.PlaceholderText = "Search products...";
            txtSearch.TextChanged += TxtSearch_TextChanged!;
            this.Controls.Add(txtSearch);
        }

        private void ConfigureDataGridView()
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(76, 175, 80);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(76, 175, 80);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 40;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgv.DataSource is DataTable dt)
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
                        btnAdd.PerformClick(); // Add
                        break;
                    case Keys.E:
                        btnEdit.PerformClick(); // Edit
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
                    dgv.DataSource = dt;

                    if (dgv.Columns.Count > 0)
                    {
                        dgv.Columns["Product code"].HeaderText = "Code";
                        dgv.Columns["Name"].HeaderText = "Product Name";
                        dgv.Columns["Quantity"].HeaderText = "Stock Qty";
                        dgv.Columns["Unit price in stock"].HeaderText = "Unit Price";
                        dgv.Columns["Sale unit price"].HeaderText = "Sale Price";

                        // Format currency columns
                        dgv.Columns["Unit price in stock"].DefaultCellStyle.Format = "C2";
                        dgv.Columns["Sale unit price"].DefaultCellStyle.Format = "C2";
                    }
                }
            }
        }

        private void ClearForm()
        {
            isEditing = false;
            txtCode.Clear(); // Product Code
            txtName.Clear(); // Name
            txtUPIS.Clear(); // Quantity
            txtQty.Clear(); // Unit Price
            txtSUP.Clear(); // Sale Price
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnUpdate.Enabled = false;

        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtName.Text))
                throw new Exception("Product Name is required.");
            if (string.IsNullOrWhiteSpace(txtQty.Text) || !short.TryParse(txtQty.Text, out short qty) || qty < 0)
                throw new Exception("Quantity must be a valid non-negative number.");
            if (string.IsNullOrWhiteSpace(txtUPIS.Text) || !decimal.TryParse(txtUPIS.Text, out decimal uprice) || uprice < 0)
                throw new Exception("Unit Price must be a valid non-negative number.");
            if (string.IsNullOrWhiteSpace(txtSUP.Text) || !decimal.TryParse(txtSUP.Text, out decimal sprice) || sprice < 0)
                throw new Exception("Sale Price must be a valid non-negative number.");

        }

        private void btnAddOrUp_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                using SqlConnection conn = new(connStr);
                string query = isEditing ? "spUpdateProduct" : "spInsertProduct";

                using SqlCommand cmd = new(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                if (isEditing)
                    cmd.Parameters.AddWithValue("@code", int.Parse(txtCode.Text));
                cmd.Parameters.AddWithValue("@name", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@qty", short.Parse(txtQty.Text));
                cmd.Parameters.AddWithValue("@UPIS", decimal.Parse(txtUPIS.Text));
                cmd.Parameters.AddWithValue("@SUP", decimal.Parse(txtSUP.Text));

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Please select a product to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var row = dgv.CurrentRow;
                txtCode.Text = row.Cells["Product code"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtQty.Text = row.Cells["Quantity"].Value?.ToString() ?? "";
                txtUPIS.Text = row.Cells["Unit price in stock"].Value is decimal UPIS ? $"{UPIS:F2}" : "";
                txtSUP.Text = row.Cells["Sale unit price"].Value is decimal SUP ? $"{SUP:F2}" : "";

                isEditing = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false;
                btnUpdate.Enabled = true;


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

    }
}
