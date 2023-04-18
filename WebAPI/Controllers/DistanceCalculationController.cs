using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        bool dockerSuccess = false;
        public DistanceCalculationController(ILogger<DistanceCalculationController> logger)
        {
            _logger = logger;
            dockerSuccess = cities.prepareMongoDB();
        }

        [HttpGet(Name = "CalculateDistanceByZipCodes")]
        public string Get(string zipOrig, string zipDest)
        {
            string response;

            if(dockerSuccess)
            {
                response = cities.CalculateDistance(zipOrig, zipDest);
            }
            else {
                response = "Docker daemon is not running";
            }
            return JsonSerializer.Serialize(response);
        }
    }
}