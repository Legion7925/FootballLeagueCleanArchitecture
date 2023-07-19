using AutoMapper;
using AutoMapper.QueryableExtensions;
using FootballLeague.Application.Extensions;
using FootballLeague.Application.Interfaces.Repositories;
using FootballLeague.Domain.Entities;
using FootballLeague.Shared;
using MediatR;

namespace FootballLeague.Application.Feature.Players.Queries.GetPlayersWithPagination;

public record GetPlayersWithPaginationQuery : IRequest<PaginatedResult<GetPlayersWithPaginationDto>>
{
    public int PageNumber { get; set; }

    public int PageSize { get; set; }

    public GetPlayersWithPaginationQuery() { }

    public GetPlayersWithPaginationQuery(int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
    }
}

internal class GetPlayersWithPaginationQueryHandler : IRequestHandler<GetPlayersWithPaginationQuery, PaginatedResult<GetPlayersWithPaginationDto>>
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IMapper mapper;

    public GetPlayersWithPaginationQueryHandler(IUnitOfWork unitOfWork , IMapper mapper)
    {
        this.unitOfWork = unitOfWork;
        this.mapper = mapper;
    }

    public async Task<PaginatedResult<GetPlayersWithPaginationDto>> Handle(GetPlayersWithPaginationQuery query, CancellationToken cancellationToken)
    {
        return await unitOfWork.Repository<Player>().Entities
            .OrderBy(x => x.Name)
            .ProjectTo<GetPlayersWithPaginationDto>(mapper.ConfigurationProvider)
            .ToPaginatedListAsync(query.PageNumber , query.PageSize, cancellationToken);
    }
}
