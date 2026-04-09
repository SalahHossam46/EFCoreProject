//using EFCoreProject;
//using EFCoreProject.Models;
//using EFCoreProject.Services;
//using MyProject.Models;
//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace EFCoreProject
//{
//    public partial class MainForm : Form
//    {
//        private User currentUser;

//        public MainForm(User user)
//        {
//            InitializeComponent();
//            currentUser = user;
//            this.Text = $"Main Menu - Logged in as {currentUser.Role}: {currentUser.Username}";
//        }

//        //Student 
//        private void btnStudent_Click(object sender, EventArgs e)
//        {

//            using (var context = new MyDbContext())
//            {
//                var service = new StudentService(context);
//                var studentForm = new StudentForm(currentUser, service);
//                studentForm.ShowDialog();
//            }
//        }



//        // Course
//        private void btnCourse_Click(object sender, EventArgs e)
//        {
//            using (var context = new MyDbContext())
//            {
//                var service = new StudentService(context);
//                var courseForm = new CourseForm(currentUser, service);
//                courseForm.ShowDialog();
//            }
//        }

//        //Instructor 
//        private void btnInstructor_Click(object sender, EventArgs e)
//        {
//            using (var context = new MyDbContext())
//            {
//                var service = new StudentService(context);
//                var instructorForm = new InstructorForm(currentUser, service);
//                instructorForm.ShowDialog();
//            }
//        }


//        //Department
//        private void btnDepartment_Click(object sender, EventArgs e)
//        {

//            using (var context = new MyDbContext())
//            {
//                var service = new StudentService(context);
//                var departmentForm = new DepartmentForm(currentUser, service);
//                departmentForm.ShowDialog();
//            }
//        }
//    }
//}


using EFCoreProject.Models;
using EFCoreProject.Services;
using MyProject.Models;
using System;
using System.Windows.Forms;

namespace EFCoreProject
{
    public partial class MainForm : Form
    {
        private User currentUser;

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            this.Text = $"Main Menu - Logged in as {currentUser.Role}: {currentUser.Username}";
        }

        // Student Button - uses only StudentService
        private void btnStudent_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var studentService = new StudentService(context);
                var studentForm = new StudentForm(currentUser, studentService);
                studentForm.ShowDialog();
            }
        }

        // Course Button - uses CourseService + StudentService
        private void btnCourse_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var courseService = new CourseService(context);
                var studentService = new StudentService(context);
                var courseForm = new CourseForm(currentUser, courseService, studentService);
                courseForm.ShowDialog();
            }
        }

        // Instructor Button - uses InstructorService + StudentService
        private void btnInstructor_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var instructorService = new InstructorService(context);
                var studentService = new StudentService(context);
                var instructorForm = new InstructorForm(currentUser, instructorService, studentService);
                instructorForm.ShowDialog();
            }
        }

        // Department Button - uses DepartmentService + StudentService
        private void btnDepartment_Click(object sender, EventArgs e)
        {
            using (var context = new MyDbContext())
            {
                var departmentService = new DepartmentService(context);
                var studentService = new StudentService(context);
                var departmentForm = new DepartmentForm(currentUser, departmentService, studentService);
                departmentForm.ShowDialog();
            }
        }
    }
}