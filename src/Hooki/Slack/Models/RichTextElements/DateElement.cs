using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class DateElement : IRichTextElement
{
    [JsonPropertyName("type")] public RichTextElementType Type => RichTextElementType.Date;
    
    /// <summary>
    /// A Unix timestamp for the date to be displayed in seconds
    /// </summary>
    [JsonPropertyName("timestamp")] public required int Timestamp { get; set; }
    
    /// <summary>
    /// A template string containing curly-brace-enclosed tokens to substitute your provided timestamp
    /// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#color-element-type
    /// </summary>
    [JsonPropertyName("format")] public required string Format { get; set; }
}