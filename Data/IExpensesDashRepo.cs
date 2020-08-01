using System.Collections.Generic;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Data
{
    public interface IExpensesDashRepo
    {
        IEnumerable<Command> GetAllCommands();
        Command GetCommandById(int id);
    }
}