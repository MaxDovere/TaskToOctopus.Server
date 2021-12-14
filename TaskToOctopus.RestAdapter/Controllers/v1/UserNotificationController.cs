using Microsoft.AspNetCore.Mvc;
using TaskToOctopus.Domain.Model;
using TaskToOctopus.Domain.Port;

namespace TaskToOctopus.RestAdapter.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserNotificationController : ControllerBase
    {
        private readonly IRequestEntity<AspNetUsersNot> _request;

        public UserNotificationController(IRequestEntity<AspNetUsersNot> request)
        {
            _request = request;
        }

        // GET: api/usernotification
        [HttpGet]
        public IActionResult Get()
        {
            var result = _request.GetAll();
            return Ok(result);
        }

        // GET: api/usernotification/1
        [HttpGet]
        [Route("{key}", Name = "GetSingle")]
        public IActionResult Get(string key)
        {
            var result = _request.GetSingle(key);
            return Ok(result);
        }
    }
}
