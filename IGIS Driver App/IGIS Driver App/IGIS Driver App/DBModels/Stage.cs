using System;
using System.Collections.Generic;
using System.Text;

namespace IGIS_Driver_App.DBModels
{
    public class Stage
    {
        public int IDStart { get; set; }
        public int IDEnd { get; set; }
        public int StageLength { get; set; }
        public string StageCoordinates { get; set; }
    }
}
