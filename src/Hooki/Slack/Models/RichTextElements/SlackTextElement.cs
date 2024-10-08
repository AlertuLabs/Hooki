using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class SlackTextElement : ISlackRichTextElement
{
    [JsonPropertyName("type")] public SlackRichTextElementType Type => SlackRichTextElementType.Text;
    
    [JsonPropertyName("text")] public required string Text { get; set; }
    
    [JsonPropertyName("style")] public SlackBasicTextStyle? Style { get; set; }
}