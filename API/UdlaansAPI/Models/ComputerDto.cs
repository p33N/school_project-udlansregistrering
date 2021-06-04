using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class ComputerDto
    {
        public string ComputerId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int StatusId { get; set; }
    }
}
