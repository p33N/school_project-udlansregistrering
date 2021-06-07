using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdlaansAPI.Entities;

namespace UdlaansAPI.Services
{
    public interface IUdlaansRepository
    {
        // Get all of type
        IEnumerable<Computer> GetComputers();
        IEnumerable<ComputerStatus> GetComputerStatuses();
        IEnumerable<Keyboard> GetKeyboards();
        IEnumerable<Mouse> GetMice();
        IEnumerable<Student> GetStudents();
        IEnumerable<Ticket> GetTickets();

        // Get specific of type
        Computer GetComputer(string computerId);
        ComputerStatus GetComputerStatus(int computerStatusId);
        Keyboard GetKeyboard(int keyboardId);
        Mouse GetMouse(int mouseId);
        Student GetStudent(string studentId);
        Ticket GetTicketByTicketId(int ticketId);
        Ticket GetTicketByComputerId(string computerId);
        Ticket GetTicketByStudentId(string studentId);
        // Add new of type
        void AddComputer(Computer computer);
        void AddComputerStatus(ComputerStatus computerStatus);
        void AddKeyboard(Keyboard keyboard);
        void AddMouse(Mouse mouse);
        void AddStudent(Student student);
        void AddTicket(Ticket ticket);
        // Delete
        void RemoveComputer(Computer computer);
        void RemoveComputerStatus(ComputerStatus computerStatus);
        void RemoveKeyboard(Keyboard keyboard);
        void RemoveMouse(Mouse mouse);
        void RemoveStudent(Student student);
        void RemoveTicket(Ticket ticket);
        // Update Computer
        void UpdateComputer(Computer computer);
        void UpdateComputerStatus(ComputerStatus computerStatus);
        void UpdateKeyboard(Keyboard keyboard);
        void UpdateMouse(Mouse mouse);
        void UpdateStudent(Student student);
        void UpdateTicket(Ticket ticket);
        // General
        bool Save();
    }
}
