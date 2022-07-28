using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Monbsoft.Feeader.Application.UseCases.Feeds;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Application;

public static class ServiceCollectionsExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddMediatR(typeof(ListFeedsHandler));
        return serviceCollection;
    }
}
