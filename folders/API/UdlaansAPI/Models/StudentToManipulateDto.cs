using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class StudentToManipulateDto
    {
        public virtual string StudentNumber { get; set; }
        public virtual string StudentName { get; set; }
        public virtual string Address { get; set; }
        public virtual string ZipCity { get; set; }
        public virtual string SocialSecurity { get; set; }
        public virtual string Email { get; set; }
        public virtual string Class { get; set; }
    }
}
