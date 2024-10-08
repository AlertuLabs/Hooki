using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#datepicker
/// </summary>
public class SlackDatePickerElement : SlackBlockElement, ISlackActionBlockElement, IInputBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.DatePicker;

    /// <summary>
    /// Format YYYY-MM-DD
    /// </summary>
    [JsonPropertyName("initial_date")] public string? InitialDate { get; set; }
    
    [JsonPropertyName("confirm")] public SlackConfirmDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }

    /// <summary>
    /// When provided, the TextObject type should be "PlainText"
    /// </summary>
    [JsonPropertyName("placeholder")] public SlackTextObject? Placeholder { get; set; }
}