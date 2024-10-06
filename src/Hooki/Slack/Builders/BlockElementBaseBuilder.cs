using Hooki.Slack.Models.BlockElements;

namespace Hooki.Slack.Builders.BlockElementBuilders;


public class BlockElementBaseBuilder
{
    private string? _actionId;

    public BlockElementBaseBuilder WithActionId(string actionId)
    {
        _actionId = actionId;
        return this;
    }

    public virtual BlockElementBase Build()
    {
        return new BlockElementBase
        {
            ActionId = _actionId
        };
    }
}