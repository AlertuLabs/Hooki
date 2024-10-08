using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackDividerBlockBuilder : ISlackBlockBuilder
{
    private string? _blockId;
    
    public SlackDividerBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public SlackBlock Build()
    {
        return new SlackDividerBlock
        {
            BlockId = _blockId
        };
    }
}