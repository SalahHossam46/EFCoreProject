using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        // I will use email property to link between student and user 
        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        // Relationship

        /*
         Student (S) CourseSessionAttendance (CSA)
         S (one, m) CSA (many, o)
         */
        public ICollection<CourseSessionAttendance> CourseSessionAttendances { get; set; }
        = new HashSet<CourseSessionAttendance>();

        /*
         Student (S) StudentCourse(SC)
         S(one , m) SC(many , o)
         */
        public ICollection<StudentCourse> StudentCourses { get; set; }
        = new HashSet<StudentCourse>();


    //    ///Helper methods
    //    public IEnumerable<Course> Courses
    //=> StudentCourses.Select(sc => sc.Course);

    //    public IEnumerable<Instructor> Instructors
    //        => StudentCourses
    //            .Where(sc => sc.Course != null)
    //            .Select(sc => sc.Course.Instructor)
    //            .Distinct();

    }
}


