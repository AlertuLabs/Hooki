using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class ContextBlockBuilderTests
{
    [Fact]
    public void Build_With_Single_Element_Returns_Valid_ContextBlock()
    {
        // Arrange
        var builder = new ContextBlockBuilder()
            .AddElement(() => new TextObject { Text = "Context text", Type = TextObjectType.PlainText });

        // Act
        var result = builder.Build() as ContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(1);
        result.Elements.First().Should().BeOfType<TextObject>();
        (result.Elements.First() as TextObject)!.Text.Should().Be("Context text");
    }

    [Fact]
    public void Build_With_Multiple_Elements_Returns_Valid_ContextBlock()
    {
        // Arrange
        var builder = new ContextBlockBuilder()
            .AddElement(() => new TextObject { Text = "Text 1", Type = TextObjectType.PlainText })
            .AddElement(() => new TextObject { Text = "Text 2", Type = TextObjectType.Markdown });

        // Act
        var result = builder.Build() as ContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(2);
        result.Elements.Should().AllBeOfType<TextObject>();
        result.Elements.Cast<TextObject>().Select(t => t.Text).Should().ContainInOrder("Text 1", "Text 2");
    }

    [Fact]
    public void Build_With_No_Elements_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ContextBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("At least one element is required for an ActionBlock.");
    }

    [Fact]
    public void Build_Inherits_BlockId_From_Base_Builder()
    {
        // Arrange
        var builder = new ContextBlockBuilder()
            .AddElement(() => new TextObject { Text = "Context text", Type = TextObjectType.PlainText })
            .WithBlockId("test-block-id");

        // Act
        var result = builder.Build() as ContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.BlockId.Should().Be("test-block-id");
    }

    [Fact]
    public void Build_With_ImageElement_And_TextObject_Returns_Valid_ContextBlock()
    {
        // Arrange
        var builder = new ContextBlockBuilder()
            .AddElement(() => new ImageElement 
            { 
                ImageUrl = "http://example.com/image.jpg", 
                AltText = "Example Image" 
            })
            .AddElement(() => new TextObject 
            { 
                Text = "Context text", 
                Type = TextObjectType.PlainText 
            });

        // Act
        var result = builder.Build() as ContextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(2);
        result.Elements[0].Should().BeOfType<ImageElement>();
        result.Elements[1].Should().BeOfType<TextObject>();
        
        var imageElement = result.Elements[0] as ImageElement;
        imageElement.Should().NotBeNull();
        imageElement!.ImageUrl.Should().Be("http://example.com/image.jpg");
        imageElement.AltText.Should().Be("Example Image");

        var textObject = result.Elements[1] as TextObject;
        textObject.Should().NotBeNull();
        textObject!.Text.Should().Be("Context text");
        textObject.Type.Should().Be(TextObjectType.PlainText);
    }

    [Fact]
    public void AddElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ContextBlockBuilder();

        // Act
        var result = builder.AddElement(() => new TextObject {Text = "Text", Type = TextObjectType.Markdown });

        // Assert
        result.Should().BeSameAs(builder);
    }
}