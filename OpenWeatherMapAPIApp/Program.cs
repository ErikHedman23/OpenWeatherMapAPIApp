using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using OpenWeatherMapAPIApp;

var weatherAPI = new OpenWeatherAPIApp();
bool userInputZC = true;
do
{
    Console.WriteLine("Hello, to deterime the weather in your local area, or the area of your choice, please, first enter a zip code here:");

    userInputZC = int.TryParse(Console.ReadLine(), out int zipCode);


    if (userInputZC == false)
    {
        Console.WriteLine("Invalid entry: Please enter a valid zip code to continue...");

    }

    weatherAPI.CallOpenWeatherAPI(zipCode);

} while (userInputZC == false);
