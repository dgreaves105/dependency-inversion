using Application.Abstractions;
using Domain;
using Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class CookieRepository : IRepository<Cookie>
    {
        private readonly IStore<CookieEntity> _cookieStore;

        public CookieRepository(IStore<CookieEntity> cookieStore)
        {
            _cookieStore = cookieStore ?? throw new ArgumentNullException(nameof(cookieStore));
        }

        public async Task<int> Create(Cookie entity)
        {
            var cookieEntity = (CookieEntity)entity;
            return await _cookieStore.Create(cookieEntity);
        }

        public async Task<Cookie> Get(int identifier)
        {
            var entity = await _cookieStore.Get(identifier);
            return (Cookie)entity;
        }

        public async Task<IEnumerable<Cookie>> GetAll()
        {
            var entities = await _cookieStore.GetAll();
            return entities.Select(c => (Cookie)c);
        }
    }
}
