using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CollectResponseQr.Models;
using CollectResponseQr.Data;

namespace CollectResponseQr
{
    public class CollectApi
    {
        private readonly ApplicationDbContext _db;
        public CollectApi(ApplicationDbContext db)
        {
            _db = db;
        }


        [FunctionName("Collect")]
        public async Task<IActionResult> Collect(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "collectresponseqr")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("Receiving Qr payment confirmations.");
            string requestData = await new StreamReader(req.Body).ReadToEndAsync();
            var data = JsonConvert.DeserializeObject<ResponseQr>(requestData);

            var item = new ResponseQr
            {
                PayId = data.PayId,
                QrId = data.QrId,
                Amount = data.Amount,
                Description = data.Description,
                Metadata = data.Metadata
            };

            _db.ResponseQrs.Add(item);
            await _db.SaveChangesAsync();

            return new OkObjectResult(item);
        }
    }
}
