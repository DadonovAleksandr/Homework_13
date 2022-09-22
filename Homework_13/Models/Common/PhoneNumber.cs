using System;
using System.Text.RegularExpressions;
using NLog;

namespace Homework_13.Models.Common;
/// <summary>
/// Номер телефона
/// </summary>
internal class PhoneNumber
{
    private static Logger logger = LogManager.GetCurrentClassLogger();
    
    /// <summary>
    /// Текстовое представление телефонного номера
    /// </summary>
    public string Number { get; set; }

    public PhoneNumber()
    {
        logger.Debug($"Вызов конструктора {GetType().Name} по умолчанию");
    }

    /// <summary>
    /// Создаем номер телефона из текстовой строки
    /// </summary>
    /// <param name="number"></param>
    public PhoneNumber(string number)
    {
        logger.Debug($"Вызов конструктора {GetType().Name} c параметрами: номер телефлна {number}");
        Number = number;
    }
    
    /// <summary>
    /// Проверяем, является ли вводимая строка номером телефона
    /// </summary>
    /// <param name="number"></param>
    /// <returns></returns>
    public static bool IsPhoneNumber(string number)
    {
        if (string.IsNullOrEmpty(number) || string.IsNullOrWhiteSpace(number))
        {
            logger.Debug($"Номер телефона не может быть пустым или пробелом");
            return false;
        }
        
        var result = Regex.Match(number, @"^(\+[0-9]{9})$").Success;
        logger.Debug($"Проверка строки \"{number}\" на соответствие телефонному номеру: {(result ? "соответствует" : "не соответчтвует")}");
        return result;
    }
    
    public override string ToString()
    {
        return $"{Number}";
    }
}