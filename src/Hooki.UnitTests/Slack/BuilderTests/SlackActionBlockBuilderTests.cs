using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class SlackActionBlockBuilderTests
{
    [Fact]
    public void Build_With_Single_Element_Returns_Valid_ActionBlock()
    {
        // Arrange
        var builder = new SlackActionBlockBuilder()
            .AddElement(() => new SlackButtonElement { SlackText = new SlackTextObject { Text = "Click me", Type = SlackTextObjectType.PlainText } });

        // Act
        var result = builder.Build() as SlackActionBlock;

        // Assert
        result.Should().NotBeNull();
        result?.Elements.Should().HaveCount(1);
        result?.Elements.First().Should().BeOfType<SlackButtonElement>();
        (result?.Elements.First() as SlackButtonElement)!.SlackText.Text.Should().Be("Click me");
    }

    [Fact]
    public void Build_With_Multiple_Elements_Returns_Valid_ActionBlock()
    {
        // Arrange
        var builder = new SlackActionBlockBuilder()
            .AddElement(() => new SlackButtonElement { SlackText = new SlackTextObject { Text = "Button 1", Type = SlackTextObjectType.PlainText } })
            .AddElement(() => new SlackButtonElement { SlackText = new SlackTextObject { Text = "Button 2", Type = SlackTextObjectType.PlainText } });

        // Act
        var result = builder.Build() as SlackActionBlock;

        // Assert
        result.Should().NotBeNull();
        result?.Elements.Should().HaveCount(2);
        result?.Elements.Should().AllBeOfType<SlackButtonElement>();
        result?.Elements.Cast<SlackButtonElement>().Select(b => b.SlackText.Text).Should().ContainInOrder("Button 1", "Button 2");
    }

    [Fact]
    public void Build_With_No_Elements_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new SlackActionBlockBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Elements are required");
    }

    [Fact]
    public void Build_Inherits_BlockId_From_Base_Builder()
    {
        // Arrange
        var builder = new SlackActionBlockBuilder()
            .AddElement(() => new SlackButtonElement
                { SlackText = new SlackTextObject { Text = "Click me", Type = SlackTextObjectType.PlainText } });

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
    }

    [Fact]
    public void Build_With_Different_Element_Types_Returns_Valid_ActionBlock()
    {
        // Arrange
        var builder = new SlackActionBlockBuilder()
            .AddElement(() => new SlackButtonElement { 
                SlackText = new SlackTextObject { Text = "Button", Type = SlackTextObjectType.PlainText } 
            })
            .AddElement(() => new SlackSelectMenuElement { 
                Options = new[] { new SlackOptionObject { SlackText = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Option" }, Value = "value" } },
                Placeholder = new SlackTextObject { Text = "Select", Type = SlackTextObjectType.PlainText } 
            })
            .AddElement(() => new SlackMultiSelectMenuElement { 
                Options = new[] { new SlackOptionObject { SlackText = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Option" }, Value = "value" } },
                Placeholder = new SlackTextObject { Text = "Multi Select", Type = SlackTextObjectType.PlainText } 
            })
            .AddElement(() => new SlackOverflowMenuElement { 
                Options = new List<SlackOptionObject>() {new SlackOptionObject { SlackText = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Option" }, Value = "value" } }
            })
            .AddElement(() => new Hooki.Slack.Models.BlockElements.SlackDatePickerElement { 
                Placeholder = new SlackTextObject { Text = "Select date", Type = SlackTextObjectType.PlainText } 
            })
            .AddElement(() => new SlackTimePickerElement { 
                Placeholder = new SlackTextObject { Text = "Select time", Type = SlackTextObjectType.PlainText } 
            })
            .AddElement(() => new SlackDateTimePickerElement())
            .AddElement(() => new SlackRadioButtonGroupElement { 
                Options = new[] { new SlackOptionObject { SlackText = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Option" }, Value = "value" } }
            })
            .AddElement(() => new SlackCheckboxElement { 
                Options = new List<SlackOptionObject> { new SlackOptionObject { SlackText = new SlackTextObject { Type = SlackTextObjectType.PlainText, Text = "Option" }, Value = "value" } }
            })
            .AddElement(() => new SlackWorkflowButtonElement { 
                SlackText = new SlackTextObject { Text = "Workflow", Type = SlackTextObjectType.PlainText },
                Workflow = new SlackWorkflowObject { SlackTrigger = new SlackTriggerObject { Url = "https://example.com" } }
            });

        // Act
        var result = builder.Build() as SlackActionBlock;

        // Assert
        result.Should().NotBeNull();
        result?.Elements.Should().HaveCount(10);
        result?.Elements[0].Should().BeOfType<SlackButtonElement>();
        result?.Elements[1].Should().BeOfType<SlackSelectMenuElement>();
        result?.Elements[2].Should().BeOfType<SlackMultiSelectMenuElement>();
        result?.Elements[3].Should().BeOfType<SlackOverflowMenuElement>();
        result?.Elements[4].Should().BeOfType<Hooki.Slack.Models.BlockElements.SlackDatePickerElement>();
        result?.Elements[5].Should().BeOfType<SlackTimePickerElement>();
        result?.Elements[6].Should().BeOfType<SlackDateTimePickerElement>();
        result?.Elements[7].Should().BeOfType<SlackRadioButtonGroupElement>();
        result?.Elements[8].Should().BeOfType<SlackCheckboxElement>();
        result?.Elements[9].Should().BeOfType<SlackWorkflowButtonElement>();
    }

    [Fact]
    public void AddElement_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new SlackActionBlockBuilder();

        // Act
        var result = builder.AddElement(() => new SlackButtonElement 
            {SlackText = new SlackTextObject {Text = "Text", Type = SlackTextObjectType.PlainText}});

        // Assert
        result.Should().BeSameAs(builder);
    }
}