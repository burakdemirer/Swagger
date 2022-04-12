using Microsoft.AspNetCore.Mvc;

namespace Swagger.Api.Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class BasePublicController : ControllerBase
    {

    }
}
