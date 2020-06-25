using System.Collections.Generic;

namespace Data.Entities
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public IEnumerable<int> CookieIds { get; set; } = new List<int>();
    }
}
