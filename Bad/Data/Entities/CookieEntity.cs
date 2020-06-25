using System.Collections.Generic;

namespace Data.Entities
{
    public class CookieEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Toppings { get; set; }
    }
}
