using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#radio
/// </summary>
public class RadioButtonGroupElement : BlockElementBase
{
    public override BlockElementType Type => BlockElementType.RadioButtonGroup;

    [JsonPropertyName("options")] public required OptionObject[] Options { get; set; }

    /// <summary>
    /// Must match one of the options within Options
    /// </summary>
    [JsonPropertyName("initial_option")] public OptionObject? InitialOption { get; set; }

    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
}