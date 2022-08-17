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


    public async Task CreateCategoryAsync(CreateCategory request, CancellationToken cancellationToken)
    {
        _ = await _httpClient.PostAsJsonAsync("categories", request, cancellationToken);
    }
    public async Task CreateFeedAsync(CreateFeed request, CancellationToken cancellationToken)
    {
        _ = await _httpClient.PostAsJsonAsync("feeds", request, cancellationToken);
    }

    public Task<Category?> GetCategoryAsync(Guid id, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Category?>($"/categories/{Uri.EscapeDataString(id.ToString())}", cancellationToken);
    public Task<Feed?> GetFeedAsync(Guid id, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed?>($"/feeds/{Uri.EscapeDataString(id.ToString())}", cancellationToken);
    public Task<Article[]?> ListArticlesAsync(Guid feedId, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Article[]>($"/articles?feedId={feedId}", cancellationToken);
    public Task<Article[]?> ListArticlesAsync(int limit, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Article[]>($"/articles?limit={limit}", cancellationToken);
    public Task<Category[]?> ListCategoriesAsync(CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Category[]>($"/categories", cancellationToken);
    public Task<Feed[]?> ListFeedsAsync(CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed[]>("feeds", cancellationToken);
    public async Task UpdateFeedAsync(UpdateFeed request, CancellationToken cancellationToken)
    {
        _ = await _httpClient.PutAsJsonAsync<UpdateFeed>($"/feeds/{Uri.EscapeUriString(request.Id.ToString())}", request, cancellationToken);
    }
}
