using Core.Entities;

namespace Application.Definition
{
    public interface ICardParser
    {
        Card ParseCard(string cardString);
        List<Card> ParseDeck(List<string> lines);
    }
}
