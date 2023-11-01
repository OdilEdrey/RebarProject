using Rebar.Models;

namespace Rebar.Services
{
    public interface IOrderService
    {
        public void AddOrder(string clientName, List<UserOrderShake> userOrderShakes, DateTime startOrder);


    }
}
