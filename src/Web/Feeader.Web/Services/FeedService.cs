using Feeader.Web.Models;
using System.Net.Http.Json;

namespace Feeader.Web.Services;

public class FeedService
{
    private readonly HttpClient _httpClient;

    public FeedService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task CreateFeedAsync(CreateFeed request, CancellationToken cancellationToken)
    {
        _ = await _httpClient.PostAsJsonAsync("feeds", request, cancellationToken);

    }

    public Task<Feed?> GetFeedAsync(Guid id, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed?>($"/feeds/{Uri.EscapeDataString(id.ToString())}", cancellationToken);
    public Task<Article[]?> ListArticlesAsync(Guid feedId, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Article[]>($"/articles?feedId={feedId}", cancellationToken);    
    public Task<Article[]> ListArticlesAsync(int limit, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Article[]>($"/articles?limit={limit}", cancellationToken);
    public Task<Feed[]?> ListFeedsAsync(CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed[]>("feeds", cancellationToken);

}
