using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CookieStore : IStore<CookieEntity>
    {
        private readonly List<CookieEntity> _cookieList;

        public CookieStore()
        {
            _cookieList = new List<CookieEntity>
            {
                new CookieEntity
                {
                    Id = 1,
                    Name = "Chocolate Special",
                    Price = 2.5m,
                    Toppings = new List<string>
                    {
                        "ChocolateChip"
                    }
                }
            };
        }

        public Task<int> Create(CookieEntity entity)
        {
            entity.Id = _cookieList.Count + 1;
            _cookieList.Add(entity);

            return Task.FromResult(entity.Id);
        }

        public Task<CookieEntity> Get(int identifier)
        {
            var cookie = _cookieList.Find(c => c.Id == identifier);
            return Task.FromResult(cookie);
        }

        public Task<IEnumerable<CookieEntity>> GetAll()
        {
            return Task.FromResult<IEnumerable<CookieEntity>>(_cookieList);
        }
    }
}
