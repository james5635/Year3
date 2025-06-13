using Microsoft.Data.SqlClient;
using System.Data;
using WinFormsAppISAD.Configuration;

namespace WinFormsAppISAD
{
    public partial class frmPayments : Form
    {
        private readonly string _connStr = Config.GetConfig().ConnectionString;

        public frmPayments()
        {
            InitializeComponent();
        }

        private void frmPayments_Load(object sender, EventArgs e)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fnGetAllStaff()", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID";
            cboStaffID.ValueMember = "FullName";
            cboStaffID.Text = null;

        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID?.SelectedValue?.ToString();

        }
    }
}
