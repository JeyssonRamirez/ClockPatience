using Application;
using Application.Definition;
using Data.Common;
using Microsoft.Extensions.DependencyInjection;

namespace Crosscutting.DependencyInjectionFactory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClockPatience(this IServiceCollection services)
        {

            // Register dependencies
            services.AddSingleton<IInputReader, ConsoleInputReader>();
            services.AddSingleton<IOutputWriter, ConsoleOutputWriter>();
            services.AddSingleton<ICardParser, CardParser>();
            services.AddSingleton<IGameEngine, ClockPatienceGameEngine>();
            services.AddSingleton<IClockPatienceService, ClockPatienceService>();
            return services;
        }
    }
}
