using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackTextObjectBuilderTests
{
    [Fact]
    public void Build_With_Required_Properties_Returns_Valid_TextObject()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.PlainText)
            .WithText("Hello, World!");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Type.Should().Be(SlackTextObjectType.PlainText);
        result.Text.Should().Be("Hello, World!");
        result.Emoji.Should().BeNull();
        result.Verbatim.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_For_PlainText_Returns_ValidTextObject()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.PlainText)
            .WithText("Hello, World!")
            .WithEmoji(true);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Type.Should().Be(SlackTextObjectType.PlainText);
        result.Text.Should().Be("Hello, World!");
        result.Emoji.Should().BeTrue();
        result.Verbatim.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_For_Markdown_Returns_ValidTextObject()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.Markdown)
            .WithText("*Hello, World!*")
            .WithVerbatim(true);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Type.Should().Be(SlackTextObjectType.Markdown);
        result.Text.Should().Be("*Hello, World!*");
        result.Emoji.Should().BeNull();
        result.Verbatim.Should().BeTrue();
    }

    [Fact]
    public void Build_Without_Type_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithText("Hello, World!");

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Type is required for a TextObject.");
    }

    [Fact]
    public void Build_Without_Text_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.PlainText);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Text is required for a TextObject.");
    }

    [Fact]
    public void Build_With_Empty_Text_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.PlainText)
            .WithText("");

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Text is required for a TextObject.");
    }

    [Fact]
    public void Build_With_Emoji_For_Markdown_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.Markdown)
            .WithText("*Hello, World!*")
            .WithEmoji(true);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Emoji can only be set when Type is PlainText.");
    }

    [Fact]
    public void Build_With_Verbatim_For_PlainText_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(SlackTextObjectType.PlainText)
            .WithText("Hello, World!")
            .WithVerbatim(true);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Verbatim can only be set when Type is Markdown.");
    }

    [Theory]
    [InlineData(SlackTextObjectType.PlainText, true, null)]
    [InlineData(SlackTextObjectType.PlainText, false, null)]
    [InlineData(SlackTextObjectType.Markdown, null, true)]
    [InlineData(SlackTextObjectType.Markdown, null, false)]
    public void Build_With_Valid_Combinations_Returns_Valid_TextObject(SlackTextObjectType type, bool? emoji, bool? verbatim)
    {
        // Arrange
        var builder = new SlackTextObjectBuilder()
            .WithType(type)
            .WithText("Test Text");

        if (emoji.HasValue)
            builder.WithEmoji(emoji.Value);

        if (verbatim.HasValue)
            builder.WithVerbatim(verbatim.Value);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Type.Should().Be(type);
        result.Text.Should().Be("Test Text");
        result.Emoji.Should().Be(emoji);
        result.Verbatim.Should().Be(verbatim);
    }
}