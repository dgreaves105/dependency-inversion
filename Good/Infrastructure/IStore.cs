using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public interface IStore<T>
    {
        Task<T> Get(int identifier);
        Task<IEnumerable<T>> GetAll();
        Task<int> Create(T entity);
    }
}
