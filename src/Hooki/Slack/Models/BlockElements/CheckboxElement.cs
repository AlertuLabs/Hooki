using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#checkboxes
/// </summary>

public class CheckboxElement : BlockElementBase, IActionBlockElement, IInputBlockElement, ISectionBlockElement
{
    [JsonPropertyName("type")] public BlockElementType Type => BlockElementType.Checkboxes;

    [JsonPropertyName("options")] public required List<OptionObject> Options { get; set; }

    [JsonPropertyName("initial_options")] public List<OptionObject>? InitialOptions { get; set; }

    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }

    [JsonPropertyName("focus_on_load")] public bool? FocusOnLoad { get; set; }
}