using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Homework_13.Models.Common;
using NLog;

namespace Homework_13.Models.Clients;

internal class ClientsFileRepository : IClientsRepository, IEnumerable<Client>
{
    private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

    /// <summary>
    /// Максимальный ИД в текущем списке клиентов 
    /// </summary>
    private static int _maxId;
    
    static ClientsFileRepository()
    {
        Logger.Debug($"Вызов статического конструктора ClientsFileRepository по умолчанию");
        _maxId = 0;
    }
    
    /// <summary>
    /// Файл репозитория
    /// </summary>
    readonly string _path;
    
    private List<Client>? _clients;
    /// <summary>
    /// Список клиентов
    /// </summary>
    public List<Client>? Clients => _clients;
    
    /// <summary>
    /// Конструктор репозитория
    /// </summary>
    /// <param name="path">Путь к файлу-репозиторию</param>
    public ClientsFileRepository(string path)
    {
        Logger.Debug($"Вызов конструктора {GetType().Name} c параметрами: база клиентов {path}");

        if (string.IsNullOrEmpty(path) || string.IsNullOrWhiteSpace(path))
        {
            Logger.Error($"{path} не допустимое наименование файла");
            throw new ArgumentNullException(nameof(path));
        }
        _path = path;

        if (File.Exists(_path)) // если файл существует, подгружаем данные
        {
            Load();
            return;
        }
        // если файл не существует, создаем новый пустой репозиторий
        File.Create(_path);
        NoClientsForLoad();
    }
    /// <summary>
    /// Получение следующего свободного идентификатора клиента
    /// </summary>
    /// <returns></returns>
    private static int NextId() => ++_maxId;

    /// <summary>
    /// Кол-во клиентов
    /// </summary>
    public int Count
    {
        get
        {
            if (Clients is null) ClientsIsNull();
            return Clients.Count;   
        }
    }

    /// <summary>
    /// Получить список клиентов
    /// </summary>
    /// <returns></returns>
    public IEnumerable<Client>? GetAllClients() => Clients;
    
    /// <summary>
    /// Получение информации о клиенте по ИД
    /// </summary>
    /// <param name="id">ИД клиента</param>
    /// <returns></returns>
    public Client? GetClient(int id)
    {
        if(Clients is null) ClientsIsNull();
        if(Clients.Any(c=>c.Id == id))
        {
            Logger.Debug($"Получение клиента с ID =  {id}");
            return Clients.First(c => c.Id == id);    
        }
        Logger.Error($"Получение клиента с ID =  {id} не возможно. Заданный ID не найден");
        return null;
    }

    /// <summary>
    /// Добавление клиента в репозиторий
    /// </summary>
    /// <param name="client">Клиент</param>
    /// <param name="phoneNumber">Номер телефона</param>
    /// <param name="passportData">Паспортные данные</param>
    /// <param name="firstName">Имя</param>
    /// <param name="lastName">Фамилия</param>
    /// <param name="middleName">Отчество</param>
    public void InsertClient(PhoneNumber phoneNumber, PassportData passportData, 
        string firstName, string lastName, string middleName = "")
    {
        var client = new Client(NextId(), phoneNumber, passportData, firstName, lastName, middleName);
        if(_clients is null) return;
        _clients.Add(client);   
        Logger.Debug($"Добавление клиента: ID={client.Id}, Имя={client.FirstName}, Фамилия={client.LastName}, Отчество={client.MiddleName}, " +
                     $"Номер телефона={client.PhoneNumber}, Пасспортные данные={client.PassportData}");
        Save();
    }
    
    /// <summary>
    /// Удаление клиента
    /// </summary>
    /// <param name="id">ИД клиента</param>
    public void DeleteClient(int id)
    {
        if(Clients is null) ClientsIsNull();
        if(Clients.Any(c=>c.Id == id))
        {
            Clients.Remove(Clients.First(c => c.Id == id));    
            Logger.Debug($"Удаление клиента с ID =  {id}");
            Save();
            return;
        }
        
        Logger.Warn($"Удаление клиента с ID =  {id} не возможно. Заданный ID не найден");
    }
    
    /// <summary>
    /// Обновление данных о клиенте
    /// </summary>
    /// <param name="client">Клиент</param>
    public void UpdateClient(Client client)
    {
        if (Clients is null)
        {
            Logger.Error($"Репозиторий клиентов null");
            return;
        }
            
        if (Clients.All(c => c.Id != client.Id))
        {
            Logger.Error($"Клиент c ID={client.Id}, Имя={client.FirstName}, Фамилия={client.LastName} отсутствует в базе");
        }
        
        Clients[Clients.IndexOf(Clients.First(c=>c.Id == client.Id))] = client;
        Logger.Debug($"Клиент c ID={client.Id}, Имя={client.FirstName}, Фамилия={client.LastName}, Отчество={client.MiddleName}, " +
                     $"Номер телефона={client.PhoneNumber}, Пасспортные данные={client.PassportData} обновлен");
        Save();
    }

    /// <summary>
    /// Удаление всех данных
    /// </summary>
    public void Clear()
    {
        if (Clients is null) ClientsIsNull();
        Clients.Clear();
    }
    
    /// <summary>
    /// Сохранение списка клиентов в файл
    /// </summary>
    void Save()
    {
        string json = JsonSerializer.Serialize(_clients);
        File.WriteAllText(_path, json);
        Logger.Debug($"Сохранение {Count} клиентов в файл {_path}");
    }

    /// <summary>
    /// Загрузка списка клинтов
    /// </summary>
    void Load()
    {
        string data = File.ReadAllText(_path);
        if (string.IsNullOrEmpty(data))
        {
            NoClientsForLoad();
            return;
        }
        _clients = JsonSerializer.Deserialize<List<Client>>(data, new JsonSerializerOptions()
        {
            PropertyNameCaseInsensitive = true
        });
        
        if (_clients is null)
        {
            NoClientsForLoad();
            return;
        }
        Logger.Debug($"Загрузка {Count} клиентов из файла {_path}");
        _maxId = Count > 0 ? _clients.Max(c => c.Id) : 0;
    }

    /// <summary>
    /// Обработка ситуации, когда не возможно загрузить клиентов
    /// </summary>
    private void NoClientsForLoad()
    {
        Logger.Error($"Не удалось загрузить клиентов из файла {_path}");
        InitClients();
    }
    
    /// <summary>
    /// Обработка ситуации, когда список клиентов null
    /// </summary>
    private void ClientsIsNull()
    {
        Logger.Error($"Список клиентов равен null");
        InitClients();
    }
    
    /// <summary>
    /// Инициализация списка клиентов
    /// </summary>
    private void InitClients()
    {
        _clients = new List<Client>();
        _maxId = 0;
    }

    
    public IEnumerator<Client> GetEnumerator()
    {
        if(Clients is null) ClientsIsNull();
        return ((IEnumerable<Client>)Clients).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}