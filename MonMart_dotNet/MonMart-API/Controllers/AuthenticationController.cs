using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonMart.Models;
using MonMart.DTOs;
using MonMart.Services;
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
        private readonly IUserService _userService;
        
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(AuthenticationDTO authenticationDTO)
        {
            var token = _userService.Authenticate(authenticationDTO);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_userService.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            UserModel user = _userService.GetByUserId(id);
            if (user != null)
            {
                return Ok(new UserDTO() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email });
            }

            return NotFound();
        }
    }
}
