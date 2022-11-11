using System;
using System.Collections.Generic;
using System.Text;

namespace IGIS_Driver_App.DBModels
{
    public class Carrier
    {
        public string CarrierCode { get; set; }
        public string CarrierName { get; set;}
        public double CarrierLongitude { get; set; }
        public double CarrierLatitude { get; set;}
        public string CarrierAddress { get; set; }
        public string CarrierPhoneNumber { get; set;}
    }
}
