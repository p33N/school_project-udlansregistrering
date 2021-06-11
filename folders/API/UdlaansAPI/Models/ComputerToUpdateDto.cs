using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class ComputerToUpdateDto : ComputerToManipulateDto
    {
        public override string ComputerId { get => base.ComputerId; set => base.ComputerId = value; }
        public override string Brand { get => base.Brand; set => base.Brand = value; }
        public override string Model { get => base.Model; set => base.Model = value; }
        public override int StatusId { get => base.StatusId; set => base.StatusId = value; }
    }
}