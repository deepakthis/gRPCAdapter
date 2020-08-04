using Microservice.Controllers;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GRPCLibrary
{
    public class GRPCAdapter<T> where T: class
    {
        public async Task<T> ServerAsync()
        {
            var controller = new MainController();
            IActionResult response = await controller.PostAsync();

            var m2Response = response as OkObjectResult;
            var grpcResponse = JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(m2Response.Value));

            return grpcResponse;
        }
    }
}
