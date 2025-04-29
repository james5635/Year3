using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsAppISAD
{
    public partial class frmStaffs : Form
    {
        // const string connStr = "Server=.;Database=WinFormsAppISAD;Trusted_Connection=True;TrustServerCertificate=True;";
        const string connStr = "Server=.;Database=WinFormsAppISAD; User=sa; Password=james@2025; TrustServerCertificate=True;";

        public frmStaffs()
        {
            InitializeComponent();
            SqlDependency.Start(connStr); // Best to move to Program.cs if possible
            loadData();
        }

        void loadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Important: use CommandType.Text and SELECT directly
                using (SqlCommand com = new SqlCommand(
                    // "SELECT staffID, FullName AS [Name], Gen AS [Sex], Dob, Position, Salary, Stopwork FROM dbo.tbStaffs",
                    "spGetAllStaff",
                    conn))
                {

                    com.CommandType = CommandType.StoredProcedure;

                    SqlDependency dep = new SqlDependency(com);
                    dep.OnChange += new OnChangeEventHandler(
                        OnDependencyChange); // Separate method for event

                    SqlDataAdapter dap = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

        private void OnDependencyChange(object sender, SqlNotificationEventArgs e)
        {

            // MessageBox.Show($"OnChange Event fired. SqlNotificationEventArgs: Info={e.Info}, Source={e.Source}, Type={e.Type}\r\n");
            // resubscribe
            Invoke(new Action(loadData)); // Make sure to call on UI thread


        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Get input values
            string idText = textBox1.Text;
            string name = textBox2.Text;
            string gender = radioButton1.Checked ? "F" : radioButton2.Checked ? "M" : "";
            DateTime birthDate = dateTimePicker1.Value;
            string position = textBox3.Text;
            string salaryText = textBox4.Text;
            bool stopWork = checkBox1.Checked;

            // Validate inputs
            if (!int.TryParse(idText, out int id))
            {
                MessageBox.Show("Staff ID must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Full name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (gender == "")
            {
                MessageBox.Show("Please select a gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (birthDate > DateTime.Today)
            {
                MessageBox.Show("Birth date cannot be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Position is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!decimal.TryParse(salaryText, out decimal salary) || salary < 0)
            {
                MessageBox.Show("Salary must be a valid non-negative number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"UPDATE tbStaffs
                         SET FullName = @name,
                             Gen = @gender,
                             Dob = @dob,
                             Position = @position,
                             Salary = @salary,
                             Stopwork = @stopwork
                         WHERE staffID = @id";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@dob", birthDate);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@stopwork", stopWork);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();

                        (sender as Button).Enabled = false;
                        MessageBox.Show("Staff updated successfully.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Get input values
            string idText = textBox1.Text;
            string name = textBox2.Text;
            string gender = radioButton1.Checked ? "F" : radioButton2.Checked ? "M" : "";
            DateTime birthDate = dateTimePicker1.Value;
            string position = textBox3.Text;
            string salaryText = textBox4.Text;
            bool stopWork = checkBox1.Checked;

            // Validate inputs
            if (!int.TryParse(idText, out int id))
            {
                MessageBox.Show("Staff ID must be a number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Full name is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (gender == "")
            {
                MessageBox.Show("Please select a gender.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (birthDate > DateTime.Today)
            {
                MessageBox.Show("Birth date cannot be in the future.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (string.IsNullOrWhiteSpace(position))
            {
                MessageBox.Show("Position is required.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }

            if (!decimal.TryParse(salaryText, out decimal salary) || salary < 0)
            {
                MessageBox.Show("Salary must be a valid non-negative number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                return;
            }



            using (SqlConnection conn = new SqlConnection(connStr))
            {
                string query = @"INSERT INTO tbStaffs (staffID, FullName, Gen, Dob, Position, Salary, Stopwork)
                         VALUES (@id, @name, @gender, @dob, @position, @salary, @stopwork)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    cmd.Parameters.AddWithValue("@name", name);
                    cmd.Parameters.AddWithValue("@gender", gender);
                    cmd.Parameters.AddWithValue("@dob", birthDate);
                    cmd.Parameters.AddWithValue("@position", position);
                    cmd.Parameters.AddWithValue("@salary", salary);
                    cmd.Parameters.AddWithValue("@stopwork", stopWork);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Staff inserted successfully.", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Database error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            // MessageBox.Show($"{id} {name} {gender} {birthDate} {position} {salary} {stopWork}");




        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void frmStaffs_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var row = dataGridView1.CurrentRow;

            textBox1.Text = row.Cells["staffID"].Value.ToString();
            textBox2.Text = row.Cells["Name"].Value.ToString();

            string gender = row.Cells["Sex"].Value.ToString();
            radioButton1.Checked = gender == "F";
            radioButton2.Checked = gender == "M";

            dateTimePicker1.Value = Convert.ToDateTime(row.Cells["Birth"].Value);
            textBox3.Text = row.Cells["Position"].Value.ToString();
            textBox4.Text = row.Cells["Salary"].Value.ToString();
            checkBox1.Checked = Convert.ToBoolean(row.Cells["Stopwork"].Value);

            button1.Enabled = true;
        }
    }
}
