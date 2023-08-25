using Basket.API.Entites;

namespace Basket.API.Repository
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> UpdateCart(ShoppingCart cart);
        Task<ShoppingCart> GetShoppingCart(string userName);
        Task DeleteShoppingCart(string userName);
    }
}
