using System.Text.Json.Serialization;

namespace Hooki.Slack.Models.CompositionObjects;

/// <summary>
/// Refer to Slack's documentation for more details: https://api.slack.com/reference/block-kit/composition-objects#dispatch_action_config
/// </summary>
public class DispatchActionConfigurationObject
{
    [JsonPropertyName("trigger_actions_on")] public string[]? TriggerActionsOn { get; set; }
}