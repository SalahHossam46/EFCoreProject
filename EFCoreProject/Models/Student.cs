using System;
using System.Collections.Generic;
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
    }
}


