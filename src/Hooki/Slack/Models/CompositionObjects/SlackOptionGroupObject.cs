using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#option_group
/// </summary>
public class SlackOptionGroupObject
{
    /// <summary>
    /// TextObject type should be "PlainText"
    /// </summary>
    [JsonPropertyName("label")] public required SlackTextObject Label { get; set; }
    
    [JsonPropertyName("options")] public required SlackOptionObject[] Options { get; set; }
}