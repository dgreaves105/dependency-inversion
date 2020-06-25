using System.Collections.Generic;

namespace Domain
{
    public class CookieOrder
    {
        public int Id { get; set; }
        public IEnumerable<Cookie> Cookies { get; set; } = new List<Cookie>();
    }
}
