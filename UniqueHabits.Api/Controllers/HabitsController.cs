using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.User;
using ImplementationStep = UniqueHabits.Domain.Aggregates.ImplementationStep;

namespace UniqueHabits.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly HabitsContext _context;
        private readonly IMapper _mapper;
        private readonly IUser _user;
        public HabitsController(HabitsContext context, IMapper mapper, IUser user)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
        }

        [HttpGet]
        public async Task<IActionResult> GetHabits()
        {
            Guid userId;

            var habits = await _context.Habits.Where(h => h.CreatedById.ToLower() == _user.Id.GetValueOrDefault().ToString().ToLower()).ToListAsync();

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

            try
            {
                var habit = Habit.Create(habitModel.Id, habitModel.SystemName, habitModel.MeasurableResult, habitModel.Why, habitModel.StartDate,
                    habitModel.Category.GetValueOrDefault(), habitModel.CategoryDescription, _user.Id.GetValueOrDefault());

                var steps = habitModel.ImplementationDetails.Steps.Select(s => ImplementationStep.Create(s.Id, s.Step, s.Sequence)).ToList();

                var implementation = Implementation.Create(habitModel.ImplementationDetails.Id, habitModel.Id, habitModel.ImplementationDetails.WithWhat,
                    habitModel.ImplementationDetails.When, habitModel.ImplementationDetails.Where, habitModel.ImplementationDetails.WithWhom, steps);

                habit.AddImplementation(implementation);

                await _context.Habits.AddAsync(habit);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(message);
            }
        }

        [HttpGet("{habitId}/review")]
        public async Task<IActionResult> ReviewHabit(Guid habitId)
        {
            var habit = await _context.Habits.FindAsync(habitId);

            if (habit == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<HabitReviewModel>(habit);

            return Ok(model);
        }
        
        [HttpPost("{habitId}/review")]
        public async Task<IActionResult> AddHabitReview([FromBody] HabitReviewModel model)
        {
            try
            {
                var habit = await _context.Habits.FindAsync(model.Id);

                if (habit == null)
                    return NotFound("No habit to review");

                var steps = model.Steps.Select(s => ImplementationStep.Create(Guid.NewGuid(), s.Step, s.Sequence)).ToList();

                habit.AddReview(model.Result, model.CustomizationDescription, model.CustomizationCategory, model.When, model.Where, model.WithWhat,
                    model.WithWhom, steps);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return BadRequest(message);
            }
        }
    }
}