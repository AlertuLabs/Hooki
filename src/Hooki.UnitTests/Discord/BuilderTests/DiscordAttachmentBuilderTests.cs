using FluentAssertions;
using Hooki.Discord.Builders;

namespace Hooki.UnitTests.Discord.BuilderTests;

public class DiscordAttachmentBuilderTests
{
    [Fact]
    public void Build_With_Required_Properties_Returns_Correct_Attachment()
    {
        // Arrange
        var builder = new DiscordAttachmentBuilder()
            .WithId("123")
            .WithFileName("test.txt");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be("123");
        result.FileName.Should().Be("test.txt");

        // Assert that all non-required fields are null
        result.Title.Should().BeNull();
        result.Description.Should().BeNull();
        result.ContentType.Should().BeNull();
        result.Size.Should().BeNull();
        result.Url.Should().BeNull();
        result.ProxyUrl.Should().BeNull();
        result.Height.Should().BeNull();
        result.Width.Should().BeNull();
        result.Ephemeral.Should().BeNull();
        result.DurationSecs.Should().BeNull();
        result.Waveform.Should().BeNull();
        result.Flags.Should().BeNull();
        result.Content.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_Returns_Correct_Attachment()
    {
        // Arrange
        var builder = new DiscordAttachmentBuilder()
            .WithId("123")
            .WithFileName("test.txt")
            .WithTitle("Test Title")
            .WithDescription("Test Description")
            .WithContentType("text/plain")
            .WithSize(100)
            .WithUrl("http://example.com/test.txt")
            .WithProxyUrl("http://proxy.example.com/test.txt")
            .WithHeight(200)
            .WithWidth(300)
            .WithEphemeral(true)
            .WithDurationSecs(10.5f)
            .WithWaveform("waveform-data")
            .WithFlags(1)
            .WithContent([1, 2, 3]);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().Be("123");
        result.FileName.Should().Be("test.txt");
        result.Title.Should().Be("Test Title");
        result.Description.Should().Be("Test Description");
        result.ContentType.Should().Be("text/plain");
        result.Size.Should().Be(100);
        result.Url.Should().Be("http://example.com/test.txt");
        result.ProxyUrl.Should().Be("http://proxy.example.com/test.txt");
        result.Height.Should().Be(200);
        result.Width.Should().Be(300);
        result.Ephemeral.Should().BeTrue();
        result.DurationSecs.Should().Be(10.5f);
        result.Waveform.Should().Be("waveform-data");
        result.Flags.Should().Be(1);
        result.Content.Should().BeEquivalentTo(new byte[] { 1, 2, 3 });
    }
}