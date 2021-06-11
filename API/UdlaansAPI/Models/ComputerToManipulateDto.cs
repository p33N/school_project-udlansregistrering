using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class ComputerToManipulateDto
    {
        public virtual string ComputerName { get; set; }
        public virtual string Brand { get; set; }
        public virtual string Model { get; set; }
        public virtual int StatusId { get; set; }
    }
}
