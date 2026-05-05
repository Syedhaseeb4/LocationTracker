using LocationTracker.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LocationTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationLogger : ControllerBase
    {
        private readonly ILocationTracker _locationtracker;

        public LocationLogger(ILocationTracker  locationtracker) 
        {
            _locationtracker = locationtracker;
        }

        [HttpPost("LogLocation")]
        public IActionResult LogLocation(string latitude , string longitude)
        {
            var result = _locationtracker.LogLocation(latitude, longitude);
            return Ok("Logged Successfully"); ;
        }
    }
}
