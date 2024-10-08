using System.Text.Json.Serialization;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models;

public class SlackWebhookPayload
{
    [JsonPropertyName("blocks")] public required List<SlackBlock> Blocks { get; set; }
}