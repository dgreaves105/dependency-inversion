using Application.Abstractions;
using Domain;
using Infrastructure.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrderRepository : IRepository<CookieOrder>
    {
        private readonly IStore<OrderEntity> _orderStore;
        private readonly IRepository<Cookie> _cookieRepository;

        public OrderRepository(IStore<OrderEntity> orderStore, IRepository<Cookie> cookieRepository)
        {
            _orderStore = orderStore;
            _cookieRepository = cookieRepository;
        }

        public async Task<int> Create(CookieOrder entity)
        {
            var orderEntity = BuildOrderEnitity(entity);
            return await _orderStore.Create(orderEntity);
        }

        public async Task<CookieOrder> Get(int identifier)
        {
            var entity = await _orderStore.Get(identifier);
            return await BuildCookieOrder(entity);
        }

        public async Task<IEnumerable<CookieOrder>> GetAll()
        {
            var entities = await _orderStore.GetAll();
            
            var tasks = await Task.WhenAll(entities.Select(o => BuildCookieOrder(o)));
            var orders = tasks.Where(result => result != null).ToList();

            return orders;
        }

        private OrderEntity BuildOrderEnitity(CookieOrder order)
        {
            return new OrderEntity
            {
                CookieIds = order.Cookies.Select(c => c.Id)
            };
        }

        private async Task<CookieOrder> BuildCookieOrder(OrderEntity order)
        {
            var tasks = await Task.WhenAll(order.CookieIds.Select(c => _cookieRepository.Get(c)));
            var cookies = tasks.Where(result => result != null).ToList();

            return new CookieOrder
            {
                Id = order.Id,
                Cookies = cookies
            };
        }
    }
}
