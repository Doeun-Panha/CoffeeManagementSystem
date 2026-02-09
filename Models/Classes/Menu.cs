using CoffeeManagementSystem.Models.Interfaces;
using System;

namespace CoffeeManagementSystem.Models.Classes
{
    // Encapsulation & Abstraction
    public class Menu : ISaleable
    {
        public int ID { get; set; }
        private string _name;
        public string Name 
        { 
            get => _name; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Name is required.");
                _name = value.Trim();
            } 
        }
        private string _type;
        public string Type 
        { 
            get => _type; 
            set 
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Type is required.");
                _type = value.Trim();
            } 
        }
        public string Desc { get; set; }
        private double _price;
        public double Price
        {
            get { return _price; }
            set 
            { 
                if (value <= 0)
                    throw new ArgumentException("Price must be greater than zero.");
                _price = value; 
            }
        }

        public Menu() { }
        public Menu(int id, string name, string type, string desc, double price)
        {
            ID = id;
            Name = name;
            Type = type;
            Desc = desc;
            Price = price;
        }

        public int GetID() => ID;
        public string GetName() => Name;
        public double GetPrice() => Price;
        public string GetDetails() => $"ID: {ID} | Name: {Name} | Type: {Type} | Description: {Desc}| Price: {Price:C}";
    }
}
