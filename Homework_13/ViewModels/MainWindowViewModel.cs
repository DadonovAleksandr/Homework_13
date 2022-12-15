using System.Windows.Controls;
using System.Windows.Input;
using Homework_13.Infrastructure.Commands;
using Homework_13.Models;
using Homework_13.Models.AppSettings;
using Homework_13.Models.Clients;
using Homework_13.ViewModels.Base;
using Homework_13.Views.MainWindow.Pages;

namespace Homework_13.ViewModels;
internal class MainWindowViewModel : BaseViewModel
{
    /// <summary>
    /// Модель банка
    /// </summary>
    public Bank Bank { get; private set; }
    
    public MainWindowViewModel(IAppSettingsRepository repository)
    {
        logger.Debug($"Вызов конструктора {this.GetType().Name} по умолчанию");
        
        //загрузка настроек
        AppSettings.Set(repository.Load());
        
        Bank = new Bank(Title, new ClientsFileRepository(AppSettings.Get().ClientsRepositoryFilePath));
        //_Title = $"{Bank.Name}. Программа консультант";
        //Worker = worker;
        
        #region Pages
        //_clients = new ClientsView();
        //_appSettings = new SettingsView();

        ViewOpacity = 1.0;
        CurrentView = new ClientsView();
        #endregion

        #region commands
        ShowClientsView = new LambdaCommand(OnSetClientsViewExecuted, CanSetClientsViewExecute);
        ShowSettingsView = new LambdaCommand(OnSetAppSettingsViewExecuted, CanSetAppSettingsViewExecute);
        #endregion
    }
    
    #region Pages
    //private readonly UserControl _clients;
    //private readonly UserControl _appSettings;

    private UserControl _currentView;
    /// <summary>
    /// Текущая страничка
    /// </summary>
    public UserControl CurrentView
    {
        get => _currentView;
        set
        {
            Set(ref _currentView, value);
            logger.Debug($"Переход на страницу: {value.GetType().Name}");
        }
    }

    private double _viewOpacity;
    public double ViewOpacity
    {
        get => _viewOpacity;
        set => Set(ref _viewOpacity, value);
    }
    #endregion
    
    #region Commands

    #region SetClientsViewCommand
    public ICommand ShowClientsView { get; }
    private void OnSetClientsViewExecuted(object p) => CurrentView = new ClientsView();
    private bool CanSetClientsViewExecute(object p) => true;
    #endregion
    
    #region SetAppSettingsViewCommand
    public ICommand ShowSettingsView { get; }
    private void OnSetAppSettingsViewExecuted(object p) => CurrentView = new SettingsView();
    private bool CanSetAppSettingsViewExecute(object p) => true;
    #endregion
    
    #endregion
    
    #region Заголовок окна
    /// <summary>
    /// Заголовок окна
    /// </summary>
    public string Title => AppSettings.Get().BankTitle;
    #endregion
}