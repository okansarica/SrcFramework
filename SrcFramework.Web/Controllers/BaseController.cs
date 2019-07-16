using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SrcFramework.Web.ViewModel;
using System;
using System.Linq;
using System.Security.Claims;

namespace SrcFramework.Web.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BaseController : Controller
    {
        public IActionResult ValidationFailedResult => StatusCode(StatusCodes.Status500InternalServerError, "Validation failed");
        public IActionResult EmptySuccessResult => Ok(new BaseViewModel());
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
