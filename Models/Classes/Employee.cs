using CoffeeManagementSystem.Models.Abstract_Classes;
using CoffeeManagementSystem.Models.Enum;
using System;

namespace CoffeeManagementSystem.Models.Classes
{
    // Inheritance & Polymorphism: Employee Class (Child)
    public class Employee : APerson
    {
        private DateTime _doB;
        public DateTime DoB 
        { 
            get => _doB; 
            set 
            {
                int age = DateTime.Today.Year - value.Year;
                if (value > DateTime.Today.AddYears(-age)) age--;
                if (age < 18)
                    throw new ArgumentException("Employee must be at least 18 years old.");
                _doB = value;
            } 
        }
        private string _phone;
        public string Phone 
        { 
            get => _phone; 
            set 
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^\+?[0-9]{8,15}$"))
                    throw new ArgumentException("Invalid phone number format.");
                _phone = value;
            } 
        }
        private string _email;
        public string Email 
        { 
            get => _email; 
            set 
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(value, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                    throw new ArgumentException("Invalid email format.");
                _email = value;
            } 
        }
        public string Pos { get; set; }
        public bool StopWork { get; set; }
        public Employee() : base() { }
        public Employee(
            int id,
            string name,
            Gender gender,
            
            DateTime doB,
            string phone,
            string email,
            string pos,
            bool stopWork
            ) : base(id, name, gender)
        {
            DoB = doB;
            Phone = phone;
            Email = email;
            Pos = pos;
            StopWork = stopWork;
        }

        public override string GetSummary()
        {
            return $"{base.GetSummary()} | DateofBirth: {DoB} | Phone: {Phone} | Email: {Email} | Position: {Pos} | StopWork: {StopWork}";
        }
    }
}
