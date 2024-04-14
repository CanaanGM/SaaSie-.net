using System.Collections;
using GoodHabits.Database.Entites;
using GoodHabits.Database.Interfaces;
using Microsoft.EntityFrameworkCore;
namespace Goodhabits.Database.Entites;

[Index(nameof(Name), nameof(Id))]
public class Habit : IHasTenant{
  public int Id { get; set; }
  public string Name { get; set; } = default!;
  public string Description { get; set; } = default!;
  public int UserId { get; set; }
  public virtual ICollection<Reminder> Reminders { get; set; } = default!;
  public virtual Goal Goal { get; set; } = default!;
  public Duration Duration { get; set; }
  public string TenantName { get; set; } = default!;
}

public enum Duration { DayLong, WeekLong, MonthLong }