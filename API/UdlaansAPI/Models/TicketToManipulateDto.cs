using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class TicketToManipulateDto
    {
        public virtual int StudentId { get; set; }
        public virtual int ComputerId { get; set; }
        public virtual int MouseId { get; set; }
        public virtual int KeyboardId { get; set; }
        public virtual DateTime BorrowDate { get; set; }
        public virtual DateTime ExpirationDate { get; set; }
        public virtual byte Returned { get; set; }
    }
}
