using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class HeaderBlockBuilder : BlockBaseBuilder
{
    private TextObject? _text;

    public HeaderBlockBuilder WithText(TextObject text)
    {
        _text = text;
        return this;
    }

    public override BlockBase Build()
    {
        if (_text is null)
            throw new InvalidOperationException("Text is required");
        
        return new HeaderBlock
        {
            BlockId = base.Build().BlockId,
            Text = _text
        };
    }
}