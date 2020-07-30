using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
            string url = string.Format("https://localhost:44324/m2");
            M2RequestModel requestModel = new M2RequestModel();
            var json = JsonConvert.SerializeObject(requestModel);
            // Json, Request - url, data
            // Request of gRPC

            var data = new StringContent(json, Encoding.UTF8, "application/json");// remove
            var jsonResponse = getClient().PostAsync(url, data).Result; // remove

            // gRPC response -> M2ResponseModel.proto -> M2ResponseModel
            M2ResponseModel m2ResponseModel = JsonConvert.DeserializeObject<M2ResponseModel>(await jsonResponse.Content.ReadAsStringAsync());
            return Ok(m2ResponseModel);
        }

        private HttpClient getClient()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Accept", "application/json");
            return client;
        }
    }
}
