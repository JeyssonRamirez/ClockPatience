using Core.Entities;

namespace Application.Definition
{
    public interface IGameEngine
    {
        GameResult PlayGame(List<Card> deck);
    }
}
