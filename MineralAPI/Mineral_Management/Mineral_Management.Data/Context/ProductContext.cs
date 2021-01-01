using System.Security.Authentication;
using Microsoft.Extensions.Options;
using Mineral_Management.Data.Models;
using MongoDB.Driver;

namespace Mineral_Management.Data.Context
{
    public class ProductContext
    {
        private readonly IMongoDatabase _database = null;

        public ProductContext(IOptions<Mineral_Management_ApiDbSettings> settings)
        {
            MongoClientSettings settings2 = MongoClientSettings.FromUrl(
                new MongoUrl(settings.Value.ConnectionString)
            );
            settings2.SslSettings =
                new SslSettings() { EnabledSslProtocols = SslProtocols.Tls12 };

            var client = new MongoClient(settings2);
            if (client != null)
                _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<Product> Products
        {
            get
            {
                return _database.GetCollection<Product>("Product");
            }
        }
    }

}
