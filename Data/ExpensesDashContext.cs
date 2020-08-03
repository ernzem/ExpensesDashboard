using ExpensesDashboard.Models;
using Microsoft.EntityFrameworkCore;

namespace ExpensesDashboard.Data
{
    public class ExpensesDashContext : DbContext
    {
        public ExpensesDashContext(DbContextOptions<ExpensesDashContext> opt) : base(opt)
        {

        }
        
        public DbSet<Transaction> Transactions { get; set; }

    }
}