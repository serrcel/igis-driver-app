using System;
using System.Collections.Generic;
using System.Text;

namespace IGIS_Driver_App.DBModels
{
    public class Subroute
    {
        public int RouteID { get; set; }
        public int Direction { get; set;}
        public string StopIDs { get; set;}
        public int IsChangingStopSet { get; set; }

    }
}
