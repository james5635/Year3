using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsAppISAD.Configuration;
namespace WinFormsAppISAD
{
    public partial class frmOrderDetail : Form
    {

        private readonly string _connStr = Config.GetConfig().ConnectionString;

        public frmOrderDetail()
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
            cboCusID.DataSource = dt;
            cboCusID.DisplayMember = "cusID";
            cboCusID.ValueMember = "CusName";
            cboCusID.Text = null;

            lview.View = View.Details;
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

        private void cboCusName_SelectionChangeCommitted(object sender, EventArgs e)
        {
            txtCusName.Text = cboCusID?.SelectedValue?.ToString();

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
                txtUnitPrice.Text = dr["UPIS"].ToString();
            }
            else
            {
                txtProName.Text = string.Empty;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Action addNewItem = () =>
            {
                string[] arr = new string[5];
                arr[0] = txtProCode.Text.Trim();
                arr[1] = txtProName.Text.Trim();
                arr[2] = txtQty.Text.Trim();
                arr[3] = $"{decimal.Parse(txtUnitPrice.Text.Trim()):C}";
                decimal amount = decimal.Parse(txtQty.Text.Trim()) * decimal.Parse(txtUnitPrice.Text.Trim());
                arr[4] = $"{amount:C}";

                ListViewItem item = new ListViewItem(arr);
                lview.Items.Add(item);
            };
            Action<ListViewItem> updateItem = (foundItem) =>
            {
                int qty = int.Parse(foundItem.SubItems[2].Text) + int.Parse(txtQty.Text.Trim());
                decimal amount = qty * decimal.Parse(txtUnitPrice.Text.Trim());
                foundItem.SubItems[2].Text = qty.ToString();
                foundItem.SubItems[3].Text = $"{decimal.Parse(txtUnitPrice.Text.Trim()):C}";
                foundItem.SubItems[4].Text = $"{amount:C}";
            };


            if (String.Equals(String.Empty, txtProCode.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid Product Code.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (String.Equals(String.Empty, txtQty.Text.Trim()))
            {
                MessageBox.Show("Please enter a valid Quantity.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                ListViewItem? foundItem = lview.FindItemWithText(txtProCode.Text.Trim());
                if (foundItem == null)
                {
                    addNewItem();
                }
                else
                {
                    updateItem(foundItem);
                }
            }

            decimal total = 0.0m;
            lview.Items.Cast<ListViewItem>().ToList().ForEach(

                item =>
                {
                    total += decimal.Parse(item.SubItems[4].Text, NumberStyles.Currency);
                }

                );
            txtTotal.Text = $"{total:C}";

            txtProCode.Clear();
            txtProName.Clear();
            txtQty.Clear();
            txtUnitPrice.Clear();
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
            try
            {
                DataTable dtMaster = new DataTable();
                dtMaster.Columns.Add("OrdDate", typeof(DateTime));
                dtMaster.Columns.Add("staffID", typeof(int));
                dtMaster.Columns.Add("FullName", typeof(string));
                dtMaster.Columns.Add("cusID", typeof(int));
                dtMaster.Columns.Add("cusName", typeof(string));
                dtMaster.Columns.Add("Total", typeof(decimal));
                dtMaster.Rows.Add(
                    dtpOrderDate.Value,
                    int.Parse(cboStaffID.Text),
                    txtStaffName.Text,
                    int.Parse(cboCusID.Text),
                    txtCusName.Text,
                    decimal.Parse(txtTotal.Text, NumberStyles.Currency)
                );

                DataTable dtDetail = new DataTable();
                dtDetail.Columns.Add("ProCode", typeof(int));
                dtDetail.Columns.Add("ProName", typeof(string));
                dtDetail.Columns.Add("Qty", typeof(int));
                dtDetail.Columns.Add("Price", typeof(decimal));
                dtDetail.Columns.Add("Amount", typeof(decimal));
                foreach (ListViewItem item in lview.Items)
                {
                    dtDetail.Rows.Add(
                        String.Equals(String.Empty, item.SubItems[0].Text.Trim()) ? -1 : int.Parse(item.SubItems[0].Text),
                        item.SubItems[1].Text,
                        int.Parse(item.SubItems[2].Text),
                        decimal.Parse(item.SubItems[3].Text, NumberStyles.Currency),
                        decimal.Parse(item.SubItems[4].Text, NumberStyles.Currency)
                    );
                }


                using SqlConnection conn = new SqlConnection(_connStr);
                using SqlCommand cmd = new SqlCommand("spSetOrderDetail", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter par = new SqlParameter("@OM", SqlDbType.Structured)
                {
                    Value = dtMaster
                };
                SqlParameter par2 = new SqlParameter("@OD", SqlDbType.Structured)
                {
                    Value = dtDetail
                };
                cmd.Parameters.Add(par);
                cmd.Parameters.Add(par2);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Saved Successfully!", "Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboCusID_MouseLeave(object sender, EventArgs e)
        {
            using SqlConnection conn = new SqlConnection(_connStr);
            using SqlCommand da = new SqlCommand("SELECT * FROM fnGetAllCustomer()", conn);

            try
            {
                conn.Open();
                using SqlDataReader dr = da.ExecuteReader();
                while (dr.Read())
                {
                    if (String.Equals(dr["cusID"].ToString(), cboCusID.Text.Trim()))
                    {
                        txtCusName.Text = dr["CusName"].ToString();
                        return;
                    }
                }
                txtCusName.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
