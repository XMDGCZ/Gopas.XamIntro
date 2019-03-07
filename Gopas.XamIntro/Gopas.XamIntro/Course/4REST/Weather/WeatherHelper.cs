using Gopas.XamIntro.Course._4REST.Weather.DTOs;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Gopas.XamIntro.Course._4REST.Weather
{
    class WeatherHelper
    {
        private const string APIKEY = "14a0d3d20aabb40e459d7a9b6efed0dd";
        public async static Task<WeatherListDTO> GetCurrentConditionsAsync(double latitude, double longitude)
        {
            string url = $"https://api.openweathermap.org/data/2.5/forecast?lat={latitude}&lon={longitude}&APPID={APIKEY}";
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = Newtonsoft.Json.JsonConvert.DeserializeObject<WeatherListDTO>( await response.Content.ReadAsStringAsync());
                return result;
            }
            return null;
        }
    }
}
