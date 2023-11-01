using MongoDB.Bson.Serialization.Attributes;

namespace Rebar.Models
{
    public class Account
    {
        [BsonId]
        public string Name { get; set; }
        [BsonElement("Orders")]
        public List<Order> Orders { get; set; } = new List<Order>();
        [BsonElement("TotalOrderAmount")]
        public int TotalOrderAmount { get; set; } = 0;
    }
}
