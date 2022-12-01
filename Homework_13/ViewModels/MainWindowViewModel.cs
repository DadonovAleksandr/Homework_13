using System.Windows.Controls;
using System.Windows.Input;
using Homework_13.Infrastructure.Commands;
using Homework_13.Models.AppSettings;
using Homework_13.ViewModels.Base;
using Homework_13.Views.MainWindow.Pages;

namespace Homework_13.ViewModels;
internal class MainWindowViewModel : BaseViewModel
{
    /// <summary>
    /// Репозиторий настроек приложения
    /// </summary>
    IAppSettingsRepository _appSettingsrepository;
    /// <summary>
    /// Настройки приложения
    /// </summary>
    //public AppSettings AppSettings { get; private set; }
    
    /// <summary>
    /// Модель банка
    /// </summary>
    //public Bank Bank { get; private set; }
    
    public MainWindowViewModel()
    {
        logger.Debug($"Вызов конструктора {this.GetType().Name} по умолчанию");
        
        //_appSettingsrepository = new AppSettingsFileRepository();
        //AppSettings = _appSettingsrepository.Load();
        
        //Bank = new Bank("Банк А", new ClientsFileRepository(AppSettings.ClientsRepositoryFilePath), worker);
        //_Title = $"{Bank.Name}. Программа консультант";
        //Worker = worker;
        
        #region Pages
        _clients = new ClientsView();
        _appSettings = new SettingsView();

        ViewOpacity = 1.0;
        CurrentView = new ClientsView();
        #endregion

        #region commands
        ShowClientsView = new LambdaCommand(OnSetClientsViewExecuted, CanSetClientsViewExecute);
        ShowSettingsView = new LambdaCommand(OnSetAppSettingsViewExecuted, CanSetAppSettingsViewExecute);
        #endregion
    }
    
    #region Pages
    private readonly UserControl _clients;
    private readonly UserControl _appSettings;

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
    private void OnSetClientsViewExecuted(object p)
    {
        CurrentView = _clients;
        // if (_clients.DataContext is ClientsViewModel clientsVm)
        // {
        //     clientsVm.UpdateClientsList.Invoke();
        // }
    }
    private bool CanSetClientsViewExecute(object p) => true;
    #endregion
    
    #region SetAppSettingsViewCommand
    public ICommand ShowSettingsView { get; }
    private void OnSetAppSettingsViewExecuted(object p) => CurrentView = _appSettings;
    private bool CanSetAppSettingsViewExecute(object p) => true;
    #endregion
    
    #endregion
    
    #region Window title
    
    private string _title = "Банк";
    /// <summary>
    /// Заголовок окна
    /// </summary>
    public string Title
    {
        get => _title;
        set => Set(ref _title, value);
    }
    #endregion
}