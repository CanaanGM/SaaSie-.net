using Goodhabits.Database.Entites;
using GoodHabits.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace GoodHabits.Database;

public class GoodHabitDbContext : DbContext {
  public DbSet<Habit>? Habits { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=sqlserver; Database=GoodHabitsDatabase; User Id=sa; Password=Password1;Integrated Security=false;TrustServerCertificate=true;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        SeedData.Seed(modelBuilder);
    }
}