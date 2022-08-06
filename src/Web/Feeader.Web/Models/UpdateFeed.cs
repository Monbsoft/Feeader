namespace Feeader.Web.Models;

public record UpdateFeed(Guid Id, string Name, string Url, Guid? CategoryId);

