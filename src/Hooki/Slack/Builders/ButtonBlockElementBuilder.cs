using Hooki.Slack.Models.BlockElements;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class ButtonElementBuilder : BlockElementBaseBuilder
{
    private TextObject? _text;
    private string? _url;
    private string? _value;
    private string? _style;
    private ConfirmationDialogObject? _confirm;
    private string? _accessibilityLabel;

    public ButtonElementBuilder WithText(Action<TextObjectBuilder> buildAction)
    {
        var builder = new TextObjectBuilder();
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

    public ButtonElementBuilder WithConfirm(Action<ConfirmationDialogObjectBuilder> buildAction)
    {
        var builder = new ConfirmationDialogObjectBuilder();
        buildAction(builder);
        _confirm = builder.Build();
        return this;
    }

    public ButtonElementBuilder WithAccessibilityLabel(string accessibilityLabel)
    {
        _accessibilityLabel = accessibilityLabel;
        return this;
    }

    public override BlockElementBase Build()
    {
        if (_text == null)
            throw new InvalidOperationException("Text is required for a ButtonElement.");

        return new ButtonElement
        {
            ActionId = base.Build().ActionId,
            Text = _text,
            Url = _url,
            Value = _value,
            Style = _style,
            Confirm = _confirm,
            AccessibilityLabel = _accessibilityLabel
        };
    }
}
