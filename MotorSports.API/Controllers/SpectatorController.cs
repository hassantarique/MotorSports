using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.ADODAL;
using MotorSports.DomainObjects;
using MotoSports.ADODAL;

namespace MotorSports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpectatorController : ControllerBase
    {
        [HttpGet("race-schedule")]
        public ActionResult<IEnumerable<RaceSchedule>> GetRaceSchedule()
        {
            List<RaceSchedule> raceScheduleList = new RaceScheduleDA().ViewRaceScheduleSP();
            return Ok(raceScheduleList);
        }

        [HttpGet("race-standings")]
        public ActionResult<IEnumerable<RaceStanding>> GetRaceStandings()
        {
            List<RaceStanding> raceStandings = new RaceStandingsDA().ViewRaceStandingsSP();
            return Ok(raceStandings);
        }

    }
}
