using FluentAssertions;
using Hooki.Discord.Builders;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class DiscordEmbedBuilderTests
{
    [Fact]
    public void Build_With_All_Properties_Returns_Correct_Embed()
    {
        const int hexColor = 959721;
        const string url = "http://example.com";
        const string imageUrl = "http://example.com/footer.png";
        var timestamp = DateTimeOffset.UtcNow;
        
        // Arrange
        var builder = new DiscordEmbedBuilder()
            .WithTitle("Test Title")
            .WithDescription("Test Description")
            .WithUrl(url)
            .WithTimestamp(timestamp)
            .WithColor(hexColor)
            .WithFooter("Test Footer", imageUrl)
            .WithImage(imageUrl)
            .WithThumbnail(imageUrl)
            .WithAuthor("Test Author", "http://example.com/author", imageUrl)
            .AddField("Field 1", "Value 1", true)
            .AddField("Field 2", "Value 2", false);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().Be("Test Title");
        result.Description.Should().Be("Test Description");
        result.Url.Should().Be(url);
        result.Timestamp.Should().Be(timestamp);
        result.Color.Should().Be(hexColor);

        result.Footer.Should().NotBeNull();
        result.Footer?.Text.Should().Be("Test Footer");
        result.Footer?.IconUrl.Should().Be(imageUrl);

        result.Image.Should().NotBeNull();
        result.Image?.Url.Should().Be(imageUrl);

        result.Thumbnail.Should().NotBeNull();
        result.Thumbnail?.Url.Should().Be(imageUrl);

        result.Author.Should().NotBeNull();
        result.Author?.Name.Should().Be("Test Author");
        result.Author?.Url.Should().Be("http://example.com/author");
        result.Author?.IconUrl.Should().Be(imageUrl);

        result.Fields.Should().NotBeNull().And.HaveCount(2);
        result.Fields?[0].Name.Should().Be("Field 1");
        result.Fields?[0].Value.Should().Be("Value 1");
        result.Fields?[0].Inline.Should().BeTrue();
        result.Fields?[1].Name.Should().Be("Field 2");
        result.Fields?[1].Value.Should().Be("Value 2");
        result.Fields?[1].Inline.Should().BeFalse();
    }

    [Fact]
    public void Build_With_No_Properties_Returns_Empty_Embed()
    {
        // Arrange
        var builder = new DiscordEmbedBuilder();

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().BeNull();
        result.Description.Should().BeNull();
        result.Url.Should().BeNull();
        result.Timestamp.Should().BeNull();
        result.Color.Should().BeNull();
        result.Footer.Should().BeNull();
        result.Image.Should().BeNull();
        result.Thumbnail.Should().BeNull();
        result.Author.Should().BeNull();
        result.Fields.Should().BeNull();
    }
}