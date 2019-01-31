using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using RSBrasil.Business;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace RSBrasil.API.Controllers
{
    [Route("api/[controller]")]
    //[Authorize()]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpGet]
        public string Logar()
        {
            Login loga = new Login();
            loga.VerificaLogin("lalala", "lelele");
            return null;
        }
    }
}