using Microsoft.EntityFrameworkCore;
using ProductionControlSystem.Core.Models;

namespace ProductionControlSystem.Data.Services
    {
    public class ClientService
        {
        private readonly ProductionDbContext _db;

        public ClientService(ProductionDbContext db)
            {
            _db = db;
            }

        public async Task<List<Client>> GetAllClientsAsync()
            {
            return await _db.Clients
                .Include(c => c.Projects)
                .ToListAsync();
            }

        public async Task<Client?> GetClientByIdAsync(int clientId)
            {
            return await _db.Clients
                .Include(c => c.Projects)
                .FirstOrDefaultAsync(c => c.Id == clientId);
            }

        public async Task AddClientAsync(Client client)
            {
            _db.Clients.Add(client);
            await _db.SaveChangesAsync();
            }

        public async Task UpdateClientAsync(Client client)
            {
            _db.Clients.Update(client);
            await _db.SaveChangesAsync();
            }

        public async Task DeleteClientAsync(int clientId)
            {
            var client = await _db.Clients.FindAsync(clientId);
            if (client != null)
                {
                _db.Clients.Remove(client);
                await _db.SaveChangesAsync();
                }
            }
        }
    }

