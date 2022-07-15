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

    public async Task CreateAsync(CreateFeed request, CancellationToken cancellationToken)
    {               
        var response  = await _httpClient.PostAsJsonAsync("feeds", request, cancellationToken);

    }

    public Task<Feed?> GetAsync(Guid id, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed?>($"feeds/{id}", cancellationToken);

    public Task<Feed[]?> ListAsync(CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed[]>("feeds", cancellationToken);

}
