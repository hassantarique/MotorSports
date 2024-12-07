using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.ADODAL;
using MotorSports.DomainObjects;
using MotoSports.ADODAL;

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

        [HttpPost]
        public ActionResult<User> GivePositions(int driverId, int newPosition)
        {
            RaceOfficialDA raceOfficialDA = new RaceOfficialDA();
            raceOfficialDA.PositionAssignment(driverId, newPosition);

            return Ok(raceOfficialDA);
        }
    }
}
