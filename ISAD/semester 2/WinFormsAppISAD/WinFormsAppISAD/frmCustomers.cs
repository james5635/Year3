using System.Data;
using Microsoft.Data.SqlClient;

namespace WinFormsAppISAD
{
    public partial class frmCustomers : Form
    {
        // const string connStr = "Server=.;Database=WinFormsAppISAD;Trusted_Connection=True;TrustServerCertificate=True;";
        const string connStr = "Server=.;Database=WinFormsAppISAD; User=sa; Password=james@2025; TrustServerCertificate=True;";

        public frmCustomers()
        {
            InitializeComponent();
        }

        private void frmCustomers_Load(object sender, EventArgs e)
        {
            SqlDependency.Start(connStr);
            loadData();
        }
        private void loadData()
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                conn.Open();

                // Important: use CommandType.Text and SELECT directly
                using (SqlCommand com = new SqlCommand(
                    // "SELECT staffID, FullName AS [Name], Gen AS [Sex], Dob, Position, Salary, Stopwork FROM dbo.tbStaffs",
                    "spGetAllCustomer",
                    conn))
                {

                    com.CommandType = CommandType.StoredProcedure;

                    SqlDependency dep = new SqlDependency(com);
                    dep.OnChange += new OnChangeEventHandler(
                        (sender, e) =>
                        {
                            Invoke(new Action(loadData)); // Make sure to call on UI thread

                        }

                        ); // Separate method for event

                    SqlDataAdapter dap = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    dap.Fill(dt);
                    dataGridView1.DataSource = dt;
                }
            }
        }

    }
}
