using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        //Relations

        /*
        Instructor (I) Department (D)
        1. mange  I (one, m) D (one, m)
        2. contain  I (many, o) D (one, m)
         */
        //1)manage
        public Department ManagedDepartmentNavigation { get; set; } // department he manages
        //2)contain
        public Department Department { get; set; } 
        public int? DepartmentId { get; set; }  
        
        /*
           Instructor (I) Course (C) 
           I (one, m) C (many , o)
         */
        public Course Course { get; set; }
        public ICollection<Course> Courses { get; set; }
        = new HashSet<Course>();

        /*
            Instructor (I) CourseSection (CS)
            I (one, m) CS (many, o)
         */
        public ICollection<CourseSession> CourseSessions { get; set; }
        = new HashSet<CourseSession>();


    }
}
