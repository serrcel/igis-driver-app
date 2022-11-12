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
using SQLite;

namespace IGIS_Driver_App.Models
{
    [SQLite.Table("Transport")]
    public class Transport
    {
        public string ts_code { get; set; }
        [PrimaryKey]
        public string gosnumber { get; set; }
        public string type { get; set; }
    }
}