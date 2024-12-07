using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.DomainObjects;
using MotoSports.ADODAL;

namespace MotorSports.API.Controllers
{
    [Route("api/sponsor")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<Sponsor>> GetAllSponsorships()
        {
            return Ok();
        }

        [HttpDelete]
        public ActionResult DeleteSponsor(int sponsorID, int eventID)
        {
            EventSponsorsDA eventSponsorsDA = new EventSponsorsDA();
            eventSponsorsDA.RemoveSponsorship(sponsorID, eventID);

            return Ok("Removed Successfully.");
        }
    }
}
