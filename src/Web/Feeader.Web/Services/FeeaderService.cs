using Monbsoft.Feeader.Domain;
using System.Net.Http.Json;

namespace Feeader.Web.Services;

public class FeeaderService : IFeeaderService
{
    private readonly HttpClient _httpClient;

    public FeeaderService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public Task<Feed> GetFeed(Guid id, CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed>($"/feeds/{id}", cancellationToken);

    public Task<Feed[]> ListFeeds(CancellationToken cancellationToken) =>
        _httpClient.GetFromJsonAsync<Feed[]>($"/feeds", cancellationToken);
}
