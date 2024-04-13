using System.Collections.Immutable;
using Goodhabits.Database.Entites;
using GoodHabits.Database;
using Microsoft.EntityFrameworkCore;

namespace GoodHabits.HabitService;

public class HabitService : IHabitService
{
  public readonly GoodHabitsDbContext _habitsDbContext;

  public HabitService(GoodHabitsDbContext habitsDbContext)
  {
    _habitsDbContext = habitsDbContext;
  }
  public async Task<Habit> Create(string name, string description)
  {
    var habit = _habitsDbContext.Habits!.Add(new Habit { Name = name, Description = description }).Entity;
    await _habitsDbContext.SaveChangesAsync();
    return habit;
  }

  public async Task<IReadOnlyList<Habit>> GetAll()
  {
    return await _habitsDbContext.Habits!.ToListAsync();
  }

  public async Task<Habit> GetById(int iden)
  {
    return await _habitsDbContext.Habits.FindAsync(iden);
  }
}