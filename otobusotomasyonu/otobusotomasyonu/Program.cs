using System;
using System.Windows.Forms;

namespace otobusotomasyonu
{
    internal static class Program
    {
        public static Form1 AnaForm;  // Global Form1 tan�m�

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // AnaForm'u ba�tan olu�tur
            AnaForm = new Form1();

            // Uygulama admin formuyla ba�l�yor
            Application.Run(new admin());
        }
    }
}
