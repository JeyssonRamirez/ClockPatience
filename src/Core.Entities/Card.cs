using Crosscutting.Util.Extension;

namespace Core.Entities
{
    public class Card
    {
        public CardType Type { get; set; }
        public char Suit { get; set; }

        public Card(CardType type, char suit)
        {
            Type = type;
            Suit = suit;
        }

        public int GetPilePosition()
        {
            return Type.ToInt();
        }

        public override string ToString() => $"{Type.GetStringValue()}{Suit}";
    }
}
