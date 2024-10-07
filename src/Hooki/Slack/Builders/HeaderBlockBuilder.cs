using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Builders;

public class HeaderBlockBuilder : IBlockBuilder
{
    private TextObject? _text;
    private string? _blockId;
    
    public HeaderBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public HeaderBlockBuilder WithText(TextObject text)
    {
        _text = text;
        return this;
    }

    public BlockBase Build()
    {
        if (_text is null)
            throw new InvalidOperationException("Text is required");
        
        return new HeaderBlock
        {
            BlockId = _blockId,
            Text = _text
        };
    }
}