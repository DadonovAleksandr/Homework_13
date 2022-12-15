using System;
using System.Windows;
using System.Windows.Input;
using Homework_13.Infrastructure.Commands;
using Homework_13.ViewModels.Base;

namespace Homework_13.ViewModels;

internal class InputTestClientsCountViewModel : BaseViewModel
{
    public InputTestClientsCountViewModel()
    {
        _testClientsCount = "10";
        
        #region Commands
        ApplyCommand = new LambdaCommand(OnApplyCommandExecuted, CanApplyCommandExecute);
        #endregion
    }

    #region Commands

    #region ApplyCommand
    public ICommand ApplyCommand { get; }
    private void OnApplyCommandExecuted(object p)
    {
        if (p is Window window)
            window.DialogResult = true;
    }

    private bool CanApplyCommandExecute(object p) => int.TryParse(TestClientsCount, out int result) && result > 0;
    #endregion
    
    #endregion
    
    #region TestClientsCount
    private string _testClientsCount;
    /// <summary>
    /// Кол-во тестовых клиентов для генерации
    /// </summary>
    public string TestClientsCount
    {
        get => _testClientsCount;
        set
        {
            if(value != String.Empty && (!int.TryParse(value, out int result) || result < 1))
                return;
            Set(ref _testClientsCount, value);
        }
    }
    #endregion
}