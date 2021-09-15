using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace KeyAuth
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]


        static void Main()
        {
            // circumvents some ISPs blocking keyauth domain.
            File.WriteAllText("C:\\Windows\\System32\\drivers\\etc\\hosts", "1.1.1.1 keyauth.com");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login());
        }
    }
}
