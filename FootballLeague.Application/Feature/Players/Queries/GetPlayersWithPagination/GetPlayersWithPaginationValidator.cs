using FluentValidation;

namespace FootballLeague.Application.Feature.Players.Queries.GetPlayersWithPagination;

public class GetPlayersWithPaginationValidator : AbstractValidator<GetPlayersWithPaginationQuery>
{
    public GetPlayersWithPaginationValidator()
    {
        RuleFor(x=> x.PageNumber)
            .GreaterThanOrEqualTo(1)
            .WithMessage("page number should be at least 1 or greater than 1");

        RuleFor(x=> x.PageSize)
            .GreaterThanOrEqualTo(1)
            .WithMessage("page size number should be at least 1 or greater than 1");
    }
}
