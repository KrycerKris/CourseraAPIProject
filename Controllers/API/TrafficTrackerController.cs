using CourseraAPIProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CourseraAPIProject.Controllers 
{

    [ApiController]
    [Route("api/traffic")]
    public class TrafficTrackerController : ControllerBase
    {
    
        private readonly ITrafficTracker _trafficTracker;

        public TrafficTrackerController(ITrafficTracker trafficTracker) {
            _trafficTracker = trafficTracker;
        }

        [HttpGet]
        public KeyValuePair<string, int>[] GetStats(){
            return _trafficTracker.GetStatistics();
        }
    
    }
}
