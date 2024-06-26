namespace GoodHabits.Database.Entites;
using Microsoft.EntityFrameworkCore;

[Index(nameof(Id))]
public class User
{
  public int Id { get; set; }
  public string FirstName { get; set; } = default!;
  public string LastName { get; set; } = default!;
  public string Email { get; set; } = default!;
}