using FootballLeague.Application.Interfaces;
using FootballLeague.Domain.Common;
using FootballLeague.Domain.Common.Interfaces;
using FootballLeague.Infrastructure.Services;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace FootballLeague.Infrastructure.Extensions;

public static class IServiceCollectionExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services)
    {
        services.AddServices();
    }

    public static void AddServices(this IServiceCollection services)
    {
        services
                .AddTransient<IMediator, Mediator>()
                .AddTransient<IDomainEventDispatcher, DomainEventDispatcher>()
                .AddTransient<IEmailService, EmailService>();
    }
}
