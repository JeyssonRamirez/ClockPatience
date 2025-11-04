using Application.Definition;
using Crosscutting.DependencyInjectionFactory;
using Data.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Presentation.ConsoleGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var serviceProvider = new ServiceCollection()
               .AddClockPatience()
               .BuildServiceProvider();

                var service = serviceProvider.GetService<IClockPatienceService>();
                service.Run();
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while running the application.");

            }

        }
    }
}
