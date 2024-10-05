using System.Text.Json.Serialization;
using Hooki.Slack.Enums;
using Hooki.Slack.Models.CompositionObjects;

namespace Hooki.Slack.Models.BlockElements;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/block-elements#workflow_button
/// </summary>
public class WorkflowButtonElement : BlockElementBase
{
    public override BlockElementType Type => BlockElementType.WorkflowButton;

    [JsonPropertyName("text")] public required TextObject Text { get; set; }

    [JsonPropertyName("workflow")] public required WorkflowObject Workflow { get; set; } 

    /// <summary>
    /// If you don't provide a value, default button style will be used
    /// </summary>
    [JsonPropertyName("style")] public WorkflowButtonElementStyle? Style { get; set; }

    [JsonPropertyName("accessibility_label")] public string? AccessibilityLabel { get; set; }
}