using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._4REST.Weather.DTOs
{
    class TempDTO
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }
}
