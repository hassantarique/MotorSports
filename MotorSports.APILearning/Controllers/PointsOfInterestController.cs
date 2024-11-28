using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.APILearning.NewFolder;

namespace MotorSports.APILearning.Controllers
{
    [Route("api/event/{eventId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
       // [HttpGet]
        //public ActionResult<IEnumerable<PointOfInterestDto>> GetPointOfInterest(int cityId)
        //{
        //    var event = EventDataStore.Current.Cities.FirstOrDefault 
        //}
    }
}
