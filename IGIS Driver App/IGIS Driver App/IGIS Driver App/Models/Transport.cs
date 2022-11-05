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

namespace IGIS_Driver_App.Models
{
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
        public float SecondsToPreviousTransport { get; private set; }
        public float SecondsToNextTransport { get; private set; }
        public Transport(string gosNumber)
        {
            GosNumber = gosNumber;
            Code = "18-001-1-0005710"; //when DB will be - add request for Code (based on gos number) insted of placeholder
            GetData();
        }
        //remove all parce methods after finde out way to parce generics
        public void GetData()
        {
            var data = API.GetRequest(0, Code);
            Route = new Route(
                int.Parse(API.GetResponseData("route_id")),
                int.Parse(API.GetResponseData("stop_begin")),
                int.Parse(API.GetResponseData("stop_end"))
                );
            Status = API.GetResponseData("status");
            //when DB will be - add request for Stop's (based on id's)
            StopPreviousId = int.Parse(API.GetResponseData("stop_previous"));
            StopCurrentId = int.Parse(API.GetResponseData("stop_current"));
            StopNextId = int.Parse(API.GetResponseData("stop_next"));
            SecondsToTheNextStop = int.Parse(API.GetResponseData("seconds_to_next_stop"));
            DeviationInSeconds = int.Parse(API.GetResponseData("seconds_deviation"));
            SecondsToPreviousTransport = int.Parse(API.GetResponseData("nearest_ts.back.seconds"));
            SecondsToNextTransport = int.Parse(API.GetResponseData("nearest_ts.forward.seconds"));
        }
    }
}