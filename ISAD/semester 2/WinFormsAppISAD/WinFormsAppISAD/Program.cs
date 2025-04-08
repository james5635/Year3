namespace WinFormsAppISAD
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            //Task.Run(() =>
            //{
            //    Application.Run(new frmStaffs());
            //});
            //Task.Run(() =>
            //{
            //    Application.Run(new frmSuppliers());
            //});
            //while (true) { }
            Application.Run(new frmStaffs());
        }
    }
}