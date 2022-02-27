using Monbsoft.Feeader.ViewModels;

namespace Monbsoft.Feeader.Extensions;

public static class ViewModelExtensions
{
    public static MauiAppBuilder ConfigureViewModels(this MauiAppBuilder builder)
    {
        builder.Services.AddSingleton<ShellViewModel>();
        builder.Services.AddSingleton<FeedListViewModel>();
        builder.Services.AddSingleton<SettingsViewModel>();
        return builder;
    }
}
