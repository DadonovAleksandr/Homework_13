using System.Collections.Generic;
using Homework_13.Models.BankAccounts;
using Homework_13.Models.Common;
using NLog;

namespace Homework_13.Models.Clients;

internal class Client : Person
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    private readonly int _id;
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id => _id;
    
    /// <summary>
    /// Номер телефона
    /// </summary>
    public PhoneNumber PhoneNumber { get; set; }

    /// <summary>
    /// Паспортные данные
    /// </summary>
    public PassportData PassportData { get; set; }

    /// <summary>
    /// Банковские счета
    /// </summary>
    public List<BankAccount> Accounts { get; }

    /// <summary>
    /// Создаем клиента
    /// </summary>
    /// <param name="phoneNumber">Номер тедефона</param>
    /// <param name="passportData">Паспортный данные</param>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="middleName">отчество</param>
    public Client(int id, PhoneNumber phoneNumber, PassportData passportData, string firstName, string lastName, string middleName = "")
        : base(firstName, lastName, middleName)
    {
        _id = id;
        PhoneNumber = phoneNumber;
        PassportData = passportData;
    }
    
    
    
}