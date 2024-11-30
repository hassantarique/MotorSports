using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.ADODAL;
using MotorSports.DomainObjects;

namespace MotorSports.API.Controllers
{
    [Route("api/raceofficial")]
    [ApiController]
    public class RaceOfficialController : ControllerBase
    {
        [HttpGet("race-standings")]
        public ActionResult<IEnumerable<RaceStanding>> GetRaceStandings()
        {
            List<RaceStanding> raceStandings = new RaceStandingsDA().ViewRaceStandingsSP();
            return Ok(raceStandings);
        }
    }
}
