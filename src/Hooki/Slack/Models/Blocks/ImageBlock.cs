using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#image
/// </summary>
public class ImageBlock : BlockBase
{
    [JsonPropertyName("type")] public override BlockType Type => BlockType.ImageBlock;
    
    [JsonPropertyName("alt_text")] public required string AltText { get; set; }
    
    /// <summary>
    /// Must provide either ImageUrl or SlackFile
    /// </summary>
    [JsonPropertyName("image_url")] public string? ImageUrl { get; set; }
    
    /// <summary>
    /// Must provide either SlackFile or ImageUrl
    /// </summary>
    [JsonPropertyName("slack_file")] public SlackFileObject? SlackFile { get; set; }
    
    /// <summary>
    /// When provided, TextObject must be of type "PlainText"
    /// </summary>
    [JsonPropertyName("title")] public TextObject? Title { get; set; }
}