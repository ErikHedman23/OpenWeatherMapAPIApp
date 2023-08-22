using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenWeatherMapAPIApp
{
    public class OpenWeatherAPIApp
    {
        public async void CallOpenWeatherAPI(int zipCode)
        {
            var client = new HttpClient();

            var apiKeyObj = File.ReadAllText("appsettings.json");

            
            var apiKey = JObject.Parse(apiKeyObj).GetValue("apiKey").ToString();

            
            var apiURL = $"https://api.openweathermap.org/data/2.5/weather?zip={zipCode}&appid={apiKey}&units=imperial";

            var response = client.GetAsync(apiURL).Result;
            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var weatherData = JObject.Parse(responseBody);

                var cityName = weatherData["name"].ToString();
                var temperature = weatherData["main"]["temp"].ToString();
                var tempLow = weatherData["main"]["temp_min"].ToString();
                var tempHigh = weatherData["main"]["temp_max"].ToString();
                var humidity = weatherData["main"]["humidity"].ToString();
                var description = weatherData["weather"][0]["description"].ToString();
                

                Console.WriteLine($"Today in {cityName}");
                Thread.Sleep(500);
                Console.Write("~~ ");
                Thread.Sleep(500);
                Console.Write("~~ ");
                Thread.Sleep(500);
                Console.Write("~~ \n");
                Thread.Sleep(2000);
                Console.WriteLine($"The current temperature is: {temperature} degrees Fahrenheit\n\nWith a low today of: {tempLow} degrees Fahrenheit\n\nA high of: {tempHigh} degrees Fahrenheit\n\nAnd humidity at a nice {humidity}%");
                Thread.Sleep(500);
                Console.Write("~~ ");
                Thread.Sleep(500);
                Console.Write("~~ ");
                Thread.Sleep(500);
                Console.Write("~~ \n");
                Thread.Sleep(2000);
                Console.WriteLine($"A brief description of the current weather is: {description}\n");
                Thread.Sleep(500);
                Console.Write(". . ");
                Thread.Sleep(500);
                Console.Write(". . ");
                Thread.Sleep(500);
                Console.Write(". . \n\n");
                Thread.Sleep(2000);
                Console.WriteLine("And thats it for the weather at the moment.  Come back later for an updated look at your current forecast!");
                //Console.WriteLine(weatherData);
            }
            else
            {
               
                Console.WriteLine($"API request failed with status code: {response.StatusCode}");
                
                 
            }
        }
    }
}
