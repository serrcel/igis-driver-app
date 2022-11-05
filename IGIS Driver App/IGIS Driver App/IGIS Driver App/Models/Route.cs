using System;
using System.Collections.Generic;
using System.Text;

namespace IGIS_Driver_App.Models
{
    public class Route
    {
        public Route(int rId, int begin, int end)
        {
            RouteId = rId;
            StopBeginId = begin;
            StopEndId = end;
        }
        public string DisplayedName { get; private set; }
        public int RouteId { get; private set; }
        public int StopBeginId { get; private set; }
        public int StopEndId { get; private set; }
    }
}
