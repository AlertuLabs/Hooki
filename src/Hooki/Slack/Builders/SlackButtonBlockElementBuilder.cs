using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class ButtonElementBuilder : SlackBlockElementBaseBuilder
{
    private SlackTextObject? _text;
    private string? _url;
    private string? _value;
    private string? _style;
    private SlackConfirmDialogObject? _confirm;
    private string? _accessibilityLabel;

    public ButtonElementBuilder WithText(Action<SlackTextObjectBuilder> buildAction)
    {
        var builder = new SlackTextObjectBuilder();
        buildAction(builder);
        _text = builder.Build();
        return this;
    }

    public ButtonElementBuilder WithUrl(string url)
    {
        _url = url;
        return this;
    }

    public ButtonElementBuilder WithValue(string value)
    {
        _value = value;
        return this;
    }

    public ButtonElementBuilder WithStyle(string style)
    {
        _style = style;
        return this;
    }

    public ButtonElementBuilder WithConfirm(Action<SlackConfirmDialogObjectBuilder> buildAction)
    {
        var builder = new SlackConfirmDialogObjectBuilder();
        buildAction(builder);
        _confirm = builder.Build();
        return this;
    }

    public ButtonElementBuilder WithAccessibilityLabel(string accessibilityLabel)
    {
        _accessibilityLabel = accessibilityLabel;
        return this;
    }

    public override SlackBlockElement Build()
    {
        if (_text == null)
            throw new InvalidOperationException("Text is required for a ButtonElement.");

        return new SlackButtonElement
        {
            ActionId = base.Build().ActionId,
            SlackText = _text,
            Url = _url,
            Value = _value,
            Style = _style,
            Confirm = _confirm,
            AccessibilityLabel = _accessibilityLabel
        };
    }
}
