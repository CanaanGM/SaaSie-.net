namespace GoodHabits.Database.Entites;

using Goodhabits.Database.Entites;
using Microsoft.EntityFrameworkCore;
[Index(nameof(Id))]
public class Progress
{
  public int Id { get; set; }
  public DateTime Date { get; set; }
  public int HabitId { get; set; }
  public virtual Habit Habit { get; set; } = default!;
}