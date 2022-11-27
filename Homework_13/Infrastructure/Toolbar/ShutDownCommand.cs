using System.Windows;
using Homework_13.Infrastructure.Commands.Base;

namespace Homework_13.Infrastructure.Toolbar;

internal class ShutDownCommand : Command
{
    public override bool CanExecute(object parameter) => true;

    public override void Execute(object parameter) => Application.Current.Shutdown();
}