using System;
using System.Collections.Generic;
using System.Text;

namespace IGIS_Driver_App.DBModels
{
    public class Route
    {
        public int RouteID { get; set; }
        public string RouteTransportType { get; set; }
        public int RouteSignature { get; set; }
        public int RouteNumber { get; set; }
        public string FirstEndingStation { get; set; }
        public string SedondEndingStation { get; set; }
    }
}
