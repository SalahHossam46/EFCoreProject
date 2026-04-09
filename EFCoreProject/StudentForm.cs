using System;
using System.Windows.Forms;
using EFCoreProject.Models;
using EFCoreProject.Services;
using MyProject.Models;

namespace EFCoreProject
{
    public partial class StudentForm : Form
    {
        private User currentUser;
        private StudentService studentService;
        private Student? currentStudent;

        public StudentForm(User user, StudentService studentService)
        {
            InitializeComponent();
            this.currentUser = user;
            this.studentService = studentService;

            LoadDataBasedOnRole();
        }

        private void LoadDataBasedOnRole()
        {
            switch (currentUser.Role)
            {
                case "Student":
                    LoadStudentOwnProfile();
                    break;
                case "Admin":
                    LoadAllStudents();
                    break;
                case "Instructor":
                    LoadStudentsForInstructor();
                    break;
                default:
                    MessageBox.Show("Unknown role");
                    Close();
                    break;
            }
        }

        private void LoadStudentOwnProfile()
        {
            this.Text = "My Profile (Student View)";

            currentStudent = studentService.GetStudentByEmail(currentUser.Email);
            if (currentStudent == null)
            {
                MessageBox.Show("Student record not found");
                return;
            }

            txtId.Text = currentStudent.Id.ToString();
            txtFirstName.Text = currentStudent.FirstName;
            txtLastName.Text = currentStudent.LastName;
            txtPhone.Text = currentStudent.Phone;
            txtEmail.Text = currentStudent.Email;

            txtPhone.ReadOnly = false;
            txtFirstName.ReadOnly = true;
            txtLastName.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtId.ReadOnly = true;

            btnSave.Visible = true;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
            dataGridViewStudents.Visible = false;
            panelDetails.Visible = true;
        }

        private void LoadAllStudents()
        {
            this.Text = "All Students (Admin View)";

            var students = studentService.GetAllStudents();
            dataGridViewStudents.DataSource = students;
            dataGridViewStudents.Visible = true;
            panelDetails.Visible = false;

            btnSave.Visible = true;
            btnDelete.Visible = true;
            btnAdd.Visible = true;
        }

        private void LoadStudentsForInstructor()
        {
            this.Text = "My Students (Instructor View)";

            var instructor = studentService.GetInstructorByEmail(currentUser.Email);
            if (instructor == null)
            {
                MessageBox.Show("Instructor record not found");
                return;
            }

            var courseIds = studentService.GetCoursesByInstructorId(instructor.Id).Select(c => c.Id).ToList();
            var students = studentService.GetStudentsByCourseIds(courseIds);

            dataGridViewStudents.DataSource = students;
            dataGridViewStudents.Visible = true;
            panelDetails.Visible = false;

            btnSave.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentUser.Role == "Student")
            {
                if (currentStudent != null)
                {
                    studentService.UpdateStudentPhone(currentStudent.Id, txtPhone.Text);
                    MessageBox.Show("Phone updated successfully", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (currentUser.Role == "Admin")
            {
                // Check if a student is selected in the grid
                if (dataGridViewStudents.SelectedRows.Count > 0)
                {
                    var selectedStudent = (Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;

                    // Create dialog for editing student
                    var editForm = new Form
                    {
                        Text = $"Edit Student: {selectedStudent.FirstName} {selectedStudent.LastName}",
                        Size = new System.Drawing.Size(350, 280),
                        StartPosition = FormStartPosition.CenterParent,
                        FormBorderStyle = FormBorderStyle.FixedDialog,
                        MaximizeBox = false,
                        MinimizeBox = false
                    };

                    // Create input fields with existing values
                    var txtFirstName = new TextBox { Text = selectedStudent.FirstName, Location = new System.Drawing.Point(120, 20), Width = 180 };
                    var txtLastName = new TextBox { Text = selectedStudent.LastName, Location = new System.Drawing.Point(120, 55), Width = 180 };
                    var txtPhone = new TextBox { Text = selectedStudent.Phone ?? "", Location = new System.Drawing.Point(120, 90), Width = 180 };
                    var txtEmail = new TextBox { Text = selectedStudent.Email ?? "", Location = new System.Drawing.Point(120, 125), Width = 180 };

                    // Create labels
                    editForm.Controls.Add(new Label { Text = "First Name:", Location = new System.Drawing.Point(20, 25), Width = 80 });
                    editForm.Controls.Add(txtFirstName);
                    editForm.Controls.Add(new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, 60), Width = 80 });
                    editForm.Controls.Add(txtLastName);
                    editForm.Controls.Add(new Label { Text = "Phone:", Location = new System.Drawing.Point(20, 95), Width = 80 });
                    editForm.Controls.Add(txtPhone);
                    editForm.Controls.Add(new Label { Text = "Email:", Location = new System.Drawing.Point(20, 130), Width = 80 });
                    editForm.Controls.Add(txtEmail);

                    // Make email read-only (should not change primary identifier)
                    txtEmail.ReadOnly = true;

                    // Create buttons
                    var btnOk = new Button
                    {
                        Text = "Save",
                        Location = new System.Drawing.Point(80, 180),
                        Width = 80,
                        DialogResult = DialogResult.OK
                    };

                    var btnCancel = new Button
                    {
                        Text = "Cancel",
                        Location = new System.Drawing.Point(180, 180),
                        Width = 80,
                        DialogResult = DialogResult.Cancel
                    };

                    editForm.Controls.Add(btnOk);
                    editForm.Controls.Add(btnCancel);

                    // Show dialog and process input
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Validate required fields
                        if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                            string.IsNullOrWhiteSpace(txtLastName.Text))
                        {
                            MessageBox.Show("First Name and Last Name are required.", "Validation Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        // Update student object
                        selectedStudent.FirstName = txtFirstName.Text.Trim();
                        selectedStudent.LastName = txtLastName.Text.Trim();
                        selectedStudent.Phone = txtPhone.Text.Trim();
                        // Email is not updated (read-only)

                        // Save to database
                        bool success = studentService.UpdateStudent(selectedStudent);

                        if (success)
                        {
                            MessageBox.Show("Student updated successfully!", "Success",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadAllStudents(); // Refresh the grid
                        }
                        else
                        {
                            MessageBox.Show("Failed to update student.", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Please select a student to edit.", "No Selection",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewStudents.SelectedRows.Count > 0)
            {
                var student = (Student)dataGridViewStudents.SelectedRows[0].DataBoundItem;
                studentService.DeleteStudent(student.Id);
                LoadAllStudents();
                MessageBox.Show("Student deleted");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Create dialog for adding new student
            var addForm = new Form
            {
                Text = "Add New Student",
                Size = new System.Drawing.Size(350, 280),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Create input fields
            var txtFirstName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 180 };
            var txtLastName = new TextBox { Location = new System.Drawing.Point(120, 55), Width = 180 };
            var txtPhone = new TextBox { Location = new System.Drawing.Point(120, 90), Width = 180 };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(120, 125), Width = 180 };

            // Create labels
            addForm.Controls.Add(new Label { Text = "First Name:", Location = new System.Drawing.Point(20, 25), Width = 80 });
            addForm.Controls.Add(txtFirstName);
            addForm.Controls.Add(new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, 60), Width = 80 });
            addForm.Controls.Add(txtLastName);
            addForm.Controls.Add(new Label { Text = "Phone:", Location = new System.Drawing.Point(20, 95), Width = 80 });
            addForm.Controls.Add(txtPhone);
            addForm.Controls.Add(new Label { Text = "Email:", Location = new System.Drawing.Point(20, 130), Width = 80 });
            addForm.Controls.Add(txtEmail);

            // Create buttons
            var btnOk = new Button
            {
                Text = "OK",
                Location = new System.Drawing.Point(80, 180),
                Width = 80,
                DialogResult = DialogResult.OK
            };

            var btnCancel = new Button
            {
                Text = "Cancel",
                Location = new System.Drawing.Point(180, 180),
                Width = 80,
                DialogResult = DialogResult.Cancel
            };

            addForm.Controls.Add(btnOk);
            addForm.Controls.Add(btnCancel);

            // Show dialog and process input
            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Validate required fields
                if (string.IsNullOrWhiteSpace(txtFirstName.Text) ||
                    string.IsNullOrWhiteSpace(txtLastName.Text) ||
                    string.IsNullOrWhiteSpace(txtEmail.Text))
                {
                    MessageBox.Show("First Name, Last Name, and Email are required.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Create new student
                var newStudent = new Student
                {
                    FirstName = txtFirstName.Text.Trim(),
                    LastName = txtLastName.Text.Trim(),
                    Phone = txtPhone.Text.Trim(),
                    Email = txtEmail.Text.Trim()
                };

                // Save to database
                bool success = studentService.AddStudent(newStudent);

                if (success)
                {
                    MessageBox.Show("Student added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadAllStudents(); // Refresh the grid
                }
                else
                {
                    MessageBox.Show("Failed to add student. Email might already exist.", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}