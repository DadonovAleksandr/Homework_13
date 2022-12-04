using System.IO;
using System.Text;
using System.Text.Json;
using NLog;

namespace Homework_13.Models.AppSettings;

internal class AppSettingsFileRepository : IAppSettingsRepository
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    private readonly string _path;

    public AppSettingsFileRepository()
    {
        _path = @"app-settings.json";
        _logger.Debug($"Вызов конструктора по умолчанию {this.GetType().Name}");
        _logger.Debug($"Настройки проекта хранятся в файле: {_path}");
    }
    
    public AppSettingsFileRepository(string path)
    {
        _path = path;
        _logger.Debug($"Вызов конструктора {this.GetType().Name}");
        _logger.Debug($"Настройки проекта хранятся в файле: {_path}");
    }

    /// <summary>
    /// Сохранение настроек приложения
    /// </summary>
    /// <param name="settings"></param>
    public void Save(AppSettings settings)
    {
        string json = JsonSerializer.Serialize(settings);
        File.WriteAllText(_path, json, Encoding.UTF8);
        _logger.Debug($"Сохранение настроек приложения в файл: {_path}");
    }

    /// <summary>
    /// Загрузка настроек приложения
    /// </summary>
    /// <returns></returns>
    public AppSettings Load()
    {
        _logger.Debug($"Закгрузка настроек приложения из файла: {_path}");
        if (!File.Exists(_path))
            return new AppSettings();
        string data = File.ReadAllText(_path);
        return JsonSerializer.Deserialize<AppSettings>(data) ?? new AppSettings();
    }

    public override string ToString()
    {
        return $"Файловый репозиторий: {_path}";
    }
    
}