using Schen.Code;
using NUnit.Framework;
using FluentAssertions;

namespace Schen.Tests;

public class TaskComparerTests
{
    [Test]
    public void TaskComparerTests_00()
    {
        // Arrange
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(null, null);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void TaskComparerTests_01()
    {
        // Arrange
        var x = new Tarefa { Name = "Play music" };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(x, null);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void TaskComparerTests_02()
    {
        // Arrange
        var y = new Tarefa { Name = "Print PDF" };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(null, y);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void TaskComparerTests_03()
    {
        // Arrange
        var x = new Tarefa { Name = "Play music", ArrivalInstant = 2, BurstTime = 3, };
        var y = new Tarefa { Name = "Print PDF", ArrivalInstant = 2, BurstTime = 3, };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        result.Should().Be(0);
    }

    [Test]
    public void TaskComparerTests_04()
    {
        // Arrange
        var x = new Tarefa { Name = "Play music", ArrivalInstant = 1, BurstTime = 3, };
        var y = new Tarefa { Name = "Print PDF", ArrivalInstant = 2, BurstTime = 3, };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void TaskComparerTests_05()
    {
        // Arrange
        var x = new Tarefa { Name = "Play music", ArrivalInstant = 2, BurstTime = 3, };
        var y = new Tarefa { Name = "Print PDF", ArrivalInstant = 1, BurstTime = 3, };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        result.Should().Be(1);
    }

    [Test]
    public void TaskComparerTests_06()
    {
        // Arrange
        var x = new Tarefa { Name = "Play music", ArrivalInstant = 2, BurstTime = 1, };
        var y = new Tarefa { Name = "Print PDF", ArrivalInstant = 1, BurstTime = 3, };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        result.Should().Be(-1);
    }

    [Test]
    public void TaskComparerTests_07()
    {
        // Arrange
        var x = new Tarefa { Name = "Play music", ArrivalInstant = 2, BurstTime = 4, };
        var y = new Tarefa { Name = "Print PDF", ArrivalInstant = 1, BurstTime = 3, };
        var comparer = new TaskComparer();

        // Act
        var result = comparer.Compare(x, y);

        // Assert
        result.Should().Be(1);
    }
}
