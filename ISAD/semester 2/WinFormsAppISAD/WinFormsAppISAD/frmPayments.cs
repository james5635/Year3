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

            da = new SqlDataAdapter("SELECT * FROM fnGetAllOrderNotCompletePayment()", conn);
            dt = new DataTable();
            da.Fill(dt);
            cboOrderCode.DataSource = dt;
            cboOrderCode.DisplayMember = "OrdCode";
            cboOrderCode.ValueMember = "Total";
            cboOrderCode.Text = null;

        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID?.SelectedValue?.ToString();

        }

        private void cboOrderCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtAmount.Text = decimal.Parse(cboOrderCode?.SelectedValue?.ToString()!).ToString("0.00");
            txtDeposit_MouseLeave(sender, e);
        }

        private void txtDeposit_MouseLeave(object sender, EventArgs e)
        {

            if (decimal.TryParse(txtDeposit.Text, out decimal deposit) == false)
            {
                txtRemaining.Text = null;
                return;
            }
            decimal amount = decimal.Parse(txtAmount.Text);
            decimal remaining = amount - deposit;
            txtRemaining.Text = remaining >= 0 ? remaining.ToString("0.00") : "0.00";

        }
    }
}
