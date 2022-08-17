using MediatR;
using Microsoft.AspNetCore.Mvc;
using Monbsoft.Feeader.Api.Models;
using Monbsoft.Feeader.Application.UseCases.Categories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Monbsoft.Feeader.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CategoriesController> _logger;

        public CategoriesController(IMediator mediator, ILogger<CategoriesController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        // POST: categories
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Guid>> CreateAsync(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(request);
            _logger.LogInformation($"Category {id} created");
            return Ok(id);
        }

        // GET: categories
        [HttpGet]
        public async Task<IEnumerable<CategoryDto>> ListAsync(int? limit, CancellationToken cancellationToken)
        {
            var categories = await _mediator.Send(new ListCategoriesQuery
            {
                Limit = limit,

            }, cancellationToken);
            _logger.LogInformation($"{categories.Count} categories listed");
            return categories.Select(c => new CategoryDto(c));
        }

        // GET categories/5
        [HttpGet("{id}")]
        public async Task<CategoryDto> GetAsync(Guid id, CancellationToken cancellationToken)
        {
            var category = await _mediator.Send(new GetCategoryQuery(id), cancellationToken);
            _logger.LogDebug($"Category {id} got");
            return new CategoryDto(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
