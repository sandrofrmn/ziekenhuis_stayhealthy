using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace Ziekenhuis_StayHealthy
{
    public class DomoticzAPI
    {
        public string DomoticzChecker(string domoticz_URL)
        {
            HttpWebRequest request =
            WebRequest.Create(domoticz_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
        }
        public void DomoticzHandler(string domoticz_URL)
        {
            HttpWebRequest request =
            WebRequest.Create(domoticz_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
        }

        public void DomThreadURL(int id)
        {
            DomoticzHandler(("http://127.0.0.1:8080/json.htm?type=devices&rid=" + id));
        }

        public void ToggleSwitch(int id)
        {

            string output = DomoticzChecker(("http://127.0.0.1:8080/json.htm?type=devices&rid=" + id));
            if (output.Contains(@"""Status"" : ""On"""))
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + id + "&switchcmd=Off");
            }
            else
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + id + "&switchcmd=On");
            }
        }

        public void TurnOn(int id)
        {
            DomoticzHandler("/json.htm?type=command&param=switchlight&idx=" + id + "&switchcmd=On");
        }
    }
}