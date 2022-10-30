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
    public static class APIControll
    {
        public static readonly string driverRequest = "https://testapi.igis-transport.ru/driver-CS4aPcdcqoU2U5Xe/ts/";
        public static readonly string routeRequest = "https://testapi.igis-transport.ru/driver-CS4aPcdcqoU2U5Xe/schedule/";
        public static HttpWebRequest request { get; private set; }
        public static string response { get; private set; }
        public static string GetRequest(short requestType, string tsCode)
        {
            request.Method = "GET";
            switch (requestType)
            {
                case 0:
                    request = WebRequest.CreateHttp(driverRequest + tsCode);
                    break;
                case 1:
                    request = WebRequest.CreateHttp(routeRequest + tsCode);
                    break;
                    return null;
            }

            try
            {
                HttpWebResponse httpWebResponse = (HttpWebResponse)request.GetResponse();
                var stream = httpWebResponse.GetResponseStream();
                if (stream != null)
                    response = new StreamReader(stream).ReadToEnd();
                return response;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }

    //contain current structured info about transport vehicle

    public class Transport
    {
        public string code { get; private set; }
        public float latitude { get; private set; }
        public float longitude { get; private set; }
        public short azimuth { get; private set; }
        public string status { get; private set; }          //need to create Status class and change type of this fild to it!!!!!
        public short routeId { get; private set; }
        public DateTime reysBegin { get; private set; }
        public DateTime reysEnd { get; private set; }
        public int stopPreviousId { get; private set; }
        public int stopCurrentId { get; private set; }
        public int stopNextId { get; private set; }
        public int stopBeginId { get; private set; }
        public int stopEndId { get; private set; }
        public int secondsToTheNextStop { get; private set; }
        public int deviationInSeconds { get; private set; }
        public Transport previousTransport { get; private set; }
        public int secondsToNearest { get; private set; }
        public Transport nearestTransport { get; private set; }
        public void GetData()
        {

        }
    }
}
