using HR_department.Models;
using System;
using System.Windows.Forms;

namespace HR_department
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            MainOfClass.GenTestData();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Start_Form());
        }
    }
}
