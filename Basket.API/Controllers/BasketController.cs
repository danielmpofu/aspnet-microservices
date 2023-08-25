using Basket.API.Entites;
using Basket.API.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Basket.API.Controllers;

[ApiController]
[Route("[controller]")]
public class BasketController : Controller
{
    private readonly IBasketRepository basketRepository;

    public BasketController(IBasketRepository basketRepository)
    {
        this.basketRepository = basketRepository;
    }
    
    [HttpGet("{username}")]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string username)
    {
        ShoppingCart? basket = await basketRepository.GetShoppingCart(username);
        return Ok(basket ?? new ShoppingCart());
    }

    [HttpPut]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody] ShoppingCart shoppingCart)
    {
        var updatedCart = await basketRepository.UpdateCart(shoppingCart);
        return Ok(updatedCart);
    }


    [HttpDelete("{username}")]
    public async Task<ActionResult> DeleteCart(string username)
    {
        await basketRepository.DeleteShoppingCart(username);
        return NoContent();
    }
}