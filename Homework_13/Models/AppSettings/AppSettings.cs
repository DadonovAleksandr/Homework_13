using NLog;

namespace Homework_13.Models.AppSettings;
/// <summary>
/// Настройки приложения (потоконебезопасный синглтон)
/// </summary>
internal class AppSettings
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private static AppSettings _instance;
    
    public AppSettings()
    {
        _logger.Debug($"Вызов конструктора {GetType().Name}");
        _clientsRepositoryFilePath = string.Empty;
    }

    public static AppSettings Get()
    {
        if(_instance is null)
            _instance = new AppSettings();
        return _instance;
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