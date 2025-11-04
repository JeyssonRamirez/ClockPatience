using Core.Entities;

namespace Data.Common
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void WriteResult(GameResult result)
        {
            Console.WriteLine(result.ToString());
        }
    }
}
