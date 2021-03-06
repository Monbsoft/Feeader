using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monbsoft.Feeader.Api.Models;
using Monbsoft.Feeader.Application.UseCases.CreateFeed;
using Monbsoft.Feeader.Application.UseCases.GetFeed;
using Monbsoft.Feeader.Application.UseCases.ListFeeds;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<FeedsController> _logger;

        public FeedsController(IMediator mediator, ILogger<FeedsController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateAsync(CreateFeedCommand request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(request);
            _logger.LogInformation($"Feed {id} created");
            return Ok(id);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeedDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeedDto>> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var feed = await _mediator.Send(new GetFeedRequest(id), cancellationToken);
            return feed == null ? NotFound() : Ok(new FeedDto(feed));
        }

        [HttpGet]
        public async IAsyncEnumerable<FeedDto> ListAsync(int limit, CancellationToken cancellationToken)
        {
            var feeds = _mediator.CreateStream(new ListFeedsRequest(), cancellationToken);
            await foreach(var feed in feeds)
            {
                yield return new FeedDto(feed);
            }
        }
    }
}
