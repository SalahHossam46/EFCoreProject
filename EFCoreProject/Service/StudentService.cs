using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Services
{
    public class StudentService
    {
        private readonly MyDbContext _context;

        public StudentService(MyDbContext context)
        {
            _context = context;
        }

        // ============ METHOD 1: Find student when role = "Student" ============
        public Student? GetStudentByEmail(string email)
        {
            return _context.Students
                .FirstOrDefault(s => s.Email == email);
        }

        // ============ METHOD 2: Get courses for a specific student ============
        public List<Course> GetRegisteredCourses(int studentId)
        {
            return _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Include(sc => sc.Course)
                .Select(sc => sc.Course!)
                .ToList();
        }

        // ============ METHOD 3: Get instructors for a specific student ============
        public List<Instructor> GetMyInstructors(int studentId)
        {
            // Step 1: Get all course IDs that the student is enrolled in
            var courseIds = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId)
                .ToList();

            // Step 2: Find all instructors who teach those courses
            return _context.Instructors
                .Where(i => i.Courses.Any(c => courseIds.Contains(c.Id)))
                .Include(i => i.Courses)  // Include courses if you need course details
                .Distinct()
                .ToList();
        }

        // ============ METHOD 4: Get departments for a specific student ============
        public List<Department> GetMyDepartments(int studentId)
        {
            // Step 1: Get all course IDs that the student is enrolled in
            var courseIds = _context.StudentCourses
                .Where(sc => sc.StudentId == studentId)
                .Select(sc => sc.CourseId)
                .ToList();

            // Step 2: Find all departments that offer those courses
            return _context.Courses
                .Where(c => courseIds.Contains(c.Id) && c.DepartmentId != null)
                .Select(c => c.Department!)
                .Distinct()
                .ToList();
        }

        // ============ METHOD 5: Find instructor when role = "Instructor" ============
        public Instructor? GetInstructorByEmail(string email)
        {
            return _context.Instructors
                .FirstOrDefault(i => i.Email == email);
        }

        // ============ METHOD 6: Get courses for an instructor ============
        public List<Course> GetCoursesByInstructorId(int instructorId)
        {
            return _context.Courses
                .Where(c => c.InstructorId == instructorId)
                .ToList();
        }

        // ============ EXTRA HELPER METHODS YOU MIGHT NEED ============

        // Get student by ID
        public Student? GetStudentById(int id)
        {
            return _context.Students.Find(id);
        }

        // Get all students (for Admin)
        public List<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        // Get students enrolled in specific courses (for Instructor)
        public List<Student> GetStudentsByCourseIds(List<int> courseIds)
        {
            return _context.StudentCourses
                .Where(sc => courseIds.Contains(sc.CourseId ?? 0))
                .Include(sc => sc.Student)
                .Select(sc => sc.Student!)
                .Distinct()
                .ToList();
        }

        // Update student phone (Student only)
        public bool UpdateStudentPhone(int studentId, string newPhone)
        {
            var student = _context.Students.Find(studentId);
            if (student == null) return false;
            student.Phone = newPhone;
            _context.SaveChanges();
            return true;
        }

        // Update full student (Admin only)
        public bool UpdateStudent(Student student)
        {
            _context.Students.Update(student);
            _context.SaveChanges();
            return true;
        }

        // Delete student (Admin only)
        public bool DeleteStudent(int studentId)
        {
            var student = _context.Students.Find(studentId);
            if (student == null) return false;
            _context.Students.Remove(student);
            _context.SaveChanges();
            return true;
        }

        // Add new student (Admin only)
        public bool AddStudent(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return true;
        }
    }
}