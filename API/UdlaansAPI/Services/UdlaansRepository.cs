using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdlaansAPI.Entities;

namespace UdlaansAPI.Services
{
    public class UdlaansRepository : IUdlaansRepository, IDisposable
    {
        private readonly udlaansregistreringContext _context;
        public UdlaansRepository(udlaansregistreringContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void AddComputer(Computer computer)
        {
            var computerFromRepo = _context.Computers.SingleOrDefault(c => c.ComputerId == computer.ComputerId);
            if(computerFromRepo == null)
            {
                _context.Computers.Add(computer);
            } else
            {
                throw new ArgumentNullException(nameof(computer));
            }
        }

        public void AddStudent(Student student)
        {
            var studentFromRepo = _context.Students.SingleOrDefault(s => s.StudentId == student.StudentId);
            if (studentFromRepo == null)
            {
                _context.Students.Add(student);
            }
            else
            {
                throw new ArgumentNullException(nameof(student));
            }
        }

        public void AddTicket(Ticket ticket)
        {
            var ticketFromRepo = _context.Tickets.SingleOrDefault(t => t.TicketId == ticket.TicketId);
            if (ticketFromRepo == null)
            {
                _context.Tickets.Add(ticket);
            }
            else
            {
                throw new ArgumentNullException(nameof(ticket));
            }
        }       

        public Computer GetComputer(string ComputerId)
        {
            return _context.Computers.FirstOrDefault(c => c.ComputerId == ComputerId);
        }

        public IEnumerable<Computer> GetComputers()
        {
            return _context.Computers.ToList<Computer>();
        }

        public Student GetStudent(string StudentId)
        {
            return _context.Students.FirstOrDefault(s => s.StudentId == StudentId);
        }

        public IEnumerable<Student> GetStudents()
        {
            return _context.Students.ToList<Student>();
        }

        public Ticket GetTicketByComputerId(string ComputerId)
        {
            return _context.Tickets.FirstOrDefault(t => t.ComputerId == ComputerId);
        }

        public Ticket GetTicketByStudentId(string StudentId)
        {
            return _context.Tickets.FirstOrDefault(t => t.StudentId == StudentId);
        }

        public Ticket GetTicketByTicketId(int TicketId)
        {
            return _context.Tickets.FirstOrDefault(t => t.TicketId == TicketId);
        }

        public IEnumerable<Ticket> GetTickets()
        {
            return _context.Tickets.ToList<Ticket>();
        }

        public void RemoveComputer(Computer computer)
        {
            _context.Computers.Remove(computer);
        }

        public void RemoveStudent(Student student)
        {
            _context.Students.Remove(student);
        }

        public void RemoveTicket(Ticket ticket)
        {
            _context.Tickets.Remove(ticket);
        }

        public void UpdateComputer(Computer computer)
        {
            // Leave empty
        }

        public void UpdateStudent(Student student)
        {
            // Leave empty
        }

        public void UpdateTicket(Ticket ticket)
        {
            // Leave empty
        }
        
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // dispose resources when needed
            }
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IEnumerable<ComputerStatus> GetComputerStatuses()
        {
            return _context.ComputerStatuses.ToList<ComputerStatus>();
        }

        public IEnumerable<Keyboard> GetKeyboards()
        {
            return _context.Keyboards.ToList<Keyboard>();
        }

        public IEnumerable<Mouse> GetMice()
        {
            return _context.Mice.ToList<Mouse>();
        }

        public ComputerStatus GetComputerStatus(int computerStatusId)
        {
            return _context.ComputerStatuses.FirstOrDefault(s => s.StatusId == computerStatusId);
        }

        public Keyboard GetKeyboard(int keyboardId)
        {
            return _context.Keyboards.FirstOrDefault(s => s.KeyboardId == keyboardId);
        }

        public Mouse GetMouse(int mouseId)
        {
            return _context.Mice.FirstOrDefault(s => s.MouseId == mouseId);
        }

        public void AddComputerStatus(ComputerStatus computerStatus)
        {
            var computerStatusFromRepo = _context.ComputerStatuses.SingleOrDefault(c => c.StatusId == computerStatus.StatusId);
            if (computerStatusFromRepo == null)
            {
                _context.ComputerStatuses.Add(computerStatus);
            }
            else
            {
                throw new ArgumentNullException(nameof(computerStatus));
            }
        }

        public void AddKeyboard(Keyboard keyboard)
        {
            var keyboardFromRepo = _context.Keyboards.SingleOrDefault(k => k.KeyboardId == keyboard.KeyboardId);
            if (keyboardFromRepo == null)
            {
                _context.Keyboards.Add(keyboard);
            }
            else
            {
                throw new ArgumentNullException(nameof(keyboard));
            }
        }

        public void AddMouse(Mouse mouse)
        {
            var mouseFromRepo = _context.Mice.SingleOrDefault(m => m.MouseId == mouse.MouseId);
            if (mouseFromRepo == null)
            {
                _context.Mice.Add(mouse);
            }
            else
            {
                throw new ArgumentNullException(nameof(mouse));
            }
        }

        public void RemoveComputerStatus(ComputerStatus computerStatus)
        {
            _context.ComputerStatuses.Remove(computerStatus);
        }

        public void RemoveKeyboard(Keyboard keyboard)
        {
            _context.Keyboards.Remove(keyboard);
        }

        public void RemoveMouse(Mouse mouse)
        {
            _context.Mice.Remove(mouse);
        }

        public void UpdateComputerStatus(ComputerStatus computerStatus)
        {
            // Leave empty
        }

        public void UpdateKeyboard(Keyboard keyboard)
        {
            // Leave empty
        }

        public void UpdateMouse(Mouse mouse)
        {
            // Leave empty
        }
    }
}
