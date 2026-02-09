using CoffeeManagementSystem.Models.Enum;
using System;

namespace CoffeeManagementSystem.Models.Abstract_Classes
{
    // Inheritance: Abstract Person Class (Parent) 
    public abstract class APerson
    {
        public int ID { get; set; }
        private string _name;
        public string Name 
        { 
            get => _name; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name cannot be empty.");
                _name = value.Trim();
            } 
        }
        public Gender Gender { get; set; }
        public APerson() { }
        public APerson(int id, string name, Gender gender)
        {
            ID = id;
            Name = name;
            Gender = gender;
        }

        public virtual string GetSummary()
        {
            return $"ID: {ID} | Name: {Name} | Gender: {Gender}";
        }
    }
}
