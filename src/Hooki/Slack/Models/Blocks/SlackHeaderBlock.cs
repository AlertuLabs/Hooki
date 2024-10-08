using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#header
/// </summary>
public class SlackHeaderBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.HeaderBlock;
    
    [JsonPropertyName("text")] public required SlackTextObject SlackText { get; set; }
}