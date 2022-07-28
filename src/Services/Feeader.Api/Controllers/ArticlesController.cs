using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monbsoft.Feeader.Api.Models;
using Monbsoft.Feeader.Application.UseCases.Articles;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monbsoft.Feeader.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: articles
        [HttpGet]
        public async Task<IEnumerable<ArticleDto>> ListAsync(Guid? feedId, CancellationToken cancellationToken)
        {
            var articles = await _mediator.Send(new ListArticlesQuery
            {
                FeedId = feedId
            }, cancellationToken);
            return articles.Select(a => new ArticleDto(a));
        }

        // GET articles/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ArticlesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ArticlesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ArticlesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
