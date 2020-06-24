using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.Abstractions
{
    public interface IRepository<T>
    {
        Task<T> Get(int identifier);
        Task<IEnumerable<T>> GetAll();
        Task<int> Create(T entity);
    }
}
