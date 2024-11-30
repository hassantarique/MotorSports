using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.DomainObjects;

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
    }
}
