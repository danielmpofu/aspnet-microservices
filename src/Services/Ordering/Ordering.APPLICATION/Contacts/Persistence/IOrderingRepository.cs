using Oerdering.DOMAIN.Entities;

namespace Ordering.APPLICATION.Contacts.Persistence;

public interface IOrderingRepository : IAsyncRepository<Order>
{
    Task<IEnumerable<Order>> GetOrdersByUsername(string username);
}