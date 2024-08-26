using System;

namespace FinanceApp.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Category { get; set; }
        public string Date { get; set; }
    }
}