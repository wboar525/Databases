// обратимся к OpenWeatherAPI по ключу с целью получения информации о погоде в заданном городе/местности

using System;
using System.Linq;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
#nullable disable

string appid = "";
string city = "Moscow,RU";

HttpClient client = new HttpClient();

async Task<OpenWeatherResponse> GetOpenWeatherAPIData()
{
    string responseBody = await client.GetStringAsync("http://api.openweathermap.org/data/2.5/weather?q=" + city + "&appid=" + appid + "&units=metric&lang=ru");
    System.Console.WriteLine(responseBody);
    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(responseBody);
    return rawWeather;
}

OpenWeatherResponse info = await GetOpenWeatherAPIData();

System.Console.WriteLine();
System.Console.WriteLine("В г." + info.Name + " сейчас " + info.Main.Temp + " градусов Цельсия, чувствуется как " + info.Main.Feels_Like + " градусов Цельсия");
System.Console.WriteLine(" Скорость ветра составляет : " + info.Wind.Speed + " м/с");

public class OpenWeatherResponse
{
    public string Name { get; set; }
    public Main Main { get; set; }
    public Wind Wind { get; set; }
}

public class Main
{
    public string Temp { get; set; }
    public string Feels_Like { get; set; }
}

public class Wind
{
    public string Speed { get; set; }
}
