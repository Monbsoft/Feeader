using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monbsoft.Feeader.Api.Models;
using Monbsoft.Feeader.Application.UseCases.Feeds;

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

        // POST: feeds
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateAsync(CreateFeedCommand request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(request);
            _logger.LogInformation($"Feed {id} created");
            return Ok(id);
        }

        // GET: feeds/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(FeedDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<FeedDto>> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var feed = await _mediator.Send(new GetFeedQuery(id), cancellationToken);
            return feed == null ? NotFound() : Ok(new FeedDto(feed));
        }

        // GET: feeds
        [HttpGet]
        public async Task<IEnumerable<FeedDto>> ListAsync(int limit, CancellationToken cancellationToken)
        {
            var feeds = await _mediator.Send(new ListFeedsQuery(), cancellationToken);
            return feeds.Select(f => new FeedDto(f));
        }

        // PUT feeds/5
        [HttpPut("{id}")]
        public async void UpdateAsync(Guid id, [FromBody] UpdateFeedCommand request, CancellationToken cancellationToken)
        {
            await _mediator.Send(request, cancellationToken);
        }
    }
}
