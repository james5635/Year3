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
            //Task.Run(() =>
            //{
            //    Application.Run(new frmStaffs());
            //});
            new frmStaffs().Show();
        }

        private void btnSupplierM_Click(object sender, EventArgs e)
        {
            //Task.Run(() =>
            //{
            //    Application.Run(new frmSuppliers());
            //});
            new frmSuppliers().Show();
        }

        private void btnCustomerM_Click(object sender, EventArgs e)
        {
            //Task.Run(() =>
            //{
            //    Application.Run(new frmCustomers());
            //});
            new frmCustomers().Show();
        }

        private void btnProductM_Click(object sender, EventArgs e)
        {
            //Task.Run(() =>
            //{
            //    Application.Run(new frmProducts());
            //});
            new frmProducts().Show();
        }

        private void btnImportDetailInformation_Click(object sender, EventArgs e)
        {
            new frmImportDetail().Show();
        }

        private void btnOrderDetailInformation_Click(object sender, EventArgs e)
        {
            new frmOrderDetail().Show();
        }
    }
}

