using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.BlockElements;

[JsonConverter(typeof(BlockElementBaseConverter))]
public abstract class BlockElementBase
{
    [JsonPropertyName("type")]
    public abstract BlockElementType Type { get; }

    [JsonPropertyName("action_id")]
    public string? ActionId { get; set; }
}