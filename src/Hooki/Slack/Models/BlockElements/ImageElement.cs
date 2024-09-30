using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#image
/// </summary>
public class ImageElement : BlockElementBase
{
    public override BlockElementType Type { get; } = BlockElementType.Image;

    [JsonPropertyName("alt_text")] public required string AltText { get; set; }
    
    [JsonPropertyName("image_url")] public string? ImageUrl { get; set; }

    [JsonPropertyName("slack_file")] public SlackFileObject? SlackFile { get; set; }
}