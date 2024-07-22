using MarkertplaceApi.Models;
using Microsoft.EntityFrameworkCore;

namespace MarkertplaceApi.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options):base(options)
    {
            
    }
    
    public DbSet<Item> Items { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //data sending
        modelBuilder.Entity<Item>().HasData(
            new Item() { Id = 1, Name = "Camera", Price = 18.99, Description = "It takes photos", QuantityAvailable = 100 },
            new Item() { Id = 2, Name = "Microphone", Price = 30.99, Description = "Best audio quality", QuantityAvailable = 10 },
            new Item() { Id = 3, Name = "Keyboard", Price = 10.99, Description = "Mechanical switches", QuantityAvailable = 30 },
            new Item() { Id = 4, Name = "Mouse", Price = 5.99, Description = "Gamer mouse", QuantityAvailable = 200 },
            new Item() { Id = 5, Name = "Notebook", Price = 999.99, Description = "Good for work", QuantityAvailable = 22 },
            new Item() { Id = 6, Name = "Tablet", Price = 180.99, Description = "Good for drawing", QuantityAvailable = 1 }
        );
    }
}