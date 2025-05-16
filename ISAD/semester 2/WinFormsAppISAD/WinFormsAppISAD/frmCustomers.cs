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
            txtName.PlaceholderText = "Enter Customer Name";
            txtCont.PlaceholderText = "Enter Contact Number";

            // Add keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown!;
        }

        private void InitializeSearchBox()
        {
            txtSearch = new TextBox();
            txtSearch.Location = new Point(dgv.Location.X, dgv.Location.Y - 30);
            txtSearch.Size = new Size(200, 23);
            txtSearch.PlaceholderText = "Search customers...";
            txtSearch.TextChanged += TxtSearch_TextChanged!;
            this.Controls.Add(txtSearch);
        }

        private void ConfigureDataGridView()
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(33, 150, 243);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(33, 150, 243);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 40;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgv.DataSource is DataTable dt)
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
                    dgv.DataSource = dt;

                    if (dgv.Columns.Count > 0)
                    {
                        dgv.Columns["cusID"].HeaderText = "ID";
                        dgv.Columns["Name"].HeaderText = "Customer Name";
                        dgv.Columns["Phone"].HeaderText = "Contact";
                    }
                }
            }
        }

        private void ClearForm()
        {
            isEditing = false;
            txtID.Clear(); // ID
            txtName.Clear(); // Name
            txtCont.Clear(); // Contact
            txtID.Enabled = true;
            btnUpdate.Enabled = false; // Disable update button
            btnAdd.Enabled = true; // Enable add button
            btnEdit.Enabled = true; // Enable edit button
        }

        private void ValidateInput()
        {

            if (string.IsNullOrWhiteSpace(txtName.Text))
                throw new Exception("Customer Name is required.");
            if (string.IsNullOrWhiteSpace(txtCont.Text))
                throw new Exception("Contact number is required.");
            if (txtCont.Text.Length > 15)
                throw new Exception("Contact number cannot exceed 15 characters.");
        }

        private void btnAddOrUp_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                using SqlConnection conn = new(connStr);
                string query = isEditing ? "spUpdateCustomer" : "spInsertCustomer";

                using SqlCommand cmd = new(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (isEditing)
                    cmd.Parameters.AddWithValue("@id", int.Parse(txtID.Text));
                cmd.Parameters.AddWithValue("@cusName", txtName.Text.Trim());
                cmd.Parameters.AddWithValue("@cusContact", txtCont.Text.Trim());

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Please select a customer to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var row = dgv.CurrentRow;
                txtID.Text = row.Cells["cusID"].Value?.ToString() ?? "";
                txtName.Text = row.Cells["Name"].Value?.ToString() ?? "";
                txtCont.Text = row.Cells["Phone"].Value?.ToString() ?? "";

                isEditing = true;
                txtID.Enabled = false;
                btnUpdate.Enabled = true;
                btnAdd.Enabled = false;
                btnEdit.Enabled = false; // Disable edit button
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
