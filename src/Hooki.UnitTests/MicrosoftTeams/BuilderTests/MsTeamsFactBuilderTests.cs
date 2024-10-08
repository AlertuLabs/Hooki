using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class MsTeamsFactBuilderTests
{
    [Fact]
    public void Build_With_All_Properties_Returns_Correct_Fact()
    {
        // Arrange
        var builder = new MsTeamsFactBuilder()
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
    public void Build_Without_Properties_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new MsTeamsFactBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Name is required");

        builder.WithName("Test Name")
            .Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Value is required");
    }
}