using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._4REST.Weather.DTOs
{
    class CityDTO
    {
        public string name { get; set; }
        public CoordDTO coord { get; set; }
        public string country { get; set; }
    }
}
