using Microsoft.AspNetCore.Mvc;

namespace MotorSports.APILearning.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public JsonResult GetEvents()
        {
            return new JsonResult(EventDataStore.Current.Events);
        }

    }
}
