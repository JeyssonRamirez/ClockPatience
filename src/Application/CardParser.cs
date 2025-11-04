using Application.Definition;
using Core.Entities;
using Crosscutting.Util.Extension;

namespace Application
{
    public class CardParser : ICardParser
    {
        public Card ParseCard(string cardString)
        {
            if (string.IsNullOrWhiteSpace(cardString) || cardString.Length != 2)
                throw new ArgumentException($"Invalid card format: {cardString}");

            return new Card(CustomEnumExtensions.GetFromStringValue<CardType>(cardString[0].ToString()), cardString[1]);
        }

        public List<Card> ParseDeck(List<string> lines)
        {
            var cards = new List<Card>();

            foreach (var line in lines)
            {
                var cardStrings = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                foreach (var cardString in cardStrings)
                {
                    cards.Add(ParseCard(cardString));
                }
            }

            return cards;
        }
    }
}
