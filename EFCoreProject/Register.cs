using EFCoreProject.Models;
using Microsoft.EntityFrameworkCore;
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

namespace EFCoreProject
{
    public partial class Register : Form
    {
        MyDbContext _context;
        public Register()
        {
            _context = new MyDbContext();
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;
            string role = cboRole.SelectedItem?.ToString() ?? "Student";

            // NEW: Get student/instructor specific fields
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string phone = txtPhone.Text.Trim();

            // Validation
            if (string.IsNullOrEmpty(username))
            {
                lblError.Text = "Username is required";
                return;
            }

            if (string.IsNullOrEmpty(email))
            {
                lblError.Text = "Email is required";
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                lblError.Text = "Password is required";
                return;
            }

            if (password != confirmPassword)
            {
                lblError.Text = "Passwords do not match";
                return;
            }

            if (password.Length < 6)
            {
                lblError.Text = "Password must be at least 6 characters";
                return;
            }

            // NEW: Validate student/instructor fields if role requires them
            if ((role == "Student" || role == "Instructor") && (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)))
            {
                lblError.Text = "First Name and Last Name are required for Students and Instructors";
                return;
            }

            if (_context.Users.Any(u => u.Username == username))
            {
                lblError.Text = "Username already exists";
                return;
            }

            if (_context.Users.Any(u => u.Email == email))
            {
                lblError.Text = "Email already exists";
                return;
            }

            // Start a transaction to ensure both User and Student/Instructor are created
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newUser = new User
                    {
                        Username = username,
                        Email = email,
                        PasswordHash = PasswordHelper.HashPassword(password),
                        Role = role,
                        CreatedAt = DateTime.Now,
                        IsActive = true
                    };

                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    // NEW: Create corresponding Student or Instructor record
                    if (role == "Student")
                    {
                        var newStudent = new Student
                        {
                            Id = newUser.Id,  // Same ID as User
                            FirstName = firstName,
                            LastName = lastName,
                            Phone = phone,
                            Email = email
                        };
                        _context.Students.Add(newStudent);
                    }
                    else if (role == "Instructor")
                    {
                        var newInstructor = new Instructor
                        {
                            Id = newUser.Id,  // Same ID as User
                            FirstName = firstName,
                            LastName = lastName,
                            Phone = phone,
                            Email = email,
                            DepartmentId = null  // Can be assigned later by Admin
                        };
                        _context.Instructors.Add(newInstructor);
                    }
                    // Admin doesn't need Student or Instructor record

                    _context.SaveChanges();
                    transaction.Commit();

                    MessageBox.Show("Registration successful! You can now login.", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.Close();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    lblError.Text = $"Registration failed: {ex.Message}";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Register_Load(object sender, EventArgs e)
        {
            cboRole.Items.Add("Student");
            cboRole.Items.Add("Instructor");
            cboRole.Items.Add("Admin");

            cboRole.SelectedIndex = 0; // default

            // NEW: Show/hide additional fields based on role
            cboRole.SelectedIndexChanged += CboRole_SelectedIndexChanged;
            UpdateFieldsVisibility();
        }

        // NEW: Show/hide FirstName, LastName, Phone based on role
        private void CboRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFieldsVisibility();
        }

        private void UpdateFieldsVisibility()
        {
            string selectedRole = cboRole.SelectedItem?.ToString() ?? "Student";

            // For Student or Instructor, show name/phone fields
            // For Admin, hide them (not needed)
            bool showDetails = (selectedRole == "Student" || selectedRole == "Instructor");

            lblFirstName.Visible = showDetails;
            txtFirstName.Visible = showDetails;
            lblLastName.Visible = showDetails;
            txtLastName.Visible = showDetails;
            lblPhone.Visible = showDetails;
            txtPhone.Visible = showDetails;
        }
    }
}