namespace WeatherApp.Models
{
    public class WeatherModel
    {
        public string Name { get; set; }
        public string Region { get; set; }
        public double TemperatureF { get; set; }
        public string Description { get; set; }
        public double WindSpeed { get; set; }
        public string WindDir { get; set; }
        public double Humidity { get; set; }
        public double FeelsLikeF { get; set; }
        public double MaxTempF { get; set; }
        public double MinTempF { get; set; }
        public double TotalPrecip { get; set; }
        public double UV { get; set; }
        public string SunRise { get; set; }
        public string SunSet { get; set; }

    }
}
