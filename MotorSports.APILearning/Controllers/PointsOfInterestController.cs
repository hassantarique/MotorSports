using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.APILearning.NewFolder;
using System.Security.Cryptography.X509Certificates;

namespace MotorSports.APILearning.Controllers
{
    [Route("api/event/{eventId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int eventId)
        {
            var event1 = EventDataStore.Current.Events.FirstOrDefault(c => c.Id == eventId);

            if(event1 == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{pointofinterestid}")]

        public ActionResult<PointOfInterestDto> GetPointOfInterest(int eventId, int pointofinterestid)
        {
            var event1 = EventDataStore.Current.Events.FirstOrDefault(c => c.Id == eventId);

            if (event1 == null)
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
