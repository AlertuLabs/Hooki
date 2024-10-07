using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.BlockElements;

public class BlockElementBase
{
    [JsonPropertyName("action_id")] public string? ActionId { get; set; }
}