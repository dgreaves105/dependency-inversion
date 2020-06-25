using Domain;
using System.Collections.Generic;

namespace Infrastructure.Entities
{
    public class CookieEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Toppings { get; set; }

        public static explicit operator Cookie(CookieEntity entity)
        {
            return new Cookie
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Toppings = entity.Toppings
            };
        }

        public static explicit operator CookieEntity(Cookie cookie)
        {
            return new CookieEntity
            {
                Id = cookie.Id,
                Name = cookie.Name,
                Price = cookie.Price,
                Toppings = cookie.Toppings
            };
        }
    }
}
