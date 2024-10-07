using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SectionBlockBuilderTests
{
    [Fact]
    public void Build_With_Text_Returns_Valid_SectionBlock()
    {
        // Arrange
        var builder = new SectionBlockBuilder()
            .WithText(t => t.WithText("Section Text").WithType(TextObjectType.PlainText));

        // Act
        var result = builder.Build() as SectionBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Text.Should().NotBeNull();
        result.Text!.Text.Should().Be("Section Text");
        result.Text.Type.Should().Be(TextObjectType.PlainText);
        result.Fields.Should().BeNull();
        result.Accessory.Should().BeNull();
        result.Expand.Should().BeNull();
    }

    [Fact]
    public void Build_With_Fields_Returns_Valid_SectionBlock()
    {
        // Arrange
        var builder = new SectionBlockBuilder()
            .AddField(t => t.WithText("Field 1").WithType(TextObjectType.PlainText))
            .AddField(t => t.WithText("Field 2").WithType(TextObjectType.Markdown));

        // Act
        var result = builder.Build() as SectionBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Text.Should().BeNull();
        result.Fields.Should().NotBeNull();
        result.Fields!.Length.Should().Be(2);
        result.Fields[0].Text.Should().Be("Field 1");
        result.Fields[0].Type.Should().Be(TextObjectType.PlainText);
        result.Fields[1].Text.Should().Be("Field 2");
        result.Fields[1].Type.Should().Be(TextObjectType.Markdown);
    }

    [Fact]
    public void Build_With_Accessory_Returns_Valid_SectionBlock()
    {
        // Arrange
        var builder = new SectionBlockBuilder()
            .WithText(t => t.WithText("Section Text").WithType(TextObjectType.PlainText))
            .WithAccessory(() => new ButtonElement { Text = new TextObject { Text = "Click me", Type = TextObjectType.PlainText } });

        // Act
        var result = builder.Build() as SectionBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Text.Should().NotBeNull();
        result.Accessory.Should().NotBeNull();
        result.Accessory.Should().BeOfType<ButtonElement>();
        (result.Accessory as ButtonElement)!.Text.Text.Should().Be("Click me");
    }

    [Fact]
    public void Build_With_Expand_Returns_Valid_SectionBlock()
    {
        // Arrange
        var builder = new SectionBlockBuilder()
            .WithText(t => t.WithText("Section Text").WithType(TextObjectType.PlainText))
            .WithExpand(true);

        // Act
        var result = builder.Build() as SectionBlock;

        // Assert
        result.Should().NotBeNull();
        result!.Text.Should().NotBeNull();
        result.Expand.Should().BeTrue();
    }

    [Fact]
    public void Build_Without_Text_And_Fields_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SectionBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Either text or at least one field is required for a SectionBlock.");
    }

    [Fact]
    public void Build_With_BlockId_Returns_Valid_SectionBlock()
    {
        // Arrange
        var builder = new SectionBlockBuilder()
            .WithText(t => t.WithText("Section Text").WithType(TextObjectType.PlainText));

        // Act
        var result = builder.Build() as SectionBlock;

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void WithText_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SectionBlockBuilder();

        // Act
        var result = builder.WithText(t => t.WithText("Section Text").WithType(TextObjectType.PlainText));

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void AddField_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SectionBlockBuilder();

        // Act
        var result = builder.AddField(t => t.WithText("Field Text").WithType(TextObjectType.PlainText));

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithAccessory_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SectionBlockBuilder();

        // Act
        var result = builder.WithAccessory(() => new ButtonElement { Text = new TextObject { Text = "Click me", Type = TextObjectType.PlainText } });

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithExpand_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SectionBlockBuilder();

        // Act
        var result = builder.WithExpand(true);

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void Multiple_Builds_With_Same_Builder_Return_Different_Instances()
    {
        // Arrange
        var builder = new SectionBlockBuilder()
            .WithText(t => t.WithText("Section Text").WithType(TextObjectType.PlainText));

        // Act
        var result1 = builder.Build() as SectionBlock;
        var result2 = builder.Build() as SectionBlock;

        // Assert
        result1.Should().NotBeSameAs(result2);
        result1.Should().NotBeNull();
        result2.Should().NotBeNull();
    
        result1!.Text.Should().NotBeNull();
        result2!.Text.Should().NotBeNull();
    
        result1.Text!.Text.Should().Be("Section Text");
        result1.Text.Type.Should().Be(TextObjectType.PlainText);
    
        result2.Text!.Text.Should().Be("Section Text");
        result2.Text.Type.Should().Be(TextObjectType.PlainText);
    
        // Ensure that modifying one TextObject doesn't affect the other
        var originalText = result1.Text.Text;
        result1.Text = new TextObject { Text = "Modified Text", Type = TextObjectType.PlainText };
        result2.Text!.Text.Should().Be(originalText);
    }
}