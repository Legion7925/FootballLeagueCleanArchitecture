using FootballLeague.Application.Interfaces;
using FootballLeague.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {

    }

    public static void AddServices(this IServiceCollection services)
    {
        services
            .AddTransient<IEmailService, EmailService>();
    }
}
