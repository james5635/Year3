using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Globalization;
using System.Net;
using System.Windows.Forms;
using WinFormsAppISAD.Configuration;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
namespace WinFormsAppISAD
{
    public partial class frmImportDetail : Form
    {
        private readonly string _connStr = Config.GetConfig().ConnectionString;

        public frmImportDetail()
        {
            InitializeComponent();
        }
        private void frmImportDetail_Load(object sender, EventArgs e)
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

            da = new SqlDataAdapter("SELECT * FROM fnGetAllSupplier()", conn);
            dt = new DataTable();
            da.Fill(dt);
            cboSup.DataSource = dt;
            cboSup.DisplayMember = "Supplier";
            cboSup.ValueMember = "supID";
            cboSup.Text = null;

            lview.View = View.Details;
            //lview.Columns.Add("Product ID", 100, HorizontalAlignment.Left);
            //lview.Columns.Add("Product Name", 200, HorizontalAlignment.Left);
            //lview.Columns.Add("Quantity", 100, HorizontalAlignment.Left);
            //lview.Columns.Add("Price", 150, HorizontalAlignment.Left);
            //lview.Columns.Add("Amount", 120, HorizontalAlignment.Left);

            lview.Columns.Add("Product ID", 100);
            lview.Columns.Add("Product Name", 200);
            lview.Columns.Add("Quantity", 100);
            lview.Columns.Add("Price", 150);
            lview.Columns.Add("Amount", 120);

        }
        private void cboStaffID_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtStaffName.Text = cboStaffID?.SelectedValue?.ToString();

        }

        private void cboSup_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtSupID.Text = cboSup?.SelectedValue?.ToString();

        }

        private void txtProCode_Leave(object sender, EventArgs e)
        {
            if (int.TryParse(txtProCode.Text, out _) == false)
            {
                txtProName.Text = string.Empty;
                return;
            }

            using SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();

            using SqlCommand cmd = new SqlCommand("spGetProduct", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pc", int.Parse(txtProCode.Text.Trim()));
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem? foundItem = lview.FindItemWithText(txtProCode.Text.Trim());
            decimal amount;
            if (foundItem == null)
            {
                string[] arr = new string[5];
                arr[0] = txtProCode.Text.Trim();
                arr[1] = txtProName.Text.Trim();
                arr[2] = txtQty.Text.Trim();
                arr[3] = $"{decimal.Parse(txtUnitPrice.Text.Trim()):C}";
                amount = decimal.Parse(txtQty.Text.Trim()) * decimal.Parse(txtUnitPrice.Text.Trim());
                arr[4] = $"{amount:C}";

                ListViewItem item = new ListViewItem(arr);
                lview.Items.Add(item);
            }
            else
            {
                int qty = int.Parse(foundItem.SubItems[2].Text) + int.Parse(txtQty.Text.Trim());
                amount = qty * decimal.Parse(txtUnitPrice.Text.Trim());
                foundItem.SubItems[2].Text = qty.ToString();
                foundItem.SubItems[3].Text = $"{decimal.Parse(txtUnitPrice.Text.Trim()):C}";
                foundItem.SubItems[4].Text = $"{amount:C}";
            }

            decimal total = 0.0m;
            lview.Items.Cast<ListViewItem>().ToList().ForEach(

                item =>
                {
                    total += decimal.Parse(item.SubItems[4].Text, NumberStyles.Currency);
                }

                );
            txtTotal.Text = $"{total:C}";
            btnSave.Enabled = lview.Items.Count > 0;

        }


        private void lview_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = lview.SelectedItems.Count > 0;

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult res;
            foreach (ListViewItem item in lview.Items)
            {
                if (item.Selected)
                {
                    res = MessageBox.Show($"Are you sure you want to delete this item?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (res == DialogResult.Yes)
                    {
                        lview.Items.Remove(item);
                        decimal total = 0.0m;
                        lview.Items.Cast<ListViewItem>().ToList().ForEach(
                            i => total += decimal.Parse(i.SubItems[4].Text, NumberStyles.Currency)
                            );
                        txtTotal.Text = $"{total:C}";
                    }
                }
            }
            btnSave.Enabled = lview.Items.Count > 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DataTable dtMaster = new DataTable();
            dtMaster.Columns.Add("ImpDate", typeof(DateTime));
            dtMaster.Columns.Add("staffID", typeof(int));
            dtMaster.Columns.Add("FullName", typeof(string));
            dtMaster.Columns.Add("supID", typeof(int));
            dtMaster.Columns.Add("Supplier", typeof(string));
            dtMaster.Columns.Add("Total", typeof(decimal));
            dtMaster.Rows.Add(
                dtpImportDate.Value,
                int.Parse(cboStaffID.Text),
                txtStaffName.Text,
                int.Parse(txtSupID.Text),
                cboSup.Text,
                decimal.Parse(txtTotal.Text, NumberStyles.Currency)
            );

            using SqlConnection conn = new SqlConnection(_connStr);
            conn.Open();
            using SqlCommand cmd = new SqlCommand("spSetImportDetail", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter par = new SqlParameter("@IM", SqlDbType.Structured)
            {
                //TypeName = "dbo.ImportDetailType",
                Value = dtMaster
            };
            cmd.Parameters.Add(par);
            cmd.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
