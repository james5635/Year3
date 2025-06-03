using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsAppISAD.Configuration;
namespace WinFormsAppISAD
{
    public partial class frmSuppliers : Form
    {
        private readonly string _connStr = Config.GetConfig().ConnectionString;
        private bool _isEditing = false;
        private TextBox _txtSearch = null!;

        public frmSuppliers()
        {
            InitializeComponent();
            InitializeSearchBox();
            ConfigureDataGridView();
            SqlDependency.Start(_connStr);
            loadData();
            ClearForm();

            // Set placeholder texts
            txtSupName.PlaceholderText = "Enter Supplier Name";
            txtCont.PlaceholderText = "Enter Contact Number";
            txtAddr.PlaceholderText = "Enter Address";

            // Add keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown!;
        }

        private void InitializeSearchBox()
        {
            _txtSearch = new TextBox();
            _txtSearch.Location = new Point(dgv.Location.X, dgv.Location.Y - 30);
            _txtSearch.Size = new Size(200, 23);
            _txtSearch.PlaceholderText = "Search suppliers...";
            _txtSearch.TextChanged += TxtSearch_TextChanged!;
            this.Controls.Add(_txtSearch);
        }

        private void ConfigureDataGridView()
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            dgv.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 150, 136);
            dgv.DefaultCellStyle.SelectionForeColor = Color.White;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(0, 150, 136);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersHeight = 40;
        }

        private void TxtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgv.DataSource is DataTable dt)
            {
                string searchStr = string.Format("Supplier LIKE '%{0}%' OR [Supplier Address] LIKE '%{0}%' OR Phone LIKE '%{0}%'",
                    _txtSearch.Text.Replace("'", "''"));
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
            using (SqlConnection conn = new SqlConnection(_connStr))
            {
                conn.Open();

                using (SqlCommand com = new SqlCommand("spGetAllSupplier", conn))
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
                        dgv.Columns["supID"].HeaderText = "ID";
                        dgv.Columns["Supplier"].HeaderText = "Name";
                        dgv.Columns["Supplier Address"].HeaderText = "Address";
                        dgv.Columns["Phone"].HeaderText = "Contact";
                    }
                }
            }
        }

        private void ClearForm()
        {
            _isEditing = false;
            txtSupID.Clear(); // ID
            txtSupName.Clear(); // Supplier Name
            txtCont.Clear(); // Contact
            txtAddr.Clear(); // Address
            txtSupID.Enabled = true;
            btnUpdate.Enabled = false; // Disable update button
            btnEdit.Enabled = true; // Enable edit button
            btnAdd.Enabled = true; // Enable add button
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtSupName.Text))
                throw new Exception("Supplier Name is required.");
            if (string.IsNullOrWhiteSpace(txtCont.Text))
                throw new Exception("Contact number is required.");
            if (string.IsNullOrWhiteSpace(txtAddr.Text))
                throw new Exception("Address is required.");
        }

        private void btnAddOrUp_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInput();

                using SqlConnection conn = new(_connStr);
                string query = _isEditing ? "spUpdateSupplier" : "spInsertSupplier";

                using SqlCommand cmd = new(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;

                if (_isEditing)
                {
                    cmd.Parameters.AddWithValue("@id", txtSupID.Text.Trim());
                }
                cmd.Parameters.AddWithValue("@supplier", txtSupName.Text.Trim());
                cmd.Parameters.AddWithValue("@supAdd", txtAddr.Text.Trim());
                cmd.Parameters.AddWithValue("@supCon", txtCont.Text.Trim());

                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show(
                        _isEditing ? "Supplier updated successfully! 🎉" : "Supplier added successfully! 🎉",
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
                MessageBox.Show("Please select a supplier to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var row = dgv.CurrentRow;
                txtSupID.Text = row.Cells["supID"].Value?.ToString() ?? "";
                txtSupName.Text = row.Cells["Supplier"].Value?.ToString() ?? "";
                txtCont.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtAddr.Text = row.Cells["Supplier Address"].Value?.ToString() ?? "";

                _isEditing = true;
                txtSupID.Enabled = false;
                btnUpdate.Enabled = true;
                btnEdit.Enabled = false;
                btnAdd.Enabled = false; // Disable add button

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading supplier data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmSuppliers_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(_connStr);
            loadData();
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Enabled = true;
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
