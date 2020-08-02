using System.Collections.Generic;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Data
{
    public interface IExpensesDashRepo
    {   
        bool SaveChanges();
        IEnumerable<Command> GetAllExpenses();
        Command GetExpenseById(int id);
        void CreateExpense(Command cmd);
        void UpdateExpense(Command cmd);
    }
}