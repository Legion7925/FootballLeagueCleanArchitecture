using AutoMapper;
using FootballLeague.Application.Common.Mappings;
using FootballLeague.Application.Interfaces.Repositories;
using FootballLeague.Domain.Entities;
using FootballLeague.Shared;
using MediatR;

namespace FootballLeague.Application.Feature.Players.Commands;

public record CreatePlayerCommand : IRequest<Result<int>> , IMapFrom<Player>
{
    public required string Name { get; set; }
    public int ShirtNo { get; set; }
    public required string PhotoUrl { get; set; }
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
    public async Task<Result<int>> Handle(CreatePlayerCommand request, CancellationToken cancellationToken)
    {
        var player = mapper.Map<Player>(request);
        await unitOfWork.Repository<Player>().AddAsync(player);
        player.AddDomainEvent(new PlayerCreatedEvent(player));
        await unitOfWork.Save(cancellationToken);
        return await Result<int>.SuccessAsync(player.Id, "player created");
    }
}
