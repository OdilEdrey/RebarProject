namespace Rebar.Models
{
    public class Account
    {
        public List<Order> Orders { get; set; }
        public decimal TotalOrderAmount { get; set; }

        public Account()
        {
            Orders = new List<Order>();
        }

        public void CreateOrder(Order order)
        {
            Orders.Add(order);
        }
    }
}
