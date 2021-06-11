using System;
using System.Collections.Generic;

#nullable disable

namespace UdlaansAPI.Entities
{
    public partial class Ticket
    {
        public int TicketId { get; set; }
        public int StudentId { get; set; }
        public int ComputerId { get; set; }
        public int MouseId { get; set; }
        public int KeyboardId { get; set; }
        public DateTime BorrowDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public byte Returned { get; set; }

        public virtual Computer Computer { get; set; }
        public virtual Keyboard Keyboard { get; set; }
        public virtual Mouse Mouse { get; set; }
        public virtual Student Student { get; set; }
    }
}
