using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net;
using System.Net.Http.Headers;
using System.IO;
using Newtonsoft.Json.Linq;

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
                    return null;
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

    //contain current structured info about route
    //leter replace all id's to actual string names
    public class Route
    {
        public Route(short rId, int begin, int end)
        {
            RouteId = rId;
            StopBeginId = begin;
            StopEndId = end;
        }
        public string DisplayedName { get; private set; }
        public short RouteId { get; private set; }
        public int StopBeginId { get; private set; }
        public int StopEndId { get; private set; }
    }

    //contain current structured info about transport vehicle
    public class Transport
    {
        public string Code { get; private set; }
        public string GosNumber { get; private set; }
        public Route Route { get; private set; }
        //public float latitude { get; private set; }
        //public float longitude { get; private set; }
        //public short azimuth { get; private set; }
        public string Status { get; private set; }          //need to create Status class and change type of this fild to it!!!!!
        //public DateTime reysBegin { get; private set; }
        //public DateTime reysEnd { get; private set; }
        public int StopPreviousId { get; private set; }
        public int StopCurrentId { get; private set; }
        public int StopNextId { get; private set; }
        public int SecondsToTheNextStop { get; private set; }
        public int DeviationInSeconds { get; private set; }
        public Transport SecondsToPreviousTransport { get; private set; }
        public Transport SecondsToNextTransport { get; private set; }
        public Transport(string gosNumber)
        {
            GosNumber = gosNumber;
            Code = "18-001-1-0005656"; //when DB will be - add request for Code (based on gos number) insted of placeholder
            GetData();
        }
        public void GetData()
        {
            var data = APIControll.GetRequest(0, Code);
            Route = new Route((short)data["route_id"], (int)data["stop_begin"], (int)data["stop_end"]);
            Status = (string)data["status"];
            //when DB will be - add request for Stop's (based on id's)
            StopPreviousId = (int)data["stop_previous"];
            StopCurrentId = (int)data["stop_current"];
            StopNextId = (int)data["stop_next"];
            SecondsToTheNextStop = (int)data["seconds_to_next_stop"];
            DeviationInSeconds = (int)data["seconds_deviation"];
            //SecondsToPreviousTransport = 
        }
    }
}
