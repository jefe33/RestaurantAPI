using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly IWeatherForecastService _service;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherForecastService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpPost("generate")]
        public ActionResult<IEnumerable<WeatherForecast>> Func([FromQuery] int numOfResults, [FromBody] Container ranges)
        {
            if (numOfResults < 0 || ranges.MaxTemp < ranges.MinTemp)
            {
                return StatusCode(400);
            }
            var result = _service.Get(numOfResults, ranges.MinTemp, ranges.MaxTemp);
            return StatusCode(200, result);
        }

        [HttpPost]
        public ActionResult<string> Hello([FromBody] string name)
        {
            //HttpContext.Response.StatusCode = 401;
            //return StatusCode(401, $"Hello {name}");
            return NotFound($"Hello {name}");
        }
    }

    public class Container
    {
        public int MinTemp { get; set; }
        public int MaxTemp { get; set; }
    }
}
