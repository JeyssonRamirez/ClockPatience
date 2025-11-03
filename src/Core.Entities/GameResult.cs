namespace Core.Entities
{
    public class GameResult
    {
        public int CardsExposed { get; set; }
        public Card LastCard { get; set; }

        public override string ToString()
        {
            return $"{CardsExposed:D2},{LastCard}";
        }
    }
}
