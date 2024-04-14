using Goodhabits.Database.Entites;
using Microsoft.EntityFrameworkCore;
namespace GoodHabits.Database.Entites;

[Index(nameof(Id))]
public class Goal {

  public int Id { get; set; }
  public int HabitId { get; set; }
  public virtual Habit Habit { get; set; } = default!;
}