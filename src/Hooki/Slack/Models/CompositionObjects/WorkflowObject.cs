using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#workflow
/// </summary>
public class WorkflowObject
{
    [JsonPropertyName("trigger")] public required TriggerObject Trigger { get; set; }
}