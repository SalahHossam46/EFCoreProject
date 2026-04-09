using EFCoreProject.Models;
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
    public partial class MainForm : Form
    {
        // Logged-in user
        private User currentUser;

        // Only needed for Student role
        private int currentStudentId;

        // EF context (optional, can also use inside methods)
        private MyDbContext context = new MyDbContext();

        public MainForm(User user)
        {
            InitializeComponent();
            currentUser = user;
            LoadStudentId();

        }

        // Method to get studentId from email
        private void LoadStudentId()
        {
            if (currentUser.Role == "Student")
            {
                currentStudentId = context.Students
                    .Where(s => s.Email == currentUser.Email)
                    .Select(s => s.Id)
                    .FirstOrDefault();

                if (currentStudentId == 0)
                {
                    MessageBox.Show("Student not found!");
                }
            }
        }

        // Student button
        private void btnStudent_Click(object sender, EventArgs e)
        {
            // Only pass currentStudentId for student role
            if (currentUser.Role == "Student")
            {
                new StudentForm("Student", studentId: currentStudentId).Show();
            }
            else
            {
                new StudentForm(currentUser.Role, userId: currentUser.Id).Show();
            }
        }

        // Department button


    }
}