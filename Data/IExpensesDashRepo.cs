using System.Collections.Generic;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Data
{
    public interface IExpensesDashRepo
    {   
        bool SaveChanges();
        IEnumerable<Transaction> GetAllExpenses();
        Transaction GetExpenseById(int id);
        void CreateExpense(Transaction trn);
        void UpdateExpense(Transaction trn);
        void DeleteExpense(Transaction trn);
    }
}