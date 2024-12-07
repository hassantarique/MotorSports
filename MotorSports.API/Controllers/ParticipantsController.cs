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

        [HttpPost]
        public ActionResult<User> RegisterForRace(int eventID, int teamID)
        {
            if (eventID <= 0 || teamID <= 0)
            {
                return BadRequest("Invalid userId or roleId. Both must be positive integers.");
            }

            EventParticipantDA eventParticipantDA = new EventParticipantDA();
            eventParticipantDA.RaceRegistration(eventID, teamID);

            return StatusCode(StatusCodes.Status201Created, "Registered successfully.");
        }

        [HttpGet("results")]
        public ActionResult<IEnumerable<RaceResult>> GetResults()
        {
            List<RaceResult> results = new EventParticipantDA().ViewAllResultsSP();
            return Ok(results);
        }
    }
}
