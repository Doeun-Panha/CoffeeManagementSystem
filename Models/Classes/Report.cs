using System;
using CoffeeManagementSystem.Models.Interfaces;
using CoffeeManagementSystem.Models.Classes;

namespace CoffeeManagementSystem.Models.Classes
{
    // Composition
    public class Report
    {
        public int ID { get; set; }
        public Employee Emp { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public double Received { get; set; }
        public double Change { get; set; }
        public Report() { }
        public Report(int id, Employee emp, DateTime date, double total, double received, double change)
        {
            ID = id;
            Emp = emp;
            Date = date;
            Total = total;
            Received = received;
            Change = change;
        }
    }
}
