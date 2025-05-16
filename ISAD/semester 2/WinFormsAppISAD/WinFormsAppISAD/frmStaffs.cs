using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;
using System.Globalization;

namespace WinFormsAppISAD
{
    public partial class frmStaffs : Form
    {
        const string connStr = "Server=.;Database=WinFormsAppISAD; User=sa; Password=james@2025; TrustServerCertificate=True;";
        private ToolTip toolTip = null!;
        private TextBox txtSearch = null!;
        private bool isEditing = false;

        public int? x { get; set; } = null;
        public frmStaffs()
        {
            InitializeComponent();
            InitializeToolTips();
            InitializeSearchBox();
            ConfigureDataGridView();
            SqlDependency.Start(connStr);
            loadData();
            ClearForm();


            // Set placeholder texts
            txtFName.PlaceholderText = "Enter Full Name";
            txtPos.PlaceholderText = "Enter Position";
            txtSalary.PlaceholderText = "Enter Salary";

            // Add keyboard shortcuts
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown!;

            // Configure initial button states
            UpdateButtonStates();
        }

        private void UpdateButtonStates(bool rowSelected = false)
        {
            btnUpdate.Enabled = isEditing; // Update button
            btnAdd.Enabled = !isEditing; // Add button
            btnEdit.Enabled = rowSelected && !isEditing; // Edit button
            btnDelete.Enabled = rowSelected && !isEditing; // Delete button
            txtId.Enabled = !isEditing; // ID field
            btnView.Enabled = rowSelected; // View button
        }

        private void ClearForm()
        {
            isEditing = false;
            txtId.Clear();
            txtFName.Clear();
            txtPos.Clear();
            txtSalary.Clear();
            rdoF.Checked = false;
            rdoM.Checked = false;
            dtpDOB.Value = DateTime.Today;
            txtStatus.Checked = false;
            if (pBox.Image != null)
            {
                pBox.Image.Dispose();
                pBox.Image = null;
            }
            UpdateButtonStates();
        }

        private void InitializeToolTips()
        {
            toolTip = new ToolTip();
            toolTip.SetToolTip(txtId, "Unique identifier for the staff member");
            toolTip.SetToolTip(txtFName, "Full name of the staff member");
            toolTip.SetToolTip(rdoF, "Select if staff member is female");
            toolTip.SetToolTip(rdoM, "Select if staff member is male");
            toolTip.SetToolTip(dtpDOB, "Staff member's date of birth");
            toolTip.SetToolTip(txtPos, "Current position in the company");
            toolTip.SetToolTip(txtSalary, "Current salary");
            toolTip.SetToolTip(txtStatus, "Check if staff member has stopped working");
            toolTip.SetToolTip(btnUpdate, "Update staff member details (Ctrl+U)");
            toolTip.SetToolTip(btnAdd, "Add new staff member (Ctrl+A)");
            toolTip.SetToolTip(btnEdit, "Edit selected staff member (Ctrl+E)");
            toolTip.SetToolTip(btnDelete, "Delete selected staff member (Del)");
            toolTip.SetToolTip(pBox, "Click to upload staff photo");
        }

        private void InitializeSearchBox()
        {
            txtSearch = new TextBox();
            txtSearch.Location = new Point(dgv.Location.X, dgv.Location.Y - 30);
            txtSearch.Size = new Size(200, 23);
            txtSearch.PlaceholderText = "Search staff...";
            txtSearch.TextChanged += TxtSearch_TextChanged!;
            this.Controls.Add(txtSearch);
        }

        private void ConfigureDataGridView()
        {
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
            dgv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            dgv.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgv.RowHeadersVisible = false;
            dgv.BorderStyle = BorderStyle.None;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(51, 51, 76);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        }

        private void TxtSearch_TextChanged(object? sender, EventArgs e)
        {
            if (dgv.DataSource is DataTable dt)
            {
                // make sure ' is handled properly (example: O'Reilly => 'O''Reilly')
                string searchStr = string.Format("Name LIKE '%{0}%' OR Position LIKE '%{0}%'",
                    txtSearch.Text.Replace("'", "''"));
                dt.DefaultView.RowFilter = searchStr;
            }
        }

        private void Form_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                switch (e.KeyCode)
                {
                    case Keys.U:
                        if (btnUpdate.Enabled) btnUpdate.PerformClick();
                        break;
                    case Keys.A:
                        if (btnAdd.Enabled) btnAdd.PerformClick();
                        break;
                    case Keys.E:
                        if (btnEdit.Enabled) btnEdit.PerformClick();
                        break;
                }
            }
            else if (e.KeyCode == Keys.Delete)
            {
                if (btnDelete.Enabled) btnDelete.PerformClick();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                ClearForm();
            }
        }

        private void pBox_Click(object sender, EventArgs e)
        {
            using OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Select Staff Photo";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (pBox.Image != null)
                    {
                        pBox.Image.Dispose();
                    }
                    pBox.Image = Image.FromFile(openFileDialog.FileName);
                    pBox.SizeMode = PictureBoxSizeMode.Zoom;

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading image: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        void loadData()
        {
            using SqlConnection conn = new(connStr);
            conn.Open();

            using SqlCommand com = new("spGetAllStaff", conn)
            {
                CommandType = CommandType.StoredProcedure
            };

            SqlDependency dep = new(com);
            dep.OnChange += OnDependencyChange!;

            using SqlDataAdapter dap = new(com);
            DataTable dt = new();
            dap.Fill(dt);
            dgv.DataSource = dt;
            dgv.Columns["Photo"].Visible = false; // Hide the photo column
            dgv.Columns["Stopwork"].Visible = false; // Hide the Stopwork column

            // Configure columns after data load
            if (dgv.Columns.Count > 0)
            {
                dgv.Columns["staffID"].HeaderText = "ID";
                dgv.Columns["Name"].HeaderText = "Full Name";
                dgv.Columns["Sex"].HeaderText = "Gender";
                dgv.Columns["Birth"].HeaderText = "Birth Date";
                dgv.Columns["Position"].HeaderText = "Position";
                dgv.Columns["Salary"].HeaderText = "Salary";
                dgv.Columns["Salary"].DefaultCellStyle.Format = "C2";
                //  dgv.Columns["Stopwork"].HeaderText = "Inactive";
            }
        }

        private void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(loadData));
            }
            else
            {
                loadData();
            }
        }

        private void ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtFName.Text))
                throw new Exception("Full name is required.");
            if (!rdoF.Checked && !rdoM.Checked)
                throw new Exception("Please select a gender.");
            if (dtpDOB.Value > DateTime.Today)
                throw new Exception("Birth date cannot be in the future.");
            if (string.IsNullOrWhiteSpace(txtPos.Text))
                throw new Exception("Position is required.");
            if (string.IsNullOrWhiteSpace(txtSalary.Text))
                throw new Exception("Salary is required.");
            if (!decimal.TryParse(txtSalary.Text, out decimal salary) || salary < 0)
                throw new Exception("Salary must be a valid non-negative number.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

            try
            {
                using SqlConnection conn = new(connStr);
                string query = @"spUpdateStaff";

                using SqlCommand cmd = new(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                cmd.Parameters.AddWithValue("@name", txtFName.Text.Trim());
                cmd.Parameters.AddWithValue("@gender", rdoF.Checked ? "F" : "M");
                cmd.Parameters.AddWithValue("@dob", dtpDOB.Value);
                cmd.Parameters.AddWithValue("@position", txtPos.Text.Trim());
                cmd.Parameters.AddWithValue("@salary", decimal.Parse(txtSalary.Text));
                cmd.Parameters.AddWithValue("@stopwork", txtStatus.Checked);
                cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = pBox.Image is Image img ? new Func<byte[]>(() => { var ms = new MemoryStream(); img.Save(ms, pBox.Image.RawFormat); return ms.ToArray(); })() : DBNull.Value;


                conn.Open();
                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Staff updated successfully! 🎉", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearForm();

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            try
            {
                ValidateInput();

                // Check if ID already exists
                using (SqlConnection conn = new(connStr))
                {
                    conn.Open();
                    // using SqlCommand checkCmd = new("SELECT COUNT(*) FROM tbStaffs WHERE staffID = @id", conn);
                    // checkCmd.Parameters.AddWithValue("@id", int.Parse(txtId.Text));
                    // int exists = (int)checkCmd.ExecuteScalar();

                    // if (exists > 0)
                    // {
                    //     MessageBox.Show("Staff ID already exists. Please use a different ID.", "Error",
                    //         MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //     return;
                    // }

                    bool IdExist = dgv.Rows
                       .Cast<DataGridViewRow>()
                       .Any(row => row.Cells["staffID"].Value?.ToString() == txtId.Text);
                    if (IdExist)
                    {
                        MessageBox.Show("Staff ID already exists. Please use a different ID.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    string query = @"spInsertStaff";
                    using SqlCommand cmd = new(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@name", txtFName.Text.Trim());
                    cmd.Parameters.AddWithValue("@gender", rdoF.Checked ? "F" : "M");
                    cmd.Parameters.AddWithValue("@dob", dtpDOB.Value);
                    cmd.Parameters.AddWithValue("@position", txtPos.Text.Trim());
                    cmd.Parameters.AddWithValue("@salary", decimal.Parse(txtSalary.Text));
                    cmd.Parameters.AddWithValue("@stopwork", txtStatus.Checked);
                    cmd.Parameters.Add("@photo", SqlDbType.VarBinary).Value = pBox.Image is Image img ? new Func<byte[]>(() => { var ms = new MemoryStream(); img.Save(ms, pBox.Image.RawFormat); return ms.ToArray(); })() : DBNull.Value;

                    // cmd.Parameters.AddWithValue("@photo", new Func<byte[]>(() =>
                    //{
                    //    Image img = pBox.Image;
                    //    byte[] arr;
                    //    ImageConverter converter = new ImageConverter();
                    //    arr = (byte[])converter.ConvertTo(img, typeof(byte[]));
                    //    return arr;
                    //})());


                    int result = cmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Staff added successfully! 🎉", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();

                    }
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
                MessageBox.Show("Please select a staff member to edit.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var row = dgv.CurrentRow;

                txtId.Text = row.Cells["staffID"].Value?.ToString() ?? "";
                txtFName.Text = row.Cells["Name"].Value?.ToString() ?? "";

                string gender = row.Cells["Sex"].Value?.ToString() ?? "";
                rdoF.Checked = gender == "F";
                rdoM.Checked = gender == "M";

                if (row.Cells["Birth"].Value is DateTime birthDate)
                {
                    dtpDOB.Value = birthDate;
                }

                txtPos.Text = row.Cells["Position"].Value?.ToString() ?? "";
                txtSalary.Text = row.Cells["Salary"].Value is decimal sal ? $"{sal:F2}" : "";

                if (row.Cells["Stopwork"].Value is bool stopwork)
                {
                    txtStatus.Checked = stopwork;
                }
                if (row.Cells["Photo"].Value is byte[] p)
                {
                    var ms = new MemoryStream(p);
                    pBox.Image = Image.FromStream(ms);
                }
                else
                {
                    pBox.Image = null;
                }

                isEditing = true;
                UpdateButtonStates(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading staff data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.CurrentRow == null)
            {
                MessageBox.Show("Please select a staff member to delete.", "Information",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var staffId = dgv.CurrentRow.Cells["staffID"].Value?.ToString();
            var staffName = dgv.CurrentRow.Cells["Name"].Value?.ToString();

            var result = MessageBox.Show(
                $"Are you sure you want to delete staff member:\nID: {staffId}\nName: {staffName}?",
                "Confirm Delete ⚠️",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using SqlConnection conn = new(connStr);
                    string query = "spDeleteStaff";

                    using SqlCommand cmd = new(query, conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", int.Parse(staffId!));

                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Staff deleted successfully! ✅", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        ClearForm();

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting staff: " + ex.Message, "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgv_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            bool rowSelected = e.RowIndex >= 0;
            UpdateButtonStates(rowSelected);
        }


        private void btnView_Click(object sender, EventArgs e)
        {
            try
            {
                var row = dgv.CurrentRow;
                if (row.Cells["Photo"].Value is byte[] p)
                {
                    using (var ms = new MemoryStream(p)) pBox.Image = Image.FromStream(ms);
                }
                else
                {
                    MessageBox.Show("No photo available for this staff member.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading photo data: " + ex.Message, "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
