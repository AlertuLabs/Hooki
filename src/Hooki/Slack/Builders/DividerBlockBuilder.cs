using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class DividerBlockBuilder : IBlockBuilder
{
    private string? _blockId;
    
    public DividerBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public BlockBase Build()
    {
        return new DividerBlock
        {
            BlockId = _blockId
        };
    }
}