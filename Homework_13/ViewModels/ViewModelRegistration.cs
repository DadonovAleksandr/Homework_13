﻿using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.ViewModels;

internal static class ViewModelRegistration
{
    public static IServiceCollection RegisterViewModels(this IServiceCollection services)
    {
        services.AddSingleton<MainWindowViewModel>();
        services.AddSingleton<SettingsViewModel>();
        services.AddSingleton<ClientsViewModel>();
        //services.AddTransient<LogViewerViewModel>();
        return services;
    }
}