using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using osu_archive_launcher;

namespace osu_archive_launcher
{
    static class Program
    {
        public static bool validConnection;
        public static Networking net;

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            net = new Networking();

            // check connection to osu!archive
            if (net.checkConnection())
            {
                validConnection = true;
            }
            else
            {
                validConnection = false;
                MessageBox.Show("Could not connect to osu!archive API, functionality may be limited.");
            }

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
