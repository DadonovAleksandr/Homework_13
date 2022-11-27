using System.Windows;
using Homework_13.Infrastructure.Commands.Base;

namespace Homework_13.Infrastructure.Toolbar;

internal class MoveWindowCommand : Command
{
    public override bool CanExecute(object parameter) => true;

    //public override void Execute(object parameter) => Application.Current.MainWindow.DragMove();
    public override void Execute(object parameter)
    {
        foreach (var item in Application.Current.Windows)
        {
            (item as Window).DragMove();
        }
    }
}