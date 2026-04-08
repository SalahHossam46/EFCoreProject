using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreProject.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string PasswordHash { get; set; } // Store hashed password, not plain text
        public string Email { get; set; }
        public string Role { get; set; } // "Admin", "Instructor", "Student", etc.
        public DateTime CreatedAt { get; set; }
        public bool IsActive { get; set; }
    }
}
