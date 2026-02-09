using System;

namespace CoffeeManagementSystem.Models.Classes
{
    public class ReportDetail
    {
        public int ID { get; set; }
        public Report report { get; set; }
        public Menu menu { get; set; }
        public int Qty { get; set; }
        public Decimal SubTotal { get; set; }
        public ReportDetail() { }
        public ReportDetail(int id, Report report, Menu menu, int qty, decimal subTotal)
        {
            ID = id;
            this.report = report;
            this.menu = menu;
            Qty = qty;
            SubTotal = subTotal;
        }
    }
}
