using System.Collections.Generic;

namespace FinanceApp.Models
{
    public class FinanceViewModel
    {
        public IEnumerable<Income> Incomes { get; set; }
        public IEnumerable<Expense> Expenses { get; set; }
        public double TotalIncome { get; set; }
        public double TotalExpenses { get; set; }
        public double Balance { get; set; }
    }
}