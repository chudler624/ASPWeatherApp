namespace WeatherApp
{
    public class WeatherApi
    {
        public WeatherApi() { }
        

            public async Task GetForcastAsync()
            {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://weatherbit-v1-mashape.p.rapidapi.com/forecast/3hourly?lat=35.5&lon=-78.5"),
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
                //Console.WriteLine(body);
            }


        }

        

    }
}
