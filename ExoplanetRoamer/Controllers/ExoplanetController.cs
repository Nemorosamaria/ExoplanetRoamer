using ExoplanetRoamer.Models;
using ExoplanetRoamer.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExoplanetRoamer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExoplanetController : ControllerBase
    {
        private readonly IExoplanetQuery _nasaClient;

        public ExoplanetController(IExoplanetQuery nasaClient)
        {
            _nasaClient = nasaClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Planet>>> GetExoplanets()
        {
            var result = await _nasaClient.GetExoplanets();

            return Ok(result);
        }
    }
}
