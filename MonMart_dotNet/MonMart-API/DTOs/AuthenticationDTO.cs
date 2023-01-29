using System.ComponentModel.DataAnnotations;

namespace MonMart.DTOs
{
    public class AuthenticationDTO
    {
        /// <summary>
        /// Username of the user.
        /// </summary>
        [Required]
        public string UserName { get; set; }

        /// <summary>
        /// Password of the user.
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}
