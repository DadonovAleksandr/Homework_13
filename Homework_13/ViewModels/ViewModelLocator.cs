using Homework_13.ViewModels.MainWindowVM;
using Microsoft.Extensions.DependencyInjection;

namespace Homework_13.ViewModels;

internal class ViewModelLocator
{
    public MainWindowViewModel MainWindowViewModel => App.Host.Services.GetRequiredService<MainWindowViewModel>();
}