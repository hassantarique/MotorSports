using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.DomainObjects;
using MotoSports.ADODAL;

namespace MotorSports.API.Controllers
{
    [Route("api/participants")]
    [ApiController]
    public class ParticipantsController : ControllerBase
    {
        [HttpGet("events")]
        public ActionResult<IEnumerable<Event>> GetEvents()
        {
            List<Event> allEventsStoredInDB = new EventManagerDA().ViewAllEventsSP();
            return Ok(allEventsStoredInDB);
        }

        [HttpGet("results")]
        public ActionResult<IEnumerable<RaceResult>> GetResults()
        {
            List<RaceResult> results = new EventParticipantDA().ViewAllResultsSP();
            return Ok(results);
        }
    }
}
