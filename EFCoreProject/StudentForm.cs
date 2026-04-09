using MyProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace EFCoreProject
{
    //public partial class StudentForm : Form
    //{
    //    public StudentForm()
    //    {
    //        InitializeComponent();
    //    }
    //}

    public partial class StudentForm : Form
    {
        private string role;      // Role of the current user
        private int? studentId;   // Optional: only used if role is Student
        private int? userId;      // Optional: used for Instructor/Admin if needed

        private MyDbContext context = new MyDbContext();

        // Single constructor
        public StudentForm(string role, int? studentId = null, int? userId = null)
        {
            InitializeComponent();
            this.role = role;
            this.studentId = studentId;
            this.userId = userId;
        }

        private void StudentForm_Load(object sender, EventArgs e)
        {
            if (role == "Student" && studentId.HasValue)
            {
                // Only show this student's profile
                var student = context.Students.Find(studentId.Value);
                txtName.Text = student.FirstName + " " + student.LastName;
                txtPhone.Text = student.Phone;
                txtEmail.Text = student.Email;
                txtEmail.Enabled = false; // cannot edit
            }
            else if (role == "Instructor" && userId.HasValue)
            {
                // Show all students of this instructor
                var students = context.Courses
                    .Where(c => c.InstructorId == userId.Value)
                    .SelectMany(c => c.StudentCourses.Select(sc => sc.Student))
                    .Distinct()
                    .ToList();

                dataGridView1.DataSource = students;
            }
            else if (role == "Admin")
            {
                // Show all students
                var students = context.Students.ToList();
                dataGridView1.DataSource = students;
            }
        }

    }

}
