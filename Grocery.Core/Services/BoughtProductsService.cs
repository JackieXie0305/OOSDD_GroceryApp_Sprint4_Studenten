using Grocery.Core.Interfaces.Repositories;
using Grocery.Core.Interfaces.Services;
using Grocery.Core.Models;

namespace Grocery.Core.Services
{
    public class BoughtProductsService : IBoughtProductsService
    {
        private readonly IGroceryListItemsRepository _groceryListItemsRepository;
        private readonly IGroceryListRepository _groceryListRepository;
        private readonly IProductRepository _productRepository;
        private readonly IClientRepository _clientRepository;

        public BoughtProductsService(
            IGroceryListItemsRepository groceryListItemsRepository,
            IGroceryListRepository groceryListRepository,
            IProductRepository productRepository,
            IClientRepository clientRepository)
        {
            _groceryListItemsRepository = groceryListItemsRepository;
            _groceryListRepository = groceryListRepository;
            _productRepository = productRepository;
            _clientRepository = clientRepository;
        }

        public List<BoughtProducts> Get(int? productId)
        {
            if (productId == null)
                return new List<BoughtProducts>();

            var items = _groceryListItemsRepository.GetAll()
                .Where(i => i.ProductId == productId && i.IsBought)
                .ToList();

            var result = new List<BoughtProducts>();

            foreach (var it in items)
            {
                var list = _groceryListRepository.Get(it.GroceryListId);
                var product = _productRepository.Get(it.ProductId);
                var client = list != null ? _clientRepository.Get(list.ClientId) : null;

                if (list != null && product != null && client != null)
                {
                    result.Add(new BoughtProducts(client, list, product));
                }
            }

            return result;
        }
    }
}
