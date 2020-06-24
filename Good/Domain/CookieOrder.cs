using System.Collections.Generic;
using System.ComponentModel;

namespace Domain
{
    public class CookieOrder
    {
        public int Id { get; set; }
        public IEnumerable<Cookie> Cookies { get; set; } = new List<Cookie>();
    }
}
