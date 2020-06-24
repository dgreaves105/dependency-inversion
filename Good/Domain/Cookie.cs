using Domain.Toppings;
using System.Collections.Generic;

namespace Domain
{
    public class Cookie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<ITopping> Toppings { get; set; } = new List<ITopping>();
    }
}
