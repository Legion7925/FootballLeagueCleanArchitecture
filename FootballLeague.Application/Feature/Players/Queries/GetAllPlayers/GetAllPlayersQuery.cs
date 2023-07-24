using AutoMapper;
using AutoMapper.QueryableExtensions;
using FootballLeague.Application.Interfaces.Repositories;
using FootballLeague.Domain.Entities;
using FootballLeague.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FootballLeague.Application.Feature.Players.Queries.GetAllPlayers;

public record GetAllPlayersQuery : IRequest<Result<List<GetAllPlayersDto>>>;

internal class GetAllPlayersQueryHandler : IRequestHandler<GetAllPlayersQuery, Result<List<GetAllPlayersDto>>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetAllPlayersQueryHandler(IUnitOfWork unitOfWork , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }
    public async Task<Result<List<GetAllPlayersDto>>> Handle(GetAllPlayersQuery query, CancellationToken cancellationToken)
    {
       var players = await unitOfWork.Repository<Player>().Entities
            .ProjectTo<GetAllPlayersDto>(mapper.ConfigurationProvider)
            .ToListAsync();

        return await Result<List<GetAllPlayersDto>>.SuccessAsync(players);
    }
}

