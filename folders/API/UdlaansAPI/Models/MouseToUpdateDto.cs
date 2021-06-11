using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class MouseToUpdateDto : MouseToManipulateDto
    {
        public override string MouseType { get => base.MouseType; set => base.MouseType = value; }
    }
}
