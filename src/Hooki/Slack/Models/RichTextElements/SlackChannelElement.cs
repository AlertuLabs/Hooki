using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class SlackChannelElement : ISlackRichTextElement
{
    [JsonPropertyName("type")] public SlackRichTextElementType Type => SlackRichTextElementType.Channel;
    
    [JsonPropertyName("channel_id")] public required string ChannelId { get; set; }
    
    [JsonPropertyName("style")] public SlackAdvancedTextStyle? Style { get; set; }
}