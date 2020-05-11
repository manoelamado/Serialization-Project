using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Threading.Tasks;

using System.Collections.Specialized;

namespace Serialization_Project
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Serialization Project!\n");

            // GitHubSerializer();

            // GitHubDeSerializer();

            BingLocationDeSerializer();

            // BingRouteDeSerializer();
        }
        public static void GitHubSerializer()
        {
            WeatherForecast wf = new WeatherForecast();

            wf.Summary = "Summary";
            wf.TemperatureCelsius = 50;

            DateTime dstDate = new DateTime(2007, 6, 10, 0, 0, 0);
            wf.Date = dstDate;

            string jsonString1;
            jsonString1 = JsonSerializer.Serialize(wf);

            Console.WriteLine("Results from GitHubSerializer\n");
            Console.WriteLine(jsonString1);

            WeatherForecastWithPOCOs wf2 = new WeatherForecastWithPOCOs();
            wf2.Summary = "Hot";
            wf2.TemperatureCelsius = 50;
            wf2.Date = dstDate;

            HighLowTemps ColdTemps = new HighLowTemps();
            ColdTemps.High = 20;
            ColdTemps.Low = -10;

            HighLowTemps HotTemps = new HighLowTemps();
            HotTemps.High = 20;
            HotTemps.Low = 20;

            Dictionary<string, HighLowTemps> temps = new Dictionary<string, HighLowTemps>();
            temps.Add("Cold", ColdTemps);
            temps.Add("Hot", HotTemps);

            wf2.TemperatureRanges = temps;

            DateTimeOffset availability1 = new DateTime(2019, 8, 1, 0, 0, 7);
            DateTimeOffset availability2 = new DateTime(2019, 8, 2, 0, 0, 7);

            IList<DateTimeOffset> obj = new List<DateTimeOffset>();
            obj.Add(availability1);
            obj.Add(availability2);

            wf2.DatesAvailable = obj;

            string[] words = { "One", "Two", "Three" };
            wf2.SummaryWords = words;

            string jsonString2;
            jsonString2 = JsonSerializer.Serialize<WeatherForecastWithPOCOs>(wf2);

            Console.WriteLine("\nResults from JsonSerializer #2\n");
            Console.WriteLine(jsonString2);
        }
        
        public static void GitHubDeSerializer()
        {
            string fileName = "C:/Users/maamad/Documents/Personal/Alex/Coding Assessment/TestData.json";
            string jsonString;

            // WeatherForecast wf = new WeatherForecast();
            WeatherForecastWithPOCOs wf3 = new WeatherForecastWithPOCOs();

            Console.WriteLine("\nJSON File Contents \n");
            jsonString = File.ReadAllText(fileName);

            Console.WriteLine(jsonString);

            wf3 = JsonSerializer.Deserialize<WeatherForecastWithPOCOs>(jsonString);

            Console.WriteLine("\nResults from JsonSerializer.Deserialize \n");
            Console.WriteLine("Date " + wf3.Date + "\n");
            Console.WriteLine("TemperatureCelsius " + wf3.TemperatureCelsius + "\n");
            Console.WriteLine("Summary " + wf3.Summary + "\n");
            Console.WriteLine("SummaryWords[0] " + wf3.SummaryWords[0] + "\n");
            Console.WriteLine("SummaryWords[1] " + wf3.SummaryWords[1] + "\n");
            Console.WriteLine("SummaryWords[2] " + wf3.SummaryWords[2] + "\n");
            //Console.WriteLine("SummaryWords[0] " + wf3.DatesAvailable[0] + "\n");
            //Console.WriteLine("SummaryWords[1] " + wf3.DatesAvailable[1] + "\n");
        }
        public static void BingLocationDeSerializer()
        {
            string jsonString;

            Console.WriteLine("\nBING LOCATION RESPONSE JSON: \n");

            // Get JSON From a file
            // string fileName = "C:/Users/maamad/Documents/Personal/Alex/Coding Assessment/BingRouteResponse.json";
            // jsonString = File.ReadAllText(fileName);

            // Get JSON Response from Bing Location API Call
            string URI = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=Seattle,WA&wp.1=Redmond,WA&avoid=minimizeTolls&key=AgaqjxdNFdxk1bUKfd1RiTIZrrTyJd3167Y-GS0BEr0JgpL754QvpYGGW_Njfw_7";
            
            using (var client = new WebClient())
            {
                jsonString = client.DownloadString(URI);
            }

            Console.WriteLine(jsonString);

            BingLocation loc = new BingLocation();
            loc = JsonSerializer.Deserialize<BingLocation>(jsonString);

            Console.WriteLine("\nResults from BingLocationDeSerializer: \n");
            Console.WriteLine("AuthenticationResultCode: " + loc.authenticationResultCode + "\n");
            Console.WriteLine("BrandLogoUri: " + loc.brandLogoUri + "\n");
            Console.WriteLine("Copyright: " + loc.copyright + "\n");
            Console.WriteLine("EstimatedTotal: " + loc.resourceSets[0].estimatedTotal + "\n");
            Console.WriteLine("Name: " + loc.resourceSets[0].resources[0].name + "\n");
        }

        public static void BingRouteDeSerializer()
        {
            string jsonString;

            Console.WriteLine("\nBING ROUTE RESPONSE JSON: \n");

            // Get JSON From a file
            // string fileName = "C:/Users/maamad/Documents/Personal/Alex/Coding Assessment/BingLocationResponse.json";
            // jsonString = File.ReadAllText(fileName);

            // Get JSON Response from Bing Location API Call
            string URI = "http://dev.virtualearth.net/REST/V1/Routes/Driving?o=json&wp.0=Seattle,WA&wp.1=Redmond,WA&avoid=minimizeTolls&key=AgaqjxdNFdxk1bUKfd1RiTIZrrTyJd3167Y-GS0BEr0JgpL754QvpYGGW_Njfw_7";
            using (var client = new WebClient())
            {
                jsonString = client.DownloadString(URI);
            }

            Console.WriteLine(jsonString);

            BingRoute rte = new BingRoute();
            rte = JsonSerializer.Deserialize<BingRoute>(jsonString);

            Console.WriteLine("\nResults from BingLocationDeSerializer: \n");
            Console.WriteLine("AuthenticationResultCode: " + rte.authenticationResultCode + "\n");
            Console.WriteLine("BrandLogoUri: " + rte.brandLogoUri + "\n");
            Console.WriteLine("Copyright: " + rte.copyright + "\n");
            Console.WriteLine("EstimatedTotal: " + rte.resourceSets[0].estimatedTotal + "\n");
            Console.WriteLine("Lat: " + rte.resourceSets[0].resources[0].routeLegs[0].itineraryItems[0].maneuverPoint.coordinates[0] + "\n");
            Console.WriteLine("Long: " + rte.resourceSets[0].resources[0].routeLegs[0].itineraryItems[0].maneuverPoint.coordinates[1] + "\n");
        }
    }
}
