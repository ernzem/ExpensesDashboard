using ExpensesDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesDashboard.Data
{
    public class CommanderContext : DbContext
    {
        public CommanderContext(DbContextOptions<CommanderContext> opt) : base(opt)
        {

        }
        
        public DbSet<Command> Expenses { get; set; }
    }
}