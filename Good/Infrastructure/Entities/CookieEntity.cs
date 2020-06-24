using Domain;
using Domain.Toppings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                Toppings = entity.Toppings.Select(t => MapToTopping(t))
            };
        }

        private static ITopping MapToTopping(string toppingName)
        {
            switch (toppingName)
            {
                case "ChocolateChip":
                    return new ChocolateChip();
                default:
                    throw new Exception();
            }
        }

        public static explicit operator CookieEntity(Cookie cookie)
        {
            return new CookieEntity
            {
                Id = cookie.Id,
                Name = cookie.Name,
                Price = cookie.Price,
                Toppings = cookie.Toppings.Select(t => MapToppingToString(t))
            };
        }

        private static string MapToppingToString(ITopping topping)
        {
            return topping.GetType().Name;
        }
    }
}
