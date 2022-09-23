using Homework_13.Models.Clients;
using Homework_13.Models.Common;
using NLog;

namespace Homework_13.Models;

internal class Bank
{
    private static Logger _logger = LogManager.GetCurrentClassLogger();
    
    /// <summary>
    /// Наименование Банка.
    /// </summary>
    public string Name { get; private set; }

    /// <summary>
    /// База клиентов
    /// </summary>
    public IClientsRepository ClientsRepository { get; set; }
    
    public Bank(string name, IClientsRepository clientsRepository)
    {
        Name = name;
        ClientsRepository = clientsRepository;
    }

    public bool AddClient(PhoneNumber phoneNumber, PassportData passportData, 
        string firstName, string lastName, string middleName = "")
    {
        var client = ClientsRepository.InsertClient(phoneNumber, passportData, firstName, lastName, middleName);
        if (client is null)
        {
            _logger.Error($"Операция добавления клиента невыполненна");
            return false;
        }
        _logger.Info($"Добавление клиента: ID={client.Id}, Имя={client.FirstName}, Фамилия={client.LastName}, " +
                     $"Отчество={client.MiddleName}, Пасспортные данные: {client.PassportData}, Телефон={client.PhoneNumber}");
        return true;
    }
    
    public bool EditClient(Client client)
    {
        if (ClientsRepository.UpdateClient(client))
        {
            _logger.Info($"Редактирование клиента: ID={client.Id}, Имя={client.FirstName}, Фамилия={client.LastName}, " +
                         $"Отчество={client.MiddleName}, Пасспортные данные: {client.PassportData}, Телефон={client.PhoneNumber}");
            return true;
        }
        _logger.Error($"Операция редактирования клиента невыполненна");
        return false;
    }
    
    public bool DeleteClient(Client client)
    {
        if (ClientsRepository.DeleteClient(client))
        {
            _logger.Info($"Удаление клиента: ID={client.Id}, Имя={client.FirstName}, Фамилия={client.LastName}, " +
                         $"Отчество={client.MiddleName}, Пасспортные данные: {client.PassportData}, Телефон={client.PhoneNumber}");
            return true;
        }
        _logger.Error($"Операция удаления клиента невыполненна");
        return false;
    }
    
    
    
    
    
}