using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using UniqueHabits.Api.Commands;
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
        public async Task<IActionResult> GetHabits(CancellationToken ct)
        {
            try
            {
                // The mediator sends the query to the correct handler automatically
                var result = await _mediator.Send(new HabitListQuery(), ct);

                if (result == null || !result.Any())
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        private bool IsByCurrentUser(Habit habit)
        {
            return habit.CreatedById != null && habit.CreatedById.ToLower() == _user.Id.GetValueOrDefault().ToString().ToLower();
        }

        [HttpGet("{habitId}")]
        public async Task<IActionResult> GetHabit(Guid habitId, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(new HabitDetailsQuery(), ct);

                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddHabit([FromBody] HabitModel habitModel, CancellationToken ct)
        {
            try
            {
                var result = await _mediator.Send(new AddHabitCommand() { Habit = habitModel }, ct);

                if (result == null)
                {
                    return NotFound();
                }
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