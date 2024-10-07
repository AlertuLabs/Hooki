using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#input
/// </summary>
public class PlainTextInputElement : BlockElementBase, IInputBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.PlainTextInput;

    [JsonPropertyName("initial_value")] public string? InitialValue { get; set; }

    [JsonPropertyName("multiline")] public bool? Multiline { get; set; }

    [JsonPropertyName("min_length")] public int? MinLength { get; set; }

    [JsonPropertyName("max_length")] public int? MaxLength { get; set; }

    [JsonPropertyName("dispatch_action_config")] public DispatchActionConfigurationObject? DispatchActionConfig { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }

    /// <summary>
    /// When provided, TextObject Type must be PlainText
    /// </summary>
    [JsonPropertyName("placeholder")] public TextObject? Placeholder { get; set; }
}