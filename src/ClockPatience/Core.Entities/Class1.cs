namespace Core.Entities
{
    public class Card
    {
        public char Rank { get; set; }
        public char Suit { get; set; }

        public Card(char rank, char suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public int GetPilePosition()
        {
            return Rank switch
            {
                'A' => 1,
                '2' => 2,
                '3' => 3,
                '4' => 4,
                '5' => 5,
                '6' => 6,
                '7' => 7,
                '8' => 8,
                '9' => 9,
                'T' => 10,
                'J' => 11,
                'Q' => 12,
                'K' => 13,
                _ => 13
            };
        }

        public override string ToString() => $"{Rank}{Suit}";
    }
}
