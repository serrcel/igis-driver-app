using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
namespace IGIS_Driver_App.Models
{
    [SQLite.Table("Route")]
    public class Route
    {
        [PrimaryKey]
        public int ts_code { get; set; }
        public string RouteTransportType { get; set; }
        public int RouteSignature { get; set; }
        public int RouteNumber { get; set; }
        public string FirstEndingStation { get; set; }
        public string SecondEndingStation { get; set; }
    }
}
