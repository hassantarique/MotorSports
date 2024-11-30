using Microsoft.AspNetCore.Mvc;
using MotorSports.APILearning.NewFolder;

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

            if (event1 == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpGet("{pointofinterestid}")]

        public ActionResult<PointOfInterestDto> GetPointOfInterest(
            int eventId, int pointofinterestid)
        {
            var event1 = EventDataStore.Current.Events.FirstOrDefault(c => c.Id == eventId);

            if (event1 == null)
            {
                return NotFound();
            }

            return Ok();
        }

        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(
            int eventId,
            PointOfInterestForCreationDto pointOfInterest)
        {
            EventDto? event1 = EventDataStore.Current.Events.FirstOrDefault(c => c.Id == eventId);

            if (event1 == null)
            {
                return NotFound();
            }

            int maxPointOfInterestId = EventDataStore.Current.Events.SelectMany(
                c => c.PointsOfInterest).Max(p => p.Id);

            var finalPointOfInterest = new PointOfInterestDto()
            {
                Id = ++maxPointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            event1.PointsOfInterest.Add(finalPointOfInterest);

            return CreatedAtRoute("GetPointOfInterest",
                new
                {
                    eventId = eventId,
                    PointOfInterestId = finalPointOfInterest.Id
                },
                finalPointOfInterest);
        }

    }
}
