using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherService
    {
        private static WeatherService _instance;

        public static WeatherService Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new WeatherService();

                return _instance;
            }
        }
        public async Task<Weather> GetWeatherAsync(string zipCode)
        {
            string key = "fc9f6c524fc093759cd28d41fda89a1b";
            string queryString = "http://api.openweathermap.org/data/2.5/weather?zip="
                + zipCode + "&appid=" + key;

            var results = await GetDataFromServiceAsync(queryString).ConfigureAwait(false);

            if (results["weather"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["name"];
                weather.Temperature = (string)results["main"]["temp"] + " F";
                weather.Wind = (string)results["wind"]["speed"] + " mph";
                weather.Humidity = (string)results["main"]["humidity"] + " %";
                weather.Visibility = (string)results["weather"][0]["main"];

                DateTime time = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                DateTime sunrise = time.AddSeconds((double)results["sys"]["sunrise"]);
                DateTime sunset = time.AddSeconds((double)results["sys"]["sunset"]);
                weather.Sunrise = sunrise.ToString() + " UTC";
                weather.Sunset = sunset.ToString() + " UTC";

                return weather;
            }
            else
            {
                return null;
            }
        }

        internal static async Task<JContainer> GetDataFromServiceAsync(string queryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(queryString);

            JContainer data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = (JContainer)JsonConvert.DeserializeObject(json);
            }

            return data;
        }
    }
}