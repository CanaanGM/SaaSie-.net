using System.Collections.Immutable;
using Goodhabits.Database.Entites;
using GoodHabits.Database;
using GoodHabits.HabitService.Dtos;
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

  public async Task<Habit?> UpdateById(int id, UpdateHabitDto request)
  {
    var habit = await _habitsDbContext.Habits!.FindAsync(id) ;
    if (habit is null) return null;

    habit.Name = request.Name;
    habit.Description = request.Description;
    await _habitsDbContext.SaveChangesAsync();
    return habit;
  }

  public async Task DeleteById(int id)
  {
    var habit = await _habitsDbContext.Habits!.FindAsync(id)
      ?? throw new ArgumentException("User Not Found");

    _habitsDbContext.Habits.Remove(habit);
    await _habitsDbContext.SaveChangesAsync();
  }
}