using FluentAssertions;
using Hooki.Slack.Builders;
using Hooki.Slack.Enums;

namespace Hooki.UnitTests.Slack.BuilderTests;

public class ConfirmationDialogObjectBuilderTests
{
    [Fact]
    public void Build_With_Required_Properties_Returns_Valid_ConfirmationDialogObject()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithTitle(t => t.WithType(TextObjectType.PlainText).WithText("Title"))
            .WithText(t => t.WithType(TextObjectType.PlainText).WithText("Text"))
            .WithConfirm(t => t.WithType(TextObjectType.PlainText).WithText("Confirm"))
            .WithDeny(t => t.WithType(TextObjectType.PlainText).WithText("Deny"));

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().NotBeNull();
        result.Title.Text.Should().Be("Title");
        result.Text.Should().NotBeNull();
        result.Text.Text.Should().Be("Text");
        result.Confirm.Should().NotBeNull();
        result.Confirm.Text.Should().Be("Confirm");
        result.Deny.Should().NotBeNull();
        result.Deny.Text.Should().Be("Deny");
        result.Style.Should().BeNull();
    }

    [Fact]
    public void Build_With_All_Properties_Returns_Valid_ConfirmationDialogObject()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithTitle(t => t.WithType(TextObjectType.PlainText).WithText("Title"))
            .WithText(t => t.WithType(TextObjectType.PlainText).WithText("Text"))
            .WithConfirm(t => t.WithType(TextObjectType.PlainText).WithText("Confirm"))
            .WithDeny(t => t.WithType(TextObjectType.PlainText).WithText("Deny"))
            .WithStyle("danger");

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Title.Should().NotBeNull();
        result.Title.Text.Should().Be("Title");
        result.Text.Should().NotBeNull();
        result.Text.Text.Should().Be("Text");
        result.Confirm.Should().NotBeNull();
        result.Confirm.Text.Should().Be("Confirm");
        result.Deny.Should().NotBeNull();
        result.Deny.Text.Should().Be("Deny");
        result.Style.Should().Be("danger");
    }

    [Fact]
    public void Build_Without_Title_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithText(t => t.WithType(TextObjectType.PlainText).WithText("Text"))
            .WithConfirm(t => t.WithType(TextObjectType.PlainText).WithText("Confirm"))
            .WithDeny(t => t.WithType(TextObjectType.PlainText).WithText("Deny"));

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Title is required for a ConfirmationDialogObject.");
    }

    [Fact]
    public void Build_Without_Text_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithTitle(t => t.WithType(TextObjectType.PlainText).WithText("Title"))
            .WithConfirm(t => t.WithType(TextObjectType.PlainText).WithText("Confirm"))
            .WithDeny(t => t.WithType(TextObjectType.PlainText).WithText("Deny"));

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Text is required for a ConfirmationDialogObject.");
    }

    [Fact]
    public void Build_Without_Confirm_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithTitle(t => t.WithType(TextObjectType.PlainText).WithText("Title"))
            .WithText(t => t.WithType(TextObjectType.PlainText).WithText("Text"))
            .WithDeny(t => t.WithType(TextObjectType.PlainText).WithText("Deny"));

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Confirm is required for a ConfirmationDialogObject.");
    }

    [Fact]
    public void Build_Without_Deny_Throws_InvalidOperationException()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithTitle(t => t.WithType(TextObjectType.PlainText).WithText("Title"))
            .WithText(t => t.WithType(TextObjectType.PlainText).WithText("Text"))
            .WithConfirm(t => t.WithType(TextObjectType.PlainText).WithText("Confirm"));

        // Act & Assert
        builder.Invoking(b => b.Build())
            .Should().Throw<InvalidOperationException>()
            .WithMessage("Deny is required for a ConfirmationDialogObject.");
    }

    [Fact]
    public void Build_With_Different_TextObject_Types_Returns_Valid_ConfirmationDialogObject()
    {
        // Arrange
        var builder = new ConfirmationDialogObjectBuilder()
            .WithTitle(t => t.WithType(TextObjectType.PlainText).WithText("Title"))
            .WithText(t => t.WithType(TextObjectType.Markdown).WithText("*Text*"))
            .WithConfirm(t => t.WithType(TextObjectType.PlainText).WithText("Confirm"))
            .WithDeny(t => t.WithType(TextObjectType.PlainText).WithText("Deny"));

        // Act
        var result = builder.Build();

        // Assert
        result.Should().NotBeNull();
        result.Title.Type.Should().Be(TextObjectType.PlainText);
        result.Text.Type.Should().Be(TextObjectType.Markdown);
        result.Confirm.Type.Should().Be(TextObjectType.PlainText);
        result.Deny.Type.Should().Be(TextObjectType.PlainText);
    }
}