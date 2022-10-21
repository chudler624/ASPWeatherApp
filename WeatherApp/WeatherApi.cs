using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;
using WeatherApp.Models;

namespace WeatherApp
{
    public class WeatherApi
    {
        public WeatherApi() { }


        public CurrentWeatherModel GetTodaysForcast(string zipCode)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weatherbit-v1-mashape.p.rapidapi.com/current?postal_code={zipCode}&country=US&units=imperial&lang=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
                    { "X-RapidAPI-Host", "weatherbit-v1-mashape.p.rapidapi.com" },
                },
            };

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;
                var todaysForcast = JObject.Parse(body)["data"];
                var currentForcastResults = JsonConvert.DeserializeObject<CurrentDayForcastResult>(body);

                //get first and only data object
                var resultData = currentForcastResults.data.First();

                var CurrentWeatherModel = new CurrentWeatherModel();
                CurrentWeatherModel.CityName = resultData.city_name;
                CurrentWeatherModel.Temperature = resultData.temp;
                CurrentWeatherModel.DateAndTime = resultData.datetime;
                CurrentWeatherModel.Description = resultData.weather.description;
                CurrentWeatherModel.WeatherIcon = resultData.weather.icon;

                return CurrentWeatherModel;
            }
        }

        public FiveDayWeatherModel GetFiveDayForcast(string zipCode)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?postal_code={zipCode}&country=US&units=imperial&lang=en"),
                Headers =
                {
                    { "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
                    { "X-RapidAPI-Host", "weatherbit-v1-mashape.p.rapidapi.com" },
                },
            };

            using (var response = client.SendAsync(request).Result)
            {
                response.EnsureSuccessStatusCode();
                var body = response.Content.ReadAsStringAsync().Result;
                var fiveDayForcastResults = JsonConvert.DeserializeObject<FiveDayForcastResults>(body);

                var fiveDayForcastList = fiveDayForcastResults.data.OrderBy(x => x.datetime);
                var testStr = "2022-05-01:15";

                //var newDate = testStr.Substring();
                //IndexAt
                //how to parse through a string


                foreach (var item in fiveDayForcastList)
                {
                    var fiveDayWeatherModel = new FiveDayWeatherModel();
                    //fiveDayWeatherModel.CityName = day.;
                    //fiveDayWeatherModel.Temperature = day.fiveDayData.

                }
                return new FiveDayWeatherModel();
            }
        }
    }
}
