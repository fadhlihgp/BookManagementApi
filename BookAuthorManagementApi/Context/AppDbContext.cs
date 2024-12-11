using BookAuthorManagementApi.Data;
using BookAuthorManagementApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorManagementApi.Context;

public class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions options)
        : base(options)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);
    }
    
    public virtual DbSet<User> Users { get; set; }
    
    public virtual DbSet<Author> Authors { get; set; }
    
    public virtual DbSet<Book> Books { get; set; }
    
    public virtual DbSet<Publisher> Publishers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(user =>
        {
            user.HasData(SeedData.Users);
        });

        modelBuilder.Entity<Author>(author =>
        {
            author.HasData(SeedData.Authors);
        });

        modelBuilder.Entity<Publisher>(publisher =>
        {
            publisher.HasData(SeedData.Publishers);
        });
        
        modelBuilder.Entity<Book>(book =>
        {
            book.HasData(SeedData.Books);
           
            book.HasOne(b => b.Author).WithMany(a => a.Books).HasForeignKey(b => b.AuthorId).OnDelete(DeleteBehavior.Cascade);
            book.HasOne(b => b.Publisher).WithMany(p => p.Books).HasForeignKey(b => b.PublisherId).OnDelete(DeleteBehavior.Cascade);
            
        });
    }
}