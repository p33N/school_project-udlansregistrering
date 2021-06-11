using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class KeyboardToUpdateDto : KeyboardToManipulateDto
    {
        public override string KeyboardType { get => base.KeyboardType; set => base.KeyboardType = value; }
    }
}
