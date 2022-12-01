using Homework_13.Models.AppSettings;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.Services;

internal static class ServiceRegistration
{
    public static IServiceCollection RegisterServices(this IServiceCollection services)
    {
        services.AddSingleton<IAppSettingsRepository, AppSettingsFileRepository>();
        return services;
    }
}