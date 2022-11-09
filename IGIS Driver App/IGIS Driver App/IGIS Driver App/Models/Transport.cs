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
        public string GosNumber { get; set; }
        public Route Route { get; set; }
        //public float latitude { get; private set; }
        //public float longitude { get; private set; }
        //public short azimuth { get; private set; }
        public string Status { get; set; }          //need to create Status class and change type of this fild to it!!!!!
        //public DateTime reysBegin { get; private set; }
        //public DateTime reysEnd { get; private set; }
        public int StopPreviousId { get; set; }
        public int StopCurrentId { get; set; }
        public int StopNextId { get; set; }
        public int SecondsToTheNextStop { get; set; }
        public int DeviationInSeconds { get; set; }
        public float SecondsToPreviousTransport { get; set; }
        public float SecondsToNextTransport { get;  set; }
        public Transport(string gosNumber)
        {
            GosNumber = gosNumber;
            Code = "18-001-1-0005649"; //when DB will be - add request for Code (based on gos number) insted of placeholder
        }
        //remove all parce methods after finde out way to parce generics
    }
}