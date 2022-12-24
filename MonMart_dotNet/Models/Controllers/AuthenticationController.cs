using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonMart.Models;
using MonMart.DTOs;
using Npgsql;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;

namespace MonMart.Controllers
{
    [ApiController]
    public class AuthenticationController : Controller
    {
        
        public AuthenticationController()
        {

        }

        [HttpPost("Login")]
        public ActionResult Login(AuthenticationDTO authenticationDTO)
        {

        }

    }
}
