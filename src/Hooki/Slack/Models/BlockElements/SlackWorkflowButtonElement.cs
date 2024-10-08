using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.Blocks;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#workflow_button
/// </summary>
public class SlackWorkflowButtonElement : SlackBlockElement, ISlackActionBlockElement, ISlackSectionBlockElement
{
    [JsonPropertyName("type")] public SlackBlockElementType Type => SlackBlockElementType.WorkflowButton;

    [JsonPropertyName("text")] public required SlackTextObject SlackText { get; set; }

    [JsonPropertyName("workflow")] public required SlackWorkflowObject Workflow { get; set; } 

    /// <summary>
    /// If you don't provide a value, default button style will be used
    /// </summary>
    [JsonPropertyName("style")] public SlackWorkflowButtonElementStyle? Style { get; set; }

    [JsonPropertyName("accessibility_label")] public string? AccessibilityLabel { get; set; }
}