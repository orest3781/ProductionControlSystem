using ReactiveUI;
using System.Collections.ObjectModel;
using System.Reactive;
using System.Threading.Tasks;
using ProductionControlSystem.Core.Models;
using ProductionControlSystem.Data.Services;

namespace ProductionControlSystem.UI.ViewModels
    {
    public class MainWindowViewModel : ReactiveObject
        {
        private readonly ClientService _clientService;

        public MainWindowViewModel()
            {
            // Resolve from DI
            _clientService = ServiceLocator.Resolve<ClientService>();

            LoadClientsCommand = ReactiveCommand.CreateFromTask(LoadClientsAsync);

            Clients.Add(new Client { ClientCode = "C0001", Name = "Acme Corp" });
            Clients.Add(new Client { ClientCode = "C0002", Name = "Initech" });

            }

        private ObservableCollection<Client> _clients = new ObservableCollection<Client>();
        public ObservableCollection<Client> Clients
            {
            get => _clients;
            set => this.RaiseAndSetIfChanged(ref _clients, value);
            }

        public ReactiveCommand<Unit, Unit> LoadClientsCommand { get; }

        private async Task LoadClientsAsync()
            {
            var allClients = await _clientService.GetAllClientsAsync();
            Clients = new ObservableCollection<Client>(allClients);
            }
        }
    }

