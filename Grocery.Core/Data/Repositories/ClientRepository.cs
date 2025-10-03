using Grocery.Core.Models;
using Grocery.Core.Interfaces.Repositories;

namespace Grocery.Core.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly List<Client> clients = new()
        {
            new Client(1, "user1", "user1@email.com", "pw1"),
            new Client(2, "user2", "user2@email.com", "pw2"),
            new Client(3, "user3", "user3@email.com", "pw3", Role.Admin)
        };

        public List<Client> GetAll() => clients;

        public Client? Get(int id) => clients.FirstOrDefault(c => c.Id == id);
    }
}
