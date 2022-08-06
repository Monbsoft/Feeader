namespace Feeader.Web.Models;

public record Category
{
    public Guid Id { get; set; }
    public string Genre { get; set; }
    public string Updated { get; set; }

    public override string ToString() => Genre;
}


