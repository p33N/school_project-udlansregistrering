using System;
using System.Collections.Generic;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class Keyboard
    {
        public Keyboard()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int KeyboardId { get; set; }
        public string KeyboardType { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
