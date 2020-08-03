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

        public void CreateExpense(Transaction trn)
        {
            if(trn == null)
            {
                throw new ArgumentNullException(nameof(trn));
            }

            _context.Transactions.Add(trn);
        }

        public void DeleteExpense(Transaction trn)
        {
            if(trn == null)
            {
                throw new ArgumentNullException(nameof(trn));
            }
            _context.Transactions.Remove(trn);
        }

        public IEnumerable<Transaction> GetAllExpenses()
        {
            return _context.Transactions.ToList();
        }

        public Transaction GetExpenseById(int id)
        {
            return _context.Transactions.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateExpense(Transaction trn)
        {
            // Nothing, because DbContext doesn't need update command
        }
    }
}