using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MonMart.Models;
using System.Data;
using Npgsql;

namespace MonMart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly NpgsqlConnection _connection = new(@"Server=localhost;Port=5432;User Id=postgres;Password=J0Pl4t0P%^;Database=MonMartDB;");
        public NpgsqlCommand _command;
        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost, Route("[action]", Name = "Register")]
        public string Register(UserModel User)
        {
            _command = new NpgsqlCommand("usp_Register", _connection);
            return "sexy";
        }
    }
}
