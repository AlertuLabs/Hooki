using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models;

public class SlackWebhookPayload
{
    public required List<BlockBase> Blocks { get; set; }
}