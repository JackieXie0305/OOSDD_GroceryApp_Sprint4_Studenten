using Grocery.Core.Models;
using System.Collections.Generic;

namespace Grocery.Core.Interfaces.Repositories
{
    public interface IClientRepository
    {
        List<Client> GetAll();
        Client? Get(int id);
    }
}
