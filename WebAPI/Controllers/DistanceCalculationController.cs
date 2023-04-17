using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    /// <summary>
    /// A REST webapi controller that recieves requests like this 
    /// https://localhost:7242/DistanceCalculation?zipOrig=2342&zipDest=35345
    /// and returns the string with the distance message
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class DistanceCalculationController : ControllerBase
    {
        CitiesList cities = new CitiesList();
        private readonly ILogger<DistanceCalculationController> _logger;

        public DistanceCalculationController(ILogger<DistanceCalculationController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "CalculateDistanceByZipCodes")]
        public string Get(string zipOrig, string zipDest)
        {
            return cities.CalculateDistance(zipOrig, zipDest);
        }
    }
}