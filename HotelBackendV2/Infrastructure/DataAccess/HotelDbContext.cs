using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Debitor> Debitors { get; set; }
        //public DbSet<Activity> Activities { get; set; } 
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Address> Adresses { get; set; }

    }
}
