using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.BlockElements;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class ButtonElementBuilderTests
{
    [Fact]
    public void Build_With_Required_Properties_Returns_Valid_ButtonElement()
    {
        // Arrange
        var builder = new ButtonElementBuilder()
            .WithText(t => t.WithText("Click me").WithType(SlackTextObjectType.PlainText));

        // Act
        var result = builder.Build() as SlackButtonElement;

        // Assert
        result.Should().NotBeNull();
        result!.SlackText.Should().NotBeNull();
        result.SlackText.Text.Should().Be("Click me");
        result.SlackText.Type.Should().Be(SlackTextObjectType.PlainText);
        result.ActionId.Should().BeNull();
        result.Url.Should().BeNull();
        result.Value.Should().BeNull();
        result.Style.Should().BeNull();
        result.Confirm.Should().BeNull();
        result.AccessibilityLabel.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_Returns_Valid_ButtonElement()
    {
        // Arrange
        var builder = new ButtonElementBuilder()
            .WithText(t => t.WithText("Click me").WithType(SlackTextObjectType.PlainText))
            .WithUrl("https://example.com")
            .WithValue("button_value")
            .WithStyle("primary")
            .WithConfirm(c => c
                .WithTitle(t => t.WithText("Are you sure?").WithType(SlackTextObjectType.PlainText))
                .WithText(t => t.WithText("This action cannot be undone.").WithType(SlackTextObjectType.PlainText))
                .WithConfirm(t => t.WithText("Yes").WithType(SlackTextObjectType.PlainText))
                .WithDeny(t => t.WithText("No").WithType(SlackTextObjectType.PlainText)))
            .WithAccessibilityLabel("Accessible button label")
            .WithActionId("button_action");

        // Act
        var result = builder.Build() as SlackButtonElement;

        // Assert
        result.Should().NotBeNull();
        result!.ActionId.Should().Be("button_action");
        result.SlackText.Should().NotBeNull();
        result.SlackText.Text.Should().Be("Click me");
        result.Url.Should().Be("https://example.com");
        result.Value.Should().Be("button_value");
        result.Style.Should().Be("primary");
        result.Confirm.Should().NotBeNull();
        result.AccessibilityLabel.Should().Be("Accessible button label");
    }

    [Fact]
    public void Build_Without_Text_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Text is required for a ButtonElement.");
    }

    [Fact]
    public void WithText_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act
        var result = builder.WithText(t => t.WithText("Click me").WithType(SlackTextObjectType.PlainText));

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithUrl_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act
        var result = builder.WithUrl("https://example.com");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithValue_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act
        var result = builder.WithValue("button_value");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithStyle_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act
        var result = builder.WithStyle("primary");

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithConfirm_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act
        var result = builder.WithConfirm(c => c
            .WithTitle(t => t.WithText("Are you sure?").WithType(SlackTextObjectType.PlainText))
            .WithText(t => t.WithText("This action cannot be undone.").WithType(SlackTextObjectType.PlainText))
            .WithConfirm(t => t.WithText("Yes").WithType(SlackTextObjectType.PlainText))
            .WithDeny(t => t.WithText("No").WithType(SlackTextObjectType.PlainText)));

        // Assert
        result.Should().BeSameAs(builder);
    }

    [Fact]
    public void WithAccessibilityLabel_Returns_Same_Builder_Instance()
    {
        // Arrange
        var builder = new ButtonElementBuilder();

        // Act
        var result = builder.WithAccessibilityLabel("Accessible button label");

        // Assert
        result.Should().BeSameAs(builder);
    }
}