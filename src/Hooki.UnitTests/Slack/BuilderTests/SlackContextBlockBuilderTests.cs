using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackContextBlockBuilderTests
{
    [Fact]
    public void Build_With_Single_Element_Returns_Valid_ContextBlock()
    {
        // Arrange
        var builder = new SlackContextBlockBuilder()
            .AddElement(() => new SlackTextObject { Text = "Context text", Type = SlackTextObjectType.PlainText });

        // Act
        var result = builder.Build() as SlackContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(1);
        result.Elements.First().Should().BeOfType<SlackTextObject>();
        (result.Elements.First() as SlackTextObject)!.Text.Should().Be("Context text");
    }

    [Fact]
    public void Build_With_Multiple_Elements_Returns_Valid_ContextBlock()
    {
        // Arrange
        var builder = new SlackContextBlockBuilder()
            .AddElement(() => new SlackTextObject { Text = "Text 1", Type = SlackTextObjectType.PlainText })
            .AddElement(() => new SlackTextObject { Text = "Text 2", Type = SlackTextObjectType.Markdown });

        // Act
        var result = builder.Build() as SlackContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(2);
        result.Elements.Should().AllBeOfType<SlackTextObject>();
        result.Elements.Cast<SlackTextObject>().Select(t => t.Text).Should().ContainInOrder("Text 1", "Text 2");
    }

    [Fact]
    public void Build_With_No_Elements_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackContextBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("At least one element is required for an ActionBlock.");
    }

    [Fact]
    public void Build_Inherits_BlockId_From_Base_Builder()
    {
        // Arrange
        var builder = new SlackContextBlockBuilder()
            .AddElement(() => new SlackTextObject { Text = "Context text", Type = SlackTextObjectType.PlainText });

        // Act
        var result = builder.Build() as SlackContextBlock;

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Build_With_ImageElement_And_TextObject_Returns_Valid_ContextBlock()
    {
        // Arrange
        var builder = new SlackContextBlockBuilder()
            .AddElement(() => new SlackImageElement 
            { 
                ImageUrl = "http://example.com/image.jpg", 
                AltText = "Example Image" 
            })
            .AddElement(() => new SlackTextObject 
            { 
                Text = "Context text", 
                Type = SlackTextObjectType.PlainText 
            });

        // Act
        var result = builder.Build() as SlackContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(2);
        result.Elements[0].Should().BeOfType<SlackImageElement>();
        result.Elements[1].Should().BeOfType<SlackTextObject>();
        
        var imageElement = result.Elements[0] as SlackImageElement;
        imageElement.Should().NotBeNull();
        imageElement!.ImageUrl.Should().Be("http://example.com/image.jpg");
        imageElement.AltText.Should().Be("Example Image");

        var textObject = result.Elements[1] as SlackTextObject;
        textObject.Should().NotBeNull();
        textObject!.Text.Should().Be("Context text");
        textObject.Type.Should().Be(SlackTextObjectType.PlainText);
    }

    [Fact]
    public void AddElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackContextBlockBuilder();

        // Act
        var result = builder.AddElement(() => new SlackTextObject {Text = "Text", Type = SlackTextObjectType.Markdown });

        // Assert
        result.Should().BeSameAs(builder);
    }
}