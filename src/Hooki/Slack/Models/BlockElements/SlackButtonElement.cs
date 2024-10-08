using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#button
/// </summary>
public class SlackButtonElement : SlackBlockElement, ISlackActionBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.Button;

    [JsonPropertyName("text")] public required SlackTextObject SlackText { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("value")] public string? Value { get; set; }

    [JsonPropertyName("style")] public string? Style { get; set; }

    [JsonPropertyName("confirm")] public SlackConfirmDialogObject? Confirm { get; set; }

    [JsonPropertyName("accessibility_label")] public string? AccessibilityLabel { get; set; }
}