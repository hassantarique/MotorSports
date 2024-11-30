using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.DomainObjects;
using MotoSports.ADODAL;

namespace MotorSports.API.Controllers
{
    [Route("api/events")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {

            List<Event> allEventsStoredInDB = new EventManagerDA().ViewAllEventsSP();
            return Ok(allEventsStoredInDB);
        }

        [HttpGet("{eventID}")]
        public ActionResult<Event> GetEvent(int eventID)
        {
            List<Event> allEventsStoredInDB = new EventManagerDA().ViewAllEventsSP();

            Event matchingEvent = allEventsStoredInDB.FirstOrDefault(x => x.EventId == eventID);

            return Ok(matchingEvent);
        }

    }
}
