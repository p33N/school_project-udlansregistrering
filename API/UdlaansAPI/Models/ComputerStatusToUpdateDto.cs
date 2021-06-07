using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class ComputerStatusToUpdateDto : ComputerStatusToManipulateDto
    {
        public override string Status { get => base.Status; set => base.Status = value; }
    }
}
