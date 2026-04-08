using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Department
    {
        public int Id { get; set; }   

        public string Name { get; set; }
        public string Location { get; set; }

        //Relations
        /*
        Department (D) and Instructor (I)
        1-manage D(one, m) I(one,m)
        2-contain D(one,m) I(many , o)
         */

        //1) manage
        public Instructor Instructor { get; set; }
        public int? ManagerId { get; set; }

        //2) contain
        public ICollection<Instructor> Instructors { get; set; }
        = new HashSet<Instructor>();

        /*
            Depatrtment (D) Course (C)
            D(one,m) C(many, o)
         */
        public Course Course { get; set; }
        public ICollection<Course> Courses { get; set; }
        = new HashSet<Course>();
    }
}
