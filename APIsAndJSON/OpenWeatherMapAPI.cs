using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static System.Net.WebRequestMethods;

namespace APIsAndJSON;

public class OpenWeatherMapAPI
{
    private HttpClient _client;

    /// <summary>
    /// This is a client
    /// </summary>
    /// <param name="client">instance</param>
    public OpenWeatherMapAPI(HttpClient client)
    {
        _client = client;
    }

    /// <summary>
    /// This does something
    /// </summary>
    public void Action()
    {
        var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
        var apiKey = config["api_key"];

        string weatherUrl = $"https://api.openweathermap.org/data/2.5/weather?q=Orem&appid={apiKey}&units=imperial";
        var weatherCall = _client.GetStringAsync(weatherUrl).Result;
        //var currentWeather = JObject.Parse(weatherCall);

        //Console.WriteLine(currentWeather["main"]["temp"]);

        WeatherModel model = JsonConvert.DeserializeObject<WeatherModel>(weatherCall);
        Console.WriteLine($"{model.name}  {model.main.temp} degrees Fahrenheit");
    }

}
