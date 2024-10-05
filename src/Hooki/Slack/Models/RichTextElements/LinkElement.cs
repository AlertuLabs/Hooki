using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class LinkElement : IRichTextElement
{
    [JsonPropertyName("type")] public RichTextElementType Type => RichTextElementType.Link;
    
    [JsonPropertyName("url")] public required string Url { get; set; }
    
    [JsonPropertyName("text")] public string? Text { get; set; }
    
    [JsonPropertyName("unsafe")] public bool? Unsafe { get; set; }
    
    [JsonPropertyName("style")] public required BasicTextStyle Style { get; set; }
}