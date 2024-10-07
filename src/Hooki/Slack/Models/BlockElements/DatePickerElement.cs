using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#datepicker
/// </summary>
public class DatePickerElement : BlockElementBase, IActionBlockElement, IInputBlockElement, ISectionBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.DatePicker;

    /// <summary>
    /// Format YYYY-MM-DD
    /// </summary>
    [JsonPropertyName("initial_date")] public string? InitialDate { get; set; }
    
    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }

    /// <summary>
    /// When provided, the TextObject type should be "PlainText"
    /// </summary>
    [JsonPropertyName("placeholder")] public TextObject? Placeholder { get; set; }
}