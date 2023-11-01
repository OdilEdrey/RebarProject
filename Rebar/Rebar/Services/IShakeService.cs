using Rebar.Models;

namespace Rebar.Services
{
    public interface IShakeService
    {
        public List<Shake> GetAllShakes();
        public OrderedShakes GetShake(string name, string id, string size);
        public void AddShake(string name, string description, double priceLarge, double priceMedium, double priceSmall);


    }
}
