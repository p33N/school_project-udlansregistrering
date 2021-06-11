using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public string StudentId { get; set; }
        public string ComputerId { get; set; }
        public int MouseId { get; set; }
        public int KeyboardId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte Returned { get; set; }
    }
}
