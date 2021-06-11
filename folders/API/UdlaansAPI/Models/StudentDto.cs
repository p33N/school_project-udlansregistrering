using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class StudentDto
    {
        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string ZipCity { get; set; }
        public string SocialSecurity { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }
    }
}
