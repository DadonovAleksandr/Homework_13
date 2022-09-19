namespace Homework_13.Models.AppSettings;

internal interface IAppSettingsRepository
{
    /// <summary>
    /// Сохранение настроек приложения
    /// </summary>
    /// <param name="settings"></param>
    public void Save(AppSettings settings);

    /// <summary>
    /// Загрузка настроек приложения
    /// </summary>
    /// <returns></returns>
    public AppSettings Load();
}