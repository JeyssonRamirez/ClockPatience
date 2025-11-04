using Application.Definition;
using Data.Common;

namespace Application
{
    public class ClockPatienceService : IClockPatienceService
    {
        private readonly IInputReader _inputReader;
        private readonly IOutputWriter _outputWriter;
        private readonly ICardParser _cardParser;
        private readonly IGameEngine _gameEngine;

        public ClockPatienceService(IInputReader inputReader, IOutputWriter outputWriter, ICardParser cardParser, IGameEngine gameEngine)
        {
            _inputReader = inputReader;
            _outputWriter = outputWriter;
            _cardParser = cardParser;
            _gameEngine = gameEngine;
        }

       
        public void Run()
        {
            Console.WriteLine("Reading Decks");
            //read all decks from input
            var decks = _inputReader.ReadDecks();

            foreach (var deckLines in decks)
            {
                var deck = _cardParser.ParseDeck(deckLines);
                var result = _gameEngine.PlayGame(deck);
                _outputWriter.WriteResult(result);
            }
        }
    }
}
