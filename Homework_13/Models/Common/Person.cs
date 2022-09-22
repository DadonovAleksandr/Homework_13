using NLog;

namespace Homework_13.Models.Common;
/// <summary>
/// Пользователь
/// </summary>
internal class Person
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Имя
    /// </summary>
    public string FirstName { get; set; }
    /// <summary>
    /// Фамилия
    /// </summary>
    public string LastName { get; set; }
    /// <summary>
    /// Отчество
    /// </summary>
    public string MiddleName { get; set; }
    
    public Person()
    {
        Logger.Debug($"Вызов конструктора {GetType().Name} по умолчанию");
    }
    
    public Person(string firstName, string lastName, string middleName)
    {
        FirstName = firstName;
        LastName = lastName;
        MiddleName = middleName;
        
        Logger.Debug($"Вызов конструктора {GetType().Name} c параметрами: имя {firstName}, фамилия {lastName}, отчество {middleName}");
    }
}