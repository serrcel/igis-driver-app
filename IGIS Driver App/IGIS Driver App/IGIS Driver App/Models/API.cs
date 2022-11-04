﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;

namespace IGIS_Driver_App.Models
{
    public static class APIControll
    {
        public static readonly string driverRequest = "https://testapi.igis-transport.ru/driver-CS4aPcdcqoU2U5Xe/ts/";
        public static readonly string routeRequest = "https://testapi.igis-transport.ru/driver-CS4aPcdcqoU2U5Xe/schedule/";
        public static HttpWebRequest Request { get; private set; }
        public static JObject Response { get; private set; }
        public static JObject GetRequest(short requestType, string tsCode)
        {
            Request.Method = "GET";
            switch (requestType)
            {
                case 0:
                    Request = WebRequest.CreateHttp(driverRequest + tsCode);
                    break;
                case 1:
                    Request = WebRequest.CreateHttp(routeRequest + tsCode);
                    break;
            }

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)Request.GetResponse();
                var stream = httpWebResponse.GetResponseStream();
                if (stream != null)
                    Response = JObject.Parse(new StreamReader(stream).ReadToEnd());
                return Response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}