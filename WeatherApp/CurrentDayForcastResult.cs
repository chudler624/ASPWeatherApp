namespace WeatherApp
{
    public class CurrentDayForcastResult
    {
        public List<Data> data { get; set; }
    }


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Data
    {

        public string city_name { get; set; }
        public double lat { get; set; }
        public string timezone { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public double lon { get; set; }
        public DateTime timestamp_utc { get; set; }
        public int snow { get; set; }
        public string wind_cdir { get; set; }
        public int rh { get; set; }
        public string pod { get; set; }
        public double pres { get; set; }
        public int pop { get; set; }
        public int clouds { get; set; }
        public double vis { get; set; }
        public double wind_spd { get; set; }
        public int clouds_mid { get; set; }
        public string wind_cdir_full { get; set; }
        public double slp { get; set; }
        public string datetime { get; set; }
        public int ts { get; set; }
        public double dewpt { get; set; }
        public double uv { get; set; }
        public int wind_dir { get; set; }
        public double dni { get; set; }
        public double ghi { get; set; }
        public double dhi { get; set; }
        public int precip { get; set; }
        public Weather weather { get; set; }
        public double temp { get; set; }
        public double app_temp { get; set; }
        public double ozone { get; set; }
        public int clouds_hi { get; set; }
        public int clouds_low { get; set; }
        public double wind_gust_spd { get; set; }
        public DateTime timestamp_local { get; set; }
        public double solar_rad { get; set; }
        public int snow_depth { get; set; }
    }


    public class Weather
    {
        public string description { get; set; }
        public int code { get; set; }
        public string icon { get; set; }
    }


}
