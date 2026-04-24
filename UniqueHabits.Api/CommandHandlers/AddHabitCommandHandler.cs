using Microsoft.EntityFrameworkCore;
using UniqueHabits.Api.Commands;
using UniqueHabits.Api.Shared;
using UniqueHabits.Contracts.Api;
using UniqueHabits.Contracts.Models;
using UniqueHabits.Data;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.Constants;
using UniqueHabits.Shared.Enums;
using UniqueHabits.Shared.User;
using UniqueHabits.Shared.Helpers;

namespace UniqueHabits.Api.CommandHandlers
{
    public class AddHabitCommandHandler : HabitCommandHandlerBase<AddHabitCommand, HabitModel>
    {
        private readonly IUser _user;
        private readonly HabitsContext _context;

        public AddHabitCommandHandler(IUser user, HabitsContext context) : base(user)
        {
            _user = user;
            _context = context;
        }
        public override async Task<HabitModel> Handle(AddHabitCommand request, CancellationToken cancellationToken)
        {
            var habitModel = request.Habit;

            if (habitModel == null || habitModel.Id.IsEmpty())
                return null;

            try
            {
                var habit = Habit.Create(habitModel.Id, habitModel.SystemName, habitModel.MeasurableResult, habitModel.Why,
                    habitModel.StartDate, habitModel.Category.GetValueOrDefault(), habitModel.CategoryDescription,
                    _user.Id.GetValueOrDefault());

                var steps = habitModel.ImplementationDetails.Steps.Select(s =>
                Domain.Aggregates.ImplementationStep.Create(s.Id, s.Step, s.Sequence)).ToList();
                var implementation = Implementation.Create(habitModel.ImplementationDetails.Id, habitModel.Id,
                habitModel.ImplementationDetails.WithWhat, habitModel.ImplementationDetails.When,
                    habitModel.ImplementationDetails.Where, habitModel.ImplementationDetails.WithWhom, steps);

                habit.AddImplementation(implementation);

                await _context.Habits.AddAsync(habit);

                var reviewNotification = Notification.Create(Guid.NewGuid(), "Your habit is due for review",
                    DateTime.Today.AddDays(SettingConstants.SprintLengthInDays), habit.Id, _user.Id.GetValueOrDefault(), NotificationType.ReviewDue);

                await _context.Notifications.AddAsync(reviewNotification, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return habitModel;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
