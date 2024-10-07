using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#header
/// </summary>
public class HeaderBlock : BlockBase
{
    [JsonPropertyName("type")] public override BlockType Type => BlockType.HeaderBlock;
    
    [JsonPropertyName("text")] public required TextObject Text { get; set; }
}