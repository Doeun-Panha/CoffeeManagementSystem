using System;
using System.Linq;

namespace CoffeeManagementSystem.Models.Classes
{
    public class User
    {
        public int ID { get; set; }
        public Employee employee { get; set; }
        
        private string _password;
        public string Password 
        { 
            get => _password; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 8)
                    throw new ArgumentException("Password must be at least 8 characters long.");
                _password = value;
            } 
        }
        public string Salt { get; set; }

        private string _role;
        public string Role 
        { 
            get => _role; 
            set 
            {
                string[] validRoles = { "Admin", "Staff", "Manager" };
                if (string.IsNullOrWhiteSpace(value) || !System.Linq.Enumerable.Contains(validRoles, value))
                    throw new ArgumentException("Invalid role. Role must be Admin, Staff, or Manager.");
                _role = value;
            } 
        }
        public User() { }
        public User(int id, Employee emp, string password, string salt, string role)
        {
            ID = id;
            employee = emp;
            Password = password;
            Salt = salt;
            Role = role;
        }
    }
}
