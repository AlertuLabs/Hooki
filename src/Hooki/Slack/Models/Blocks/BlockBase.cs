using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

[JsonConverter(typeof(BlockBaseConverter))]
public abstract class BlockBase
{
    [JsonPropertyName("type")] public abstract BlockType Type { get; }

    [JsonPropertyName("block_id")] public string? BlockId { get; set; }
}