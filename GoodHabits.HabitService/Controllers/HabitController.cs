using GoodHabits.HabitService.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace GoodHabits.HabitService.Controllers;

[ApiController]
[Route("[controller]")]
public class HabitController : ControllerBase {
  private readonly ILogger<HabitController> _logger;
  private readonly IHabitService _habitService;

  public HabitController(ILogger<HabitController> logger, IHabitService habitService)
  {
    _logger = logger;
    _habitService = habitService;
  }

  [HttpGet("{id}")]
  public async Task<IActionResult> GetAsync(int id) => Ok(await _habitService.GetById(id));

  [HttpGet]
  public async Task<IActionResult> GetAsync() => Ok(await _habitService.GetAll());

  [HttpPost]
  public async Task<IActionResult> CreateAsync(CreateHabitDto request) => Ok(await _habitService.Create(request.Name, request.Description));

}