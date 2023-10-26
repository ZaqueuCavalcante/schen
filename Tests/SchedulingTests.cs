using NUnit.Framework;
using FluentAssertions;

namespace Schen.Tests;

public class SchedulingTests
{
    [Test]
    public void SchedulingTests_00()
    {
        // Arrange
        var id = Guid.NewGuid();

        // Act
        var otherId = Guid.NewGuid();

        // Assert
        id.Should().NotBe(otherId);
    }
}
