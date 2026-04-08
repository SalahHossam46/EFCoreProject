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

            var newUser = new User
            {
                //Id = (_context.Users.Max(u => (int?)u.Id) ?? 0) + 1,
                Username = username,
                Email = email,
                PasswordHash = PasswordHelper.HashPassword(password),
                Role = role,
                CreatedAt = DateTime.Now,
                IsActive = true
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();

            MessageBox.Show("Registration successful! You can now login.", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            this.Close();
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
        }
    }
}
