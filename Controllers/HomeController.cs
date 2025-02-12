using Microsoft.AspNetCore.Mvc;

namespace CourseraAPIProject.Controllers
{
    [ApiController]
    [Route("/")]
    [Route("/home")]
    public class HomeController : ControllerBase {
        [HttpGet]
        public ActionResult Get() {
            return Ok("Hello World!");
        }
    }
}