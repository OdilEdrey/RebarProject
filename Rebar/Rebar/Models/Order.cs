using Microsoft.AspNetCore.Components;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar.Models
{

    public record OrderedShakes ([property:BsonElement("Shake")] Shake shake, [property: BsonElement("Price")]  double price, [property: BsonElement("size")] string size);
    public record UserOrderShake( [property: BsonElement("name")] string name, [property: BsonElement("id")] string id, [property: BsonElement("size")] string size);

    public class Order
    {
        [BsonId]
        public string OrderId { get; } = Guid.NewGuid().ToString();
        [BsonElement("OrderedShakes")]
        public List<OrderedShakes> OrderedShakes { get; set; } = new List<OrderedShakes>();
        [BsonElement("ShakesTotalPrice")]
        public double ShakesTotalPrice { get; set; } = 0;
        [BsonElement("CustomerName")]
        public string CustomerName { get; set; }
        [BsonElement("OrderDate")]
        public TimeSpan OrderDate { get; set; }
        [BsonElement("OrderCreated")]
        public DateTime OrderCreated { get; set; }
        [BsonElement("OrderEnded")]
        public DateTime OrderEnded { get; set; }
        [BsonElement("Discounts")]
        public List<Discount> Discounts { get; set; }

    }
}
