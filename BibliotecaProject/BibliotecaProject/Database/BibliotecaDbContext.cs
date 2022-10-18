using BibliotecaProject.Models;
using Microsoft.EntityFrameworkCore;

namespace BibliotecaProject.Database
{
    public class BibliotecaDbContext : DbContext
    {
        public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options) : base(options)
        {


        }

        public DbSet<Book> Books { get; set; }
        
        public DbSet<Loan> Loan { get; set; }

        public DbSet<LoanQueue> LoanQueues { get; set; }

        public DbSet<PositionBook> PositionBooks { get; set; }  

        public DbSet<PurchaseQueue> PurchaseQueues { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Parent> Parents { get; set; }

        public DbSet<IdentityCard> IdentityCards { get; set; }

    }
}
