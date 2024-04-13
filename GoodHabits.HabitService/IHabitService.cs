using Goodhabits.Database.Entites;

namespace GoodHabits.HabitService;

public interface IHabitService{
  Task<Habit> Create (string name, string description);
  Task<Habit> GetById(int id);
  Task<IReadOnlyList<Habit>> GetAll();
}