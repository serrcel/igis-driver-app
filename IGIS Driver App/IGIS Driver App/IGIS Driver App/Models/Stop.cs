using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace IGIS_Driver_App.Models
{
    [SQLite.Table("Stop")]
    public class Stop
    {
        [PrimaryKey]
        public int StopID { get; set; }
        public string FullName { get; set; }
        public string ShortName { get; set; }
    }
}
