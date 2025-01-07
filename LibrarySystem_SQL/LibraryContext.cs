
// manages the database connection and tables
using Microsoft.EntityFrameworkCore;

public class LibraryContext : DbContext
{
    // DbSet properties represent tables in the database
    public DbSet<LibraryItem> LibraryItems { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Magazine> Magazines { get; set; }
    public DbSet<DVD> DVDs { get; set; }

    // Configure the database connection
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=LAPTOP-SJVUH3N3\\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    // Configure the relationships between tables
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure the inheritance hierarchy
        modelBuilder.Entity<LibraryItem>()
            .HasDiscriminator<ItemType>(item => item.Type)
            .HasValue<Book>(ItemType.Book)
            .HasValue<Magazine>(ItemType.Magazine)
            .HasValue<DVD>(ItemType.DVD);
    }
}