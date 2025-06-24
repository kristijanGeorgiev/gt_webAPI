using HomeServices.Domain.Entities;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<WorkPosition> WorkPositions { get; set; }
    public DbSet<BookingStatus> BookingStatus { get; set; }
    public DbSet<BookingEmployee> BookingEmployees { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    public DbSet<Feedback> Feedbacks { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Note> Notes { get; set; }
    public DbSet<CompanyInfo> CompanyInfo { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new BookingConfiguration());
        modelBuilder.ApplyConfiguration(new UserConfiguration());
        modelBuilder.ApplyConfiguration(new BookingEmployeeConfiguration());
        modelBuilder.ApplyConfiguration(new BookingStatusConfiguration());
        modelBuilder.ApplyConfiguration(new WorkPositionConfiguration());
        modelBuilder.ApplyConfiguration(new FeedbackConfiguration());
        modelBuilder.ApplyConfiguration(new NotificationConfiguration());
        modelBuilder.ApplyConfiguration(new InvoiceConfiguration());
        modelBuilder.ApplyConfiguration(new NoteConfiguration());
        modelBuilder.ApplyConfiguration(new CompanyInfoConfiguration());

        modelBuilder.Entity<BookingStatus>().HasData(
       new BookingStatus { Id = 1, StatusName = "Pending" },
       new BookingStatus { Id = 2, StatusName = "Approved" },
       new BookingStatus { Id = 3, StatusName = "In Progress" },
       new BookingStatus { Id = 4, StatusName = "Completed" },
       new BookingStatus { Id = 5, StatusName = "Cancelled" }
   );
        modelBuilder.Entity<User>().HasData(
    new User
    {
        UserId = 1,
        Username = "admin",
        Email = "kristijan.georg@gmail.com",
        Password = "admin123",
        PhoneNumber = "076221915",
        Role = "Admin",
        CreatedAt = new DateTime(2024, 01, 01),
        UpdatedAt = new DateTime(2024, 01, 01),
        FirstName = "System",
        LastName = "Administrator",
        DateOfBirth = new DateTime(2000, 1, 1),
        Address = "Main Office"
    }
);
        modelBuilder.Entity<Service>().HasData(
        new Service
        {
           ServiceID = 1,
           Name = "General Cleaning",
           Description = "Full home or office cleaning service",
           Price = 2500,
            UnitOfMeasure = "per day",
            IsAvailable = true,
           Image = "cleaning.jpg"
        },
        new Service
        {
           ServiceID = 2,
           Name = "Plumbing",
           Description = "Fixing leaks, clogged drains, and pipe installations",
           Price = 600,
            UnitOfMeasure = "visit",
            IsAvailable = true,
           Image = "plumbing.jpg"
        },
        new Service
        {
           ServiceID = 3,
           Name = "Electrical Repair",
           Description = "Installation and repair of electrical systems",
           Price = 600,
            UnitOfMeasure = "visit",
            IsAvailable = true,
           Image = "electrical.jpg"
        },
        new Service
        {
           ServiceID = 4,
           Name = "Painting",
           Description = "Interior and exterior painting services",
           Price = 60,
            UnitOfMeasure = "m²",
            IsAvailable = true,
           Image = "painting.jpg"
        },
        new Service
        {
           ServiceID = 5,
           Name = "Furniture Assembly",
           Description = "Assembly of household or office furniture",
           Price = 50,
            UnitOfMeasure = "m",
            IsAvailable = true,
           Image = "furniture.jpg"
        },
        new Service
        {
            ServiceID = 6,
            Name = "Machine Floor Cleaning",
            Description = "High-efficiency cleaning of industrial or commercial floors using automated machines.",
            Price = 100,
            UnitOfMeasure = "m²",
            IsAvailable = true,
            Image = "machine-floor.jpg"
        },
        new Service
        {
           ServiceID = 7,
           Name = "Dry Cleaning",
           Description = "Professional dry cleaning of garments, suits, and delicate fabrics.",
           Price = 100,
            UnitOfMeasure = "m²",
            IsAvailable = true,
           Image = "dry-cleaning.jpg"
        },
        new Service
        {
            ServiceID = 8,
            Name = "Carpet Cleaning",
            Description = "Professional cleaning of carpets.",
            Price = 100,
            UnitOfMeasure = "m²",
            IsAvailable = true,
            Image = "carpet.jpg"
        }
     );

    }
}
