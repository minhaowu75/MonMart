using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonMart.Models;
using Npgsql;
using System.Data;

namespace MonMart.Controllers
{
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        //private readonly IAuthService
        public AuthenticationController()
        {

        }

        [HttpPost("Login")]
        public ActionResult Login(AuthenticationModel authModel)
        {

        }

    }
}
