using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Api.Models;

public record CategoryDto
{
    public CategoryDto(Category category)
    {
        Id = category.Id;
        Genre = category.Genre;
        Created = category.Created;
        Updated = category.Updated;
    }

    public Guid Id { get; }
    public string Genre { get;  }
    public DateTime Created { get; }
    public DateTime Updated { get; }
}
