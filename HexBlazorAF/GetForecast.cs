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
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,06), TemperatureC = -1, Summary = "Bitter"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,07), TemperatureC = 9, Summary = "Bitter"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,08), TemperatureC = 18, Summary = "Freezing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,09), TemperatureC = 27, Summary = "Freezing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,10), TemperatureC = 36, Summary = "Bracing"},
                new HexBlazorLib.WeatherForecast() { Date = new System.DateTime(2018,05,10), TemperatureC = 45, Summary = "Balmy"}
            };

            return new OkObjectResult(forecast);
        }
    }
}

