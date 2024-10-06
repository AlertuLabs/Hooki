using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class HeaderBlockBuilder
{
    private TextObject? _text;
    private string? _blockId;

    public HeaderBlockBuilder WithText(TextObject text)
    {
        _text = text;
        return this;
    }

    public HeaderBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
}