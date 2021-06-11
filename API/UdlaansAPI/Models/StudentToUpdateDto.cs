using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class StudentToUpdateDto : StudentToManipulateDto
    {
        public override string StudentNumber { get => base.StudentNumber; set => base.StudentNumber = value; }
        public override string StudentName { get => base.StudentName; set => base.StudentName = value; }
        public override string Address { get => base.Address; set => base.Address = value; }
        public override string ZipCity { get => base.ZipCity; set => base.ZipCity = value; }
        public override string SocialSecurity { get => base.SocialSecurity; set => base.SocialSecurity = value; }
        public override string Email { get => base.Email; set => base.Email = value; }
        public override string Class { get => base.Class; set => base.Class = value; }
    }
}
