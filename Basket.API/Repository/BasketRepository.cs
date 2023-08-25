using Basket.API.Entites;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Basket.API.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache distributedCache;
        public BasketRepository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }
        public async Task DeleteShoppingCart(string userName)
        {
            var basket = await distributedCache.GetStringAsync(userName);
            if(string.IsNullOrEmpty(basket))  return;
            return JsonConvert.DeserializeObject<ShoppingCart>(basket);

        }

        public Task<ShoppingCart> GetShoppingCart(string userName)
        {
            throw new NotImplementedException();
        }

        public Task<ShoppingCart> UpdateCart(ShoppingCart cart)
        {
            throw new NotImplementedException();
        }
    }
}
