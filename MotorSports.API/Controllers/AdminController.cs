using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotorSports.DomainObjects;
using MotoSports.ADODAL;

namespace MotorSports.API.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        [HttpPost("AssignRole")]
        public ActionResult<User> AssignRole(int userId, int roleId)
        {
            if (userId <= 0 || roleId <= 0)
            {
                return BadRequest("Invalid userId or roleId. Both must be positive integers.");
            }

            AdminDA adminDA = new AdminDA();
            adminDA.RoleAssignment(userId, roleId);

            return StatusCode(StatusCodes.Status201Created, "Role assigned successfully.");
        }

        [HttpDelete]
        public ActionResult<User> RemoveRole(int userId, int roleId)
        {
            if (userId <= 0 || roleId <= 0)
            {
                return BadRequest("Invalid userId or roleId. Both must be positive integers.");
            }

            AdminDA adminDA = new AdminDA();
            adminDA.RoleRemoval(userId, roleId);

            return NoContent();
        }
    }
}
