using System.Data.Entity;

namespace FinanceApp.Models
{
    public class FinanceContext : DbContext
    {
        public FinanceContext() : base("FinanceDatabase")
        {
        }

        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expense> Expenses { get; set; }
    }
}