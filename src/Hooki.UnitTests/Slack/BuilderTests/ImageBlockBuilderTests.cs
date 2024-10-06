using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;
using Hooki.Slack.Enums;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class ImageBlockBuilderTests
{
    private readonly TextObject _validAltText = new TextObject { Text = "Alt Text", Type = TextObjectType.PlainText };

    [Fact]
    public void Build_With_Required_Properties_Returns_Valid_ImageBlock()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithAltText(_validAltText)
            .WithImageUrl("https://example.com/image.jpg");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Should().BeOfType<ImageBlock>();
        result.AltText.Should().Be(_validAltText);
        result.ImageUrl.Should().Be("https://example.com/image.jpg");
        result.SlackFile.Should().BeNull();
        result.Title.Should().BeNull();
        result.BlockId.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_Returns_Valid_ImageBlock()
    {
        // Arrange
        var title = new TextObject { Text = "Image Title", Type = TextObjectType.PlainText };
        var builder = new ImageBlockBuilder()
            .WithAltText(_validAltText)
            .WithImageUrl("https://example.com/image.jpg")
            .WithTitle(title)
            .WithBlockId("test-image-block");

        // Act
        var result = builder.Build() as ImageBlock;

        // Assert
        result.Should().NotBeNull();
        result?.BlockId.Should().Be("test-image-block");
        result?.AltText.Should().Be(_validAltText);
        result?.ImageUrl.Should().Be("https://example.com/image.jpg");
        result?.Title.Should().Be(title);
        result?.SlackFile.Should().BeNull();
    }

    [Fact]
    public void Build_With_SlackFile_Returns_Valid_ImageBlock()
    {
        // Arrange
        var slackFile = new SlackFileObject { Id = "F123456" };
        var builder = new ImageBlockBuilder()
            .WithAltText(_validAltText)
            .WithSlackFile(slackFile);

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.AltText.Should().Be(_validAltText);
        result.SlackFile.Should().Be(slackFile);
        result.ImageUrl.Should().BeNull();
    }

    [Fact]
    public void Build_Without_AltText_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithImageUrl("https://example.com/image.jpg");

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("AltText is required");
    }

    [Fact]
    public void Build_Without_ImageUrl_And_SlackFile_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithAltText(_validAltText);

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Either ImageUrl or SlackUrl need to be provided");
    }

    [Fact]
    public void WithAltText_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ImageBlockBuilder();

        // Act
        var result = builder.WithAltText(_validAltText);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithImageUrl_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ImageBlockBuilder();

        // Act
        var result = builder.WithImageUrl("https://example.com/image.jpg");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithSlackFile_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ImageBlockBuilder();
        var slackFile = new SlackFileObject { Id = "F123456" };

        // Act
        var result = builder.WithSlackFile(slackFile);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithTitle_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ImageBlockBuilder();
        var title = new TextObject { Text = "Image Title", Type = TextObjectType.PlainText };

        // Act
        var result = builder.WithTitle(title);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
    {
        // Arrange
        var builder = new ImageBlockBuilder()
            .WithAltText(_validAltText)
            .WithImageUrl("https://example.com/image.jpg");

        // Act
        var result1 = builder.Build();
        var result2 = builder.Build();

        // Assert
        result1.Should().NotBeSameAs(result2);
        result1.AltText.Should().Be(result2.AltText);
        result1.ImageUrl.Should().Be(result2.ImageUrl);
    }
}