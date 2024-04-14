using Goodhabits.Database.Entites;
using GoodHabits.HabitService.Dtos;
using AutoMapper;

namespace GoodHabits.HabitService.Mappers;

public class HabitMapper : Profile
{
  public HabitMapper()
  {
    CreateMap<Habit, HabitDto>();
  }
}