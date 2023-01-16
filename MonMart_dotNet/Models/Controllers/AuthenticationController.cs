using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonMart.Models;
using MonMart.DTOs;
using MonMart.Utilities.Repository;
using MonMart.Utilities.AuthenticationManager;
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
        private readonly IJWTAuthenticationManager _authenticationManager;
        private readonly IUserRepository _userRepository;
        
        public AuthenticationController(IUserRepository userRepository, IJWTAuthenticationManager authenticationManager)
        {
            _userRepository = userRepository;
            _authenticationManager = authenticationManager;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public IActionResult Login(AuthenticationDTO authenticationDTO)
        {
            var token = _authenticationManager.Authenticate(authenticationDTO.UserName, authenticationDTO.Password);

            if (token == null)
            {
                return Unauthorized();
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public ActionResult<IEnumerable<UserDTO>> Get()
        {
            return Ok(_userRepository.GetAll());
        }

        [Authorize]
        [HttpGet("{id}")]
        public ActionResult<UserDTO> Get(int id)
        {
            UserModel user = _userRepository.GetById(id);
            if (user != null)
            {
                return Ok(new UserDTO() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email });
            }

            return NotFound();
        }
    }
}
