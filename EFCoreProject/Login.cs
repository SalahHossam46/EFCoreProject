using Microsoft.EntityFrameworkCore;
using MyProject.Models;

namespace EFCoreProject
{
    public partial class Login : Form
    {
        MyDbContext _context;
        public Login()
        {
            InitializeComponent();
            _context = new MyDbContext();
        }

        //Login
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                lblError.Text = "Please enter username and password";
                return;
            }
            //I must have DbSet for user

            
        }
        //Register

    }
}
