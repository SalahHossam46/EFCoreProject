using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Course
    {
        public int Id { get; set; }   
        public int Duration { get; set; }
        public string Name { get; set; }


        //Relation
        /*
         Course (C) instructor (I)
         C (many , o) I (one, m)
         */
        public Instructor? Instructor { get; set; }
        public int InstructorId { get; set; }

        /*
           Course (C) Department (D)
           C (many, o) D (one, m)
         */
        public Department? Department { get; set; }
        public int? DepartmentId { get; set; }
        /*
         Ccourse (C) CourseSection (CS)
         C (one, m) CS (many, o)
         */
        //public CourseSession CourseSession { get; set; }
        public ICollection<CourseSession>? CourseSessions { get; set; }
        = new HashSet<CourseSession>();

        /*
         Course (C) StudentCourse(SC)
         S(one , m) SC(many , o)
         */
        public ICollection<StudentCourse> StudentCourses { get; set; }
        = new HashSet<StudentCourse>();
    }
}
