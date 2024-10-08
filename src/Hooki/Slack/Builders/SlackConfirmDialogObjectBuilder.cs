using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class SlackConfirmDialogObjectBuilder
{
    private SlackTextObject? _title;
    private SlackTextObject? _text;
    private SlackTextObject? _confirm;
    private SlackTextObject? _deny;
    private string? _style;

    public SlackConfirmDialogObjectBuilder WithTitle(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _title = builder.Build();
        return this;
    }

    public SlackConfirmDialogObjectBuilder WithText(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _text = builder.Build();
        return this;
    }

    public SlackConfirmDialogObjectBuilder WithConfirm(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _confirm = builder.Build();
        return this;
    }

    public SlackConfirmDialogObjectBuilder WithDeny(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _deny = builder.Build();
        return this;
    }

    public SlackConfirmDialogObjectBuilder WithStyle(string style)
    {
        _style = style;
        return this;
    }

    public SlackConfirmDialogObject Build()
    {
        if (_title == null)
            throw new InvalidOperationException("Title is required for a ConfirmationDialogObject.");
        if (_text == null)
            throw new InvalidOperationException("Text is required for a ConfirmationDialogObject.");
        if (_confirm == null)
            throw new InvalidOperationException("Confirm is required for a ConfirmationDialogObject.");
        if (_deny == null)
            throw new InvalidOperationException("Deny is required for a ConfirmationDialogObject.");

        return new SlackConfirmDialogObject
        {
            Title = _title,
            SlackText = _text,
            Confirm = _confirm,
            Deny = _deny,
            Style = _style
        };
    }
}