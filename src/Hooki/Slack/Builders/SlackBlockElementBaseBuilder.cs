using Hooki.Slack.Models.BlockElements;

namespace Hooki.Slack.Builders;


public class SlackBlockElementBaseBuilder
{
    private string? _actionId;

    public SlackBlockElementBaseBuilder WithActionId(string actionId)
    {
        _actionId = actionId;
        return this;
    }

    public virtual SlackBlockElement Build()
    {
        return new SlackBlockElement
        {
            ActionId = _actionId
        };
    }
}