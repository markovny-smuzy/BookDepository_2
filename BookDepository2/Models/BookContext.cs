using Microsoft.EntityFrameworkCore;

namespace BookDepository2.Models;

public class BookContext : DbContext
{
    public DbSet<ConcreteBook> Books { get; set; } // Набор данных для книг

    public BookContext(DbContextOptions<BookContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Конфигурация маппинга
        modelBuilder.Entity<ConcreteBook>(entity =>
        {
            entity.HasKey(b => b.Id);
            entity.Property(b => b.GenresSerialized).IsRequired();
        });
    }
}