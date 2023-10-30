namespace Rebar.Models
{
    public record Shake
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double PriceLarge { get; set; }
        public double PriceMedium { get; set; }
        public double PriceSmall { get; set; }
        public Guid ShakeId { get; set; }
    }
}
