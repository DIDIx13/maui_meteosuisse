namespace maui_meteosuisse.Models;

public class WeatherWidget
{
    public Data data { get; set; }
    public Config config { get; set; }
}

public class Data
{
    public int altitude { get; set; }
    public string city_name { get; set; }
    public Current current { get; set; }
    public int weather_symbol_id { get; set; }
    public string location_id { get; set; }
    public Forecast[] forecasts { get; set; }
    public int timestamp { get; set; }
}

public class Current
{
    public string temperature { get; set; }
    public string weather_symbol_id { get; set; }
}

public class Forecast
{
    public long noon { get; set; }
    public string temp_high { get; set; }
    public string weekday { get; set; }
    public string temp_low { get; set; }
    public string weather_symbol_id { get; set; }
}

public class Config
{
    public string name { get; set; }
    public string language { get; set; }
    public string version { get; set; }
    public int timestamp { get; set; }
}
