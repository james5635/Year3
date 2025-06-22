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

        private void frmPayments_Load(object? sender, EventArgs e)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM fnGetAllStaff()", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            cboStaffID.DataSource = dt;
            cboStaffID.DisplayMember = "staffID";
            cboStaffID.ValueMember = "FullName";

            da = new SqlDataAdapter("SELECT * FROM fnGetAllOrderNotCompletePayment() ORDER BY OrdCode", conn);
            dt = new DataTable();
            da.Fill(dt);
            cboOrderCode.DataSource = dt;
            cboOrderCode.DisplayMember = "OrdCode";
            cboOrderCode.ValueMember = "Total";

            dtpPaymentDate.Value = DateTime.Now;
            cboStaffID.Text = null;
            txtStaffName.Text = null;
            cboOrderCode.Text = null;
            txtAmount.Text = null;
            txtDeposit.Text = null;
            txtRemaining.Text = null;
        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID?.SelectedValue?.ToString();
        }

        private void cboOrderCode_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtAmount.Text = decimal.Parse(cboOrderCode?.SelectedValue?.ToString()!).ToString("0.00");
            txtRemaining.Text = decimal.Parse((cboOrderCode?.SelectedItem as DataRowView)?["Remaining"].ToString()!).ToString("0.00");
            txtDeposit.ReadOnly = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using SqlConnection conn = new SqlConnection(_connStr);
                conn.Open();

                using SqlCommand cmd = new SqlCommand("spInsertPayment", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@PayDate", dtpPaymentDate.Value);
                cmd.Parameters.AddWithValue("@staffID", int.Parse(cboStaffID.Text));
                cmd.Parameters.AddWithValue("@FullName", txtStaffName.Text);
                cmd.Parameters.AddWithValue("@OrdCode", int.Parse(cboOrderCode.Text));
                cmd.Parameters.AddWithValue("@Deposit", decimal.Parse(txtDeposit.Text));
                cmd.Parameters.AddWithValue("@Amount", decimal.Parse(txtAmount.Text));

                cmd.ExecuteNonQuery();
                MessageBox.Show("Payment saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                frmPayments_Load(null, e); // Refresh the form
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An unexpected error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void txtDeposit_MouseLeave(object sender, EventArgs e)
        {
          
        }

        private void txtDeposit_TextChanged(object sender, EventArgs e)
        {
            if(!decimal.TryParse(txtDeposit.Text, out decimal deposit) || deposit < 0)
            {
                txtRemaining.Text = decimal.TryParse((cboOrderCode?.SelectedItem as DataRowView)?["Remaining"].ToString()!, out decimal remaining) ? remaining.ToString("0.00") : "";
                return;
            }
            txtRemaining.Text = (decimal.Parse((cboOrderCode?.SelectedItem as DataRowView)?["Remaining"].ToString()!) - decimal.Parse(txtDeposit.Text)).ToString("0.00");
        }
    }
}
