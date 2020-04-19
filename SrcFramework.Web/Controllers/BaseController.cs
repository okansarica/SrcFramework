using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;

namespace SrcFramework.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    public class BaseController : Controller
    {
        public IActionResult ValidationFailedResult => StatusCode(StatusCodes.Status500InternalServerError, "Validation failed");
        public int? UserId
        {
            get
            {
                var claim = ((ClaimsIdentity)User.Identity).Claims.SingleOrDefault(p => p.Type == ClaimTypes.NameIdentifier);
                if (claim==null)
                {
                    return null;
                }
                return Convert.ToInt32(claim.Value);
            }
        }
    }
}
