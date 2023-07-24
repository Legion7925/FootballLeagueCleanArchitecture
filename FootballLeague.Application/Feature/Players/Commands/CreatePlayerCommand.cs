using AutoMapper;
using FootballLeague.Application.Common.Mappings;
using FootballLeague.Application.Interfaces.Repositories;
using FootballLeague.Domain.Entities;
using FootballLeague.Shared;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FootballLeague.Application.Feature.Players.Commands;

public class CreatePlayerCommand : IRequest<Result<int>>, IMapFrom<Player>
{
    public required string Name { get; set; }
    public int ShirtNo { get; set; }
    public string? PhotoUrl { get; set; }
    public DateTime BirthDate { get; set; }

}
internal class CreatePlayerCommandHandler : IRequestHandler<CreatePlayerCommand, Result<int>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public CreatePlayerCommandHandler(IUnitOfWork unitOfWork , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<Result<int>> Handle(CreatePlayerCommand command, CancellationToken cancellationToken)
    {
        var player = new Player()
        {
            Name = command.Name,
            ShirtNo = command.ShirtNo,
            PhotoUrl = command.PhotoUrl,
            BirthDate = command.BirthDate
        };
        await unitOfWork.Repository<Player>().AddAsync(player);
        player.AddDomainEvent(new PlayerCreatedEvent(player));
        await unitOfWork.Save(cancellationToken);
        return await Result<int>.SuccessAsync(player.Id, "player created");
    }
}
