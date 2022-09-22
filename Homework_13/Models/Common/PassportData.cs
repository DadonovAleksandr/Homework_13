using NLog;

namespace Homework_13.Models.Common;

/// <summary>
/// Паспортные данные
/// </summary>
internal class PassportData
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    public const int MinSeriesValue = 1;
    public const int MaxSeriesValue = 9999;

    public const int MinNumberValue = 1;
    public const int MaxNumberValue = 999999;
    
    /// <summary>
    /// Серия
    /// </summary>
    public int Serie { get; set; }
    
    /// <summary>
    /// Номер
    /// </summary>
    public int Number { get; set; }
    
    /// <summary>
    /// Проверка, являются ли вводимые данные серией паспорта
    /// </summary>
    /// <param name="value">Серия</param>
    /// <returns></returns>
    public static bool IsSerie(string value)
    {
        if (!int.TryParse(value, out var serie)) return false;

        if (serie < MinSeriesValue || serie > MaxSeriesValue)
        {
            Logger.Debug($"Число \"{serie}\" не является корректным для серии паспорта");
            return false;
        }
        return true;
    }
    
    /// <summary>
    /// Проверка, являются ли вводимые данные номером паспорта
    /// </summary>
    /// <param name="value">Номер</param>
    /// <returns></returns>
    public static bool IsNumber(string value)
    {
        if (!int.TryParse(value, out var number)) return false;
        
        if (number < MinNumberValue || number > MaxNumberValue)
        {
            Logger.Debug($"Число \"{number}\" не является корректным для номера паспорта");
            return false;
        }
        return true;
    }

    public PassportData()
    {
        Logger.Debug($"Вызов конструктора {GetType().Name} по умолчанию");
    }
    
    /// <summary>
    /// Создаем пасспорт с серией и номером
    /// </summary>
    /// <param name="series">Серия</param>
    /// <param name="number">Номер</param>
    public PassportData(int serie, int number)
    {
        Logger.Debug($"Вызов конструктора {GetType().Name} c параметрами (серия: {serie}, номер: {number})");
        Serie = serie;
        Number = number;
    }

    public override string ToString()
    {
        return $"{Serie}-{Number}";
    }
    
}