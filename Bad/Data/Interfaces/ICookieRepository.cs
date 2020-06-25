using Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Interfaces
{
    public interface ICookieRepository
    {
        Task<CookieEntity> Get(int cookieId);
        Task<IEnumerable<CookieEntity>> GetAll();
        Task<int> Create(CookieEntity entity);
    }
}
