using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#timepicker
/// </summary>
public class SlackTimePickerElement : SlackBlockElement, ISlackActionBlockElement, IInputBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.TimePicker;

    /// <summary>
    /// Format: HH:mm
    /// </summary>
    [JsonPropertyName("initial_time")] public string? InitialTime { get; set; }

    [JsonPropertyName("confirm")] public SlackConfirmDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }

    [JsonPropertyName("placeholder")] public SlackTextObject? Placeholder { get; set; }

    /// <summary>
    /// Format: IANA e.g. "America/Chicago"
    /// </summary>
    [JsonPropertyName("timezone")] public string? Timezone { get; set; }
}