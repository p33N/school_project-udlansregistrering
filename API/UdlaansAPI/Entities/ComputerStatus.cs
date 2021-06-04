using System;
using System.Collections.Generic;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class ComputerStatus
    {
        public ComputerStatus()
        {
            Computers = new HashSet<Computer>();
        }

        public int StatusId { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Computer> Computers { get; set; }
    }
}
