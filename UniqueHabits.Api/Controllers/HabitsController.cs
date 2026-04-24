using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniqueHabits.Api.Queries;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.Constants;
using UniqueHabits.Shared.Enums;
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
        private readonly IMediator _mediator;
        public HabitsController(HabitsContext context, IMapper mapper, IUser user, IMediator mediator)
        {
            _context = context;
            _mapper = mapper;
            _user = user;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetHabits()
        {
            // The mediator sends the query to the correct handler automatically
            var result = await _mediator.Send(new HabitListQuery());

            if (result == null || !result.Any())
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool IsByCurrentUser(Habit habit)
        {
            return habit.CreatedById != null && habit.CreatedById.ToLower() == _user.Id.GetValueOrDefault().ToString().ToLower();
        }

        [HttpGet("{habitId}")]
        public async Task<IActionResult> GetHabit(Guid habitId)
        {
            try
            {
                var habit = _context.Habits.Include(h => h.Implementations).ThenInclude(i => i.Steps)
                        .Where(IsByCurrentUser).AsQueryable()
                        .FirstOrDefault(h => h.Id == habitId);

                if (habit == null)
                {
                    return NotFound();
                }
                var model = _mapper.Map<HabitModel>(habit);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddHabit([FromBody] HabitModel habitModel)
        {
            if (await _context.Habits.FindAsync(habitModel.Id) != null)
            {  return BadRequest(); }

            try
            {
                var habit = Habit.Create(habitModel.Id, habitModel.SystemName, habitModel.MeasurableResult, habitModel.Why, 
                    habitModel.StartDate,habitModel.Category.GetValueOrDefault(), habitModel.CategoryDescription, 
                    _user.Id.GetValueOrDefault());

                var steps = habitModel.ImplementationDetails.Steps.Select(s => 
                ImplementationStep.Create(s.Id, s.Step, s.Sequence)).ToList();

                var implementation = Implementation.Create(habitModel.ImplementationDetails.Id, habitModel.Id, 
                    habitModel.ImplementationDetails.WithWhat,habitModel.ImplementationDetails.When, 
                    habitModel.ImplementationDetails.Where, habitModel.ImplementationDetails.WithWhom, steps);

                habit.AddImplementation(implementation);

                await _context.Habits.AddAsync(habit);

                var reviewNotification = Notification.Create(Guid.NewGuid(), "Your habit is due for review",
                    DateTime.Today.AddDays(SettingConstants.SprintLengthInDays), habit.Id, _user.Id.GetValueOrDefault(), NotificationType.ReviewDue);

                await _context.Notifications.AddAsync(reviewNotification);

                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpGet("{habitId}/review")]
        public async Task<IActionResult> ReviewHabit(Guid habitId)
        {
            try
            {
                var habit = _context.Habits.Include(h => h.Implementations).ThenInclude(i => i.Steps)
                        .Where(IsByCurrentUser).AsQueryable()
                        .FirstOrDefault(h => h.Id == habitId);

                if (habit == null)
                {
                    return NotFound();
                }
                var model = _mapper.Map<HabitReviewModel>(habit);

                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
        
        [HttpPost("{habitId}/review")]
        public async Task<IActionResult> AddHabitReview([FromBody] HabitReviewModel model)
        {
            try
            {
                var habit = _context.Habits.Include(h => h.Implementations).ThenInclude(i => i.Steps)
                        .Where(IsByCurrentUser).AsQueryable()
                        .FirstOrDefault(h => h.Id == model.Id);

                if (habit == null)
                    return NotFound("No habit to review");

                var steps = model.Steps.Select(s => ImplementationStep.Create(Guid.NewGuid(), s.Step, s.Sequence)).ToList();

                var review = habit.AddReview(model.Result, model.CustomizationDescription, model.CustomizationCategory, model.When, model.Where, 
                    model.WithWhat, model.WithWhom, steps);

                _context.Implementations.Add(review);

                var reviewNotification = Notification.Create(Guid.NewGuid(), "Your habit is due for review",
                    DateTime.Today.AddDays(SettingConstants.SprintLengthInDays), habit.Id, _user.Id.GetValueOrDefault(), NotificationType.ReviewDue);

                await _context.Notifications.AddAsync(reviewNotification);

                await _context.SaveChangesAsync();

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}