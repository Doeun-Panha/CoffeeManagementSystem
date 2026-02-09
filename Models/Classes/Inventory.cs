using CoffeeManagementSystem.Models.Interfaces;
using System;
namespace CoffeeManagementSystem.Models.Classes
{
    public class Inventory : ISaleable 
    {
        #region Properties
        public int ID { get; set; }
        public string Name { get; set; }
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
        private int _alertQty;
        public int AlertQty
        {
            get { return _alertQty; }
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("Alert Quantity cannot be negative.");
                _alertQty = value; 
            }
        }
        private int _stockQty;
        public int StockQty
        {
            get { return _stockQty; }
            set 
            { 
                if (value < 0)
                    throw new ArgumentException("Stock Quantity cannot be negative.");
                _stockQty = value; 
            }
        }
        #endregion

        #region Constructors
        public Inventory() { }
        public Inventory(int id, string name, double price, int alertQty, int qty)
        {
            ID = id;
            Name = name;
            Price = price;
            AlertQty = alertQty;
            StockQty = qty;
        }
        #endregion

        public int GetID() => ID;
        public string GetName() => Name;
        public double GetPrice() => Price;
        public string GetDetails() => $"ID: {ID} | Name: {Name} | Price: {Price:C} | Low Stock Alert: {AlertQty} | StockQty: {StockQty}";
        public bool DecreaseStock(int quantity)
        {
            if (StockQty >= quantity)
            {
                StockQty -= quantity;
                return true;
            }
            return false;
        }
    }
}
