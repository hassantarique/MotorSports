using Microsoft.AspNetCore.Mvc;
using MotorSports.APILearning.NewFolder;

namespace MotorSports.APILearning.Controllers
{
    [ApiController]
    [Route("api/events")]
    public class Controller : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<EventDto>> GetEvents()
        {
            return Ok(EventDataStore.Current.Events);
        }

        [HttpGet("{id}")]
        public ActionResult<EventDto> GetEvent(int id)
        {
            EventDto? cityToReturn = EventDataStore.Current.Events.FirstOrDefault(c => c.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }


            return Ok(cityToReturn);

        }

    }
}
