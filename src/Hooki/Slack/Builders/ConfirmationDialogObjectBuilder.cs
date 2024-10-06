using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class ConfirmationDialogObjectBuilder
{
    private TextObject? _title;
    private TextObject? _text;
    private TextObject? _confirm;
    private TextObject? _deny;
    private string? _style;

    public ConfirmationDialogObjectBuilder WithTitle(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _title = builder.Build();
        return this;
    }

    public ConfirmationDialogObjectBuilder WithText(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _text = builder.Build();
        return this;
    }

    public ConfirmationDialogObjectBuilder WithConfirm(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _confirm = builder.Build();
        return this;
    }

    public ConfirmationDialogObjectBuilder WithDeny(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
        buildAction(builder);
        _deny = builder.Build();
        return this;
    }

    public ConfirmationDialogObjectBuilder WithStyle(string style)
    {
        _style = style;
        return this;
    }

    public ConfirmationDialogObject Build()
    {
        if (_title == null)
            throw new InvalidOperationException("Title is required for a ConfirmationDialogObject.");
        if (_text == null)
            throw new InvalidOperationException("Text is required for a ConfirmationDialogObject.");
        if (_confirm == null)
            throw new InvalidOperationException("Confirm is required for a ConfirmationDialogObject.");
        if (_deny == null)
            throw new InvalidOperationException("Deny is required for a ConfirmationDialogObject.");

        return new ConfirmationDialogObject
        {
            Title = _title,
            Text = _text,
            Confirm = _confirm,
            Deny = _deny,
            Style = _style
        };
    }
}