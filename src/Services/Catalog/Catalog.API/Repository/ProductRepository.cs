using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;
using System.Xml.Linq;

namespace Catalog.API.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            this.catalogContext = catalogContext;
        }

        public Task CreateProduct(Product product)
        {
            catalogContext.Products.InsertOne(product);
            return Task.CompletedTask;
        }

        public Task DeleteProduct(string productId)
        {
            catalogContext.Products.DeleteOne(productId);
            return Task.CompletedTask;
        }

        public async Task<Product> GetProductById(string id)
        {
            return await catalogContext.Products.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await catalogContext.Products.Find(x => true).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategory(string category)
        {
            // return await catalogContext.Products.Find(x => x.Category == category).ToListAsync();
            //FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(product => product.Category, category);
            //FilterDefinition<Product> filter = Builders<Product>.Filter.Eq(product => product.Category, category);
            //return await catalogContext.Products.Find(filter).ToListAsync();
            return await catalogContext.Products.Find(x => x.Category   == category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByName(string name)
        {
            return await catalogContext.Products.Find(x => x.Name == name).ToListAsync();
            //FilterDefinition<Product> filter = Builders<Product>.Filter.ElemMatch(product => product.Name, name);
            //return await catalogContext.Products.Find(filter).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var updateResult = await catalogContext.Products.ReplaceOneAsync(
                filter: g => g.Id == product.Id,
                replacement: product);

            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }
    }
}
