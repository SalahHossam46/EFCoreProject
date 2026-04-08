using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class StudentCourse
    {

        //Relations
        /*
         StudentCourse (SC) Student (S)
         SC (many, o) S (one, m)
         */
        public Student? Student { get; set; }
        public int? StudentId { get; set; }

        /*
         StudentCourse (SC) Course (C)
         SC (many, o) C (one, m)
         */
        public Course? Course { get; set; }
        public int? CourseId { get; set; }

    }
}
