using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Rebar.Models;

namespace Rebar.Services
{
    public class OrderService : IOrderService
    {
        private readonly IMongoCollection<Order> _orders;
        private readonly IMongoCollection<Account> _accounts;
        private IShakeService _shakeService;
        public OrderService(IOptions<RebarMongoDB> options, IShakeService shakeService)
        {
            var mongoClient = new MongoClient(options.Value.ConnectionString);
            _orders = mongoClient.GetDatabase(options.Value.DatabaseName).
                GetCollection<Order>(options.Value.OrdersCollectionName);
            _accounts = mongoClient.GetDatabase(options.Value.DatabaseName).
                GetCollection<Account>(options.Value.AccountsCollectionName);

            _shakeService = shakeService;
        }
        public void AddOrder(string clientName, List<UserOrderShake> userOrderShakes, DateTime startOrder)
        {

            Order order = new Order();
            order.OrderCreated = startOrder;
            order.CustomerName = clientName;
            foreach (var userOrder in userOrderShakes)
            {
                OrderedShakes orderShake = _shakeService.GetShake(userOrder.name, userOrder.id, userOrder.size);
                order.OrderedShakes.Add(orderShake);
                order.ShakesTotalPrice += orderShake.price;
            }

            order.OrderEnded = DateTime.Now;

            order.OrderDate = order.OrderEnded.Date - order.OrderCreated.Date;

            _orders.InsertOne(order);

            Account account = GetAccount(clientName);

            if (account != null)
            {
                account.Orders.Add(order);
                account.TotalOrderAmount++; 
                var filter = Builders<Account>.Filter.Eq(a => a.Name, clientName);
                var update = Builders<Account>.Update
                    .Push(a => a.Orders, order)
                    .Inc(a => a.TotalOrderAmount, 1); 

                _accounts.UpdateOne(filter, update);
            }
            else
            {
                account = new Account();
                account.Name = clientName;
                account.Orders.Add(order);
                account.TotalOrderAmount = 1; 
                _accounts.InsertOne(account);
            }

        }

        private Account GetAccount(string clientName)
        {
            return _accounts.Find(a => a.Name == clientName).FirstOrDefault();

        }

    }
}
