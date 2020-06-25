using Domain;
using Infrastructure.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class OrderStore : IStore<OrderEntity>
    {
        private readonly List<OrderEntity> _orderList;

        public OrderStore()
        {
            _orderList = new List<OrderEntity>();
        }

        public Task<int> Create(OrderEntity entity)
        {
            entity.Id = _orderList.Count + 1;
            _orderList.Add(entity);

            return Task.FromResult(entity.Id);
        }

        public Task<OrderEntity> Get(int identifier)
        {
            var order = _orderList.Find(o => o.Id == identifier);
            return Task.FromResult(order);
        }

        public Task<IEnumerable<OrderEntity>> GetAll()
        {
            return Task.FromResult<IEnumerable<OrderEntity>>(_orderList);
        }
    }
}
