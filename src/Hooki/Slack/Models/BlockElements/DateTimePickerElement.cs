using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#datetimepicker
/// </summary>
public class DateTimePickerElement : BlockElementBase, IActionBlockElement, IInputBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.DatetimePicker;

    /// <summary>
    /// Form as UNIX timestamp in seconds. Here is an example: 1628633820
    /// </summary>
    [JsonPropertyName("initial_date_time")] public int? InitialDateTime { get; set; }

    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
}