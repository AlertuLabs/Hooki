using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackFileBlockBuilder : ISlackBlockBuilder
{
    private string _externalId = default!;
    private string _source = default!;
    private string? _blockId;
    
    public SlackFileBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public SlackFileBlockBuilder WithExternalId(string externalId)
    {
        _externalId = externalId;
        return this;
    }
    
    public SlackFileBlockBuilder WithSource(string source)
    {
        _source = source;
        return this;
    }
    
    public SlackBlock Build()
    {
        return new SlackFileBlock
        {
            BlockId = _blockId,
            ExternalId = _externalId,
            Source = _source
        };
    }
}