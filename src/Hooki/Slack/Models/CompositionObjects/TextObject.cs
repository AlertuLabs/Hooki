using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#text
/// </summary>
public class TextObject : IContextBlockElement
{
    [JsonPropertyName("type")] public required TextObjectType Type { get; set; }
    
    [JsonPropertyName("text")] public required string Text { get; set; }
    
    /// <summary>
    /// This field is only usable when Type is plain_text
    /// </summary>
    [JsonPropertyName("emoji")] public bool? Emoji { get; set; }
    
    /// <summary>
    /// This field is only usable when Type is mrkdwn
    /// </summary>
    [JsonPropertyName("verbatim")] public bool? Verbatim { get; set; }
}