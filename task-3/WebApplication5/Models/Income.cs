using System;

namespace FinanceApp.Models
{
    public class Income
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Source { get; set; }
        public string Date { get; set; }
    }
}