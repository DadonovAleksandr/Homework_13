using System.IO;
using System.Windows.Input;
using Homework_13.Infrastructure.Commands;
using Homework_13.Models.AppSettings;
using Homework_13.Models.Clients;
using Homework_13.Models.Common;
using Homework_13.ViewModels.Base;

namespace Homework_13.ViewModels;

internal class SettingsViewModel : BaseViewModel
{
    IAppSettingsRepository _repository;
    
    public SettingsViewModel(IAppSettingsRepository repository)
    {
        logger.Debug($"Вызов конструктора {this.GetType().Name}");
        _repository = repository;
        var appSettings = AppSettings.Get();
        appSettings = repository.Load();
        
        #region Commands
        SaveSettingsCommand = new LambdaCommand(OnSaveAppSettingsCommandExecuted, CanSaveAppSettingsCommandExecute);
        GenTestClientsCommand = new LambdaCommand(OnGenTestClientsCommandExecuted, CanGenTestClientsCommandExecute);
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
        AppSettings.Get().ClientsRepositoryFilePath = ClientRepositoryFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"clients.json");
        ClientsFileRepository clientsRepository = new ClientsFileRepository(ClientRepositoryFilePath);
        for (int i = 1; i <= 20; i++)
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