namespace Rebar.Models
{
    public class Order
    {
        public List<Shake> OrderedShakes { get; set; }
        public decimal ShakesTotalPrice { get; set; }
        public Guid OrderId { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        

        public Order()
        {
            OrderedShakes = new List<Shake>();
            // הנחות ומבצעים
        }
    }
}
