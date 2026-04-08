using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class CourseSessionAttendance
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Notes { get; set; }

        //Relation
        /*
         CourseSessionAttendance  (CSA) Coursesection (CS)
         CSA (many , o) CS(one , m)
         */
        public CourseSession? CourseSession { get; set; }
        public int? CourseSessionId { get; set; }

        /*
         CourseSessionAttendance  (CSA) Student (S)
         CSA (many , o) S(one , m)
         */
        public Student? Student { get; set; }
        public int? StudentId { get; set; }
    }
}
