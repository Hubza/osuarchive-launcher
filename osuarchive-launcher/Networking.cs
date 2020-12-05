
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace osu_archive_launcher
{
    class Networking
    {
        public bool checkConnection()
        {
            string response = grabFromApi("");
            if (response.Contains("osu!archive JSON"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string grabFromApi(string url)
        {
            url = "https://archive.osu.hubza.co.uk/new/api/" + url;

            Console.WriteLine("url: " + url);

            WebClient client = new WebClient();

            client.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");

            Stream data = client.OpenRead(url);
            StreamReader reader = new StreamReader(data);
            string s = reader.ReadToEnd();
            Console.WriteLine(s);
            data.Close();
            reader.Close();

            return s;
        }
    }
}