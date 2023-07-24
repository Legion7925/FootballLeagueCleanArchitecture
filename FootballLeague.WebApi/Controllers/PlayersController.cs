using FootballLeague.Application.Feature.Players.Commands;
using FootballLeague.Application.Feature.Players.Queries.GetAllPlayers;
using FootballLeague.Domain.Entities;
using FootballLeague.Shared;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FootballLeague.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IMediator mediator;

        public PlayersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllPlayersDto>>>> GetAllPlayers()
        {
            return await mediator.Send(new GetAllPlayersQuery());   
        }

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreatePlayerCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
