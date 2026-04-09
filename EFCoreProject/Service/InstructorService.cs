using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Services
{
    public class InstructorService
    {
        private readonly MyDbContext _context;

        public InstructorService(MyDbContext context)
        {
            _context = context;
        }

        public List<Instructor> GetAllInstructors()
        {
            return _context.Instructors.ToList();
        }

        public Instructor? GetInstructorById(int id)
        {
            return _context.Instructors.Find(id);
        }

        public Instructor? GetInstructorByEmail(string email)
        {
            return _context.Instructors.FirstOrDefault(i => i.Email == email);
        }

        public bool AddInstructor(Instructor instructor)
        {
            _context.Instructors.Add(instructor);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateInstructor(Instructor instructor)
        {
            _context.Instructors.Update(instructor);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteInstructor(int instructorId)
        {
            var instructor = _context.Instructors.Find(instructorId);
            if (instructor == null) return false;
            _context.Instructors.Remove(instructor);
            _context.SaveChanges();
            return true;
        }
    }
}