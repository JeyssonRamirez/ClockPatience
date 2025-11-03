using Application;
using Application.Definition;
using Microsoft.Extensions.DependencyInjection;

namespace Crosscutting.DependencyInjectionFactory
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddClockPatience(this IServiceCollection services)
        {
            services.AddScoped<IClockPatienceService, ClockPatienceService>();
            return services;
        }
    }
}
