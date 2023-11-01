using Microsoft.AspNetCore.Components;
using MongoDB.Bson.Serialization.Attributes;

namespace Rebar.Models
{
    public class Shake
    {
        [BsonId]
        public string ShakeId { get; set; } = Guid.NewGuid().ToString();
        [BsonElement("Name")]
        public string Name { get; set; }
        [BsonElement("Description")]
        public string Description { get; set; }
        [BsonElement("PriceLarge")]
        public double PriceLarge { get; set; }
        [BsonElement("PriceMedium")]
        public double PriceMedium { get; set; }
        [BsonElement("PriceSmall")]
        public double PriceSmall { get; set; }


    }
}
