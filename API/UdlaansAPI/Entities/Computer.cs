using System;
using System.Collections.Generic;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class Computer
    {
        public Computer()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string ComputerId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int StatusId { get; set; }

        public virtual ComputerStatus Status { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
