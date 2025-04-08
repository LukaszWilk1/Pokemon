using Microsoft.EntityFrameworkCore;
using Pokemon.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}
    public DbSet<Trainer> Trainers {get; set;}
}