using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Microservice.Controllers
{
    [ApiController]
    [Route("/m2")]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        public MainController()
        {

        }
        public MainController(ILogger<MainController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> PostAsync()
        {
            M2ResponseModel responseModel = new M2ResponseModel();
            responseModel.success = true;
            responseModel.message = "done!!";
            
            return Ok(responseModel);
        }
    }
}
