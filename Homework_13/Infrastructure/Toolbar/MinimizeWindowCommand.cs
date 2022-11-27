using System.Windows;
using Homework_13.Infrastructure.Commands.Base;

namespace Homework_13.Infrastructure.Toolbar;

internal class MinimizeWindowCommand : Command
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter)
    {
        foreach (var item in Application.Current.Windows)
        {
            ((Window)item).WindowState = ((Window)item).WindowState == WindowState.Minimized
                ? WindowState.Normal
                : WindowState.Minimized;
        }
    }
}