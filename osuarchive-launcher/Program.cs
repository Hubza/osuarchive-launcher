using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using osu_archive_launcher;

namespace osu_archive_launcher
{
    static class Program
    {
        public static bool validConnection;
        public static Networking net;
        public static Helpers helper;
        public static JObject versions;

        public static int count;


        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            net = new Networking();
            helper = new Helpers();

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

            versions = helper.stringToJObject(net.grabFromApi("versions.php"));

            count = 0;
            foreach (var a in versions)
            {
                count += 1;
                Console.WriteLine("version " + count + " : " + versions[a.Key]["Version"].ToString());
            }
            Console.WriteLine(count);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}