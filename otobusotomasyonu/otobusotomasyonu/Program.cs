using System;
using System.Windows.Forms;

namespace otobusotomasyonu
{
    internal static class Program
    {
        public static Form1 AnaForm;  // Global Form1 tanýmý

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // AnaForm'u baþtan oluþtur
            AnaForm = new Form1();

            // Uygulama admin formuyla baþlýyor
            Application.Run(new admin());
        }
    }
}
