using EFCoreProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{ 
    public class MyDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=.;Database=EFCoreProject;Trusted_Connection=True;TrustServerCertificate=True;");

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ===========================
            // 0) Turn off Identity for all PKs
            // ===========================
            // This allows manual insertion of IDs without EF auto-generating them
            modelBuilder.Entity<Student>().Property(s => s.Id).ValueGeneratedNever();
            modelBuilder.Entity<Instructor>().Property(i => i.Id).ValueGeneratedNever();
            modelBuilder.Entity<Department>().Property(d => d.Id).ValueGeneratedNever();
            modelBuilder.Entity<Course>().Property(c => c.Id).ValueGeneratedNever();
            modelBuilder.Entity<CourseSession>().Property(cs => cs.Id).ValueGeneratedNever();
            modelBuilder.Entity<CourseSessionAttendance>().Property(csa => csa.Id).ValueGeneratedNever();

            // ===========================
            // 1) Department ↔ Instructor (Manage: 1:1)
            // Department has ONE Manager (Instructor)
            // Instructor can manage ONE Department
            // FK is in Department (ManagerId)
            // ===========================
            modelBuilder.Entity<Department>()
                .HasOne(d => d.Instructor)                       // Department has ONE Manager
                .WithOne(i => i.ManagedDepartmentNavigation)     // Instructor manages ONE Department
                .HasForeignKey<Department>(d => d.ManagerId)     // FK is in Department
                .OnDelete(DeleteBehavior.Restrict);              // prevent cascade delete

            // ===========================
            // 2) Department ↔ Instructor (Contain: 1:m)
            // Instructor belongs to ONE Department
            // Department has MANY Instructors
            // FK is in Instructor (DepartmentId)
            // ===========================
            modelBuilder.Entity<Instructor>()
                .HasOne(i => i.Department)                       // Instructor belongs to ONE Department
                .WithMany(d => d.Instructors)                    // Department has MANY Instructors
                .HasForeignKey(i => i.DepartmentId)             // FK in Instructor
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 3) Instructor (1) → (∞) Course
            // ===========================
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Instructor)                       // Course has ONE Instructor
                .WithMany(i => i.Courses)                        // Instructor has MANY Courses
                .HasForeignKey(c => c.InstructorId)             // FK in Course
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 4) Department (1) → (∞) Course
            // ===========================
            modelBuilder.Entity<Course>()
                .HasOne(c => c.Department)                       // Course belongs to ONE Department
                .WithMany(d => d.Courses)                        // Department has MANY Courses
                .HasForeignKey(c => c.DepartmentId)             // FK in Course
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 5) Course (1) → (∞) CourseSession
            // ===========================
            modelBuilder.Entity<CourseSession>()
                .HasOne(cs => cs.Course)                         // CourseSession belongs to ONE Course
                .WithMany(c => c.CourseSessions)                // Course has MANY Sessions
                .HasForeignKey(cs => cs.CourseId)               // FK in CourseSession
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 6) Instructor (1) → (∞) CourseSession
            // ===========================
            modelBuilder.Entity<CourseSession>()
                .HasOne(cs => cs.Instructor)                     // CourseSession has ONE Instructor
                .WithMany(i => i.CourseSessions)                // Instructor has MANY Sessions
                .HasForeignKey(cs => cs.InstructorId)           // FK in CourseSession
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 7) Student (1) → (∞) StudentCourse
            // ===========================
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Student)                        // StudentCourse belongs to ONE Student
                .WithMany(s => s.StudentCourses)                // Student has MANY StudentCourses
                .HasForeignKey(sc => sc.StudentId)             // FK in StudentCourse
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 8) Course (1) → (∞) StudentCourse
            // ===========================
            modelBuilder.Entity<StudentCourse>()
                .HasOne(sc => sc.Course)                         // StudentCourse belongs to ONE Course
                .WithMany(c => c.StudentCourses)               // Course has MANY StudentCourses
                .HasForeignKey(sc => sc.CourseId)             // FK in StudentCourse
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 9) Composite PK for StudentCourse (StudentId + CourseId)
            // ===========================
            modelBuilder.Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId }); // no identity, easier insert

            // ===========================
            // 10) Student (1) → (∞) CourseSessionAttendance
            // ===========================
            modelBuilder.Entity<CourseSessionAttendance>()
                .HasOne(csa => csa.Student)                     // Attendance belongs to ONE Student
                .WithMany(s => s.CourseSessionAttendances)     // Student has MANY Attendances
                .HasForeignKey(csa => csa.StudentId)
                .OnDelete(DeleteBehavior.Restrict);

            // ===========================
            // 11) CourseSession (1) → (∞) CourseSessionAttendance
            // ===========================
            modelBuilder.Entity<CourseSessionAttendance>()
                .HasOne(csa => csa.CourseSession)               // Attendance belongs to ONE Session
                .WithMany(cs => cs.CourseSessionAttendances)   // Session has MANY Attendances
                .HasForeignKey(csa => csa.CourseSessionId)
                .OnDelete(DeleteBehavior.Restrict);

            // Email in Student and User

            modelBuilder.Entity<Student>()
            .HasIndex(s => s.Email)
            .IsUnique();

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();


        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<CourseSession> CourseSessions { get; set; }
        public DbSet<CourseSessionAttendance> CourseSessionAttendances { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
