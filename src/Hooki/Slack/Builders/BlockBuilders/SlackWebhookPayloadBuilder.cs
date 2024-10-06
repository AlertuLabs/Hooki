using Hooki.Slack.Models;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Builders;

public class SlackWebhookPayloadBuilder
{
    private readonly List<BlockBase> _blocks = new();

    public SlackWebhookPayloadBuilder AddBlock(Action<BlockBaseBuilder> buildAction)
    {
        var builder = new BlockBaseBuilder();
        buildAction(builder);
        _blocks.Add(builder.Build());
        return this;
    }

    public SlackWebhookPayload Build()
    {
        if (_blocks.Count == 0)
            throw new InvalidOperationException("At least one block is required.");

        return new SlackWebhookPayload
        {
            Blocks = _blocks
        };
    }
}