using System;
using System.Windows.Forms;
using EFCoreProject.Models;
using EFCoreProject.Services;
using MyProject.Models;

namespace EFCoreProject
{
    public partial class DepartmentForm : Form
    {
        private User currentUser;
        private DepartmentService departmentService;
        private StudentService studentService;

        public DepartmentForm(User user, DepartmentService departmentService, StudentService studentService)
        {
            InitializeComponent();
            this.currentUser = user;
            this.departmentService = departmentService;
            this.studentService = studentService;

            LoadDataBasedOnRole();
        }

        private void LoadDataBasedOnRole()
        {
            switch (currentUser.Role)
            {
                case "Student":
                    LoadMyDepartments();
                    break;
                case "Admin":
                    LoadAllDepartments();
                    break;
                case "Instructor":
                    LoadInstructorDepartment();
                    break;
            }
        }

        private void LoadMyDepartments()
        {
            this.Text = "My Departments (Student View)";

            var student = studentService.GetStudentByEmail(currentUser.Email);
            if (student == null)
            {
                MessageBox.Show("Student record not found");
                return;
            }

            var departments = studentService.GetMyDepartments(student.Id);
            dataGridViewDepartments.DataSource = departments;
            dataGridViewDepartments.Visible = true;
            panelDetails.Visible = false;

            btnEdit.Visible = false;
            btnSave.Visible = false;
            btnAdd.Visible = false;
            btnDelete.Visible = false;
        }

        private void LoadAllDepartments()
        {
            this.Text = "All Departments (Admin View)";

            var departments = departmentService.GetAllDepartments();
            dataGridViewDepartments.DataSource = departments;
            dataGridViewDepartments.Visible = true;
            panelDetails.Visible = false;

            btnEdit.Visible = true;
            btnSave.Visible = false;
            btnAdd.Visible = true;      
            btnDelete.Visible = true;   

        }

        private void LoadInstructorDepartment()
        {
            this.Text = "My Department (Instructor View)";

            var instructor = studentService.GetInstructorByEmail(currentUser.Email);
            if (instructor == null)
            {
                MessageBox.Show("Instructor record not found");
                return;
            }

            var department = departmentService.GetDepartmentByInstructorId(instructor.Id);

            if (department != null)
            {
                txtDepartmentId.Text = department.Id.ToString();
                txtDepartmentName.Text = department.Name;
                txtLocation.Text = department.Location;

                panelDetails.Visible = true;
                dataGridViewDepartments.Visible = false;
            }
            else
            {
                MessageBox.Show("No department assigned");
            }

            btnEdit.Visible = false;
            btnSave.Visible = false;
            txtDepartmentName.ReadOnly = true;
            txtLocation.ReadOnly = true;
            btnAdd.Visible = false;
            btnDelete.Visible = false;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentUser.Role == "Admin")
            {
                if (dataGridViewDepartments.SelectedRows.Count > 0)
                {
                    var selectedDept = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;
                    MessageBox.Show("Save functionality for admin - implement update");
                }
            }
            else if (currentUser.Role == "Instructor")
            {
                MessageBox.Show("Instructors typically cannot save department changes");
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (currentUser.Role == "Admin")
            {
                if (dataGridViewDepartments.SelectedRows.Count > 0)
                {
                    var selectedDept = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;

                    var editForm = new Form
                    {
                        Text = "Edit Department",
                        Size = new System.Drawing.Size(300, 200),
                        StartPosition = FormStartPosition.CenterParent
                    };

                    var txtName = new TextBox { Text = selectedDept.Name, Location = new System.Drawing.Point(10, 30), Width = 250 };
                    var txtLocation = new TextBox { Text = selectedDept.Location, Location = new System.Drawing.Point(10, 80), Width = 250 };

                    editForm.Controls.Add(new Label { Text = "Department Name:", Location = new System.Drawing.Point(10, 10) });
                    editForm.Controls.Add(txtName);
                    editForm.Controls.Add(new Label { Text = "Location:", Location = new System.Drawing.Point(10, 60) });
                    editForm.Controls.Add(txtLocation);

                    var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(50, 130), DialogResult = DialogResult.OK };
                    var btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(150, 130), DialogResult = DialogResult.Cancel };
                    editForm.Controls.Add(btnOk);
                    editForm.Controls.Add(btnCancel);

                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        selectedDept.Name = txtName.Text;
                        selectedDept.Location = txtLocation.Text;
                        departmentService.UpdateDepartment(selectedDept);
                        LoadAllDepartments();
                        MessageBox.Show("Department updated successfully");
                    }
                }
                else
                {
                    MessageBox.Show("Please select a department to edit");
                }
            }
            else if (currentUser.Role == "Instructor")
            {
                txtDepartmentName.ReadOnly = false;
                txtLocation.ReadOnly = false;
                MessageBox.Show("Edit mode enabled - click Save to update");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var addForm = new Form
            {
                Text = "Add New Department",
                Size = new System.Drawing.Size(350, 200),
                StartPosition = FormStartPosition.CenterParent
            };

            var txtName = new TextBox { Location = new System.Drawing.Point(120, 20), Width = 180 };
            var txtLocation = new TextBox { Location = new System.Drawing.Point(120, 60), Width = 180 };

            addForm.Controls.Add(new Label { Text = "Department Name:", Location = new System.Drawing.Point(20, 25), Width = 100 });
            addForm.Controls.Add(txtName);
            addForm.Controls.Add(new Label { Text = "Location:", Location = new System.Drawing.Point(20, 65), Width = 100 });
            addForm.Controls.Add(txtLocation);

            var btnOk = new Button { Text = "OK", Location = new System.Drawing.Point(80, 110), DialogResult = DialogResult.OK };
            var btnCancel = new Button { Text = "Cancel", Location = new System.Drawing.Point(180, 110), DialogResult = DialogResult.Cancel };
            addForm.Controls.Add(btnOk);
            addForm.Controls.Add(btnCancel);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                var newDept = new Department
                {
                    Name = txtName.Text,
                    Location = txtLocation.Text
                };

                departmentService.AddDepartment(newDept);
                LoadAllDepartments();
                MessageBox.Show("Department added successfully");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridViewDepartments.SelectedRows.Count > 0)
            {
                var selectedDept = (Department)dataGridViewDepartments.SelectedRows[0].DataBoundItem;

                var result = MessageBox.Show($"Delete {selectedDept.Name}?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    departmentService.DeleteDepartment(selectedDept.Id);
                    LoadAllDepartments();
                    MessageBox.Show("Department deleted successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select a department to delete");
            }
        }

    }
}
