using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class TextObjectBuilder
{
    private TextObjectType? _type;
    private string? _text;
    private bool? _emoji;
    private bool? _verbatim;

    public TextObjectBuilder WithType(TextObjectType type)
    {
        _type = type;
        return this;
    }

    public TextObjectBuilder WithText(string text)
    {
        _text = text;
        return this;
    }

    public TextObjectBuilder WithEmoji(bool emoji)
    {
        _emoji = emoji;
        return this;
    }

    public TextObjectBuilder WithVerbatim(bool verbatim)
    {
        _verbatim = verbatim;
        return this;
    }

    public TextObject Build()
    {
        if (_type == null)
            throw new InvalidOperationException("Type is required for a TextObject.");

        if (string.IsNullOrWhiteSpace(_text))
            throw new InvalidOperationException("Text is required for a TextObject.");

        if (_type == TextObjectType.Markdown && _emoji.HasValue)
            throw new InvalidOperationException("Emoji can only be set when Type is PlainText.");

        if (_type == TextObjectType.PlainText && _verbatim.HasValue)
            throw new InvalidOperationException("Verbatim can only be set when Type is Markdown.");

        return new TextObject
        {
            Type = _type.Value,
            Text = _text,
            Emoji = _emoji,
            Verbatim = _verbatim
        };
    }
}