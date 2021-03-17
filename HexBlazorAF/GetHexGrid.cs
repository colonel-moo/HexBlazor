using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using HexBlazorLib.Coordinates;
using HexBlazorLib.Grids;

namespace HexBlazorAF
{
    public static class GetHexGrid
    {
        [FunctionName("GetHexGrid")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var content = await new StreamReader(req.Body).ReadToEndAsync();
            HexGridParams p = JsonConvert.DeserializeObject<HexGridParams>(content);
            var grid = new Grid(p.RowCount, p.ColCount, p.Size, p.Origin, p.Schema);
            return new OkObjectResult(grid);
        }
    }

    internal struct HexGridParams
    {
        public readonly int RowCount;
        public readonly int ColCount;
        public readonly GridPoint Size;
        public readonly GridPoint Origin;
        public readonly OffsetSchema Schema;

        public HexGridParams(int rowCount, int colCount, GridPoint size, GridPoint origin, OffsetSchema schema)
        {
            RowCount = rowCount;
            ColCount = colCount;
            Size = size;
            Origin = origin;
            Schema = schema;
        }

    }

}

