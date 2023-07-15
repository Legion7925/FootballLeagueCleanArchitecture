using FootballLeague.Application.Feature.Players.Commands;
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

        [HttpPost]
        public async Task<ActionResult<Result<int>>> Create(CreatePlayerCommand command)
        {
            return await mediator.Send(command);
        }
    }
}
