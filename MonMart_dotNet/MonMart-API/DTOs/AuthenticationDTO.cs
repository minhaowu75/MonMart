using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MonMart.DTOs
{
    public class AuthenticationDTO
    {
        /// <summary>
        /// Username of the user.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password of the user.
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; } = string.Empty;
    }
}
