using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestPing
{
    public static class Function1
    {
        [FunctionName("Time")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var now = DateTimeOffset.UtcNow;
            var responseMessage =
                "你已经顺利连上服务器了！\n" +
                $"当前服务器时间是：{now:F}\n" +
                $"本地时间是:{now.ToLocalTime():F}";
            return new OkObjectResult(responseMessage);
        }
    }
}
