using NLog;

namespace Homework_13.Models.AppSettings;
/// <summary>
/// Настройки приложения
/// </summary>
internal class AppSettings
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    
    public AppSettings()
    {
        _logger.Debug($"Вызов конструктора {GetType().Name}");
        _clientsRepositoryFilePath = string.Empty;
    }
    
    private string _clientsRepositoryFilePath; 
    /// <summary>
    /// Путь до базы клиентов
    /// </summary>
    public string ClientsRepositoryFilePath
    {
        get
        {
            if (string.IsNullOrEmpty(_clientsRepositoryFilePath))
            {
                _clientsRepositoryFilePath = @"clients.json";
                _logger.Warn($"Устанавливаем путь по умолчанию для базы клиентов: {_clientsRepositoryFilePath}");
            }
            return _clientsRepositoryFilePath;
        }
        set
        {
            _clientsRepositoryFilePath = value;
        }
    }
}