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
            MessageBox.Show("You clicked");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
