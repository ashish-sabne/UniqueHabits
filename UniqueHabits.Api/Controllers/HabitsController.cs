using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqueHabits.Contracts;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;
using ImplementationStep = UniqueHabits.Domain.Aggregates.ImplementationStep;

namespace UniqueHabits.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly HabitsContext _context;
        private readonly IMapper _mapper;
        public HabitsController(HabitsContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetHabits()
        {
            var habits = await _context.Habits.ToListAsync();

            if (habits == null || !habits.Any())
            {
                return NotFound();
            }
            var models = _mapper.Map<List<HabitModel>>(habits);

            return Ok(models);
        }
        
        [HttpGet("{habitId}")]
        public async Task<IActionResult> GetHabit(Guid habitId)
        {
            var habit = await _context.Habits.FindAsync(habitId);

            if (habit == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<HabitModel>(habit);

            return Ok(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddHabit([FromBody] HabitModel habitModel)
        {
            if (await _context.Habits.FindAsync(habitModel.Id) != null)
            {  return BadRequest(); }

            var habit = Habit.Create(habitModel.Id, habitModel.SystemName, habitModel.MeasurableResult, habitModel.Why, habitModel.StartDate, habitModel.Category.GetValueOrDefault(),
                habitModel.CategoryDescription);

            var steps = habitModel.ImplementationDetails.Steps.Select(s => ImplementationStep.Create(s.Id, s.Step, s.Sequence)).ToList();

            var implementation = Implementation.Create(habitModel.ImplementationDetails.Id, habitModel.Id, habitModel.ImplementationDetails.WithWhat, habitModel.ImplementationDetails.When,
                            habitModel.ImplementationDetails.Where, habitModel.ImplementationDetails.WithWhom, steps);

            habit.AddImplementation(implementation);

            await _context.Habits.AddAsync(habit);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
