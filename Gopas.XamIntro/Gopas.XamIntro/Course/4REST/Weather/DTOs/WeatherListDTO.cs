using System.Collections.Generic;

namespace Gopas.XamIntro.Course._4REST.Weather.DTOs
{
    class WeatherLocationDTO
    {
        public string cod { get; set; }
        public double message { get; set; }
        public int cnt { get; set; }
        public List<ForecastDTO> list { get; set; }
        public CityDTO city { get; set; }
    }
}
