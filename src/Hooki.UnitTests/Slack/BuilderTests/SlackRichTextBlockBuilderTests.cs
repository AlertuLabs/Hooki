using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.RichTextElements;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackRichTextBlockBuilderTests
{
    [Fact]
    public void Build_With_Single_Element_Returns_Valid_RichTextBlock()
    {
        // Arrange
        var builder = new SlackRichTextBlockBuilder()
            .AddElement(() => new SlackRichTextSection { Elements = new[] { new SlackTextElement { Text = "Hello, World!" } } });

        // Act
        var result = builder.Build() as SlackRichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(1);
        result.Elements.First().Should().BeOfType<SlackRichTextSection>();
        var section = result.Elements.First() as SlackRichTextSection;
        section!.Elements.Should().HaveCount(1);
        section.Elements.First().Should().BeOfType<SlackTextElement>();
        (section.Elements.First() as SlackTextElement)!.Text.Should().Be("Hello, World!");
    }

    [Fact]
    public void Build_With_Multiple_Elements_Returns_Valid_RichTextBlock()
    {
        // Arrange
        var builder = new SlackRichTextBlockBuilder()
            .AddElement(() => new SlackRichTextSection { Elements = new[] { new SlackTextElement { Text = "Section 1" } } })
            .AddElement(() => new SlackRichTextList 
            { 
                Style = SlackRichTextListStyle.Bullet, 
                Elements = new[] { new SlackTextElement { Text = "Item 1" } } 
            });

        // Act
        var result = builder.Build() as SlackRichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(2);
        result.Elements[0].Should().BeOfType<SlackRichTextSection>();
        result.Elements[1].Should().BeOfType<SlackRichTextList>();
    }

    [Fact]
    public void Build_With_No_Elements_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackRichTextBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("At least one element is required for a RichTextBlock.");
    }

    [Fact]
    public void Build_Inherits_BlockId_From_Base_Builder()
    {
        // Arrange
        var builder = new SlackRichTextBlockBuilder()
            .AddElement(() => new SlackRichTextSection { Elements = new[] { new SlackTextElement { Text = "Test" } } });

        // Act
        var result = builder.Build() as SlackRichTextBlock;

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void AddElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackRichTextBlockBuilder();

        // Act
        var result = builder.AddElement(() => new SlackRichTextSection { Elements = new[] { new SlackTextElement { Text = "Test" } } });

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void Build_With_Different_RichTextBlockElement_Types()
    {
        // Arrange
        var builder = new SlackRichTextBlockBuilder()
            .AddElement(() => new SlackRichTextSection { Elements = new[] { new SlackTextElement { Text = "Section" } } })
            .AddElement(() => new SlackRichTextList { Style = SlackRichTextListStyle.Bullet, Elements = new[] { new SlackTextElement { Text = "List Item" } } })
            .AddElement(() => new SlackRichTextQuote { Elements = new[] { new SlackTextElement { Text = "Quote" } } })
            .AddElement(() => new SlackRichTextPreformatted { Elements = new[] { new SlackTextElement { Text = "Code" } } });

        // Act
        var result = builder.Build() as SlackRichTextBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Elements.Should().HaveCount(4);
        result.Elements[0].Should().BeOfType<SlackRichTextSection>();
        result.Elements[1].Should().BeOfType<SlackRichTextList>();
        result.Elements[2].Should().BeOfType<SlackRichTextQuote>();
        result.Elements[3].Should().BeOfType<SlackRichTextPreformatted>();
    }
}