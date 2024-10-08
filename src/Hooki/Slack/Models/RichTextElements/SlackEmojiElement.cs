using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.RichTextElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/blocks#element-types
/// </summary>
public class SlackEmojiElement : ISlackRichTextElement
{
    [JsonPropertyName("type")] public SlackRichTextElementType Type => SlackRichTextElementType.Emoji;
    
    /// <summary>
    /// The name of the emoji; i.e. "wave" or "wave::skin-tone-2"
    /// </summary>
    [JsonPropertyName("name")] public required string Name { get; set; }
    
    /// <summary>
    /// Represents the unicode code point of the emoji, where applicable
    /// </summary>
    [JsonPropertyName("unicode")] public string? Unicode { get; set; }
}