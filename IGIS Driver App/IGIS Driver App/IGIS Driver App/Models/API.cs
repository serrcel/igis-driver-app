using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json.Linq;
using System.Xml.Linq;
using System.Diagnostics;

namespace IGIS_Driver_App.Models
{
    public static class API
    {
        public static readonly string driverRequest = "https://testapi.igis-transport.ru/driver-CS4aPcdcqoU2U5Xe/ts/";
        public static readonly string routeRequest = "https://testapi.igis-transport.ru/driver-CS4aPcdcqoU2U5Xe/schedule/";
        static readonly HttpClient client = new HttpClient();
        public static HttpWebRequest Request { get; private set; }
        public static JObject Response { get; private set; }

        public static string GetTimePrev()
        {
            try
            {
                var result = Response["data"]["nearest_ts"]["back"]["seconds"].ToString().Split(',', '.')[0];
                int result_int = int.Parse(result);
                result_int = result_int / 60;
                return result_int.ToString();
            }
            catch
            {
                return "0";
            }
        }
        public static string GetTimeNext()
        {
            try
            {
                var result = Response["data"]["nearest_ts"]["forward"]["seconds"].ToString().Split(',', '.')[0];
                int result_int = int.Parse(result);
                result_int = result_int / 60;
                return result_int.ToString();
            }
            catch
            {
                return "0";
            }
        }
        public static string GetNextStopId()
        {
            try
            {
                var result = Response["data"]["stop_next"];
                return result.ToString();
            }
            catch
            {
                return "0";
            }
        }
        public static string GetRouteId()
        {
            try
            {
                var result = Response["data"]["route_id"];
                return result.ToString();
            }
            catch
            {
                return "0";
            }
        }

        public static async Task GetReq(short requestType, string tsCode)
        {
            HttpResponseMessage response = await client.GetAsync(driverRequest + tsCode);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            Debug.WriteLine(responseBody);
            Response = JObject.Parse(responseBody);
        }
        public static JObject GetRequest(short requestType, string tsCode)
        {
            switch (requestType)
            {
                case 0:
                    Request = WebRequest.CreateHttp(driverRequest + tsCode);
                    break;
                case 1:
                    Request = WebRequest.CreateHttp(routeRequest + tsCode);
                    break;
            }
            Request.Method = "GET";

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)Request.GetResponse();
                var stream = httpWebResponse.GetResponseStream();
                if (stream != null)
                    Response = JObject.Parse(new StreamReader(stream).ReadToEnd());
                Debug.WriteLine(Response["data"]["stop_next"].ToString());
                return Response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

}