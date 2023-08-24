using Catalog.API.Entities;

namespace Catalog.API.Repository
{
    public interface IProductRepository
    {
        public Task<IEnumerable<Product>> GetProducts();
        public Task<IEnumerable<Product>> GetProductsByName(string name);
        public Task<IEnumerable<Product>> GetProductsByCategory(string category);
        public Task CreateProduct(Product product);
        public Task<bool> UpdateProduct(Product product);
        public Task DeleteProduct(string product);
        public Task<Product> GetProductById(string id);
    }
}
