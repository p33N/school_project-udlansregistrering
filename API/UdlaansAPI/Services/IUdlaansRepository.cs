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
        IEnumerable<Student> GetStudents();
        IEnumerable<Ticket> GetTickets();
        // Get specific of type
        Computer GetComputer(string ComputerId);
        Student GetStudent(string StudentId);
        Ticket GetTicketByTicketId(int TicketId);
        Ticket GetTicketByComputerId(string ComputerId);
        Ticket GetTicketByStudentId(string StudentId);
        // Add new of type
        void AddComputer(Computer computer);
        void AddStudent(Student student);
        void AddTicket(Ticket ticket);
        // Delete
        void RemoveComputer(Computer computer);
        void RemoveStudent(Student student);
        void RemoveTicket(Ticket ticket);
        // Update Computer
        void UpdateComputer(Computer computer);
        void UpdateStudent(Student student);
        void UpdateTicket(Ticket ticket);
        // General
        bool Save();
    }
}
