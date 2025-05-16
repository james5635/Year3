namespace WinFormsAppISAD
{
    public partial class frmStart : Form
    {
        public frmStart()
        {
            InitializeComponent();
        }

        private void btnStaffM_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Application.Run(new frmStaffs());
            });
        }

        private void btnSupplierM_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Application.Run(new frmSuppliers());
            });
        }

        private void btnCustomerM_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Application.Run(new frmCustomers());
            });
        }

        private void btnProductM_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                Application.Run(new frmProducts());
            });
        }
    }
}

