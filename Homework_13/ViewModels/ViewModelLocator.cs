using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.ViewModels;

internal class ViewModelLocator
{
    public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    public SettingsViewModel SettingsViewModel => App.Host.Services.GetRequiredService<SettingsViewModel>();
    public ClientsViewModel ClientsViewModel => App.Host.Services.GetRequiredService<ClientsViewModel>();
}