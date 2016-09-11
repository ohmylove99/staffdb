using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace EmbeddedAuthorizationServer.Controllers
{
    [Authorize]
    public class IdentityController : ApiController
    {
        public IEnumerable<string> Get()
        {
            var principal = Request.GetRequestContext().Principal as ClaimsPrincipal;

            return from c in principal.Claims
                   select c.Value;
        }
    }
}
