using System;
using System.Windows.Forms;
using EFCoreProject.Models;
using EFCoreProject.Services;
using MyProject.Models;

namespace EFCoreProject
{
    public partial class InstructorForm : Form
    {
        private User currentUser;
        private InstructorService instructorService;
        private StudentService studentService;
        private Instructor? currentInstructor;

        public InstructorForm(User user, InstructorService instructorService, StudentService studentService)
        {
            InitializeComponent();
            this.currentUser = user;
            this.instructorService = instructorService;
            this.studentService = studentService;

            LoadDataBasedOnRole();
        }

        private void LoadDataBasedOnRole()
        {
            switch (currentUser.Role)
            {
                case "Student":
                    LoadMyInstructors();
                    break;
                case "Admin":
                    LoadAllInstructors();
                    break;
                case "Instructor":
                    LoadOwnInstructorProfile();
                    break;
            }
        }

        private void LoadMyInstructors()
        {
            this.Text = "My Instructors (Student View)";

            var student = studentService.GetStudentByEmail(currentUser.Email);
            if (student == null)
            {
                MessageBox.Show("Student record not found");
                return;
            }

            var instructors = studentService.GetMyInstructors(student.Id);
            dataGridViewInstructors.DataSource = instructors;
            dataGridViewInstructors.Visible = true;
            panelDetails.Visible = false;

            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnDelete.Visible = false;
            btnAdd.Visible = false;
        }

        private void LoadAllInstructors()
        {
            this.Text = "All Instructors (Admin View)";

            var instructors = instructorService.GetAllInstructors();
            dataGridViewInstructors.DataSource = instructors;
            dataGridViewInstructors.Visible = true;
            panelDetails.Visible = false;

            btnAdd.Visible = true;
            btnEdit.Visible = true;
            btnDelete.Visible = true;
            btnSave.Visible = false;

        }

        private void LoadOwnInstructorProfile()
        {
            this.Text = "My Profile (Instructor View)";

            currentInstructor = instructorService.GetInstructorByEmail(currentUser.Email);
            if (currentInstructor == null)
            {
                MessageBox.Show("Instructor record not found");
                return;
            }

            txtId.Text = currentInstructor.Id.ToString();
            txtFirstName.Text = currentInstructor.FirstName;
            txtLastName.Text = currentInstructor.LastName;
            txtPhone.Text = currentInstructor.Phone;

            panelDetails.Visible = true;
            dataGridViewInstructors.Visible = false;

            btnEdit.Visible = true;
            btnSave.Visible = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentUser.Role == "Admin")
            {
                if (dataGridViewInstructors.SelectedRows.Count > 0)
                {
                    var selectedInstructor = (Instructor)dataGridViewInstructors.SelectedRows[0].DataBoundItem;
                    MessageBox.Show("Save functionality for admin - implement update");
                }
            }
            else if (currentUser.Role == "Instructor")
            {
                if (currentInstructor != null)
                {
                    currentInstructor.FirstName = txtFirstName.Text;
                    currentInstructor.LastName = txtLastName.Text;
                    currentInstructor.Phone = txtPhone.Text;

                    instructorService.UpdateInstructor(currentInstructor);
                    MessageBox.Show("Profile updated successfully");

                    txtFirstName.ReadOnly = true;
                    txtLastName.ReadOnly = true;
                    txtPhone.ReadOnly = true;
                    btnEdit.Enabled = true;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentUser.Role == "Admin")
            {
                if (dataGridViewInstructors.SelectedRows.Count > 0)
                {
                    var selectedInstructor = (Instructor)dataGridViewInstructors.SelectedRows[0].DataBoundItem;

                    var editForm = new Form
                    {
                        Text = "Edit Instructor",
                        Size = new System.Drawing.Size(300, 200),
                        StartPosition = FormStartPosition.CenterParent
                    };

                    var txtFirstName = new TextBox { Text = selectedInstructor.FirstName, Location = new System.Drawing.Point(10, 30), Width = 250 };
                    var txtLastName = new TextBox { Text = selectedInstructor.LastName, Location = new System.Drawing.Point(10, 80), Width = 250 };
                    var txtPhone = new TextBox { Text = selectedInstructor.Phone, Location = new System.Drawing.Point(10, 130), Width = 250 };

                    editForm.Controls.Add(new Label { Text = "First Name:", Location = new System.Drawing.Point(10, 10) });
                    editForm.Controls.Add(txtFirstName);
                    editForm.Controls.Add(new Label { Text = "Last Name:", Location = new System.Drawing.Point(10, 60) });
                    editForm.Controls.Add(txtLastName);
                    editForm.Controls.Add(new Label { Text = "Phone:", Location = new System.Drawing.Point(10, 110) });
                    editForm.Controls.Add(txtPhone);

                    var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(50, 170), DialogResult = DialogResult.OK };
                    var btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(150, 170), DialogResult = DialogResult.Cancel };
                    editForm.Controls.Add(btnOk);
                    editForm.Controls.Add(btnCancel);

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        selectedInstructor.FirstName = txtFirstName.Text;
                        selectedInstructor.LastName = txtLastName.Text;
                        selectedInstructor.Phone = txtPhone.Text;

                        instructorService.UpdateInstructor(selectedInstructor);
                        LoadAllInstructors();
                        MessageBox.Show("Instructor updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Please select an instructor to edit");
                }
            }
            else if (currentUser.Role == "Instructor")
            {
                txtFirstName.ReadOnly = false;
                txtLastName.ReadOnly = false;
                txtPhone.ReadOnly = false;
                btnEdit.Enabled = false;
                MessageBox.Show("Edit mode enabled - click Save to update your profile");
            }


        }

        // ADD NEW INSTRUCTOR
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new Form
            {
                Text = "Add New Instructor",
                Size = new System.Drawing.Size(350, 300),
                StartPosition = FormStartPosition.CenterParent
            };

            var txtFirstName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 180 };
            var txtLastName = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 180 };
            var txtPhone = new TextBox { Location = new System.Drawing.Point(120, 100), Width = 180 };
            var txtEmail = new TextBox { Location = new System.Drawing.Point(120, 140), Width = 180 };
            var cmbDepartment = new ComboBox { Location = new System.Drawing.Point(120, 180), Width = 180, DropDownStyle = ComboBoxStyle.DropDownList };

            // Load departments into combo box
            using (var tempContext = new MyDbContext())
            {
                var departments = tempContext.Departments.ToList();
                cmbDepartment.DataSource = departments;
                cmbDepartment.DisplayMember = "Name";
                cmbDepartment.ValueMember = "Id";
                cmbDepartment.SelectedIndex = -1;
            }

            addForm.Controls.Add(new Label { Text = "First Name:", Location = new System.Drawing.Point(20, 25), Width = 80 });
            addForm.Controls.Add(txtFirstName);
            addForm.Controls.Add(new Label { Text = "Last Name:", Location = new System.Drawing.Point(20, 65), Width = 80 });
            addForm.Controls.Add(txtLastName);
            addForm.Controls.Add(new Label { Text = "Phone:", Location = new System.Drawing.Point(20, 105), Width = 80 });
            addForm.Controls.Add(txtPhone);
            addForm.Controls.Add(new Label { Text = "Email:", Location = new System.Drawing.Point(20, 145), Width = 80 });
            addForm.Controls.Add(txtEmail);
            addForm.Controls.Add(new Label { Text = "Department:", Location = new System.Drawing.Point(20, 185), Width = 80 });
            addForm.Controls.Add(cmbDepartment);

            var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(80, 230), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(180, 230), DialogResult = DialogResult.Cancel };
            addForm.Controls.Add(btnOk);
            addForm.Controls.Add(btnCancel);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                // Validation
                if (string.IsNullOrEmpty(txtFirstName.Text) || string.IsNullOrEmpty(txtLastName.Text))
                {
                    MessageBox.Show("First Name and Last Name are required", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var newInstructor = new Instructor
                {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    DepartmentId = cmbDepartment.SelectedValue != null ? (int?)cmbDepartment.SelectedValue : null
                };

                if (instructorService.AddInstructor(newInstructor))
                {
                    LoadAllInstructors();
                    MessageBox.Show("Instructor added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Failed to add instructor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // DELETE INSTRUCTOR
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewInstructors.SelectedRows.Count > 0)
            {
                var selectedInstructor = (Instructor)dataGridViewInstructors.SelectedRows[0].DataBoundItem;

                // Check if instructor has courses assigned
                using (var tempContext = new MyDbContext())
                {
                    int courseCount = tempContext.Courses.Count(c => c.InstructorId == selectedInstructor.Id);

                    string message = $"Are you sure you want to delete {selectedInstructor.FirstName} {selectedInstructor.LastName}?";

                    if (courseCount > 0)
                    {
                        message += $"\n\nWARNING: This instructor is teaching {courseCount} course(s). You cannot delete them until you reassign their courses.";
                        MessageBox.Show(message, "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    var result = MessageBox.Show(message, "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                    if (result == DialogResult.Yes)
                    {
                        if (instructorService.DeleteInstructor(selectedInstructor.Id))
                        {
                            LoadAllInstructors();
                            MessageBox.Show("Instructor deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Failed to delete instructor", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select an instructor to delete", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}