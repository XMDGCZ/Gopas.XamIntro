using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._4REST.Weather.DTOs
{
    class WeatherDTO
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }
}
