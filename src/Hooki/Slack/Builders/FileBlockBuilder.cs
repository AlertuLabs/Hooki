using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class FileBlockBuilder : IBlockBuilder
{
    private string _externalId = default!;
    private string _source = default!;
    private string? _blockId;
    
    public FileBlockBuilder WithBlockId(string blockId)
    {
        _blockId = blockId;
        return this;
    }
    
    public FileBlockBuilder WithExternalId(string externalId)
    {
        _externalId = externalId;
        return this;
    }
    
    public FileBlockBuilder WithSource(string source)
    {
        _source = source;
        return this;
    }
    
    public BlockBase Build()
    {
        return new FileBlock
        {
            BlockId = _blockId,
            ExternalId = _externalId,
            Source = _source
        };
    }
}