using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monbsoft.Feeader.Application.UseCases.ListFeeds;
using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class FeedsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FeedsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IAsyncEnumerable<Feed> ListAsync(int limit, CancellationToken cancellationToken)
        {
            return _mediator.CreateStream(new ListFeedsRequest(), cancellationToken);
        }
    }
}
