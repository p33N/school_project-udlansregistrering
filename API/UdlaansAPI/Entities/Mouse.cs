using System;
using System.Collections.Generic;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class Mouse
    {
        public Mouse()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int MouseId { get; set; }
        public string MouseType { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
