using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class ShakeService : IShakeService
    {
        private readonly IMongoCollection<Shake> _shakes;
        public ShakeService(IOptions<RebarMongoDB> options)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _shakes = mongoClient.GetDatabase(options.Value.DatabaseName).
                GetCollection<Shake>(options.Value.ShakesCollectionName);
        }
        public List<Shake> GetAllShakes()
        {
            return _shakes.Find(_ => true).ToList();
        }

        public OrderedShakes GetShake(string name, string id ,string size)
        {
            var shake =  _shakes.Find(s =>  s.Name == name && s.ShakeId == id).FirstOrDefault();
            try
            {
                switch (size)
                {
                    case "Large":
                        return new OrderedShakes(shake, shake.PriceLarge, size);
                    case "Medium":
                        return new OrderedShakes(shake, shake.PriceMedium, size);
                    case "Small":
                        return new OrderedShakes(shake, shake.PriceSmall, size);
                    default:
                        return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
        }
        
        public void AddShake(string name, string description, double priceLarge, double priceMedium, double priceSmall)
        {
            var shake = new Shake
            {
                Name = name,
                Description = description,
                PriceLarge = priceLarge,
                PriceMedium = priceMedium,
                PriceSmall = priceSmall
            };

            _shakes.InsertOne(shake);
        }
    }
}
