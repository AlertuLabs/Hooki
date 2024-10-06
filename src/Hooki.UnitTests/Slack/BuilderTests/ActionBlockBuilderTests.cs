using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class ActionBlockBuilderTests
{
    [Fact]
    public void Build_With_Single_Element_Returns_Valid_ActionBlock()
    {
        // Arrange
        var builder = new ActionBlockBuilder()
            .AddElement(() => new ButtonElement { Text = new TextObject { Text = "Click me", Type = TextObjectType.PlainText } });

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Elements.Should().HaveCount(1);
        result.Elements.First().Should().BeOfType<ButtonElement>();
        (result.Elements.First() as ButtonElement)!.Text.Text.Should().Be("Click me");
    }

    [Fact]
    public void Build_With_Multiple_Elements_Returns_Valid_ActionBlock()
    {
        // Arrange
        var builder = new ActionBlockBuilder()
            .AddElement(() => new ButtonElement { Text = new TextObject { Text = "Button 1", Type = TextObjectType.PlainText } })
            .AddElement(() => new ButtonElement { Text = new TextObject { Text = "Button 2", Type = TextObjectType.PlainText } });

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Elements.Should().HaveCount(2);
        result.Elements.Should().AllBeOfType<ButtonElement>();
        result.Elements.Cast<ButtonElement>().Select(b => b.Text.Text).Should().ContainInOrder("Button 1", "Button 2");
    }

    [Fact]
    public void Build_With_No_Elements_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ActionBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Elements are required");
    }

    [Fact]
    public void Build_Inherits_BlockId_From_Base_Builder()
    {
        // Arrange
        var builder = new ActionBlockBuilder()
            .AddElement(() => new ButtonElement { Text = new TextObject { Text = "Click me", Type = TextObjectType.PlainText } })
            .WithBlockId("test-block-id");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.BlockId.Should().Be("test-block-id");
    }

    [Fact]
    public void Build_With_Different_Element_Types_Returns_Valid_ActionBlock()
    {
        // Arrange
        var builder = new ActionBlockBuilder()
            .AddElement(() => new ButtonElement { 
                Text = new TextObject { Text = "Button", Type = TextObjectType.PlainText } 
            })
            .AddElement(() => new SelectMenuElement { 
                Options = new[] { new OptionObject { Text = new TextObject { Type = TextObjectType.PlainText, Text = "Option" }, Value = "value" } },
                Placeholder = new TextObject { Text = "Select", Type = TextObjectType.PlainText } 
            })
            .AddElement(() => new MultiSelectMenuElement { 
                Options = new[] { new OptionObject { Text = new TextObject { Type = TextObjectType.PlainText, Text = "Option" }, Value = "value" } },
                Placeholder = new TextObject { Text = "Multi Select", Type = TextObjectType.PlainText } 
            })
            .AddElement(() => new OverflowMenuElement { 
                Options = new List<OptionObject>() {new OptionObject { Text = new TextObject { Type = TextObjectType.PlainText, Text = "Option" }, Value = "value" } }
            })
            .AddElement(() => new DatePickerElement { 
                Placeholder = new TextObject { Text = "Select date", Type = TextObjectType.PlainText } 
            })
            .AddElement(() => new TimePickerElement { 
                Placeholder = new TextObject { Text = "Select time", Type = TextObjectType.PlainText } 
            })
            .AddElement(() => new DateTimePickerElement())
            .AddElement(() => new RadioButtonGroupElement { 
                Options = new[] { new OptionObject { Text = new TextObject { Type = TextObjectType.PlainText, Text = "Option" }, Value = "value" } }
            })
            .AddElement(() => new CheckboxElement { 
                Options = new List<OptionObject> { new OptionObject { Text = new TextObject { Type = TextObjectType.PlainText, Text = "Option" }, Value = "value" } }
            })
            .AddElement(() => new WorkflowButtonElement { 
                Text = new TextObject { Text = "Workflow", Type = TextObjectType.PlainText },
                Workflow = new WorkflowObject { Trigger = new TriggerObject { Url = "https://example.com" } }
            });

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Elements.Should().HaveCount(10);
        result.Elements[0].Should().BeOfType<ButtonElement>();
        result.Elements[1].Should().BeOfType<SelectMenuElement>();
        result.Elements[2].Should().BeOfType<MultiSelectMenuElement>();
        result.Elements[3].Should().BeOfType<OverflowMenuElement>();
        result.Elements[4].Should().BeOfType<DatePickerElement>();
        result.Elements[5].Should().BeOfType<TimePickerElement>();
        result.Elements[6].Should().BeOfType<DateTimePickerElement>();
        result.Elements[7].Should().BeOfType<RadioButtonGroupElement>();
        result.Elements[8].Should().BeOfType<CheckboxElement>();
        result.Elements[9].Should().BeOfType<WorkflowButtonElement>();
    }

    [Fact]
    public void AddElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ActionBlockBuilder();

        // Act
        var result = builder.AddElement(() => new ButtonElement 
            {Text = new TextObject {Text = "Text", Type = TextObjectType.PlainText}});

        // Assert
        result.Should().BeSameAs(builder);
    }
}