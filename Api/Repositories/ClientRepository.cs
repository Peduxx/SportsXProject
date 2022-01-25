using System.Threading.Tasks;
using Api.Data;
using Api.Repositories.Interfaces;
using VettaProject.Api.Models;

namespace Api.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly DataContext _context;

        public ClientRepository(DataContext context)
        {
            _context = context;
        }

        public async Task Save(Client client)
        {
            await _context.AddAsync(client);
            await _context.SaveChangesAsync();
        }
    }
}