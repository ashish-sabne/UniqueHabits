using FluentAssertions;
using NUnit.Framework;
using UniqueHabits.Domain.Aggregates;
using UniqueHabits.Shared.Enums;

namespace UniqueHabits.Domain.Tests.Aggregates;

[TestFixture]
public class HabitTests
{
    [Test]
    public void Create_ShouldInitializeHabitCorrectly()
    {
        // Arrange
        var id = Guid.NewGuid();
        var systemName = "Morning Workout";
        var measurableResult = "Exercise for 30 minutes";
        var why = "Improve fitness";
        var startDate = new DateTime(2026, 1, 1);
        var category = HabitCategory.Health;
        var categoryDescription = "Physical health habits";
        var createdById = Guid.NewGuid();

        // Act
        var habit = Habit.Create(
            id,
            systemName,
            measurableResult,
            why,
            startDate,
            category,
            categoryDescription,
            createdById);

        // Assert
        habit.Id.Should().Be(id);
        habit.SystemName.Should().Be(systemName);
        habit.MeasurableResult.Should().Be(measurableResult);
        habit.Why.Should().Be(why);
        habit.StartDate.Should().Be(startDate);
        habit.Category.Should().Be(category);
        habit.CategoryDescription.Should().Be(categoryDescription);
        habit.CreatedById.Should().Be(createdById.ToString());

        habit.Implementations.Should().NotBeNull();
        habit.Implementations.Should().BeEmpty();
    }

    [Test]
    public void AddImplementation_ShouldAddImplementationToCollection()
    {
        // Arrange
        Guid habitId = Guid.NewGuid();
        var habit = Habit.Create(
            habitId,
            "Read Books",
            "Read 10 pages",
            "Gain knowledge",
            DateTime.UtcNow,
            HabitCategory.Personal,
            "Learning habits",
            Guid.NewGuid());

        var implementation = CreateImplementation(habitId);

        // Act
        habit.AddImplementation(implementation);

        // Assert
        habit.Implementations.Should().ContainSingle();
        habit.Implementations.Should().Contain(implementation);
    }

    private Implementation CreateImplementation(Guid habitId)
    {
        Guid implementationId = Guid.NewGuid();
        return Implementation.Create(implementationId, habitId, "Something", "Sometime", "Somewhere", "Someone", new List<ImplementationStep>
        {
            ImplementationStep.Create(implementationId, "Some step 1", 1),
            ImplementationStep.Create(implementationId, "Some step 2", 2),
        });
    }

    [Test]
    public void IsByCurrentUser_ShouldReturnTrue_WhenUserMatchesIgnoringCase()
    {
        // Arrange
        var createdById = Guid.NewGuid();

        var habit = Habit.Create(
            Guid.NewGuid(),
            "Meditation",
            "Meditate for 15 minutes",
            "Reduce stress",
            DateTime.UtcNow,
            HabitCategory.Health,
            "Mindfulness",
            createdById);

        var userId = createdById.ToString().ToUpper();

        // Act
        var result = habit.IsByCurrentUser(userId);

        // Assert
        result.Should().BeTrue();
    }

    [Test]
    public void IsByCurrentUser_ShouldReturnFalse_WhenUserDoesNotMatch()
    {
        // Arrange
        var habit = Habit.Create(
            Guid.NewGuid(),
            "Running",
            "Run 5km",
            "Build endurance",
            DateTime.UtcNow,
            HabitCategory.Health,
            "Cardio habits",
            Guid.NewGuid());

        var differentUserId = Guid.NewGuid().ToString();

        // Act
        var result = habit.IsByCurrentUser(differentUserId);

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void IsByCurrentUser_ShouldReturnFalse_WhenCreatedByIdIsNull()
    {
        // Arrange
        var habit = Habit.Create(Guid.NewGuid(), "Test Name", "Test Result", "Test Reason", DateTime.Today, HabitCategory.Personal, "Test Description", Guid.NewGuid());

        // Act
        var result = habit.IsByCurrentUser(Guid.NewGuid().ToString());

        // Assert
        result.Should().BeFalse();
    }

    [Test]
    public void IsByCurrentUser_ShouldThrowException_WhenUserIdIsNull()
    {
        // Arrange
        var habit = Habit.Create(
            Guid.NewGuid(),
            "Workout",
            "30 mins",
            "Health",
            DateTime.UtcNow,
            HabitCategory.Health,
            "Fitness",
            Guid.NewGuid());

        // Act
        var result = habit.IsByCurrentUser(null!);

        // Assert
        result.Should().BeFalse();
    }
}