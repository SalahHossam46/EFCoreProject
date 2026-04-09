using Microsoft.EntityFrameworkCore;
using MyProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace EFCoreProject.Services
{
    public class DepartmentService
    {
        private readonly MyDbContext _context;

        public DepartmentService(MyDbContext context)
        {
            _context = context;
        }

        public List<Department> GetAllDepartments()
        {
            return _context.Departments.ToList();
        }

        public Department? GetDepartmentById(int id)
        {
            return _context.Departments.Find(id);
        }

        public Department? GetDepartmentByInstructorId(int instructorId)
        {
            var instructor = _context.Instructors
                .Include(i => i.Department)
                .FirstOrDefault(i => i.Id == instructorId);

            return instructor?.Department;
        }

        public bool AddDepartment(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
            return true;
        }

        public bool UpdateDepartment(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
            return true;
        }

        public bool DeleteDepartment(int departmentId)
        {
            var department = _context.Departments.Find(departmentId);
            if (department == null) return false;
            _context.Departments.Remove(department);
            _context.SaveChanges();
            return true;
        }
    }
}