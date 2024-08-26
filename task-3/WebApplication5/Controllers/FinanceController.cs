using System;
using System.Linq;
using System.Web.Mvc;
using FinanceApp.Models;

namespace FinanceApp.Controllers
{
    public class FinanceController : Controller
    {
        private FinanceContext db = new FinanceContext();

        // Отображение списка доходов и расходов
        public ActionResult Index()
        {
            var incomes = db.Incomes.ToList();
            var expenses = db.Expenses.ToList();
            var viewModel = new FinanceViewModel
            {
                Incomes = incomes,
                Expenses = expenses,
                TotalIncome = incomes.Sum(i => i.Amount),
                TotalExpenses = expenses.Sum(e => e.Amount),
                Balance = incomes.Sum(i => i.Amount) - expenses.Sum(e => e.Amount)
            };

            return View(viewModel);
        }

        // Страница добавления дохода
        public ActionResult AddIncome()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddIncome(Income income)
        {
            if (ModelState.IsValid)
            {
                db.Incomes.Add(income);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(income);
        }

        // Страница добавления расхода
        public ActionResult AddExpense()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddExpense(Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(expense);
        }

        // Отчеты
        public ActionResult Report()
        {
            var incomes = db.Incomes.ToList();
            var expenses = db.Expenses.ToList();
            ViewBag.TotalIncome = incomes.Sum(i => i.Amount);
            ViewBag.TotalExpenses = expenses.Sum(e => e.Amount);
            ViewBag.Balance = ViewBag.TotalIncome - ViewBag.TotalExpenses;

            return View(new { Incomes = incomes, Expenses = expenses });
        }
    }
}