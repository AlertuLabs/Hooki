using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#overflow
/// </summary>
public class OverflowMenuElement : BlockElementBase
{
    public override BlockElementType Type => BlockElementType.OverflowMenu;

    [JsonPropertyName("options")] public required List<OptionObject> Options { get; set; }

    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }
}