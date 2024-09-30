using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#option
/// </summary>
public class OptionObject
{
    [JsonPropertyName("text")] public required TextObject Text { get; set; }
    
    [JsonPropertyName("value")] public required string Value { get; set; }
    
    /// <summary>
    /// When provided, the TextObject type should be "PlainText"
    /// </summary>
    [JsonPropertyName("description")] public TextObject? Description { get; set; }
    
    [JsonPropertyName("url")] public string? Url { get; set; }
}