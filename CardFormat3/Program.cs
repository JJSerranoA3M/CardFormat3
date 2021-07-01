using System;
using System.Windows.Forms;

namespace CardFormat3
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var a = new FrmTest();
            Application.Run(new FrmTest());
        }
    }
}
