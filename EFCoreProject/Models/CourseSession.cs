using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class CourseSession
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }



        //Relation
        /*
        CourseSecion (CS) Instructor (I)
        CS (many , o) I (one, m)
         */
        public Instructor? Instructor { get; set; }
        public int InstructorId { get; set; }

        /*
        CourseSecion (CS) Couurse (C)
        CS (many , o) C (one, m)
         */

        public Course? Course { get; set; }
        public int CourseId { get; set; }

        /*
         CourseSection (CS) CourseSessionAttendance (CSA)
         CS (one, m) CSA (many, o)
         */
        public ICollection<CourseSessionAttendance> CourseSessionAttendances { get; set; }
        = new HashSet<CourseSessionAttendance>();
    }
}

