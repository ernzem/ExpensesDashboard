using System.Collections.Generic;
using ExpensesDashboard.Models;

namespace ExpensesDashboard.Data
{
    public class MockExpensesDashRepo : IExpensesDashRepo
    {
        public IEnumerable<Command> GetAllCommands()
        {
            var commands = new List<Command>
            {
                new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"},
                new Command{Id=1, HowTo="Cut a bread", Line="Get a knife", Platform="Knife & chopping board"},
                new Command{Id=2, HowTo="Make a cup of tea", Line="Place teabag in cup", Platform="Kettle & cup"}
            };
            return commands;
        }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, HowTo="Boil an egg", Line="Boil water", Platform="Kettle & Pan"};
        }
    }
}