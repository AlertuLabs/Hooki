using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#option
/// </summary>
public class SlackOptionObject
{
    [JsonPropertyName("text")] public required SlackTextObject SlackText { get; set; }
    
    [JsonPropertyName("value")] public required string Value { get; set; }
    
    /// <summary>
    /// When provided, the TextObject type should be "PlainText"
    /// </summary>
    [JsonPropertyName("description")] public SlackTextObject? Description { get; set; }
    
    [JsonPropertyName("url")] public string? Url { get; set; }
}