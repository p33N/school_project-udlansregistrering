using System;
using System.Collections.Generic;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class Student
    {
        public Student()
        {
            Tickets = new HashSet<Ticket>();
        }

        public string StudentId { get; set; }
        public string StudentName { get; set; }
        public string Address { get; set; }
        public string ZipCity { get; set; }
        public string SocialSecurity { get; set; }
        public string Email { get; set; }
        public string Class { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
