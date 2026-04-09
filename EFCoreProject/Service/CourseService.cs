using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Services
{
    public class CourseService
    {
        private readonly MyDbContext _context;

        public CourseService(MyDbContext context)
        {
            _context = context;
        }

        public List<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course? GetCourseById(int id)
        {
            return _context.Courses.Find(id);
        }

        public List<Course> GetCoursesByInstructorId(int instructorId)
        {
            return _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToList();
        }

        public bool AddCourse(Course course)
        {
            _context.Courses.Add(course);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateCourse(Course course)
        {
            _context.Courses.Update(course);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteCourse(int courseId)
        {
            var course = _context.Courses.Find(courseId);
            if (course == null) return false;
            _context.Courses.Remove(course);
            _context.SaveChanges();
            return true;
        }
    }
}