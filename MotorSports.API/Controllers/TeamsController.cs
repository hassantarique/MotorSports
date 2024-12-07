using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoSports.ADODAL;
using MotorSports.DomainObjects;

namespace MotorSports.API.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Participant>> GetPlayers()
        {
            List<Participant> participants = new TeamManagerDA().ViewAllPlayersSP();
            return Ok(participants);
        }

        [HttpGet("{eventParticipantId}")]
        public ActionResult<IEnumerable<RaceResult>> GetPlayerPerformances(int eventParticipantId)
        {
            List<RaceResult> results = new TeamManagerDA().ViewPlayerPerformasSP(eventParticipantId);
            return Ok(results);
        }

        //test
    }
}
