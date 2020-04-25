using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SrcFramework.Core.Model;
using System.Linq;
using System.Security.Claims;
using System.Text.Json;

namespace SrcFramework.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        public IActionResult ValidationFailedResult => StatusCode(StatusCodes.Status500InternalServerError, "Validation failed");
        public BaseUser LoggedUser
        {
            get
            {
            
                var claim = ((ClaimsIdentity)User.Identity).Claims.SingleOrDefault(p => p.Type == ClaimTypes.NameIdentifier);
                if (claim==null)
                {
                    return null;
                }
               return JsonSerializer.Deserialize<BaseUser>(claim.Value);                
            }
        }
    }
}
