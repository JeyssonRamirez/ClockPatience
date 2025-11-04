using Application.Definition;
using Core.Entities;

namespace Application
{
    public class ClockPatienceGameEngine : IGameEngine
    {
        public GameResult PlayGame(List<Card> deck)
        {
            var piles = InitializePiles(deck);

            // Start with the last card dealt (top of King pile)
            var currentCard = piles[13].DrawCard();
            int cardsExposed = 1;
            piles[13].PlaceFaceUpCard(currentCard);

            while (true)
            {
                int pileIndex = currentCard.GetPilePosition();

                if (!piles[pileIndex].HasFaceDownCards())
                {
                    // Game ends
                    return new GameResult
                    {
                        CardsExposed = cardsExposed,
                        LastCard = currentCard
                    };
                }

                currentCard = piles[pileIndex].DrawCard();
                cardsExposed++;
                piles[pileIndex].PlaceFaceUpCard(currentCard);
            }
        }

        private Dictionary<int, Pile> InitializePiles(List<Card> deck)
        {
            var piles = new Dictionary<int, Pile>();
            for (int i = 1; i <= 13; i++)
            {
                piles[i] = new Pile();
            }

            // Deal cards from bottom to top (reverse order)
            // The deck is listed from bottom to top, first card dealt is last in list
            for (int i = deck.Count - 1; i >= 0; i--)
            {
                int cardPosition = deck.Count - 1 - i;
                int pileNumber = (cardPosition % 13) + 1;
                piles[pileNumber].AddCard(deck[i]);
            }

            return piles;
        }
    }
}
