using System;

namespace MonMart.Models
{
    /// <summary>
    /// Model for users.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// First name of the user.
        /// </summary>
        public string FirstName { get; set; } = string.Empty;

        /// <summary>
        /// Last name of the user.
        /// </summary>
        public string LastName { get; set; } = string.Empty;

        /// <summary>
        /// Username for the user account.
        /// </summary>
        public string Username { get; set; } = string.Empty;

        /// <summary>
        /// Password for the user account.
        /// </summary>
        public string Password { get; set; } = string.Empty;

        /// <summary>
        /// Age of the user.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        public string Email { get; set; } = string.Empty;

        /// <summary>
        /// Trade status of the user.
        /// </summary>
        public bool TradeStatus { get; set; }

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Birthday of the user.
        /// </summary>
        public DateOnly Birthday { get; set; }

        /// <summary>
        /// List of cards that the user owns.
        /// </summary>
        public List<CardModel> Cards { get; set; } = new List<CardModel>();

    }
}
