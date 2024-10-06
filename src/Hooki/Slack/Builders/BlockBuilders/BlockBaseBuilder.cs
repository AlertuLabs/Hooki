using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class BlockBaseBuilder
{
    private string? _blockId;

    public BlockBaseBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }

    public virtual BlockBase Build()
    {
        return new BlockBase
        {
            BlockId = _blockId
        };
    }
}