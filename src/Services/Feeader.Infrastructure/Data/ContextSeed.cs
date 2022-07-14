using Monbsoft.Feeader.Domain;

namespace Monbsoft.Feeader.Infrastructure.Data
{
    internal static class ContextSeed
    {
        internal static Feed[] Feeds = {
        new(new Guid("5660e7b9-7555-4d3f-b863-df658440820b"), "BBC News", "http://feeds.bbci.co.uk/news/world/rss.xml"),
        new(new Guid("cbab58bb-fa24-46b9-b68d-ee25ddefb1a6"), "The New York Times", "https://www.nytimes.com/svc/collections/v1/publish/https://www.nytimes.com/section/world/rss.xml"),
        new(new Guid("bcb81fd8-ab1d-4874-af23-35513d3d673d"), "CNN", "http://rss.cnn.com/rss/edition_world.rss"),
        new(new Guid("5ebb45a0-5fff-49ac-a5d5-691e6314ce71"), "CNBC", "https://www.cnbc.com/id/100727362/device/rss/rss.html" ),
        new(new Guid("71a2df8c-cb34-4203-b045-375695439b8b"), "The Washington Post", "https://feeds.washingtonpost.com/rss/world")
        };
    }
}