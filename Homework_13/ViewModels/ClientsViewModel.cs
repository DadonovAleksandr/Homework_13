using System.Collections.ObjectModel;
using System.Windows.Input;
using Homework_13.Infrastructure.Commands;
using Homework_13.Models.Clients;
using Homework_13.ViewModels.Base;

namespace Homework_13.ViewModels;

internal class ClientsViewModel : BaseViewModel
{
    private IClientsRepository _repository;
    public ObservableCollection<Client> Clients { get; private set; }

    public ClientsViewModel(IClientsRepository repository)
    {
        logger.Debug($"Вызов конструктора {this.GetType().Name}");
        _repository = repository;
        _repository.Update();
        
        Clients = new ObservableCollection<Client>();
        foreach (var client in _repository.GetAllClients()!)
        {
            Clients.Add(client);
        }
        
        #region Commands
        AddClientCommand = new LambdaCommand(OnAddClientCommandExecuted, CanAddClientCommandExecute);
        DelClientCommand = new LambdaCommand(OnDelClientCommandExecuted, CanDelClientCommandExecute);
        EditClientCommand = new LambdaCommand(OnEditClientCommandExecuted, CanEditClientCommandExecute);
        #endregion
    }
    
    
    #region Commands

    #region AddClient
    public ICommand AddClientCommand { get; }

    private void OnAddClientCommandExecuted(object p)
    {
        // ClientCardWindow clientCard = new ClientCardWindow();
        // ClientCardViewModel clientCardVm = new ClientCardViewModel(new ClientInfo(), MainVm.Bank, this, MainVm.Worker.DataAccess);
        // clientCard.DataContext = clientCardVm;
        // clientCard.ShowDialog();
    }

    private bool CanAddClientCommandExecute(object p) => true;

    #endregion

    #region DelClient
    public ICommand DelClientCommand { get; }

    private void OnDelClientCommandExecuted(object p)
    {
        // if(SelectedClient is null) return;
        //
        // MainVm.Bank.DeleteClient(SelectedClient);
        // UpdateClients();
    }

    private bool CanDelClientCommandExecute(object p) => true;
    #endregion

    #region EditClient
    public ICommand EditClientCommand { get; }

    private void OnEditClientCommandExecuted(object p)
    {
        // if(SelectedClient is null) return;
        //
        // ClientCardWindow clientCard = new ClientCardWindow();
        // ClientCardViewModel clientCardVm = new ClientCardViewModel(SelectedClient, MainVm.Bank, this, MainVm.Worker.DataAccess);
        // clientCard.DataContext = clientCardVm;
        // clientCard.ShowDialog();
    }

    private bool CanEditClientCommandExecute(object p) => true;
    #endregion


    #endregion
    
    #region SelectedClient
    private Client _selectedClient;
    public Client SelectedClient
    {
        get => _selectedClient;
        set => Set(ref _selectedClient, value);
    }
    #endregion
    
    #region SelectedIndex
    private int _selectedIndex;
    public int SelectedIndex
    {
        get => _selectedIndex;
        set => Set(ref _selectedIndex, value);
    }
    #endregion

    
}