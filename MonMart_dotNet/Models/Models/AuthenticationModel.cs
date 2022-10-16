namespace MonMart.Models
{
    /// <summary>
    /// Model for login.
    /// </summary>
    public class AuthenticationModel
    {
        /// <summary>
        /// Username to login.
        /// </summary>
        public string UserName { get; set; } = string.Empty;

        /// <summary>
        /// Password to login.
        /// </summary>
        public string Password { get; set; } = string.Empty;
    }
}
