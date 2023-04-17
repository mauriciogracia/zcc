using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DistanceCalculationController : ControllerBase
    {
        private readonly ILogger<DistanceCalculationController> _logger;

        public DistanceCalculationController(ILogger<DistanceCalculationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "CalculateDistanceByZipCodes")]
        public string Get()
        {
            //HttpContext.Current.Request.QueryString
            return "YEAH IT WORKS";
        }
    }
}