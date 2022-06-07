using Microsoft.EntityFrameworkCore;
using InAndOut.Models;

// used for create entity of my Item

namespace InAndOut.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) //press 'ctor' and tab twice for constructor
        {

        }

        public DbSet<Item> Items { get; set; }

        public DbSet<Expense> Expenses { get; set; }
    }
}
