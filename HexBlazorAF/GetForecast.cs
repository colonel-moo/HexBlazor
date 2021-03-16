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
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,09), TemperatureC = 18, Summary = "Freezing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,10), TemperatureC = 27, Summary = "Freezing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,11), TemperatureC = 36, Summary = "Bracing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,12), TemperatureC = 45, Summary = "Cool"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,13), TemperatureC = 56, Summary = "Cool"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,14), TemperatureC = 64, Summary = "Perfect"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,15), TemperatureC = 73, Summary = "Perfect"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,16), TemperatureC = 82, Summary = "Warm"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,17), TemperatureC = 91, Summary = "Hot"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,18), TemperatureC = 99, Summary = "Hot"},
            };

            return new OkObjectResult(forecast);
        }
    }
}

