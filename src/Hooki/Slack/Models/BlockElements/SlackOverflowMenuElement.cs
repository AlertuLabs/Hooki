using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#overflow
/// </summary>
public class SlackOverflowMenuElement : SlackBlockElement, ISlackActionBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.OverflowMenu;

    [JsonPropertyName("options")] public required List<SlackOptionObject> Options { get; set; }

    [JsonPropertyName("confirm")] public SlackConfirmDialogObject? Confirm { get; set; }
}