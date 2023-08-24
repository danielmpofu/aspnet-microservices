using Catalog.API.Entities;
using Catalog.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        //private readonly IConfiguration configuration;
        public IMongoCollection<Product> Products { get; }

        //public CatalogContext(IConfiguration configuration)
        //{
        //    this.configuration = configuration;
        //    // var client = new MongoClient(configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        //    // var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSettings:DatabaseName"));
        //    //var Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSettings:CollectionName"));
        //    var client = new MongoClient("mongodb://localhost:27017");
        //    var database = client.GetDatabase("CatalogDb");
        //    var Products = database.GetCollection<Product>("Products");
        //    CatalogcontextSeed.SeedData(Products);
        //}

        public CatalogContext(IOptions<DatabaseProperties> config)
        {
            var mongoClient = new MongoClient(config.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(config.Value.DatabaseName);
            Products = mongoDatabase.GetCollection<Product>(config.Value.CollectionName);
            CatalogcontextSeed.SeedData(Products);
        }

    }
}
