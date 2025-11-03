namespace Data.Common
{
    public static class InputReader
    {
        public static List<List<string>> ReadDecks()
        {
            var result = new List<List<string>>();
            string line;
            var deck = new List<string>();

            while (!string.IsNullOrWhiteSpace(line = Console.ReadLine()))
            {
                if (line == "#") break;
                deck.AddRange(line.Split(' ', StringSplitOptions.RemoveEmptyEntries));
                if (deck.Count == 52)
                {
                    result.Add(new List<string>(deck));
                    deck.Clear();
                }
            }

            return result;
        }
    }
}
