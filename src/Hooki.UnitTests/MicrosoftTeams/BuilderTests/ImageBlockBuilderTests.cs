using FluentAssertions;
using Hooki.MicrosoftTeams.Builders;

namespace Hooki.UnitTests.MicrosoftTeams.BuilderTests;

public class ImageBlockBuilderTests
{
    private const string TestImageUrl = "https://example.com/image.jpg";
    private const string Title = "Test Image";
    
    [Fact]
    public void Build_With_All_Properties_Returns_Correct_Image()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithImageUrl(TestImageUrl)
            .WithTitle(Title);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.ImageUrl.Should().Be(TestImageUrl);
        result.Title.Should().Be(Title);
    }

    [Fact]
    public void Build_With_Minimum_Properties_Returns_Correct_Image()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithImageUrl(TestImageUrl);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.ImageUrl.Should().Be(TestImageUrl);
        result.Title.Should().BeNull();
    }

    [Fact]
    public void Build_Without_ImageUrl_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithTitle(Title);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("ImageUrl is required");
    }
}