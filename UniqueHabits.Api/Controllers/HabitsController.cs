using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;

namespace UniqueHabits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly HabitsContext _context;
        public HabitsController(HabitsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetHabits()
        {
            var habits = await _context.Habits.ToListAsync();

            if (habits == null || !habits.Any())
            {
                return NotFound();
            }

            return Ok(habits);
        }

        [HttpPost]
        public async Task<IActionResult> AddHabit([FromBody] Habit habit)
        {
            if (await _context.Habits.FindAsync(habit.Id) != null)
            {  return BadRequest(); }

            await _context.Habits.AddAsync(habit);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
