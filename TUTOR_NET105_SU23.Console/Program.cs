using System.Text.Json;
using Tutor_Net105_B1_Console;

#region Math
//HttpClient client = new HttpClient();
//Console.Write("num1 = ");
//int num1Request = Convert.ToInt32(Console.ReadLine());
//Console.Write("num2 = ");
//int num2Request = Convert.ToInt32(Console.ReadLine());
//Console.Write("num3 = ");
//int num3Request = Convert.ToInt32(Console.ReadLine());
//string url = string.Concat("https://localhost:7196/Maths/average?num1=",num1Request, "&num2=", num2Request, "&num3=", num3Request);

//var respone = await client.GetAsync(url);
//var content = await respone.Content.ReadAsStringAsync();
//Console.WriteLine(content);
#endregion

#region Call API -> Get Data
var client = new HttpClient();
var response = await client.GetAsync("https://localhost:7196/WeatherForecast/Get");
var json = await response.Content.ReadAsStringAsync();
var options = new JsonSerializerOptions
{
    PropertyNameCaseInsensitive = true
};

var weatherForecasts = JsonSerializer.Deserialize<List<WeatherForecast>>(json, options);

foreach (var forecast in weatherForecasts)
{
    Console.WriteLine($"Date: {forecast.Date}, Temperature: {forecast.TemperatureC} C ({forecast.TemperatureF} F), Summary: {forecast.Summary}");

}
#endregion

Console.ReadKey();
