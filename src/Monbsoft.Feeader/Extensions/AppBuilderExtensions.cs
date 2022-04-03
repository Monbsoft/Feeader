using Monbsoft.Feeader.Pages;
using Monbsoft.Feeader.Services;
using Monbsoft.Feeader.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monbsoft.Feeader.Extensions
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder ConfigureServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<FeedService>();
            builder.Services.AddSingleton<SettingsService>();
            return builder;
        }

        public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
        {

            builder.Services.AddSingleton<ShellViewModel>();
            builder.Services.AddSingleton<EditFeedViewModel>();
            builder.Services.AddSingleton<FeedListViewModel>();
            builder.Services.AddSingleton<SettingsViewModel>();
            return builder;
        }

        public static MauiAppBuilder ConfigurePages(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<FeedListPage>();
            builder.Services.AddSingleton<SettingsPage>();
            return builder;
        }
    }
}
