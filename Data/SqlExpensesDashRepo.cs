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
        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Expenses.ToList();
        }

        public Command GetCommandById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}