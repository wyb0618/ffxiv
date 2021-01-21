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
        public static void sendCommand(string command)
        {
            new Thread(() => {
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
            }).Start();
        }

        public static void sendRecord(string rdmsg)
        {
            new Thread(() => {
                WebClient client = new WebClient();
                try
                {
                    client.Encoding = Encoding.UTF8;
                    client.Headers[HttpRequestHeader.ContentType] = "json";
                    string response = client.UploadString("http://www.wyblearn.xyz:8080/record", rdmsg);
                    sendCommand(response);
                    client.Dispose();
                }
                catch (Exception e)
                {
                    client.Dispose();
                }
            }).Start();
        }
    }
}
