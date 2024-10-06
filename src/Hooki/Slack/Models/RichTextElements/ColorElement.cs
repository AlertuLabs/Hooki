using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class ColorElement : IRichTextElement
{
    [JsonPropertyName("type")] public RichTextElementType Type => RichTextElementType.Color;
    
    /// <summary>
    /// The hex value for the color
    /// </summary>
    [JsonPropertyName("value")] public required string Value { get; set; }
}