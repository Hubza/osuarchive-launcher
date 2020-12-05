using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace osu_archive_launcher
{
    class Helpers
    {
        public JObject stringToJObject(string text)
        {
            JObject json = JObject.Parse(text);
            return json;
        }
    }
}
