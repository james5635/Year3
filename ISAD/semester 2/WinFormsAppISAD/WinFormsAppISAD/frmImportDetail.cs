using Microsoft.Data.SqlClient;
using System.Data;

namespace WinFormsAppISAD
{
    public partial class frmImportDetail : Form
    {
        const string connStr = "Server=.;Database=WinFormsAppISAD; User=sa; Password=james@2025; TrustServerCertificate=True;";

        public frmImportDetail()
        {
            InitializeComponent();
        }
        private void frmImportDetail_Load(object sender, EventArgs e)
        {
            using SqlConnection conn = new SqlConnection(connStr);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fnGetALLStaff()", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID";
            cboStaffID.ValueMember = "FullName";
            cboStaffID.Text = null;

            da = new SqlDataAdapter("SELECT * FROM fnGetALLSupplier()", conn);
            dt = new DataTable();
            da.Fill(dt);
            cboSup.DataSource = dt;
            cboSup.DisplayMember = "Supplier";
            cboSup.ValueMember = "supID";
            cboSup.Text = null;

        }
        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID?.SelectedValue?.ToString();

        }

        private void cboSup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSupID.Text = cboSup?.SelectedValue?.ToString();

        }
    }
}
