using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.ViewModels;

internal class ViewModelLocator
{
    public MainWindowViewModel MainWindowVm => App.Host.Services.GetRequiredService<MainWindowViewModel>();
    public SettingsViewModel SettingsVm => App.Host.Services.GetRequiredService<SettingsViewModel>();
    public ClientsViewModel ClientsVm => App.Host.Services.GetRequiredService<ClientsViewModel>();
    public InputTestClientsCountViewModel InputTestClientsCountVm => App.Host.Services.GetRequiredService<InputTestClientsCountViewModel>();
}