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
        [HttpPost]
        public ActionResult<Team> AddPlayer(int userId, int teamId, int license)
        {
            TeamManagerDA teamManagerDA = new TeamManagerDA();
            teamManagerDA.PlayerAddition(userId, teamId, license);

            return StatusCode(StatusCodes.Status201Created, "Added successfully.");
        }

        [HttpDelete]
        public ActionResult DeletePlayer(int userId)
        {
            TeamManagerDA teamManagerDA = new TeamManagerDA();
            teamManagerDA.PlayerRemoval(userId);

            return StatusCode(StatusCodes.Status201Created, "Removed successfully.");
        }

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
