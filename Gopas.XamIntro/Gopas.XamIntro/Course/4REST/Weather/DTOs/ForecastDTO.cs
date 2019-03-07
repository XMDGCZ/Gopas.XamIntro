using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gopas.XamIntro.Course._4REST.Weather.DTOs
{
    class ForecastDTO
    {
        [JsonConverter(typeof(UnixTimestampConverter))]
        public DateTime dt { get; set; }
        public TempDTO main { get; set; }
        public List<WeatherDTO> weather { get; set; }
        public CloudsDTO clouds { get; set; }
        public WindDTO wind { get; set; }
        public RainDTO rain { get; set; }
        public SysDTO sys { get; set; }
        public string dt_txt { get; set; }
    }
}
