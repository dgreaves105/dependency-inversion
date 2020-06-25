using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface IOrderRepository
    {
        Task<OrderEntity> Get(int orderId);
        Task<IEnumerable<OrderEntity>> GetAll();
        Task<int> Create(OrderEntity entity);
    }
}
