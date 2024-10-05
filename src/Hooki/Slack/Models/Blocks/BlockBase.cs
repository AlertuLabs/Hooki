using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

[JsonConverter(typeof(ActionBlockConverter))]
public class BlockBase
{
    [JsonPropertyName("block_id")] public string? BlockId { get; set; }
}