using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Web;

namespace Ziekenhuis_StayHealthy
{
    public class DomoticzAPI
    {
        List<int> devices = new List<int>();

        public string DomoticzReturnText(string domoticz_URL)
        {
            HttpWebRequest request = WebRequest.Create(domoticz_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            return text;
        }
        public string DomoticzChecker(string domoticz_URL)
        {
            HttpWebRequest request =
            WebRequest.Create(domoticz_URL) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string text = reader.ReadToEnd();
            JObject j = JObject.Parse(text);
            for(int i = 0; i < 5; i++)
            {
                devices.Add((int)j["result"][i]["devidx"]);

            }
            devices.Sort();
            for (int i = 0; i < devices.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(devices[i]);
            }
            
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

            string output = DomoticzReturnText(("http://127.0.0.1:8080/json.htm?type=devices&rid=" + id));
            if (output.Contains(@"""Status"" : ""On") || output.Contains(@"""Status"" : ""Closed"))
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + id + "&switchcmd=Off");
            }
            else
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + id + "&switchcmd=On");
            }
        }

        public void KiesTemperatuur(int id)
        {
            string output = DomoticzReturnText(("http://127.0.0.1:8080/json.htm?type=devices&rid=" + id));
            if (output.Contains(@"""Status"" : ""Off"))
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=" + id + "&nvalue=2&svalue=10");
            }
            else if (output.Contains(@"""Status"" : ""Set Level: 10 %"))
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=" + id + "&nvalue=2&svalue=20");
            } 
            else if (output.Contains(@"""Status"" : ""Set Level: 20 %"))
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=" + id + "&nvalue=2%&svalue=30");
            }
            else
            {
                DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=udevice&idx=" + id + "&nvalue=2&svalue=0");
            }
        }

        public void TurnOn(int id)
        {
            DomoticzHandler("http://127.0.0.1:8080/json.htm?type=command&param=switchlight&idx=" + id + "&switchcmd=On");
        }

        public int GetRoomDevices(int roomID, string device)
        {
            int number = 0;
            DomoticzChecker("http://127.0.0.1:8080/json.htm?type=command&param=getplandevices&idx=" + roomID);
            if (device == "temperatuur")
            {
                number = 1;
            }
            if (device == "media player")
            {
                number = 2;
            }
            if (device == "gordijn")
            {
                number = 3;
            }
            return Convert.ToInt32(devices[number]);
        }
    }
}