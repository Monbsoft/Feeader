using Monbsoft.Feeader.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Extensions
{
    public static class ServiceExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<FeedService>();
            return builder;
        }
    }
}
