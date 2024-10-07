using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#option_group
/// </summary>
public class OptionGroupObject
{
    /// <summary>
    /// TextObject type should be "PlainText"
    /// </summary>
    [JsonPropertyName("label")] public required TextObject Label { get; set; }
    
    [JsonPropertyName("options")] public required OptionObject[] Options { get; set; }
}