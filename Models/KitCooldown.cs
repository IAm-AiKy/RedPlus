using System;

namespace RedPlus.Models
{
    public class KitCooldown
    {
        public string PlayerId { get; set; }
        public string KitName { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
