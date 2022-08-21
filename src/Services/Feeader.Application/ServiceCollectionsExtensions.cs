using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Monbsoft.Feeader.Application.UseCases.Feeds;

namespace Monbsoft.Feeader.Application;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ListFeedsQuery));
        return serviceCollection;
    }
}
