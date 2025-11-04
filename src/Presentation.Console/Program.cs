using Application.Definition;
using Crosscutting.DependencyInjectionFactory;
using Microsoft.Extensions.DependencyInjection;
namespace Presentation.ConsoleGame
{

    // ============================================================================
    // SAMPLE INPUT TO TEST (Copy-paste this after running the program)
    // ============================================================================
    /*
    TS QC 8S 8D QH 2D 3H KH 9H 2H TH KS KC
    9D JH 7H JD 2S QS TD 2C 4H 5H AD 4D 5D
    6D 4S 9S 5S 7S JS 8H 3D 8C 3S 4C 6S 9C
    AS 7C AH 6H KD JC 7D AC 5C TC QD 6C 3C
    #

    Expected Output: 44,KD
    */
    internal class Program
    {

        public static void ShowInstructions()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("=== Clock Patience Game ===");
            Console.WriteLine("Enter 4 lines of 13 cards each (e.g., 'AH KD 2C...')");
            Console.WriteLine("Type '#' on a new line when done");
            Console.WriteLine("Multiple decks can be entered before typing '#'");
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
              .AddClockPatience()
              .BuildServiceProvider();

            var parser = serviceProvider.GetService<ICardParser>();
            var engine = serviceProvider.GetService<IGameEngine>();

            if (parser == null || engine == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error initializing game services.");
                Console.ReadLine();
                return;
            }



            ShowInstructions();
            var deckLines = new List<string>();

            while (true)
            {

                string line = Console.ReadLine();

                if (line == null || line.Trim() == "#")
                    break;

                deckLines.Add(line);

                // Process deck when we have 4 lines
                if (deckLines.Count == 4)
                {
                    try
                    {
                        var deck = parser.ParseDeck(deckLines);

                        if (deck.Count != 52)
                        {
                            Console.WriteLine($"Error: Expected 52 cards, got {deck.Count}");
                        }
                        else
                        {
                            var result = engine.PlayGame(deck);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine($"=== Result === > {result.ToString()}");
                            Console.WriteLine($"=== End === >");

                        }
                        ShowInstructions();
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error: {ex.Message}");
                    }

                    deckLines.Clear();
                }
            }

        }
    }
}
