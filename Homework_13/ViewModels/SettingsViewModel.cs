using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    AppSettings _appSettings;
    
    public SettingsViewModel(IAppSettingsRepository repository)
    {
        logger.Debug($"Вызов конструктора {this.GetType().Name}");
        _repository = repository;
        _appSettings = repository.Load();
        
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
        _repository = new AppSettingsFileRepository();
        _repository.Save(_appSettings);
    }

    private bool CanSaveAppSettingsCommandExecute(object p) => true;

    #endregion

    #region GenTestClientsCommand
    public ICommand GenTestClientsCommand { get; }

    private void OnGenTestClientsCommandExecuted(object p)
    {
        _appSettings.ClientsRepositoryFilePath = ClientRepositoryFilePath = Path.Combine(Directory.GetCurrentDirectory(), @"clients.json");
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
        get => _appSettings?.ClientsRepositoryFilePath ?? string.Empty;
        set
        {
            Set(ref _clientRepositoryFilePath, value);
            _appSettings.ClientsRepositoryFilePath = _clientRepositoryFilePath;
        }
    }
    #endregion
}