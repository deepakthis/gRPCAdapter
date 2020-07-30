using Grpc.Core;
using Microservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microservice.Services
{
    public class GRPCCheckService : GRPCRequestResponse.GRPCRequestResponseBase
    {
        private readonly ILogger<GRPCCheckService> _logger;

        public GRPCCheckService(ILogger<GRPCCheckService> logger)
        {
            _logger = logger;
        }

        public override async Task<GRPCResponse> GRPCCheck(GRPCRequest request, ServerCallContext context)
        {
            var controller = new MainController();
            IActionResult response = await controller.PostAsync();

            var m2Response = response as OkObjectResult;
            var grpcResponse = JsonConvert.DeserializeObject<GRPCResponse>(JsonConvert.SerializeObject(m2Response.Value));
            
            return grpcResponse;
        
        }
    }
}
