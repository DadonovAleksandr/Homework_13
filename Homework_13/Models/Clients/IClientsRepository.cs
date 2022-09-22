using System.Collections.Generic;
using Homework_13.Models.Common;

namespace Homework_13.Models.Clients;

internal interface IClientsRepository
{
    /// <summary>
    /// Кол-во клиентов
    /// </summary>
    public int Count { get; }

    /// <summary>
    /// Получить список клиентов
    /// </summary>
    /// <returns></returns>
    IEnumerable<Client>? GetAllClients();

    /// <summary>
    /// Получение информации о клиенте по ИД
    /// </summary>
    /// <param name="id">ИД клиента</param>
    /// <returns></returns>
    Client? GetClient(int id);

    /// <summary>
    /// Добавление клиента в репозиторий
    /// </summary>
    void InsertClient(PhoneNumber phoneNumber, PassportData passportData, 
        string firstName, string lastName, string middleName = "");

    /// <summary>
    /// Удаление клиента
    /// </summary>
    /// <param name="id">ИД клиента</param>
    void DeleteClient(int id);

    /// <summary>
    /// Обновление данных о клиенте
    /// </summary>
    /// <param name="client">Клиент</param>
    void UpdateClient(Client client);
    
    /// <summary>
    /// Удаление всех данных
    /// </summary>
    void Clear();
}