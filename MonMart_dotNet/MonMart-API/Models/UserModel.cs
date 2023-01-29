using System.Text.Json.Serialization;

namespace MonMart.Models
{
    /// <summary>
    /// Model for users.
    /// </summary>
    public class UserModel
    {
        /// <summary>
        /// Id of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// First name of the user.
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the user.
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Username for the user account.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Password for the user account.
        /// </summary>
        [JsonIgnore]
        public string Password { get; set; }

        /// <summary>
        /// Age of the user.
        /// </summary>
        public int Age { get; set; }

        /// <summary>
        /// Email of the user.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Phone number of the user.
        /// </summary>
        public int PhoneNumber { get; set; }

        /// <summary>
        /// Birthday of the user.
        /// </summary>
        //public DateOnly Birthday { get; set; }

        /// <summary>
        /// Trade status of the user.
        /// </summary>
        public bool TradeStatus { get; set; }

        /// <summary>
        /// List of cards that the user owns.
        /// </summary>
        public List<CardModel> Cards { get; set; } = new List<CardModel>();
    }
}
