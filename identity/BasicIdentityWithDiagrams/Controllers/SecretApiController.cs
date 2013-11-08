using System.Web.Http;

namespace BasicIdentityWithDiagrams.Controllers
{
    [Authorize]
    public class SecretApiController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("This secret from a WebAPI controller requires authentication");
        }
    }
}
