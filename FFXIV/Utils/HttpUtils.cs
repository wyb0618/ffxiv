using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FFXIV.Utils
{
    public static class HttpUtils
    {
        public static void sendCommandSync(string command)
        {
            new Thread(() => {
                sendCommand(command);
            }).Start();
        }

        /* 暂时作废 */
        public static void sendRecordSync(string rdmsg)
        {
            new Thread(() => {
                sendRecord(rdmsg);
            }).Start();
        }

        public static void sendCommandWithChannel(string channel,string command)
        {
            sendCommand(channel + " " + command);
        }

        public static void sendCommand(string command)
        {
            
        }

        public static void sendCommandByHttpClient(string command)
        {
            WebClient client = new WebClient();
            try
            {
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "text";
                string response = client.UploadString("http://127.0.0.1:4869/command", command);
                client.Dispose();
            }
            catch (Exception e)
            {
                client.Dispose();
            }
        }


        /* 暂时作废 */
        public static void sendRecord(string rdmsg)
        {
            WebClient client = new WebClient();
            try
            {
                client.Encoding = Encoding.UTF8;
                client.Headers[HttpRequestHeader.ContentType] = "application/json";
                string response = client.UploadString("http://www.wyblearn.xyz:8080/record", rdmsg);
                sendCommand("/p "+response);
                client.Dispose();
            }
            catch (Exception e)
            {
                client.Dispose();
            }
        }
    }
}
