namespace Feeader.Web.Models
{
    public record Article(Guid Id, string Title, DateTime Date, string Description, string Url, string Picture);
}
