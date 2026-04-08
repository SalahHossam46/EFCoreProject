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

            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.IsActive);

            if (user != null && PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                lblError.Text = "";
                MessageBox.Show($"Login successful! Welcome {user.Username}\nRole: {user.Role}", "Success",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (user.Role == "Admain")
                {

                }
                else if (user.Role == "Instructor")
                {

                }
                else    //Student
                {

                }
                this.Hide();
            }
            //If username or password invalid
            else
            {
                lblError.Text = "Invalid username or password";
            }


        }
        //Register

        private void btnRegister_Click(object sender, EventArgs e)
        {
            Register registerForm = new Register();
            registerForm.ShowDialog();
        }


    }
}
