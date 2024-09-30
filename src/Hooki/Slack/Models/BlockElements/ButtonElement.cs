using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#button
/// </summary>
public class ButtonElement : BlockElementBase
{
    public override BlockElementType Type => BlockElementType.Button;

    [JsonPropertyName("text")] public required TextObject Text { get; set; }

    [JsonPropertyName("url")] public string? Url { get; set; }

    [JsonPropertyName("value")] public string? Value { get; set; }

    [JsonPropertyName("style")] public string? Style { get; set; }

    [JsonPropertyName("confirm")] public ConfirmationDialogObject? Confirm { get; set; }

    [JsonPropertyName("accessibility_label")] public string? AccessibilityLabel { get; set; }
}