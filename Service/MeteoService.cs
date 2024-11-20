using System.Net.Http.Json;
using maui_meteosuisse.Models;

namespace maui_meteosuisse.Service;

public class MeteoService
{
    const string baseurl = "https://www.meteosuisse.admin.ch";
    
    public async Task<Data> GetWeatherAsync(string version)
    {
        HttpClient client = new HttpClient();
        // Get json from url and deserialise it into a WeatherWidget object
        WeatherWidget weatherWidget = await client.GetFromJsonAsync<WeatherWidget>($"{baseurl}/product/output/weather-widget/forecast/version__{version}/fr/200000.json");
        if (weatherWidget != null)
        {
            return weatherWidget.data;
        }
        return null;
    }
    public async Task<string> GetVersion(string uri)
    {
        HttpClient client = new HttpClient();
        string version = await client.GetStringAsync($"{baseurl}/product/output/versions.json");
        version = version.Replace("{", "").Replace("}", "");
        string[] lines = version.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string cleanLine = line.Replace("\"", "").Replace("\\", "");
            string[] values = cleanLine.Split(new string[] { ":" }, StringSplitOptions.None);
            if (values[0].Trim() == uri)
            {
                return values[1].Trim();
            }
        }
        return String.Empty;
    }
    public async Task<Dictionary<string, string>> GetLocalities(string uri)
    {
        Dictionary<string, string> localities = new Dictionary<string, string>();
        // Create HTTPClient to get the json data from url
        HttpClient client = new HttpClient();
        // Get the json data from url
        string response = await client.GetStringAsync($"{baseurl}/static/product/resources/local-forecast-search/{uri}.json");
        // Remove brackets
        response = response.Replace("[", "").Replace("]", "");
        // Split the string into an array
        string[] lines = response.Split(new string[] { "\n", "\r\n " }, StringSplitOptions.RemoveEmptyEntries);
        foreach (string line in lines)
        {
            string cleanLine = line.Replace("\"", "").Replace(",", "");
            string[] values = cleanLine.Split(new string[] { ";" }, StringSplitOptions.None);
            localities.Add(values[0], values[values.Length - 2]);
        }

        return localities;
    }
}
