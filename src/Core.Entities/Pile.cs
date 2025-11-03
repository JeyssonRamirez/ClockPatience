namespace Core.Entities
{
    public class Pile
    {
        private readonly Stack<Card> _faceDownCards;
        private readonly List<Card> _faceUpCards;

        public Pile()
        {
            _faceDownCards = new Stack<Card>();
            _faceUpCards = new List<Card>();
        }

        public void AddCard(Card card) => _faceDownCards.Push(card);

        public bool HasFaceDownCards() => _faceDownCards.Count > 0;

        public Card DrawCard()
        {
            if (!HasFaceDownCards())
                return null;
            return _faceDownCards.Pop();
        }

        public void PlaceFaceUpCard(Card card) => _faceUpCards.Add(card);
    }
}
