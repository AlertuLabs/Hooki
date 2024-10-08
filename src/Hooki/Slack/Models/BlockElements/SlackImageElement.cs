using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#image
/// </summary>
public class SlackImageElement : SlackBlockElement, ISlackContextBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.Image;

    [JsonPropertyName("alt_text")] public required string AltText { get; set; }
    
    /// <summary>
    /// You must provide either an ImageUrl or SlackFile
    /// Maximum length is 3000 characters
    /// </summary>
    [JsonPropertyName("image_url")] public string? ImageUrl { get; set; }
    
    /// <summary>
    /// You must provide either an SlackFile or ImageUrl
    /// Refer to Discord's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#slack_file
    /// </summary>
    [JsonPropertyName("slack_file")] public SlackFileObject? SlackFile { get; set; }
}