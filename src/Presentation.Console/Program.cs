using Application.Definition;
using Crosscutting.DependencyInjectionFactory;
using Data.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
namespace Presentation.Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddClockPatience()
                .BuildServiceProvider();

            var service = serviceProvider.GetService<IClockPatienceService>();
            service.Run();
        }
    }
}
