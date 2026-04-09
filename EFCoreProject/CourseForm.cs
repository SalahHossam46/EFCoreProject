using System;
using System.Windows.Forms;
using EFCoreProject.Models;
using EFCoreProject.Services;
using MyProject.Models;

namespace EFCoreProject
{
    public partial class CourseForm : Form
    {
        private User currentUser;
        private CourseService courseService;
        private StudentService studentService;

        public CourseForm(User user, CourseService courseService, StudentService studentService)
        {
            InitializeComponent();
            this.currentUser = user;
            this.courseService = courseService;
            this.studentService = studentService;

            LoadDataBasedOnRole();
        }

        private void LoadDataBasedOnRole()
        {
            switch (currentUser.Role)
            {
                case "Student":
                    LoadStudentCourses();
                    break;
                case "Admin":
                    LoadAllCourses();
                    break;
                case "Instructor":
                    LoadInstructorCourses();
                    break;
            }
        }

        private void LoadStudentCourses()
        {
            this.Text = "My Courses (Student View)";

            var student = studentService.GetStudentByEmail(currentUser.Email);
            if (student == null)
            {
                MessageBox.Show("Student record not found");
                return;
            }

            var courses = studentService.GetRegisteredCourses(student.Id);
            dataGridViewCourses.DataSource = courses;
            dataGridViewCourses.Visible = true;

            btnAdd.Visible = false;
            btnEdit.Visible = false;
            btnDelete.Visible = false;
        }

        private void LoadAllCourses()
        {
            this.Text = "All Courses (Admin View)";

            var courses = courseService.GetAllCourses();
            dataGridViewCourses.DataSource = courses;
            dataGridViewCourses.Visible = true;

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
        }

        private void LoadInstructorCourses()
        {
            this.Text = "Courses I Teach (Instructor View)";

            var instructor = studentService.GetInstructorByEmail(currentUser.Email);
            if (instructor == null)
            {
                MessageBox.Show("Instructor record not found");
                return;
            }

            var courses = courseService.GetCoursesByInstructorId(instructor.Id);
            dataGridViewCourses.DataSource = courses;
            dataGridViewCourses.Visible = true;

            btnAdd.Visible = false;
            btnEdit.Visible = true;
            btnDelete.Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new Form
            {
                Text = "Add New Course",
                Size = new System.Drawing.Size(300, 250),
                StartPosition = FormStartPosition.CenterParent
            };

            var txtName = new TextBox { Location = new System.Drawing.Point(10, 30), Width = 250 };
            var txtDuration = new TextBox { Location = new System.Drawing.Point(10, 80), Width = 250 };
            var txtInstructorId = new TextBox { Location = new System.Drawing.Point(10, 130), Width = 250 };
            var txtDepartmentId = new TextBox { Location = new System.Drawing.Point(10, 180), Width = 250 };

            addForm.Controls.Add(new Label { Text = "Course Name:", Location = new System.Drawing.Point(10, 10) });
            addForm.Controls.Add(txtName);
            addForm.Controls.Add(new Label { Text = "Duration:", Location = new System.Drawing.Point(10, 60) });
            addForm.Controls.Add(txtDuration);
            addForm.Controls.Add(new Label { Text = "Instructor ID:", Location = new System.Drawing.Point(10, 110) });
            addForm.Controls.Add(txtInstructorId);
            addForm.Controls.Add(new Label { Text = "Department ID:", Location = new System.Drawing.Point(10, 160) });
            addForm.Controls.Add(txtDepartmentId);

            var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(50, 210), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(150, 210), DialogResult = DialogResult.Cancel };
            addForm.Controls.Add(btnOk);
            addForm.Controls.Add(btnCancel);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var newCourse = new Course
                {
                    Name = txtName.Text,
                    Duration = int.TryParse(txtDuration.Text, out int duration) ? duration : 0,
                    InstructorId = int.TryParse(txtInstructorId.Text, out int instructorId) ? instructorId : 0,
                    DepartmentId = int.TryParse(txtDepartmentId.Text, out int deptId) ? deptId : (int?)null
                };

                courseService.AddCourse(newCourse);
                LoadAllCourses();
                MessageBox.Show("Course added successfully");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count > 0)
            {
                var selectedCourse = (Course)dataGridViewCourses.SelectedRows[0].DataBoundItem;

                var editForm = new Form
                {
                    Text = "Edit Course",
                    Size = new System.Drawing.Size(300, 250),
                    StartPosition = FormStartPosition.CenterParent
                };

                var txtName = new TextBox { Text = selectedCourse.Name, Location = new System.Drawing.Point(10, 30), Width = 250 };
                var txtDuration = new TextBox { Text = selectedCourse.Duration.ToString(), Location = new System.Drawing.Point(10, 80), Width = 250 };
                var txtInstructorId = new TextBox { Text = selectedCourse.InstructorId.ToString(), Location = new System.Drawing.Point(10, 130), Width = 250 };
                var txtDepartmentId = new TextBox { Text = selectedCourse.DepartmentId?.ToString() ?? "", Location = new System.Drawing.Point(10, 180), Width = 250 };

                editForm.Controls.Add(new Label { Text = "Course Name:", Location = new System.Drawing.Point(10, 10) });
                editForm.Controls.Add(txtName);
                editForm.Controls.Add(new Label { Text = "Duration:", Location = new System.Drawing.Point(10, 60) });
                editForm.Controls.Add(txtDuration);
                editForm.Controls.Add(new Label { Text = "Instructor ID:", Location = new System.Drawing.Point(10, 110) });
                editForm.Controls.Add(txtInstructorId);
                editForm.Controls.Add(new Label { Text = "Department ID:", Location = new System.Drawing.Point(10, 160) });
                editForm.Controls.Add(txtDepartmentId);

                var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(50, 210), DialogResult = DialogResult.OK };
                var btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(150, 210), DialogResult = DialogResult.Cancel };
                editForm.Controls.Add(btnOk);
                editForm.Controls.Add(btnCancel);

                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    selectedCourse.Name = txtName.Text;
                    selectedCourse.Duration = int.TryParse(txtDuration.Text, out int duration) ? duration : 0;
                    selectedCourse.InstructorId = int.TryParse(txtInstructorId.Text, out int instructorId) ? instructorId : 0;
                    selectedCourse.DepartmentId = int.TryParse(txtDepartmentId.Text, out int deptId) ? deptId : (int?)null;

                    courseService.UpdateCourse(selectedCourse);

                    if (currentUser.Role == "Admin")
                        LoadAllCourses();
                    else if (currentUser.Role == "Instructor")
                        LoadInstructorCourses();


                    MessageBox.Show("Course updated successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to edit");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewCourses.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Are you sure you want to delete this course?", "Confirm Delete", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    var selectedCourse = (Course)dataGridViewCourses.SelectedRows[0].DataBoundItem;
                    courseService.DeleteCourse(selectedCourse.Id);
                    LoadAllCourses();
                    MessageBox.Show("Course deleted successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select a course to delete");
            }
        }
    }
}