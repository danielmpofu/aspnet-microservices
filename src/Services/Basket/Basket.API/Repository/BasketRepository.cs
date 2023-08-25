using Basket.API.Entites;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

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
            await distributedCache.RemoveAsync(userName);
        }

        public async Task<ShoppingCart> GetShoppingCart(string userName)
        {
            var basket = await distributedCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(basket)) return null;
            return  JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateCart(ShoppingCart cart)
        {
            await distributedCache.SetStringAsync(cart.Username, JsonConvert.SerializeObject(cart));
            return await GetShoppingCart(cart.Username);
        }
    }
}