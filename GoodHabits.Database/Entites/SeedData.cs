using Goodhabits.Database.Entites;
using Microsoft.EntityFrameworkCore;

namespace GoodHabits.Database.Entites;

public static class SeedData{
  public static void Seed(ModelBuilder modelBuilder)
  {
    modelBuilder.Entity<Habit>().HasData(
      new Habit { Id = 100, Name = "Learn JeetKuneDo", Description = "Move better", TenantName="CloudSphere" },
      new Habit { Id = 101, Name = "Learn to draw", Description = "Become an artiest", TenantName = "CloudSphere" },
      new Habit { Id = 102, Name = "Write everyday", Description = "a blog my man, a blog!" , TenantName = "CloudSphere" }
    );
  }
}