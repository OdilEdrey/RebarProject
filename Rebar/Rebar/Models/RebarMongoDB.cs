namespace Rebar.Models
{
    public class RebarMongoDB
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string OrdersCollectionName { get; set; } = string.Empty;
        public string AccountsCollectionName { get; set; } = string.Empty;
        public string ShakesCollectionName { get; set; } = string.Empty;
    }
}
