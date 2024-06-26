namespace GoodHabits.Database.Entites;

using Goodhabits.Database.Entites;
using Microsoft.EntityFrameworkCore;
[Index(nameof(Id))]
public class Reminder
{
  public int Id { get; set; }
  public Frequency Frequency { get; set; }
  public int HabitId { get; set; }
  public virtual Habit Habit { get; set; } = default!;
}
public enum Frequency { Daily, Weekly, Monthly }