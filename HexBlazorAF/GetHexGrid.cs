using HexBlazorInterfaces.Structs;
using HexBlazorLib.Grids;
using HexBlazorLib.SvgHelpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace HexBlazorAF
{
    public static class GetHexGrid
    {
        [FunctionName("GetHexGrid")]
        public static async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req)
        {
            // parse the request body and get params for the grid
            var requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            HexGridParams p = JsonConvert.DeserializeObject<HexGridParams>(requestBody);
            
            // generate a grid from the supplied params
            var grid = new Grid(p);
            var svgGrid = SvgGridBuilder.Build(grid, p.ViewBox);

            // serialize the svgGrid as JSON and return:
            var jsonized = JsonConvert.SerializeObject(svgGrid, Formatting.None);
            return new OkObjectResult(jsonized);
        }
    }
}

