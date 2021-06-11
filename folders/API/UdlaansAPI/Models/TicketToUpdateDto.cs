using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdlaansAPI.Models
{
    public class TicketToUpdateDto : TicketToManipulateDto
    {
        public override string StudentId { get => base.StudentId; set => base.StudentId = value; }
        public override string ComputerId { get => base.ComputerId; set => base.ComputerId = value; }
        public override int MouseId { get => base.MouseId; set => base.MouseId = value; }
        public override int KeyboardId { get => base.KeyboardId; set => base.KeyboardId = value; }
        public override DateTime BorrowDate { get => base.BorrowDate; set => base.BorrowDate = value; }
        public override DateTime ExpirationDate { get => base.ExpirationDate; set => base.ExpirationDate = value; }
        public override byte Returned { get => base.Returned; set => base.Returned = value; }
    }
}
