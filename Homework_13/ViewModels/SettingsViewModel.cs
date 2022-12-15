using System.IO;
using System.Windows.Input;
using Homework_13.Infrastructure.Commands;
using Homework_13.Models.AppSettings;
using Homework_13.Models.Clients;
using Homework_13.Models.Common;
using Homework_13.ViewModels.Base;
using Homework_13.Views;

namespace Homework_13.ViewModels;

internal class SettingsViewModel : BaseViewModel
{
    IAppSettingsRepository _repository;
    
    public SettingsViewModel(IAppSettingsRepository repository)
    {
        logger.Debug($"Вызов конструктора {this.GetType().Name}");
        _repository = repository;
        AppSettings.Set(repository.Load());
        
        #region Commands
        SaveSettingsCommand = new LambdaCommand(OnSaveAppSettingsCommandExecuted, CanSaveAppSettingsCommandExecute);
        GenTestClientsCommand = new LambdaCommand(OnGenTestClientsCommandExecuted, CanGenTestClientsCommandExecute);
        ClearClientsCommand = new LambdaCommand(OnClearClientsCommandExecuted, CanClearClientsCommandExecute);
        #endregion
    }
    
    #region Commands

    #region SaveAppSettingsCommand
    public ICommand SaveSettingsCommand { get; }

    private void OnSaveAppSettingsCommandExecuted(object p)
    {
        logger.Debug($"Сохранение настроек приложения в {_repository}");
        _repository.Save(AppSettings.Get());
    }

    private bool CanSaveAppSettingsCommandExecute(object p) => true;

    #endregion

    #region GenTestClientsCommand
    public ICommand GenTestClientsCommand { get; }

    private void OnGenTestClientsCommandExecuted(object p)
    {
        var dw = new InputTestClientsCountView();
        dw.ShowDialog();
        
        if(!dw.DialogResult.HasValue || !dw.DialogResult.Value)
            return;
        if(!int.TryParse(((InputTestClientsCountViewModel)dw.DataContext).TestClientsCount, out var count))
            return;
        
        AppSettings.Get().ClientsRepositoryFilePath = ClientRepositoryFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"clients.json");
        var clientsRepository = new ClientsFileRepository(ClientRepositoryFilePath);
        for (int i = 1; i <= count; i++)
        {
            clientsRepository.InsertClient(
                new PhoneNumber($"+7900800{(i>9 ? i : "0"+i)}"),
                new PassportData(1000+i, 50000+i),
                $"Имя {i}",
                $"Фамиля {i}",
                $"Отчество {i}");
        }
    }

    private bool CanGenTestClientsCommandExecute(object p) => true;
    #endregion
    
    #region ClearClientsCommand
    public ICommand ClearClientsCommand { get; }

    private void OnClearClientsCommandExecuted(object p)
    {
        var clientsRepository = new ClientsFileRepository(ClientRepositoryFilePath);
        clientsRepository.Clear();
        
    }

    private bool CanClearClientsCommandExecute(object p) => true;
    #endregion

    
    #endregion
    
    #region ClientRepositoryFilePath
    private string _clientRepositoryFilePath;
    /// <summary>
    /// Настройки приложения
    /// </summary>
    public string ClientRepositoryFilePath
    {
        get => AppSettings.Get().ClientsRepositoryFilePath;
        set
        {
            Set(ref _clientRepositoryFilePath, value);
            AppSettings.Get().ClientsRepositoryFilePath = _clientRepositoryFilePath;
        }
    }
    #endregion
}