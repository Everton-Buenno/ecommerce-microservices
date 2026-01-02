using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Data;

public class CatalogContext : ICatalogContext
{
    public CatalogContext(IMongoClient mongoClient, IConfiguration configuration)
    {
        var databaseName = configuration.GetValue<string>("DatabaseSettings:DatabaseName") ?? "catalogdb";
        var database = mongoClient.GetDatabase(databaseName);

        var collectionName = configuration.GetValue<string>("DatabaseSettings:CollectionName") ?? "Products";
        Products = database.GetCollection<Product>(collectionName);
    }

    public IMongoCollection<Product> Products { get; }
}