using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class UserElement : IRichTextElement
{
    [JsonPropertyName("type")] public RichTextElementType Type => RichTextElementType.User;
     
    [JsonPropertyName("user_id")] public required string UserId { get; set; }
    
    [JsonPropertyName("style")] public AdvancedTextStyle? Style { get; set; }
}