using System;
using System.Collections.Generic;
using System.Text;

namespace IGIS_Driver_App.DBModels
{
    public class Stop
    {
        public int StopID { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
        public string DirectionFromStop { get; set; }
        public int TransportType { get; set;}
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int IsDemanded { get; set; }

    }
}
