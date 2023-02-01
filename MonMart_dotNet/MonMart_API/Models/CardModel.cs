using System;

namespace MonMart.Models
{
    /// <summary>
    /// Model for all Pokemon Cards.
    /// </summary>
    public class CardModel
    {
        /// <summary>
        /// The Name of the card.
        /// </summary>
        public string CardName { get; set; } = string.Empty;

        /// <summary>
        /// The current value of the card.
        /// </summary>
        public double CardValue { get; set; }

        /// <summary>
        /// The collection number of the card.
        /// </summary>
        public int CollectionNumber { get; set; }

        /// <summary>
        /// The rarity of the card.
        /// </summary>
        public ECardRarity Rarity { get; set; }

        /// <summary>
        /// The set of the card. 
        /// </summary>
        public EPokemonSets PokemonSet { get; set; }

        /// <summary>
        /// If the card is holo or not.
        /// </summary>
        public EHolo Holo { get; set; }

        /// <summary>
        /// Owner of the specific card.
        /// </summary>
        public UserModel User { get; set; } = new UserModel();

    }
}