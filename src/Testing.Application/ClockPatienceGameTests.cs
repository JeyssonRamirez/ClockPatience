using Application;
using Application.Definition;
using Core.Entities;
using Crosscutting.Util.Extension;
using Moq;
using System.Linq;
using Xunit;

namespace Testing.Application
{
    public class ClockPatienceGameTests
    {
        private readonly ClockPatienceGameEngine _engine;

        public ClockPatienceGameTests()
        {
            _engine = new ClockPatienceGameEngine();
        }

        [Fact]
        public void PlayGame_SampleDeck_Returns44CardsAndKD()
        {
            // Arrange
            var deck = CreateSampleDeck();

            // Act
            var result = _engine.PlayGame(deck);

            // Assert
            Assert.Equal(44, result.CardsExposed);
            Assert.Equal("K", result.LastCard.Type.GetStringValue());
            Assert.Equal('D', result.LastCard.Suit);
        }
        [Fact]
        public void ToString_ReturnsCorrectFormat()
        {
            // Arrange
            var card = new Card(CardType.Ace, 'H');

            // Act
            var result = card.ToString();

            // Assert
            Assert.Equal("AH", result);
        }

        [Fact]
        public void Card_Constructor_SetsPropertiesCorrectly()
        {
            // Arrange & Act
            var card = new Card(CardType.King, 'D');

            // Assert
            Assert.Equal("K", card.Type.GetStringValue());
            Assert.Equal('D', card.Suit);
        }

        private List<Card> CreateSampleDeck()
        {
            var cardStrings = new[]
            {
                "TS", "QC", "8S", "8D", "QH", "2D", "3H", "KH", "9H", "2H", "TH", "KS", "KC",
                "9D", "JH", "7H", "JD", "2S", "QS", "TD", "2C", "4H", "5H", "AD", "4D", "5D",
                "6D", "4S", "9S", "5S", "7S", "JS", "8H", "3D", "8C", "3S", "4C", "6S", "9C",
                "AS", "7C", "AH", "6H", "KD", "JC", "7D", "AC", "5C", "TC", "QD", "6C", "3C"
            };

            return cardStrings.Select(s => new Card(CustomEnumExtensions.GetFromStringValue<CardType>(s[0].ToString()), s[1])).ToList();
        }
    }
}
