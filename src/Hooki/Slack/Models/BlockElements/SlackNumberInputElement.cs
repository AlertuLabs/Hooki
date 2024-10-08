using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#number
/// </summary>
public class SlackNumberInputElement : SlackBlockElement, IInputBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.NumberInput;

    [JsonPropertyName("is_decimal_allowed")]
    public required bool IsDecimalAllowed { get; set; }

    [JsonPropertyName("initial_value")]
    public string? InitialValue { get; set; }

    /// <summary>
    /// Cannot be greater than MaxValue
    /// </summary>
    [JsonPropertyName("min_value")]
    public string? MinValue { get; set; }

    /// <summary>
    /// Cannot be less than MinValue
    /// </summary>
    [JsonPropertyName("max_value")]
    public string? MaxValue { get; set; }

    [JsonPropertyName("dispatch_action_config")]
    public SlackDispatchActionConfigObject? DispatchActionConfig { get; set; }

    [JsonPropertyName("focus_on_load")]
    public bool? FocusOnLoad { get; set; }

    [JsonPropertyName("placeholder")]
    public SlackTextObject? Placeholder { get; set; }
}