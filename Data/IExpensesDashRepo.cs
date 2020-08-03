using System.Collections.Generic;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Data
{
    public interface IExpensesDashRepo
    {   
        bool SaveChanges();
        IEnumerable<Transaction> GetAllTransactions();
        Transaction GetTransactionById(int id);
        void CreateTransaction(Transaction trn);
        void UpdateTransaction(Transaction trn);
        void DeleteTransaction(Transaction trn);
    }
}