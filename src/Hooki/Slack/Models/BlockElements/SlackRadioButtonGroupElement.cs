using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#radio
/// </summary>
public class SlackRadioButtonGroupElement : SlackBlockElement, ISlackActionBlockElement, IInputBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.RadioButtonGroup;

    [JsonPropertyName("options")] public required SlackOptionObject[] Options { get; set; }

    /// <summary>
    /// Must match one of the options within Options
    /// </summary>
    [JsonPropertyName("initial_option")] public SlackOptionObject? InitialOption { get; set; }

    [JsonPropertyName("confirm")] public SlackConfirmDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
}