using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.BlockElements;

public class SlackBlockElement
{
    [JsonPropertyName("action_id")] public string? ActionId { get; set; }
}