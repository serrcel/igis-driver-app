using System;
using System.Collections.Generic;
using System.Text;

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
            var data = API.GetRequest(0, Code);
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
