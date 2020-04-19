using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace SrcFramework.Web.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController:ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Home page  is working");
        }
    }
}
