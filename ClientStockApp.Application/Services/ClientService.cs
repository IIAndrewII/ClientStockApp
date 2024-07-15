using ClientStockApp.Application.Interfaces;
using ClientStockApp.Domain.Models;

namespace ClientStockApp.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository _clientRepository;

        public ClientService(IClientRepository clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientRepository.GetAllClientsAsync();
        }

        public async Task<Client> GetClientByIdAsync(int clientId)
        {
            return await _clientRepository.GetClientByIdAsync(clientId);
        }

        public async Task AddClientAsync(Client client)
        {
            await _clientRepository.AddClientAsync(client);
        }

        public async Task UpdateClientAsync(Client client)
        {
            await _clientRepository.UpdateClientAsync(client);
        }

        public async Task DeleteClientAsync(int clientId)
        {
            await _clientRepository.DeleteClientAsync(clientId);
        }
    }
}
