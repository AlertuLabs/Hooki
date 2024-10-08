using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.Blocks;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#video
/// </summary>
public class SlackVideoBlock : SlackBlock
{
    [JsonPropertyName("type")] public override SlackBlockType Type => SlackBlockType.VideoBlock;
    
    [JsonPropertyName("alt_text")] public required string AltText { get; set; }
    
    [JsonPropertyName("author_name")] public string? AuthorName { get; set; }
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// </summary>
    [JsonPropertyName("description")] public required SlackTextObject Description { get; set; }
    
    [JsonPropertyName("provider_icon_url")] public string? ProviderIconUrl { get; set; }
    
    [JsonPropertyName("provider_name")] public string? ProviderName { get; set; }
    
    /// <summary>
    /// TextObject must have type of "PlainText"
    /// </summary>
    [JsonPropertyName("title")] public SlackTextObject? Title { get; set; }
    
    /// <summary>
    /// When provided, the url must be HTTPS
    /// </summary>
    
    [JsonPropertyName("title_url")] public string? TitleUrl { get; set; }
    
    [JsonPropertyName("thumbnail_url")] public required string ThumbnailUrl { get; set; }
    
    [JsonPropertyName("video_url")] public required string VideoUrl { get; set; }
}