using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    [ApiController]
    [Route("/m1")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAsync()
        {
            string url = string.Format("https://localhost:5000");
            M2RequestModel requestModel = new M2RequestModel()
            {
                name = "M2_Request"
            };
            var adapter = new GRPCAdapter();
            var message = await adapter.OutGoingRequestAsync(url, requestModel);
            
            return Ok(message);
        }

        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}
