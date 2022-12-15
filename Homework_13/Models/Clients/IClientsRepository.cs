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
    Client? InsertClient(PhoneNumber phoneNumber, PassportData passportData, 
        string firstName, string lastName, string middleName = "");

    /// <summary>
    /// Удаление клиента
    /// </summary>
    /// <param name="client">Клиент</param>
    bool DeleteClient(Client client);

    /// <summary>
    /// Обновление данных о клиенте
    /// </summary>
    /// <param name="client">Клиент</param>
    bool UpdateClient(Client client);
    
    /// <summary>
    /// Удаление всех данных
    /// </summary>
    void Clear();

    /// <summary>
    /// Обновление данных
    /// </summary>
    void Update();
}