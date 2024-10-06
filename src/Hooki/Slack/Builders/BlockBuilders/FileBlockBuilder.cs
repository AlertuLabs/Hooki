using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class FileBlockBuilder : BlockBaseBuilder
{
    private string _externalId = default!;
    private string _source = default!;
    
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
    
    public override BlockBase Build()
    {
        return new FileBlock
        {
            BlockId = base.Build().BlockId,
            ExternalId = _externalId,
            Source = _source
        };
    }
}