namespace Feeader.Web.Models;

public record Feed(Guid Id, string Name, string Url, DateTime Updated, List<Article> Articles);
