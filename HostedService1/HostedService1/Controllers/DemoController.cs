using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HostedService1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [HttpPost]
        public ActionResult Register(AddNewUserRequest req)
        {
            return Ok(req);
        }
    }
}
