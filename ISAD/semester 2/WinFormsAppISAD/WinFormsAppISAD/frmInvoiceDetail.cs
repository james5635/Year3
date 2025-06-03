using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppISAD.Configuration;
namespace WinFormsAppISAD
{
    public partial class frmInvoiceDetail : Form
    {
        private readonly string _connStr = Config.GetConfig().ConnectionString;

        public frmInvoiceDetail()
        {
            InitializeComponent();
        }

        private void frmInvoiceDetail_Load(object sender, EventArgs e)
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

            da = new SqlDataAdapter("SELECT * FROM fnGetAllCustomer()", conn);
            dt = new DataTable();
            da.Fill(dt);
            cboCusName.DataSource = dt;
            cboCusName.DisplayMember = "CusName";
            cboCusName.ValueMember = "cusID";
            cboCusName.Text = null;
        }

        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID?.SelectedValue?.ToString();

        }

        private void cboCusName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCusID.Text = cboCusName?.SelectedValue?.ToString();

        }

        private void txtProCode_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtProCode.Text, out _) == false)
            {
                txtProName.Text = string.Empty;
                return;
            }

            using SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            using SqlCommand cmd = new SqlCommand($"SELECT ProCode, ProName FROM fnGetAllProduct() WHERE ProCode={txtProCode.Text}", conn);
            using SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                txtProName.Text = dr["ProName"].ToString();
            }
            else
            {
                txtProName.Text = string.Empty;
            }
        }
    }
}
