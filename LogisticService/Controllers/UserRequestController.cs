using LogisticService.Requests;
using Microsoft.AspNetCore.Mvc;

namespace LogisticService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRequestController : ControllerBase
    {
        [HttpPost("CalculateOrder")]
        public Task<ActionResult<Order>> Calculate([FromBody] UserRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
