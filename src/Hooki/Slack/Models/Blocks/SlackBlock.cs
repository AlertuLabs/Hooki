using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.JsonConverters;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks
/// </summary>
[JsonConverter(typeof(SlackBlockBaseConverter))]
public abstract class SlackBlock
{
    [JsonPropertyName("block_id")] public string? BlockId { get; set; }
    
    [JsonIgnore] public abstract SlackBlockType Type { get; }
}