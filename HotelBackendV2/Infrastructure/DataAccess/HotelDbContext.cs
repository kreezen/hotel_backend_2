using Domain.Activities;
using Domain.Customer;
using Domain.Invoice;
using Domain.Users;
using Task = Domain.Activities.Task;
using Microsoft.EntityFrameworkCore;


public class HotelDbContext : DbContext
{

    public HotelDbContext(DbContextOptions<HotelDbContext> options) : base(options)
    {
    }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<Debitor> Debitors { get; set; }
    public DbSet<Activity> Activities { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Email> Emails { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Address> Adresses { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Relationship between Customer and Activity
        modelBuilder.Entity<Activity>()
                    .HasOne<Customer>() // No need to specify the navigation property
                    .WithMany(c => c.Activities)
                    .HasForeignKey(a => a.CustomerId);

        // Relationships between Customer and derived Activity types
        modelBuilder.Entity<Task>()
                    .HasOne<Customer>()
                    .WithMany()
                    .HasForeignKey(t => t.CustomerId);

        modelBuilder.Entity<Email>()
                    .HasOne<Customer>()
                    .WithMany()
                    .HasForeignKey(e => e.CustomerId);
    }

}

