using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace HexBlazorAF
{
    public static class GetForecast
    {
        [FunctionName("GetForecast")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req, ILogger log)
        {
            await Task.Delay(1);
            log.LogInformation("C# HTTP trigger function processed a request.");

            HexBlazorLib.WeatherForecast[] forecast = new HexBlazorLib.WeatherForecast[]
            {
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,09), TemperatureF = 18, Summary = "Freezing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,10), TemperatureF = 27, Summary = "Freezing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,11), TemperatureF = 36, Summary = "Bracing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,12), TemperatureF = 45, Summary = "Cool"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,13), TemperatureF = 56, Summary = "Cool"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,14), TemperatureF = 64, Summary = "Perfect"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,15), TemperatureF = 73, Summary = "Perfect"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,16), TemperatureF = 82, Summary = "Warm"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,17), TemperatureF = 91, Summary = "Hot"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,18), TemperatureF = 99, Summary = "Hot"},
            };

            return new OkObjectResult(forecast);
        }
    }
}

