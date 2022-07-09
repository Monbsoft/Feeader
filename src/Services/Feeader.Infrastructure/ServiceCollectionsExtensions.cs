using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Monbsoft.Feeader.Application.Interfaces;
using Monbsoft.Feeader.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Infrastructure
{
    public static class ServiceCollectionsExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("FeeaderDb");
            serviceCollection.AddSqlServer<FeeaderDbContext>(connectionString);
            serviceCollection.AddScoped<IApplicationDbContext, FeeaderDbContext>();
            return serviceCollection;
        }
    }
}
