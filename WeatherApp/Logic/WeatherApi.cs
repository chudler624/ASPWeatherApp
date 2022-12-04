using Newtonsoft.Json;
using WeatherApp.Models;

namespace WeatherApp.Logic
{
    public class WeatherApi
    {
        public WeatherApi() { }

        public WeatherModel GetForecast(string zipCode)
        {
			var client = new HttpClient();
			var request = new HttpRequestMessage
			{
				Method = HttpMethod.Get,
				RequestUri = new Uri($"https://weatherapi-com.p.rapidapi.com/forecast.json?q={zipCode}=1&lang=english"),
				Headers =
				{
					{ "X-RapidAPI-Key", "fe96c29976msh7164fa7f072bef1p19efc6jsn0ad83cbe2bb2" },
					{ "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" },
				},
			};

			using (var response = client.SendAsync(request).Result)
			{
				response.EnsureSuccessStatusCode();
				var body = response.Content.ReadAsStringAsync().Result;
				
				var forecast = JsonConvert.DeserializeObject<ForecastResults>(body);

				var weatherModel = new WeatherModel();

				weatherModel.Name = forecast.location.name;
				weatherModel.Region = forecast.location.region;
				weatherModel.TemperatureF = forecast.current.temp_f;
				weatherModel.FeelsLikeF = forecast.current.feelslike_f;
				weatherModel.Description = forecast.current.condition.text;
				weatherModel.WindSpeed = forecast.current.wind_mph;
				weatherModel.WindDir = forecast.current.wind_dir;
				weatherModel.Humidity = forecast.current.humidity;
				foreach(var item in forecast.forecast.forecastday) { weatherModel.MaxTempF = item.day.maxtemp_f; };
				foreach (var item in forecast.forecast.forecastday) { weatherModel.MinTempF = item.day.mintemp_f; };
				foreach (var item in forecast.forecast.forecastday) { weatherModel.TotalPrecip = item.day.totalprecip_in; };
				foreach (var item in forecast.forecast.forecastday) { weatherModel.UV = item.day.uv; };
				foreach (var item in forecast.forecast.forecastday) { weatherModel.SunRise = item.astro.sunrise; };
				foreach (var item in forecast.forecast.forecastday) { weatherModel.SunSet = item.astro.sunset; };

				return weatherModel;
			}
		}





    }
}
