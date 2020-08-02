using System;
using System.Collections.Generic;
using System.Linq;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Data
{
    public class SqlExpensesDashRepo : IExpensesDashRepo
    {
        private readonly ExpensesDashContext _context;

        public SqlExpensesDashRepo(ExpensesDashContext context)
        {
            _context = context;   
        }

        public void CreateExpense(Command cmd)
        {
            if(cmd == null)
            {
                throw new ArgumentNullException(nameof(cmd));
            }

            _context.Expenses.Add(cmd);
        }

        public IEnumerable<Command> GetAllExpenses()
        {
            return _context.Expenses.ToList();
        }

        public Command GetExpenseById(int id)
        {
            return _context.Expenses.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateExpense(Command cmd)
        {
            // Nothing, because DbContext doesn't need update command
        }
    }
}