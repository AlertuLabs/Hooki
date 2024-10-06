using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.RichTextElements;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class RichTextBlockBuilderTests
{
    [Fact]
    public void Build_With_Single_Element_Returns_Valid_RichTextBlock()
    {
        // Arrange
        var builder = new RichTextBlockBuilder()
            .AddElement(() => new RichTextSection { Elements = new[] { new TextElement { Text = "Hello, World!" } } });

        // Act
        var result = builder.Build() as RichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(1);
        result.Elements.First().Should().BeOfType<RichTextSection>();
        var section = result.Elements.First() as RichTextSection;
        section!.Elements.Should().HaveCount(1);
        section.Elements.First().Should().BeOfType<TextElement>();
        (section.Elements.First() as TextElement)!.Text.Should().Be("Hello, World!");
    }

    [Fact]
    public void Build_With_Multiple_Elements_Returns_Valid_RichTextBlock()
    {
        // Arrange
        var builder = new RichTextBlockBuilder()
            .AddElement(() => new RichTextSection { Elements = new[] { new TextElement { Text = "Section 1" } } })
            .AddElement(() => new RichTextList 
            { 
                Style = RichTextListStyleType.Bullet, 
                Elements = new[] { new TextElement { Text = "Item 1" } } 
            });

        // Act
        var result = builder.Build() as RichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(2);
        result.Elements[0].Should().BeOfType<RichTextSection>();
        result.Elements[1].Should().BeOfType<RichTextList>();
    }

    [Fact]
    public void Build_With_No_Elements_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new RichTextBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("At least one element is required for a RichTextBlock.");
    }

    [Fact]
    public void Build_Inherits_BlockId_From_Base_Builder()
    {
        // Arrange
        var builder = new RichTextBlockBuilder()
            .AddElement(() => new RichTextSection { Elements = new[] { new TextElement { Text = "Test" } } })
            .WithBlockId("test-rich-text-block");

        // Act
        var result = builder.Build() as RichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.BlockId.Should().Be("test-rich-text-block");
    }

    [Fact]
    public void AddElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new RichTextBlockBuilder();

        // Act
        var result = builder.AddElement(() => new RichTextSection { Elements = new[] { new TextElement { Text = "Test" } } });

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
    {
        // Arrange
        var builder = new RichTextBlockBuilder()
            .AddElement(() => new RichTextSection { Elements = new[] { new TextElement { Text = "Test" } } });

        // Act
        var result1 = builder.Build();
        var result2 = builder.Build();

        // Assert
        result1.Should().NotBeSameAs(result2);
        (result1 as RichTextBlock)!.Elements.Should().NotBeSameAs((result2 as RichTextBlock)!.Elements);
        (result1 as RichTextBlock)!.Elements.Count.Should().Be((result2 as RichTextBlock)!.Elements.Count);
    }

    [Fact]
    public void Build_With_Different_RichTextBlockElement_Types()
    {
        // Arrange
        var builder = new RichTextBlockBuilder()
            .AddElement(() => new RichTextSection { Elements = new[] { new TextElement { Text = "Section" } } })
            .AddElement(() => new RichTextList { Style = RichTextListStyleType.Bullet, Elements = new[] { new TextElement { Text = "List Item" } } })
            .AddElement(() => new RichTextQuote { Elements = new[] { new TextElement { Text = "Quote" } } })
            .AddElement(() => new RichTextPreformatted { Elements = new[] { new TextElement { Text = "Code" } } });

        // Act
        var result = builder.Build() as RichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(4);
        result.Elements[0].Should().BeOfType<RichTextSection>();
        result.Elements[1].Should().BeOfType<RichTextList>();
        result.Elements[2].Should().BeOfType<RichTextQuote>();
        result.Elements[3].Should().BeOfType<RichTextPreformatted>();
    }
}