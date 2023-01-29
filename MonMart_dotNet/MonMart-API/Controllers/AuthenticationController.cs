using Microsoft.AspNetCore.Mvc;
using MonMart.DTOs;
using MonMart.Services;
using MonMart.Utilities;

namespace MonMart.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticationDTO authenticationDTO)
        {
            var token = _userService.Authenticate(authenticationDTO);

            if (token == null)
            {
                return BadRequest(new { message = "Username or password is incorrect" });
            }

            return Ok(token);
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        //[Authorize]
        //[HttpGet("{id}")]
        //public ActionResult<UserDTO> Get(int id)
        //{
        //    UserModel user = _userService.GetByUserId(id);
        //    if (user != null)
        //    {
        //        return Ok(new UserDTO() { Id = user.Id, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email, Token =  });
        //    }

        //    return NotFound();
        //}
    }
}
