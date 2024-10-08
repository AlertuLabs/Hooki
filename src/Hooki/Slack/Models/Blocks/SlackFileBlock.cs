using System.Text.Json.Serialization;
using Hooki.Slack.Enums;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#file
/// </summary>
public class SlackFileBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.FileBlock;
    
    [JsonPropertyName("external_id")]
    public required string ExternalId { get; set; }
    
    [JsonPropertyName("source")]
    public required string Source { get; set; }
}