using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;

namespace IGIS_Driver_App.Models
{
    public class APIControll
    {
        public HttpWebRequest request { get; private set; }
        public string response { get; private set; }
        public void GetRequest(string httpAdres)
        {
            request.Method = "GET";
            request = WebRequest.CreateHttp(httpAdres);

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
                var stream = httpWebResponse.GetResponseStream();
                if (stream != null)
                    response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception ex)
            {

            }
        }
    }
    public class Driver
    {
        
    }
}
