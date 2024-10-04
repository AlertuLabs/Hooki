using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class HeaderBuilderTests
{
    [Fact]
    public void Build_WithAllProperties_ReturnsCorrectHeader()
    {
        // Arrange
        var builder = new HeaderBuilder()
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
        var builder = new HeaderBuilder();

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