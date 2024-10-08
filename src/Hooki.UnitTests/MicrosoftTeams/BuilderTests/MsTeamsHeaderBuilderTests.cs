using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class MsTeamsHeaderBuilderTests
{
    [Fact]
    public void Build_WithAllProperties_ReturnsCorrectHeader()
    {
        // Arrange
        var builder = new MsTeamsHeaderBuilder()
            .WithName("Test Name")
            .WithValue("Test Value");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Name.Should().Be("Test Name");
        result.Value.Should().Be("Test Value");
    }

    [Fact]
    public void Build_WithoutProperties_ThrowsInvalidOperationException()
    {
        // Arrange
        var builder = new MsTeamsHeaderBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Name is required for Header.");

        builder.WithName("Test Name")
            .Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Value is required for Header.");
    }
}