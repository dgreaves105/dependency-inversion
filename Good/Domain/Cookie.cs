using System.Collections.Generic;

namespace Domain
{
    public class Cookie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<string> Toppings { get; set; } = new List<string>();
    }
}
