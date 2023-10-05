using Bogus;
using UniqueHabit.Domain.Aggregates;

namespace UniqueHabits.Data
{
    public class HabitService : IHabitService
    {
        private List<Habit> _habitList = new ();

        public void AddHabit(Habit habit)
        {
            if (habit == null || string.IsNullOrEmpty(habit.What))
                throw new ArgumentNullException("Habit cannot be empty");

            if (_habitList.Any(h => h.Id == habit.Id))
                throw new InvalidOperationException("Habit already exists");

            if (habit.StartDate <  DateTime.Today)
                throw new InvalidOperationException("Habit cannot be recorded in the past");

            _habitList.Add(habit);

        }

        public IEnumerable<Habit> GetHabits()
        {
            //if (_habitList.Any())
            //    return _habitList;
            //var faker = new Faker();

            //var count = faker.Random.Int(5, 10);

            //for (int i = 0; i < count; i++)
            //{
            //    var habit = Habit.Create(Guid.NewGuid(), faker.Lorem.Sentence(), faker.Lorem.Paragraph(), faker.Date.Past(), faker.PickRandom<TemplateCategory>());
            //    _habitList.Add(habit);
            //}
            return _habitList;
        }
    }
}